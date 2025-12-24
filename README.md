# TVNConfigSW - Phần mềm cấu hình thiết bị giám sát hành trình TVN

## Tổng quan dự án

TVNConfigSW là phần mềm ứng dụng Windows desktop được phát triển bằng C# WinForms, chuyên dụng để cấu hình, giám sát và cập nhật firmware cho các thiết bị giám sát hành trình GPS của hãng DSS, bao gồm các dòng sản phẩm: **TVN02, TVN05, TVN06, TVN08**.

Phần mềm kết nối với thiết bị thông qua cổng **COM Serial** (RS232/USB), cho phép người dùng thực hiện đầy đủ các chức năng cấu hình, theo dõi trạng thái thiết bị, xem log hoạt động và cập nhật firmware từ xa.

**Nhà phát triển:** DSS (www.dss.com.vn)  
**Tác giả:** Mai Truong Giang  
**Phiên bản:** 1.1.1.116  
**Bản quyền:** © 2017-2018 DSS

---

## Kiến trúc và thành phần dự án

### 1. Cấu trúc mã nguồn

Dự án được tổ chức theo kiến trúc WinForms với các module chính:

```
TVNConfigSW/
├── FrmMain.cs                    # Form chính - giao diện điều khiển
├── BootloaderProcessing.cs       # Xử lý cập nhật firmware qua bootloader
├── ModbusCRC16.cs                # Tính toán CRC16 Modbus cho kiểm tra gói tin
├── ListBoxLog.cs                 # Hiển thị log với màu sắc theo mức độ
├── IntervalPacket.cs             # Định nghĩa các loại gói tin truyền nhận
├── Debugging.cs                  # Công cụ debug và hiển thị lỗi API
├── DebuggingDeclarations.cs      # Khai báo API cho debugging
├── FrmDeviceSetting.Designer.cs  # Form cài đặt thiết bị
├── FrmFirmwareUpdate.Designer.cs # Form cập nhật firmware
└── AssemblyInfo.cs               # Thông tin phiên bản và metadata
```

### 2. Các lớp và chức năng chính

#### **FrmMain** - Form chính của ứng dụng
- Quản lý kết nối Serial Port với thiết bị
- Hiển thị thời gian thực log từ thiết bị (GPS, GPRS, Error logs)
- Gửi các lệnh cấu hình AT Command
- Theo dõi trạng thái GPS, GPRS/4G, pin, nhiệt độ, IO
- Xuất log sang file Excel/TXT

#### **BootloaderProcessing** - Xử lý cập nhật firmware
Lớp này quản lý toàn bộ quy trình cập nhật firmware qua bootloader với các chức năng:

- **Đọc file firmware binary**: Phân tích file firmware (.bin), trích xuất thông tin phiên bản từ marker string đặc biệt
- **Phân chia gói tin**: Chia firmware thành các gói tin 2048 byte, mỗi gói bao gồm:
  - Header: `0x7E` + Length(2) + `$B`(2) + Serial(2) + MessageCode(1)
  - Firmware Version(4) + TotalPacket(2) + PacketNo(2) + PayloadLength(2)
  - Payload Data(0-2048 bytes) + CRC16(2) + `0x0D0A`(2)
- **Xác thực gói tin**: Sử dụng CRC16 Modbus để đảm bảo tính toàn vẹn dữ liệu
- **Quản lý trạng thái**: State machine với các trạng thái:
  - `IDLE`: Chờ lệnh
  - `WAITING_DEVICE_BOOTUP`: Chờ thiết bị khởi động
  - `SEND_CMD_ERASE`: Gửi lệnh xóa flash
  - `SEND_NEXT_DATAPACKET`: Gửi từng gói dữ liệu firmware

**Cấu trúc gói tin bootloader:**
```
Message Code 1 (Init):    Packet đầu tiên, không chứa payload, thông báo bắt đầu
Message Code 2 (Data):    Các packet chứa dữ liệu firmware (2048 bytes/packet)
Message Code 3 (End):     Packet cuối cùng, không chứa payload, hoàn tất
```

#### **ModbusCRC16** - Tính toán checksum
- Sử dụng thuật toán Modbus CRC16
- Đảm bảo tính toàn vẹn của gói tin truyền/nhận
- Bảng tra CRC 256 phần tử để tính toán nhanh

#### **ListBoxLog** - Hiển thị log phân màu
- Hiển thị log theo 6 mức độ: Critical, Error, Warning, Info, Verbose, Debug
- Mỗi mức có màu sắc riêng để dễ phân biệt
- Hỗ trợ copy log ra clipboard dạng RTF
- Tự động cuộn theo log mới (có thể tạm dừng)
- Giới hạn số dòng tối đa (mặc định 500) để tránh tràn bộ nhớ

