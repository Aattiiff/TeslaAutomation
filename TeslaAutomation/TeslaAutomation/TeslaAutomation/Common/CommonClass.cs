using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TeslaAutomation.Common
{
    public static class NetConfiguration
    {
        public static int Interval = 10 * 1000;

        public static bool PingTest()
        {
            try
            {
                return (new Ping().Send("google.com", Interval).Status == IPStatus.Success) ? true : false;
            }
            catch
            {
                return false;
            }
        }
    }
}
