using ACLibrary.Network;
using System;
using System.Collections.Generic;
using ACLibrary.Collection;

namespace TestNetworkLib
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> macList = NICInfoHelper.GetPrivateNICMAC();
            foreach (string m in macList)
            {
                Console.WriteLine(m);
            }

            Dictionary<string, string> dhcp = NICInfoHelper.GetPrivateNICDHCPAndMACDictonary();
            string bString = "";
            foreach (string ma in macList)
            {
                if (dhcp.TryGetValue(ma, out bString))
                {
                    Console.WriteLine(ma + " -> " + dhcp[ma]);
                }
            }

            Console.WriteLine();

            Dictionary<string, List<string>> dns = NICInfoHelper.GetPrivateNICDNSAndMACDictonary();
            ACDictionary<string, List<string>> dnsacd = (ACDictionary<string, List<string>>)ACDictionary<string, List<string>>.SystemCollection2ACCollection(dns);

            foreach (string ma in macList)
            {
                if (dnsacd.Exists(ma))
                {
                    foreach (string da in dnsacd[ma])
                    {
                        Console.WriteLine(ma + " -> " + da);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