#### **IntervalPacket** - Định nghĩa giao thức
Các loại gói tin được hỗ trợ:
- `Interval`: Gói tin dữ liệu định kỳ từ thiết bị
- `Login`: Gói tin đăng nhập thiết bị với server
- `TextMessage`: Tin nhắn văn bản
- `GprsCommand`: Lệnh điều khiển qua GPRS
- `Fota`: Cập nhật firmware qua mạng (Firmware Over The Air)

---

## Giao thức truyền thông

### 1. Kết nối Serial Port
```
- Port: COM1-COM255 (tự động quét)
- Baud Rate: 9600, 19200, 38400, 57600, 115200
- Data Bits: 8
- Stop Bits: 1
- Parity: None
- Flow Control: None
```

### 2. Lệnh AT Commands
Phần mềm hỗ trợ gửi các lệnh cấu hình tiêu chuẩn:

**Lệnh hệ thống:**
- `*TVN686,993#` - Khởi động lại vào chế độ bootloader
- `*300190,990,099#` - Reset về cấu hình mặc định
- `*300190,500#` - Xóa toàn bộ flash
- `*300190,991#` - Reset thiết bị

**Cấu hình TVN02:**
```
*000000,001,300190#              # Đặt mật khẩu
*300190,011,e-connect,,#         # Cấu hình APN
*300190,015,1,gps.tracking.vn,18860# # Cấu hình server
*300190,016,1,#                  # Kích hoạt kết nối
*300190,018,30,999#              # Cài đặt interval gửi dữ liệu
```

**Cấu hình TVN05:**
```
*000000,001,300190#
*300190,011,e-connect,,#
*300190,015,1,gps.tracking.vn,20022# # Port khác với TVN02
*300190,016,1,#
*300190,018,30,999#
```

### 3. Định dạng log từ thiết bị
Thiết bị gửi log theo dòng, các loại thông tin:
- **GPS Status**: Vị trí, vận tốc, số vệ tinh, HDOP
- **GPRS Status**: Cường độ sóng (CSQ), trạng thái kết nối
- **System Info**: Điện áp pin, nhiệt độ (TempA/B/C/D), IO status
- **Error Messages**: Lỗi phần cứng, lỗi kết nối

---

## Tính năng chính

### 1. Quản lý kết nối thiết bị
- ✅ Tự động quét các cổng COM khả dụng
- ✅ Hỗ trợ nhiều tốc độ baud rate
- ✅ Hiển thị trạng thái kết nối realtime
- ✅ Tự động nhận diện thiết bị kết nối

### 2. Giám sát thiết bị theo thời gian thực
- ✅ **GPS**: Vị trí, tốc độ, hướng, số vệ tinh, độ chính xác
- ✅ **GPRS/4G**: Cường độ sóng (CSQ), trạng thái kết nối mạng
- ✅ **System**: 
  - Điện áp pin (VBAT)
  - Nhiệt độ 4 cảm biến (TempA, TempB, TempC, TempD)
  - Trạng thái IO (Digital Input/Output)
  - Trạng thái nguồn điện
- ✅ **Device Info**: IMEI, Firmware Version, Bootloader Version, ICCID (SIM)

### 3. Cấu hình thiết bị
- ✅ Thiết lập server và port kết nối
- ✅ Cấu hình APN cho GPRS
- ✅ Thiết lập chu kỳ gửi dữ liệu
- ✅ Cấu hình các preset: TVN02, TVN05
- ✅ Reset về cài đặt mặc định
- ✅ Xóa flash memory

### 4. Cập nhật Firmware
- ✅ Đọc và xác thực file firmware binary
- ✅ Trích xuất tự động phiên bản firmware
- ✅ Chia nhỏ firmware thành gói tin 2KB
- ✅ Kiểm tra tính toàn vẹn bằng CRC16
- ✅ Hiển thị tiến trình cập nhật (progress bar)
- ✅ Xử lý lỗi và retry tự động
- ✅ Timeout protection cho từng gói tin

### 5. Quản lý Log
- ✅ Hiển thị log realtime với màu sắc phân cấp
- ✅ Tự động cuộn hoặc dừng cuộn
- ✅ Lọc hiển thị GPS sentence (NMEA)
- ✅ Copy log ra clipboard
- ✅ Xuất log sang Excel (.xlsx)
- ✅ Xuất log sang Text (.txt)
- ✅ Lưu log theo IMEI thiết bị
- ✅ Xóa log trong bộ nhớ

### 6. Phân tích gói tin
- ✅ Parser gói tin hex string
- ✅ Hiển thị cấu trúc gói tin chi tiết
- ✅ Decode các trường thông tin

