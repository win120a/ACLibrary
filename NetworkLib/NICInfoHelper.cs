using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using ACLibrary.Collection;

namespace ACLibrary.Network
{
    public class NICInfoHelper
    {
        public static Dictionary<string, string> GetPrivateNICIPAndMACDictonary()
        {
            Dictionary<string, string> l = new Dictionary<string, string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var address in n.GetIPProperties().UnicastAddresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        l.Add(n.GetPhysicalAddress().ToString(), address.Address.ToString());
                    }
                }
            }

            return l;
        }

        public static List<string> GetPrivateNICIPList()
        {
            List<string> l = new List<string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var address in n.GetIPProperties().UnicastAddresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        l.Add(address.Address.ToString());
                    }
                }
            }

            return l;
        }

        public static List<string> GetPrivateNICMAC()
        {
            List<string> l = new List<string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var i in n.GetIPProperties().UnicastAddresses)
                {
                    if (i.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        l.Add(n.GetPhysicalAddress().ToString());
                    }
                }
            }

            return l;
        }

        public static Dictionary<string, string> GetPrivateNICDHCPAndMACDictonary()
        {
            Dictionary<string, string> l = new Dictionary<string, string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var e in n.GetIPProperties().DhcpServerAddresses)
                {
                    if (e.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        l.Add(n.GetPhysicalAddress().ToString(), e.ToString());
                    }
                }
            }

            return l;
        }

        public static Dictionary<string, List<string>> GetPrivateNICDNSAndMACDictonary()
        {
            ACDictionary<string, List<string>> d = new ACDictionary<string, List<string>>();
            ACList<string> al = new ACList<string>();
            
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var e in n.GetIPProperties().DnsAddresses)
                {
                    if (e.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        if (al.Exists(n.GetPhysicalAddress().ToString()))
                        {
                            d[n.GetPhysicalAddress().ToString()].Add(e.ToString());
                        }
                        else
                        {
                            d.Add(n.GetPhysicalAddress().ToString(), new List<string>());
                            d[n.GetPhysicalAddress().ToString()].Add(e.ToString());
                        }
                        //l.Add(n.GetPhysicalAddress().ToString(), e.ToString());
                        al.Add(n.GetPhysicalAddress().ToString());
                    }
                }
            }

            return d;
        }
    }
}
