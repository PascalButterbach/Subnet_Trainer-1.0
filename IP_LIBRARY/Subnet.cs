using System;
using System.Net;

namespace IP_LIBRARY
{
    public class Subnet
    {
        readonly Random rnd = new Random();
        public string IpAdress { get; set; }
        public int CidrOld { get; set; }
        public int CidrNew { get; set; }
        public int subnetCount { get; set; }
        public string[] subnetArr { get; set; }
        public Subnet()
        {
            string rndIP = rnd.Next(0, 256) + "." + rnd.Next(0, 256) + "." + rnd.Next(0, 256) + "." + rnd.Next(0, 256) + "/" + rnd.Next(4, 29);
            IPNetwork ipnetwork = IPNetwork.Parse(rndIP);


            IpAdress = rndIP.Substring(0, rndIP.IndexOf('/'));


            CidrOld = ipnetwork.Cidr;

            CidrNew = rnd.Next(ipnetwork.Cidr, 31);

            IPNetworkCollection subneted = ipnetwork.Subnet((byte)CidrNew);

            subnetCount = (int)subneted.Count;
            subnetArr = new string[subnetCount];
            for (int i = 0; i < subnetCount; i++)
            {
                subnetArr[i] = Convert.ToString(subneted[i]);
            }
        }


    }
}