---

## Yêu cầu hệ thống

### Phần cứng tối thiểu
- **CPU**: Intel Core 2 Duo hoặc tương đương
- **RAM**: 2 GB
- **Ổ cứng**: 100 MB dung lượng trống
- **Cổng COM**: RS232 hoặc USB-to-Serial adapter

### Phần mềm
- **Hệ điều hành**: Windows Vista SP2 trở lên (Vista, 7, 8, 10, 11)
- **.NET Framework**: 4.8 trở lên
- **Quyền truy cập**: Administrator (để truy cập COM port)

### Thư viện phụ thuộc
- **EPPlus 5.8.8**: Thư viện xuất Excel (OpenXML)
- **Microsoft.IO.RecyclableMemoryStream 1.4.1**: Quản lý memory hiệu quả
- **System.ComponentModel.Annotations 4.7.0**: Data annotations
- **Microsoft.Office.Interop.Excel**: COM Interop với Excel (tùy chọn)

---

## Hướng dẫn cài đặt

### 1. Cài đặt từ source code

#### Yêu cầu môi trường phát triển
- **Visual Studio 2012** trở lên (khuyến nghị VS 2019 hoặc 2022)
- **.NET Framework 4.8 SDK**
- **NuGet Package Manager**

#### Các bước build
```bash
# 1. Clone repository
git clone https://gitlab.com/dss-tvn02/tvnconfigsw.git
cd tvnconfigsw

# 2. Restore NuGet packages
nuget restore TVNConfigSW.sln

# 3. Build solution
msbuild TVNConfigSW.sln /p:Configuration=Release /p:Platform="Any CPU"

# Hoặc build trong Visual Studio:
# - Mở file TVNConfigSW.sln
# - Chọn Build > Build Solution (Ctrl+Shift+B)
# - File .exe sẽ được tạo tại: bin/Release/TVNConfigSW.exe
```

### 2. Cài đặt driver USB-to-Serial
Nếu sử dụng cáp USB-to-Serial, cần cài đặt driver:
- **FTDI**: https://ftdichip.com/drivers/
- **Prolific**: https://www.prolific.com.tw/
- **CH340**: Driver tích hợp sẵn trong Windows 10+

### 3. Chạy ứng dụng
```bash
# Chạy từ command line
cd bin/Release
TVNConfigSW.exe

# Hoặc double-click vào file TVNConfigSW.exe
```

---

## Hướng dẫn sử dụng

### Bước 1: Kết nối thiết bị
1. Kết nối thiết bị TVN với máy tính qua cáp COM/USB
2. Chờ Windows nhận diện cổng COM (kiểm tra trong Device Manager)
3. Mở phần mềm TVNConfigSW
4. Click **"Refresh"** để quét danh sách cổng COM
5. Chọn cổng COM và Baud Rate phù hợp (thường là **115200**)
6. Click **"Open"** để kết nối

### Bước 2: Xem log thiết bị
- Log thiết bị sẽ hiển thị tự động trong tab **"Device Logs"**
- Tick **"Auto Scroll"** để tự động cuộn theo log mới
- Tick **"Display GPS Sentence"** để hiển thị câu lệnh NMEA GPS
- Click **"Clear Logs"** để xóa log hiển thị

### Bước 3: Cấu hình thiết bị
1. Chuyển sang tab **"Device Settings"**
2. Chọn preset cấu hình:
   - Click **"TVN02"** cho thiết bị TVN02
   - Click **"TVN05"** cho thiết bị TVN05
3. Hoặc nhập lệnh AT command thủ công vào ô **"Command List"**
4. Click **"Write Settings"** để gửi cấu hình

### Bước 4: Cập nhật Firmware
1. Chuyển sang tab **"Firmware Update"**
2. Click **"Open File"** và chọn file firmware (.bin)
3. Phần mềm sẽ tự động đọc và hiển thị phiên bản firmware
4. Click **"Reboot to DFU Mode"** để khởi động thiết bị vào chế độ bootloader
5. Đợi thiết bị khởi động lại (khoảng 5 giây)
6. Progress bar sẽ hiển thị tiến trình cập nhật
7. Khi hoàn tất, thiết bị sẽ tự động reset

**⚠️ Lưu ý quan trọng khi cập nhật firmware:**
- KHÔNG ngắt kết nối trong quá trình cập nhật
- Đảm bảo thiết bị có đủ nguồn điện
- Sử dụng file firmware chính xác cho model thiết bị
- Nếu cập nhật thất bại, thử lại hoặc liên hệ hỗ trợ kỹ thuật

