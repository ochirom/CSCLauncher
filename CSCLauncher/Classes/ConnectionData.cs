using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace CSCLauncher
{
    public class ConnectionData
    {
        public string server;
        public string appname;
        public string cubename;
        public string login;
        public string password;
        public bool success;


        public ConnectionData (string server, string appname, string cubename, string login, string password)
        {
            this.server = server;
            this.appname = appname;
            this.cubename = cubename;
            this.login = login;
            this.password = password;
            this.success = true;
        }
        public ConnectionData(bool success)
        {
            this.success = success;
        }

        public ConnectionData() { }

        public static bool IsValid(string server)
        {
            IPAddress ip;
            try
            {
                ip = Dns.GetHostEntry(server).AddressList.First();
            }
            catch
            {
                return false;
            }

            PingOptions pingOptions = new PingOptions(128, true);
            Ping ping = new Ping();
            byte[] buffer = new byte[32];
            PingReply pingReply = ping.Send(ip, 1000, buffer, pingOptions);

            if (!(pingReply == null))
                if (pingReply.Status == IPStatus.Success)
                    return true;
                else
                    return false;
            else
                return false;


        }
    }
}
