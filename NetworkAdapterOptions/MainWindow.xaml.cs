using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace NetworkAdapterOptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string ip;
        public static string WifiName;
        public MainWindow()
        {

            InitializeComponent();          

        }

        private void StaticEth1_Click(object sender, RoutedEventArgs e)
        {
            string ipad = IPAddrTxt.Text;
            //create the pattern of ip address
            string IPpattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex checkIp = new Regex(IPpattern);
            bool validIP = false;
            //check if the ip is valid
            if (ipad == "")
            {
                validIP = false;
            }
            else
            {
                validIP = checkIp.IsMatch(ipad, 0);
            }

            if (validIP)
            {
                SetupIPs.Ethernet1stAdapter();
            }
            else
            {
                string messageBoxTxt = "Wrong IP address";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTxt, caption, button, icon);
            }
        }
             

        private void EthDHCP_Click(object sender, RoutedEventArgs e)
        {
            string DHCPSetup= "";
            SetupIPs.SetupCustomIP(DHCPSetup);
        }
      
    }
}