### Bước 5: Xuất Log
1. Click **"Export TXT"** để xuất log dạng text
2. Click **"Export Excel"** để xuất log dạng Excel
3. File sẽ được lưu với tên theo IMEI và timestamp

---

## Chi tiết xử lý nạp Firmware

Phần này giải thích chi tiết cách chương trình xử lý quy trình nạp firmware vào thiết bị TVN.

### 1. Tổng quan quy trình

Quy trình nạp firmware được chia thành 5 giai đoạn chính:

```
┌─────────────────────────────────────────────────────────────┐
│ GIAI ĐOẠN 1: Đọc và phân tích file firmware                │
│ - Mở file .bin                                               │
│ - Tìm marker string để trích xuất phiên bản                 │
│ - Đọc toàn bộ dữ liệu binary                                │
│ - Chia thành các khối 2048 bytes                            │
└─────────────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────────────┐
│ GIAI ĐOẠN 2: Tạo danh sách gói tin                         │
│ - Tạo Init Packet (Message Code 1)                          │
│ - Tạo các Data Packet (Message Code 2) - mỗi gói 2KB       │
│ - Tạo End Packet (Message Code 3)                           │
│ - Tính CRC16 cho từng gói                                   │
└─────────────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────────────┐
│ GIAI ĐOẠN 3: Khởi động thiết bị vào chế độ Bootloader      │
│ - Gửi lệnh *TVN686,993# để reboot vào DFU mode             │
│ - Gửi Query State command                                   │
│ - Chờ nhận "-BLD-START" hoặc "-BLD-ACK" (timeout 30s)      │
└─────────────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────────────┐
│ GIAI ĐOẠN 4: Truyền firmware                               │
│ - Gửi Init Packet → Chờ ACK                                │
│ - Gửi Data Packet 1 → Chờ ACK                              │
│ - Gửi Data Packet 2 → Chờ ACK                              │
│ - ... (lặp lại cho tất cả gói)                             │
│ - Gửi End Packet → Chờ ACK                                 │
└─────────────────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────────────────┐
│ GIAI ĐOẠN 5: Hoàn tất và reboot                            │
│ - Thiết bị tự động verify firmware                          │
│ - Thiết bị tự động reboot vào firmware mới                  │
│ - Phần mềm hiển thị "Complete" trên progress bar           │
└─────────────────────────────────────────────────────────────┘
```

### 2. Chi tiết từng giai đoạn

#### GIAI ĐOẠN 1: Đọc và phân tích file firmware

**Hàm xử lý:** `BootloaderProcessing.ReadBinaryFile(string binaryFileName)`

**Các bước thực hiện:**

1. **Trích xuất phiên bản firmware:**
   ```csharp
   // Tìm marker string đặc biệt trong file
   string firmwareVersionMarker = "FIRMWARE VERSION MARKER: LIFE IS THE MOST BEAUTIFUL THING IN THE WORLD@";
   
   // Đọc từng dòng cho đến khi tìm thấy marker
   // Ví dụ marker trong file: "...MARKER@1.2.3.4"
   // → Version = [1, 2, 3, 4]
   ```
   
   - Mở file firmware dưới dạng text
   - Quét từng dòng tìm marker string
   - Sau marker là phiên bản dạng "X.Y.Z.W" (4 số)
   - Lưu vào mảng `FirmwareVersion[4]`
   - Nếu không tìm thấy marker → trả về FALSE, file không hợp lệ

2. **Đọc dữ liệu binary:**
   ```csharp
   BinaryReader binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open));
   
   // Đọc từng khối 2048 bytes
   do {
       byte[] payLoadData = binaryReader.ReadBytes(2048);
       if (payLoadData.Length > 0) {
           PayLoadList.Add(payLoadData);
           totalPayloadPacket++;
       }
   } while (payLoadData.Length > 0);
   ```
   
   - Mở file ở chế độ binary
   - Đọc liên tiếp các khối 2048 bytes
   - Lưu vào danh sách `PayLoadList`
   - Gói cuối cùng có thể < 2048 bytes
   - Tối đa 65000 gói (giới hạn của UInt16)

#### GIAI ĐOẠN 2: Tạo danh sách gói tin

**Cấu trúc gói tin bootloader:**

