using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterOptions
{

    public class SetupIPs
    {
        public string IPAdressNum = "";
        public string Subnet = "255.255.255.0";
        public string wifiDefaultGetway = "192.168.1.1";
        public string PrimaryDns = "";
        public string SecDns = "";
        public string WifiIP;
        public string WifiDns;
        public string WifiName;
        public static void SetupCustomIP(string argument)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");                
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.Verb = "runas";
                psi.Arguments = argument;
                Process.Start(psi);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Ethernet1stAdapter()
        {
          
        }

        public static void EthernetDHCP()
        {
            Process dhcp = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface ip set address \"Local Area Connection\" static 192.168.0.10 255.255.255.0 192.168.0.1 1");
            dhcp.StartInfo = psi;
            dhcp.Start();
        }


        //TODO
        public static void NicFinder()
        {
            List<string> AdapterList = new List<string>();
            IPGlobalProperties prop = IPGlobalProperties.GetIPGlobalProperties();
            foreach( NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                AdapterList.Add(adapter.Name);
                if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false) { continue; }
                Console.WriteLine(adapter.Description);
                IPInterfaceProperties adapterProp = adapter.GetIPProperties();
                IPv4InterfaceProperties ip4props = adapterProp.GetIPv4Properties();

                if (ip4props == null)
                {
                    Console.WriteLine("No IPv4 info");
                    Console.WriteLine();
                    continue;
                }
                
            }           
        }


    }
}
