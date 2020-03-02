using System.Collections.Generic;
using System.Linq;

namespace IP_LIBRARY
{
    public class IpManager
    {

        readonly List<Ip> ipDataset = new List<Ip>();

        public string[] GetDataByIp(string ipAdress)
        {
            ipDataset.Add(new Ip(ipAdress));
            return ReturnDataset();
        }
        public string[] GetRandomData()
        {
            ipDataset.Add(new Ip());
            return ReturnDataset();
        }
        public string[] ReturnDataset()
        {            
            var ipReturn = new string[8];

            ipReturn[0] = ipDataset.Last().IpAdress;
            ipReturn[1] = ipDataset.Last().Netmask;
            ipReturn[2] = ipDataset.Last().NetworkID;
            ipReturn[3] = ipDataset.Last().FirstUsable;
            ipReturn[4] = ipDataset.Last().LastUsable;
            ipReturn[5] = ipDataset.Last().Broadcast;
            ipReturn[6] = ipDataset.Last().Usable;
            ipReturn[7] = ipDataset.Last().Cidr;
            return ipReturn;
        }

        public Subnet GetRandomSubnet()
        {
            return new Subnet();
        }

        public List<Ip> GetList(int v)
        {
            ipDataset.Clear();
            for (int i = 0; i < v; i++)
            {
                ipDataset.Add(new Ip());
            }

            return ipDataset;
        }
    }
}