```
┌────────┬─────────┬────────────┬──────────┬─────────┐
│ Header │ Payload │   CRC16    │ End Mark │         │
│ 18 byte│ 0-2048  │  2 bytes   │ 0D 0A    │         │
└────────┴─────────┴────────────┴──────────┴─────────┘

Chi tiết Header (18 bytes):
Byte 0:     0x7E              - Start marker
Byte 1-2:   Length (MSB,LSB)  - Độ dài từ byte 3 đến hết payload
Byte 3-4:   $B (0x24, 0x42)   - Protocol identifier
Byte 5-6:   Serial (MSB,LSB)  - Số thứ tự gói (0, 1, 2, ...)
Byte 7:     Message Code      - Loại gói tin (1:Init, 2:Data, 3:End)
Byte 8-11:  FW Version        - 4 bytes phiên bản [X,Y,Z,W]
Byte 12-13: Total Packet      - Tổng số gói (MSB, LSB)
Byte 14-15: Packet No         - Số thứ tự gói này (MSB, LSB)
Byte 16-17: Payload Length    - Độ dài payload (MSB, LSB)
```

**2.1. Tạo Init Packet (Message Code = 1):**
```csharp
// Gói đầu tiên, không có payload
byte[] packet = new byte[22];
packet[0] = 0x7E;
packet[1] = 0x00;              // Length MSB
packet[2] = 0x0F;              // Length LSB = 15
packet[3] = 0x24;              // '$'
packet[4] = 0x42;              // 'B'
packet[5] = 0x00;              // Serial MSB
packet[6] = 0x00;              // Serial LSB
packet[7] = 0x01;              // Message Code = 1 (Init)
packet[8-11] = FirmwareVersion[0-3];
packet[12-13] = TotalPacket (MSB, LSB);
packet[14-15] = 0x00, 0x00;    // Packet No = 0
packet[16-17] = 0x00, 0x00;    // Payload Length = 0
CRC16 = Calculate(packet[3..17]);
packet[18] = CRC16 MSB;
packet[19] = CRC16 LSB;
packet[20] = 0x0D;             // CR
packet[21] = 0x0A;             // LF
```

**2.2. Tạo Data Packets (Message Code = 2):**
```csharp
// Với mỗi khối 2048 bytes trong PayLoadList
for (int i = 0; i < totalPayloadPacket; i++) {
    int payloadLen = PayLoadList[i].Length;  // 2048 hoặc ít hơn
    int packetLen = payloadLen + 15;
    byte[] packet = new byte[packetLen + 7];
    
    packet[0] = 0x7E;
    packet[1-2] = packetLen (MSB, LSB);
    packet[3-4] = 0x24, 0x42;           // $B
    packet[5-6] = (i+1) (MSB, LSB);     // Serial number
    packet[7] = 0x02;                   // Message Code = 2 (Data)
    packet[8-11] = FirmwareVersion;
    packet[12-13] = TotalPacket;
    packet[14-15] = (i+1) (MSB, LSB);   // Packet number
    packet[16-17] = payloadLen (MSB, LSB);
    
    // Copy payload data
    Copy PayLoadList[i] → packet[18..(18+payloadLen-1)]
    
    // Calculate CRC for packet[3..(18+payloadLen-1)]
    CRC16 = Calculate(...);
    packet[packetLen+3] = CRC16 MSB;
    packet[packetLen+4] = CRC16 LSB;
    packet[packetLen+5] = 0x0D;
    packet[packetLen+6] = 0x0A;
    
    PacketList.Add(packet);
}
```

**2.3. Tạo End Packet (Message Code = 3):**
```csharp
// Gói cuối cùng, không có payload
byte[] packet = new byte[22];
packet[0] = 0x7E;
packet[1] = 0x00;
packet[2] = 0x0F;              // Length = 15
packet[3] = 0x24;              // '$'
packet[4] = 0x42;              // 'B'
packet[5-6] = (TotalPacket-1) (MSB, LSB);  // Serial = Last packet number
packet[7] = 0x03;              // Message Code = 3 (End)
packet[8-11] = FirmwareVersion;
packet[12-13] = TotalPacket;
packet[14-15] = (TotalPacket-1) (MSB, LSB);
packet[16-17] = 0x00, 0x00;    // Payload Length = 0
CRC16 = Calculate(packet[3..17]);
packet[18-19] = CRC16 (MSB, LSB);
packet[20-21] = 0x0D, 0x0A;
```

#### GIAI ĐOẠN 3: Khởi động vào chế độ Bootloader

**State Machine:** `IDLE` → `WAITING_DEVICE_BOOTUP`

**Các bước:**

1. **Người dùng click "Reboot to DFU Mode":**
   ```csharp
   // Gửi lệnh AT Command để thiết bị reboot vào bootloader
   commandStrQueue.Enqueue("*TVN686,993#");
   
   // Chuyển state và khởi tạo
   bootloaderProcessing.State = BootloaderProcessingState.WAITING_DEVICE_BOOTUP;
   bootloaderProcessing.NextTxPacketNo = 0;
   bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
   
   // Gửi Query State command
   bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.CommandQueryDeviceState);
   ```

