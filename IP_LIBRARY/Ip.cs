using System;
using System.Net;

namespace IP_LIBRARY
{
    public class Ip
    {
        readonly Random rnd = new Random();
        public string IpAdress { get; set; }
        public string NetworkID { get; set; }
        public string Netmask { get; set; }
        public string Broadcast { get; set; }
        public string FirstUsable { get; set; }
        public string LastUsable { get; set; }
        public string Usable { get; set; }
        public string Cidr { get; set; }


        // Constructor     
        public Ip()
        {
            string ipAdress = rnd.Next(0, 256) + "." + rnd.Next(0, 256) + "." + rnd.Next(0, 256) + "." + rnd.Next(0, 256) + "/" + rnd.Next(1, 31);
                        

            IPNetwork ipnetwork = IPNetwork.Parse(ipAdress);
            IpAdress = ipAdress.Substring(0,ipAdress.IndexOf('/'));
            NetworkID = Convert.ToString(ipnetwork.Network);
            Netmask = Convert.ToString(ipnetwork.Netmask);
            Broadcast = Convert.ToString(ipnetwork.Broadcast);
            FirstUsable = Convert.ToString(ipnetwork.FirstUsable);
            LastUsable = Convert.ToString(ipnetwork.LastUsable);
            Usable = Convert.ToString(ipnetwork.Usable);
            Cidr = Convert.ToString(ipnetwork.Cidr);
        }
        public Ip(string ipAdress)
        {
            IPNetwork ipnetwork = IPNetwork.Parse(ipAdress);
            IpAdress = ipAdress.Substring(0, ipAdress.IndexOf('/'));
            NetworkID = Convert.ToString(ipnetwork.Network);
            Netmask = Convert.ToString(ipnetwork.Netmask);
            Broadcast = Convert.ToString(ipnetwork.Broadcast);
            FirstUsable = Convert.ToString(ipnetwork.FirstUsable);
            LastUsable = Convert.ToString(ipnetwork.LastUsable);
            Usable = Convert.ToString(ipnetwork.Usable);
            Cidr = Convert.ToString(ipnetwork.Cidr);
        }

    }
}
