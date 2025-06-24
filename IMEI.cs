using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVNConfigSW
{
    public class IMEI
    {

        private string colImei;
        private string colCCID;
        private string colFirmware;
        private string colTime;
        private string colTempA;
        private string colTempB;
        private string colPower;
        private string colIO;
        private string colCSQ;
        private string colADA;
        private string colADB;

        public string ColImei { get => colImei; set => colImei = value; }
        public string ColCCID { get => colCCID; set => colCCID = value; }
        public string ColFirmware { get => colFirmware; set => colFirmware = value; }
        public string ColTime { get => colTime; set => colTime = value; }
        public string ColTempA { get => colTempA; set => colTempA = value; }
        public string ColTempB { get => colTempB; set => colTempB = value; }
        public string ColPower { get => colPower; set => colPower = value; }
        public string ColIO { get => colIO; set => colIO = value; }
        public string ColCSQ { get => colCSQ; set => colCSQ = value; }
        public string ColADA { get => colADA; set => colADA = value; }
        public string ColADB { get => colADB; set => colADB = value; }


        public IMEI(string colImei,string colCCID,string colFirmware, string colTime, string colTempA, string colTempB, string colPower,string colIO, string colCSQ, string colADA, string colADB)
        {
            ColADA = colADA;
            ColADB = colADB;
            ColImei = colImei;
            ColCCID = colCCID;
            ColFirmware = colFirmware;
            ColTime = colTime;
            ColTempA = colTempA;
            ColTempB = colTempB;
            ColPower = colPower;
            ColIO = colIO;
            ColCSQ = colCSQ;

        }
    }
}