2. **Chờ thiết bị phản hồi:**
   - Timer mỗi 100ms kiểm tra `bootLoaderRxResponseQueue`
   - Tìm chuỗi "-BLD-START" hoặc "-BLD-ACK" trong response
   - Nếu tìm thấy:
     ```
     → Thiết bị đã vào bootloader mode
     → Chuyển sang State: SEND_CMD_ERASE
     → Hiển thị "Device entered bootloader mode, start programming..."
     ```
   
3. **Xử lý timeout:**
   - Sau 5 giây: Gửi lại Query State command
   - Sau 30 giây: Timeout, hủy quá trình
     ```
     → Hiển thị lỗi "Device cannot enter bootloader mode"
     → Quay về State: IDLE
     → IsValid = false
     ```

#### GIAI ĐOẠN 4: Truyền Firmware

**State Machine:** `SEND_CMD_ERASE` → `SEND_NEXT_DATAPACKET`

**4.1. Gửi Init Packet (SEND_CMD_ERASE state):**

```csharp
// Clear response queue
bootLoaderRxResponseQueue.Clear();

// Gửi packet đầu tiên (Init packet - Message Code 1)
bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.PacketList[0]);

// Chuyển state
bootloaderProcessing.State = BootloaderProcessingState.SEND_NEXT_DATAPACKET;
bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
```

**4.2. Gửi Data Packets (SEND_NEXT_DATAPACKET state):**

```csharp
// Timer 100ms liên tục kiểm tra
while (State == SEND_NEXT_DATAPACKET) {
    
    // Kiểm tra response từ thiết bị
    if (bootLoaderRxResponseQueue.Count > 0) {
        string response = bootLoaderRxResponseQueue.Dequeue();
        
        if (response.Contains("-BLD-ACK")) {
            // Thiết bị đã nhận gói tin thành công
            bootloaderProcessing.NextTxPacketNo++;
            bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
            
            // Cập nhật progress bar
            progressBarFirmwareUpdate.Value = NextTxPacketNo;
            labelFirmwareUpdateProcess.Text = 
                "Firmware Update Process: " + NextTxPacketNo + "/" + TotalPacket;
            
            // Kiểm tra xem đã gửi hết chưa
            if (NextTxPacketNo >= TotalPacket) {
                // Hoàn thành
                listBoxLog.Log("Firmware update complete!");
                progressBarFirmwareUpdate.Value = TotalPacket;
                bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                bootloaderProcessing.IsValid = false;
            }
            else {
                // Gửi gói tiếp theo
                bootLoaderTxPacketQueue.Enqueue(
                    bootloaderProcessing.PacketList[NextTxPacketNo]
                );
            }
        }
        else if (response.Contains("-BLD-RESEND")) {
            // Thiết bị yêu cầu gửi lại gói hiện tại
            listBoxLog.Log("Device request resend packet " + NextTxPacketNo);
            bootLoaderTxPacketQueue.Enqueue(
                bootloaderProcessing.PacketList[NextTxPacketNo]
            );
            bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
        }
    }
    else {
        // Không có response, tăng timeout counter
        bootloaderProcessing.WaitingForResponseTimeoutCounter++;
        
        // Timeout sau 10 giây → gửi lại
        if (WaitingForResponseTimeoutCounter >= (10000 / 100)) {
            listBoxLog.Log("Timeout, resend packet " + NextTxPacketNo);
            bootLoaderTxPacketQueue.Enqueue(
                bootloaderProcessing.PacketList[NextTxPacketNo]
            );
            WaitingForResponseTimeoutCounter = 0;
        }
    }
}
```

#### GIAI ĐOẠN 5: Hoàn tất và Reboot

**Sau khi gửi xong End Packet:**

1. **Thiết bị tự động verify:**
   - Kiểm tra CRC16 của toàn bộ firmware
   - Kiểm tra tính toàn vẹn dữ liệu
   - Nếu OK: Lưu firmware vào flash memory

2. **Thiết bị reboot:**
   - Tự động khởi động lại
   - Load firmware mới
   - Gửi thông tin firmware version ra serial port

3. **Phần mềm hoàn tất:**
   ```csharp
   progressBarFirmwareUpdate.Value = TotalPacket;
   labelFirmwareUpdateProcess.Text = "Firmware Update Process: Complete";
   listBoxLog.Log(Level.Info, "Firmware update completed successfully!");
   bootloaderProcessing.State = BootloaderProcessingState.IDLE;
   bootloaderProcessing.IsValid = false;
   ```

### 3. Xử lý lỗi và retry

**3.1. Lỗi CRC16 không khớp:**
- Thiết bị gửi "-BLD-RESEND"
- Phần mềm gửi lại gói tin hiện tại
- Tối đa retry không giới hạn cho đến khi thành công

