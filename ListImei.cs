using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVNConfigSW
{
    public class ListImei
    {
        private static ListImei instance;   
        List<IMEI> listImeiDevice;

        public List<IMEI> ListImeiDevice { get => listImeiDevice; set => listImeiDevice = value; }
        public static ListImei Instance
        {
            get
            {
                if(instance == null)
                    instance = new ListImei();
                return instance;

            }
            set => instance = value; 
        }

        private ListImei()
        {
            listImeiDevice = new List<IMEI>();
        }
    }
}
