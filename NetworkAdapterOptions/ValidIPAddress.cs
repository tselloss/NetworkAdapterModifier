using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace NetworkAdapterOptions
{
    public class ValidIPAddress
    {
        public bool ValidIpAddr(string IPaddress)
        {
            //create the pattern of ip address
            string IPpattern= @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";            
            Regex checkIp = new Regex(IPpattern);
            bool validIP = false;
            //check if the ip is valid
            if (IPaddress == "")
            {
                validIP = false;
            }
            else
            {
                validIP = checkIp.IsMatch(IPaddress, 0);
            }
            return validIP;
        }
    }
}