**3.2. Timeout không nhận ACK:**
- Sau 10 giây không nhận ACK
- Phần mềm tự động gửi lại gói tin
- Tiếp tục cho đến khi nhận được ACK

**3.3. Mất kết nối:**
- Nếu serial port bị disconnect
- Phần mềm dừng quá trình
- Hiển thị lỗi "Connection lost"
- User phải kết nối lại và bắt đầu lại từ đầu

**3.4. File firmware không hợp lệ:**
- Không tìm thấy version marker → Từ chối file
- File quá lớn (>65000 gói) → Từ chối file
- Hiển thị lỗi cho user

### 4. Thread và Concurrency

**Serial Port Thread:**
```csharp
// Thread này chạy khi có data từ COM port
serialPort.DataReceived += (sender, e) => {
    int numBytes = serialPort.BytesToRead;
    byte[] buffer = new byte[numBytes];
    serialPort.Read(buffer, 0, numBytes);
    serialPortRcvBufferQueue.Enqueue(buffer);  // Thread-safe queue
};
```

**Timer Thread (100ms):**
```csharp
// Timer chạy mỗi 100ms để xử lý data và bootloader
timerSerialPortRxDataParsing.Tick += (sender, e) => {
    
    // 1. Xử lý received data
    ReadLogLineFromSerialPort();
    
    // 2. Gửi command từ queue
    if (commandStrQueue.Count > 0) {
        string cmd = commandStrQueue.Dequeue();
        serialPort.WriteLine(cmd);
    }
    
    // 3. Gửi bootloader packet từ queue
    if (bootLoaderTxPacketQueue.Count > 0) {
        byte[] packet = bootLoaderTxPacketQueue.Dequeue();
        serialPort.Write(packet, 0, packet.Length);
    }
    
    // 4. Xử lý bootloader state machine
    if (bootloaderProcessing.IsValid == true) {
        BootloaderProcessingHandler();
    }
};
```

**UI Thread:**
- Cập nhật progress bar
- Hiển thị log
- Enable/disable buttons

### 5. Ví dụ Log thực tế khi nạp firmware

```
[Info] Open firmware file: TVN02_v1.2.3.4.bin
[Info] Firmware version: 1.2.3.4
[Info] Total packets: 523
[Info] File loaded successfully

[Info] User clicked "Reboot to DFU Mode"
[Info] Sending reboot command...
[Info] Waiting for device to enter bootloader mode...

[Info] Device entered bootloader mode, start programming...
[Info] Sending Init Packet (1/523)
[Info] ACK received, sending packet 2/523
[Info] ACK received, sending packet 3/523
[Info] ACK received, sending packet 4/523
...
[Info] ACK received, sending packet 522/523
[Info] ACK received, sending packet 523/523 (End Packet)
[Info] Firmware update completed successfully!
[Info] Device is rebooting...
```

### 6. Các câu hỏi thường gặp

**Q: Nạp firmware mất bao lâu?**
- A: Phụ thuộc vào kích thước firmware và baud rate
  - Firmware 1MB @ 115200 baud: ~2-3 phút
  - Firmware 1MB @ 57600 baud: ~4-5 phút

**Q: Có thể hủy giữa chừng không?**
- A: Không nên, thiết bị có thể brick. Nếu hủy, phải nạp lại từ đầu.

**Q: Nạp thất bại có làm hỏng thiết bị không?**
- A: Bootloader vẫn còn, có thể nạp lại. Thiết bị sẽ không chạy firmware mới nếu verify thất bại.

**Q: Có cần nguồn điện ngoài không?**
- A: Khuyến nghị có nguồn ngoài ổn định, không nên chỉ dùng nguồn USB.

---

## Cấu trúc dữ liệu và thuật toán

### 1. Bootloader Protocol Flow
```
[PC]                          [Device]
  |                               |
  |-- Reboot to Bootloader ------>|
  |                               |
  |<------ ACK (Ready) ----------|
  |                               |
  |-- Init Packet (Code 1) ------>|
  |   (FW Ver, Total Packets)     |
  |<------ ACK --------------------|
  |                               |
  |-- Data Packet 1 (Code 2) ----->|
  |   (2048 bytes + CRC)          |
  |<------ ACK --------------------|
  |                               |
  |-- Data Packet 2 (Code 2) ----->|
  |<------ ACK --------------------|
  |                               |
  |       ... (continue) ...      |
  |                               |
  |-- End Packet (Code 3) -------->|
  |<------ ACK --------------------|
  |                               |
  |<------ Device Reboot ---------|
```

