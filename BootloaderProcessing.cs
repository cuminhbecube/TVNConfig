using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace TVNConfigSW
{
    public class BootloaderProcessing
    {
        private readonly int numberOfPayloadBytePerBootLoaderPacket = 2048;

        private readonly string firmwareVersionMarkerString = "FIRMWARE VERSION MARKER: LIFE IS THE MOST BEAUTIFUL THING IN THE WORLD@";

        public UInt16 TotalPacket { set; get; }

        public UInt16 NextTxPacketNo { set; get; }

        public int WaitingForResponseTimeoutCounter { set; get;}

        public Byte[] FirmwareVersion { set; get; }

        public List<Byte[]> PacketList { set; get; }

        public bool IsValid { set; get; }

        public BootloaderProcessingState State { set; get; }

        public Byte[] CommandQueryDeviceState { set; get; }

        public BootloaderProcessing()
        {
            FirmwareVersion = new Byte[4];
            PacketList = new List<Byte[]>();
            PacketList.Clear();
            TotalPacket = 0;
            NextTxPacketNo = 0;
            IsValid = false;
            State = BootloaderProcessingState.IDLE;
            WaitingForResponseTimeoutCounter = 0;

            // Build query state message
            CommandQueryDeviceState = new Byte[22];
            CommandQueryDeviceState[0] = 0x7E;
            CommandQueryDeviceState[1] = 0;      // Lenght MSB
            CommandQueryDeviceState[2] = 15;     // Lenght LSB
            CommandQueryDeviceState[3] = 0x24;   // '$'
            CommandQueryDeviceState[4] = 0x42;   // 'B'
            CommandQueryDeviceState[5] = 0;      // Serial MSB
            CommandQueryDeviceState[6] = 0;      // Serial LSB
            CommandQueryDeviceState[7] = 0;      // Message Code
            CommandQueryDeviceState[8] = this.FirmwareVersion[0];
            CommandQueryDeviceState[9] = this.FirmwareVersion[1];
            CommandQueryDeviceState[10] = this.FirmwareVersion[2];
            CommandQueryDeviceState[11] = this.FirmwareVersion[3];
            CommandQueryDeviceState[12] = (Byte)(TotalPacket >> 8);     // Total packet MSB
            CommandQueryDeviceState[13] = (Byte)(TotalPacket & 0xFF);   // Total packet MSB
            CommandQueryDeviceState[14] = 0;// Packet No MSB
            CommandQueryDeviceState[15] = 0;// Packet No LSB
            CommandQueryDeviceState[16] = 0;// Payload Lenght MSB
            CommandQueryDeviceState[17] = 0;// Payload Lenght LSB
            UInt16 crc16 = ModbusCRC16.Calculate(CommandQueryDeviceState, 3, 15);
            CommandQueryDeviceState[18] = (Byte)(crc16 >> 8);
            CommandQueryDeviceState[19] = (Byte)(crc16 & 0xFF);
            CommandQueryDeviceState[20] = 0x0D;//End mark
            CommandQueryDeviceState[21] = 0x0A;// End mark
        }

        public bool ReadBinaryFile(string binaryFileName)
        {
            // Get firmware version
            try
            {
                using (TextReader textReader = new StreamReader(binaryFileName))
                {
                    string line;
                    bool firmwareVersionFound = false;
                    do
                    {
                        line = textReader.ReadLine();
                        if (line != null)
                        {
                            int indexOfFirmwareVersionMarker = line.IndexOf(firmwareVersionMarkerString);
                            if (indexOfFirmwareVersionMarker > 0)
                            {
                                string fiwmwareVersionString = line.Substring(indexOfFirmwareVersionMarker + firmwareVersionMarkerString.Length);
                                string[] fiwmwareVersionNumbers = fiwmwareVersionString.Split('.');
                                this.FirmwareVersion[0] = Convert.ToByte(fiwmwareVersionNumbers[0]);
                                this.FirmwareVersion[1] = Convert.ToByte(fiwmwareVersionNumbers[1]);
                                this.FirmwareVersion[2] = Convert.ToByte(fiwmwareVersionNumbers[2]);
                                this.FirmwareVersion[3] = Convert.ToByte(fiwmwareVersionNumbers[3]);
                                firmwareVersionFound = true;
                            }
                        }
                    } while (line != null);
                    if (firmwareVersionFound == false)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\r\n-I-" + e.Message + "\n Cannot open file.");
                return false;
            }

            // Reading data from file
            try
            {
                // Get the list of payload data
                BinaryReader binaryReader = new BinaryReader(new FileStream(binaryFileName, FileMode.Open));
                List<Byte[]> PayLoadList = new List<byte[]>();
                int readLen = 0;
                UInt16 totalPayloadPacket = 0;
                int totalByteRead = 0;
                do
                {
                    readLen = 0;
                    byte[] payLoadData = binaryReader.ReadBytes(numberOfPayloadBytePerBootLoaderPacket);
                    if (payLoadData != null)
                    {
                        readLen = payLoadData.Length;
                        if (readLen > 0)
                        {
                            totalByteRead += readLen;
                            PayLoadList.Add(payLoadData);
                            totalPayloadPacket++;
                            if(totalPayloadPacket > 65000)
                            {
                                totalPayloadPacket = 0;
                                break;
                            }
                        }
                    }
                } while (readLen > 0);
                binaryReader.Close();

                // Clear packetList
                IsValid = false;
                PacketList.Clear();
                if (totalPayloadPacket > 0)
                {
                    TotalPacket = (UInt16)(totalPayloadPacket + 2);
                    // Header structure:
                    // Format packet 0		: 0x7E:1, FrameLenght:2, $B:2, FrameSerialNumber:2, MessageCode:1, FWVersion:4, TotalPacket:2, PacketNo:2, PayloadLenght:2, PayloadData:0...2048, CRC:2, 0D0A:2 
                    //  (unit:byte)
                    // MSB first mean High Byte first
                    // Init first packet (message code = 1, not include payload data)
                    Byte[] packetBuffer = new Byte[22];
                    packetBuffer[0] = 0x7E;
                    packetBuffer[1] = 0;      // Lenght MSB
                    packetBuffer[2] = 15;     // Lenght LSB
                    packetBuffer[3] = 0x24;   // '$'
                    packetBuffer[4] = 0x42;   // 'B'
                    packetBuffer[5] = 0;      // Serial MSB
                    packetBuffer[6] = 0;      // Serial LSB
                    packetBuffer[7] = 1;      // Message Code
                    packetBuffer[8] = this.FirmwareVersion[0];
                    packetBuffer[9] = this.FirmwareVersion[1];
                    packetBuffer[10] = this.FirmwareVersion[2];
                    packetBuffer[11] = this.FirmwareVersion[3];
                    packetBuffer[12] = (Byte)(TotalPacket >> 8);     // Total packet MSB
                    packetBuffer[13] = (Byte)(TotalPacket & 0xFF);   // Total packet MSB
                    packetBuffer[14] = 0;// Packet No MSB
                    packetBuffer[15] = 0;// Packet No LSB
                    packetBuffer[16] = 0;// Payload Lenght MSB
                    packetBuffer[17] = 0;// Payload Lenght LSB
                    UInt16 crc16 = ModbusCRC16.Calculate(packetBuffer, 3, 15);
                    packetBuffer[18]= (Byte)(crc16 >> 8);
                    packetBuffer[19] = (Byte)(crc16 & 0xFF);
                    packetBuffer[20] = 0x0D;//End mark
                    packetBuffer[21] = 0x0A;// End mark
                    PacketList.Add(packetBuffer);
                    // FrameLenght is from protocol to end of payload data
                    // CRC is for checking from protocol to end of payload data

                    // Add other data packet
                    for (UInt16 i = 0; i < totalPayloadPacket; i++)
                    {
                        UInt16 payloadLen = (UInt16)PayLoadList[i].Length;
                        UInt16 packetLen = (UInt16)(payloadLen + 15);
                        UInt16 packetSerialNumber = (UInt16)((UInt16)i + 1);
                        UInt16 packetNo = packetSerialNumber;
                        UInt16 packetBufferLen = (UInt16)(packetLen + 7);
                        packetBuffer = new Byte[packetBufferLen];
                        packetBuffer[0] = 0x7E;
                        packetBuffer[1] = (Byte)(packetLen >> 8);      // Lenght MSB
                        packetBuffer[2] = (Byte)(packetLen & 0xFF);     // Lenght LSB
                        packetBuffer[3] = 0x24;   // '$'
                        packetBuffer[4] = 0x42;   // 'B'
                        packetBuffer[5] = (Byte)(packetSerialNumber >> 8);       // Serial MSB
                        packetBuffer[6] = (Byte)(packetSerialNumber & 0xFF);      // Serial LSB
                        packetBuffer[7] = 2;      // Message Code
                        packetBuffer[8] = this.FirmwareVersion[0];
                        packetBuffer[9] = this.FirmwareVersion[1];
                        packetBuffer[10] = this.FirmwareVersion[2];
                        packetBuffer[11] = this.FirmwareVersion[3];
                        packetBuffer[12] = (Byte)(TotalPacket >> 8);     // Total packet MSB
                        packetBuffer[13] = (Byte)(TotalPacket & 0xFF);   // Total packet MSB
                        packetBuffer[14] = (Byte)(packetNo >> 8);// Packet No MSB
                        packetBuffer[15] = (Byte)(packetNo & 0xFF);// Packet No LSB
                        packetBuffer[16] = (Byte)(payloadLen >> 8);// Payload Lenght MSB
                        packetBuffer[17] = (Byte)(payloadLen & 0xFF);// Payload Lenght LSB
                        Buffer.BlockCopy(PayLoadList[i], 0, packetBuffer, 18, payloadLen);
                        crc16 = ModbusCRC16.Calculate(packetBuffer, 3, packetLen); 
                        packetBuffer[packetBufferLen - 4] = (Byte)(crc16 >> 8);
                        packetBuffer[packetBufferLen - 3] = (Byte)(crc16 & 0xFF);
                        packetBuffer[packetBufferLen - 2] = 0x0D;//End mark
                        packetBuffer[packetBufferLen - 1] = 0x0A;// End mark
                        PacketList.Add(packetBuffer);
                    }

                    // Init last packet (message code = 3, not include payload data)
                    packetBuffer = new Byte[22];
                    packetBuffer[0] = 0x7E;
                    packetBuffer[1] = 0;      // Lenght MSB
                    packetBuffer[2] = 15;     // Lenght LSB
                    packetBuffer[3] = 0x24;   // '$'
                    packetBuffer[4] = 0x42;   // 'B'
                    packetBuffer[5] = (Byte)((TotalPacket-1) >> 8);      // Serial MSB
                    packetBuffer[6] = (Byte)((TotalPacket-1) & 0xFF);      // Serial LSB
                    packetBuffer[7] = 3;      // Message Code
                    packetBuffer[8] = this.FirmwareVersion[0];
                    packetBuffer[9] = this.FirmwareVersion[1];
                    packetBuffer[10] = this.FirmwareVersion[2];
                    packetBuffer[11] = this.FirmwareVersion[3];
                    packetBuffer[12] = (Byte)(TotalPacket >> 8);     // Total packet MSB
                    packetBuffer[13] = (Byte)(TotalPacket & 0xFF);   // Total packet MSB
                    packetBuffer[14] = (Byte)((TotalPacket-1) >> 8);     // Packet No MSB
                    packetBuffer[15] = (Byte)((TotalPacket-1) & 0xFF);   // Packet No MSB
                    packetBuffer[16] = 0;// Payload Lenght MSB
                    packetBuffer[17] = 0;// Payload Lenght LSB
                    crc16 = ModbusCRC16.Calculate(packetBuffer, 3, 15);
                    packetBuffer[18] = (Byte)(crc16 >> 8);
                    packetBuffer[19] = (Byte)(crc16 & 0xFF);
                    packetBuffer[20] = 0x0D;//End mark
                    packetBuffer[21] = 0x0A;// End mark
                    PacketList.Add(packetBuffer);
                }

               
                Debug.WriteLine("\r\n-I-Total byte read: " + totalByteRead.ToString());
                Debug.WriteLine("\r\n-I-Total packet: " + TotalPacket.ToString());
                Debug.WriteLine("\r\n-I-Last packet data count: " + readLen.ToString());

            }
            catch (IOException e)
            {
                Debug.WriteLine("\r\n-I-" + e.Message + "\n Cannot open file.");
                return false;
            }
            this.IsValid = true;
            return true;
        }
    }
    public enum BootloaderProcessingState
    {
        IDLE,
        WAITING_DEVICE_BOOTUP,
        SEND_CMD_ERASE,
        SEND_NEXT_DATAPACKET,
    }
}
