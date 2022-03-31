using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVNConfigSW
{
    public class IntervalPacket
    {

    }

    public enum PacketProtocol
    {
        Interval,
        Login,
        TextMessage,
        GprsCommand,
        Fota
    }
}