### 2. CRC16 Modbus Algorithm
```csharp
// Tính CRC16 cho mảng byte
// wCRCTable là bảng tra 256 phần tử được định nghĩa trong ModbusCRC16.cs
UInt16 wCRCWord = 0xFFFF;
for (int i = offset; i < offset + length; i++)
{
    byte nTemp = (byte)(data[i] ^ wCRCWord);
    wCRCWord >>= 8;
    wCRCWord ^= wCRCTable[nTemp];  // Tra bảng để tính CRC nhanh
}
return wCRCWord;
```

### 3. Serial Port Data Processing
```
Thread 1 (Serial Port):
  - Nhận data từ COM port
  - Đưa vào ConcurrentQueue

Thread 2 (Timer - 100ms):
  - Lấy data từ Queue
  - Parse thành từng dòng (kết thúc bởi \r\n)
  - Phân loại: GPS/GPRS/Error/System
  - Cập nhật UI
```

---

## Khắc phục sự cố

### Lỗi "Cannot open COM port"
- **Nguyên nhân**: Cổng COM đã được sử dụng bởi ứng dụng khác
- **Giải pháp**: 
  - Đóng các ứng dụng terminal khác (PuTTY, Arduino IDE, etc.)
  - Kiểm tra Device Manager xem driver đã cài đúng chưa
  - Thử rút và cắm lại cáp USB

### Không nhận được log từ thiết bị
- **Nguyên nhân**: Sai baud rate hoặc thiết bị chưa khởi động
- **Giải pháp**:
  - Thử các baud rate khác: 9600, 38400, 115200
  - Reset thiết bị và thử lại
  - Kiểm tra cáp kết nối

### Cập nhật firmware thất bại
- **Nguyên nhân**: Mất kết nối, file firmware sai, timeout
- **Giải pháp**:
  - Kiểm tra kết nối COM port ổn định
  - Đảm bảo file firmware đúng với model thiết bị
  - Tăng timeout trong code nếu cần thiết
  - Khởi động lại thiết bị và thử lại

### Ứng dụng bị crash khi xuất Excel
- **Nguyên nhân**: Thiếu thư viện EPPlus hoặc quyền ghi file
- **Giải pháp**:
  - Restore NuGet packages
  - Chạy ứng dụng với quyền Administrator
  - Kiểm tra đường dẫn thư mục output

---

## Đóng góp và phát triển

### Quy tắc coding
- Tuân thủ C# Coding Conventions của Microsoft
- Sử dụng English cho tên biến/hàm, Vietnamese cho comment
- Mỗi hàm không quá 100 dòng code
- Bắt exception đầy đủ

### Quy trình đóng góp
1. Fork repository
2. Tạo branch mới: `git checkout -b feature/ten-tinh-nang`
3. Commit thay đổi: `git commit -m "Thêm tính năng X"`
4. Push lên branch: `git push origin feature/ten-tinh-nang`
5. Tạo Pull Request

### Roadmap phát triển
- [ ] Hỗ trợ cập nhật firmware qua FOTA (Firmware Over The Air)
- [ ] Kết nối TCP/IP trực tiếp với thiết bị qua GPRS
- [ ] Quản lý nhiều thiết bị đồng thời
- [ ] Database lưu trữ lịch sử cấu hình
- [ ] Export log dạng CSV
- [ ] Giao diện đa ngôn ngữ (EN/VI)
- [ ] Hỗ trợ thiết bị TVN mới (TVN09, TVN10)

---

## Tác giả và bản quyền

**Công ty:** DSS - Digital Security Solutions  
**Website:** www.dss.com.vn  
**Tác giả chính:** Mai Truong Giang  
**Email hỗ trợ:** support@dss.com.vn  

**Bản quyền:** © 2017-2018 DSS. All rights reserved.

### Giấy phép
Phần mềm này là sản phẩm thương mại của DSS. Mọi hành vi sao chép, phân phối hoặc sử dụng cho mục đích thương mại mà không có sự cho phép của DSS đều bị nghiêm cấm.

---

## Thông tin liên hệ

Để được hỗ trợ kỹ thuật và thông tin chi tiết về sản phẩm:
- **Website:** www.dss.com.vn
- **Email:** support@dss.com.vn

_Vui lòng liên hệ qua website hoặc email để được hỗ trợ trực tiếp._

---

## Lịch sử phiên bản

### Version 1.1.1.116 (Current)
- Ổn định giao diện người dùng
- Cải thiện thuật toán bootloader
- Hỗ trợ xuất log Excel với EPPlus 5.8.8
- Tối ưu hiệu suất xử lý serial data

### Version 1.0.x
- Phiên bản đầu tiên
- Các tính năng cơ bản

