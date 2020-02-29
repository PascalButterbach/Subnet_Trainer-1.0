using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_LIBRARY
{
    public class IpManager
    {
        Random rnd = new Random();
        private List<Ip> ipDataset = new List<Ip>();
                
        public List<Ip> GetIpDataset()
        {
            return ipDataset;
        }
        
        public void SetIpDataset(List<Ip> value)
        {
            ipDataset = value;
        }

        public void RandomIp()
        {
            string ipString = "192.168."+rnd.Next(0, 256) + "." + rnd.Next(0, 256);

            GetIpDataset().Add(new Ip(ipString, rnd.Next(17,31)));
        }
        public string[] ReturnQuestion()
        {
            var ipReturn = new string[3];

            // IP Adresse
            ipReturn[0] = ipDataset.Last().ipAdress;
            ipReturn[1] = Convert.ToString(ipDataset.Last().cidr);
            ipReturn[2] = ipDataset.Last().getSubnetmask();
            // toDO 
            // ipReturn[3] = ipDataset.Last().getNetworkId();
            // ipReturn[4] = ipDataset.Last().getFirstHost();
            // ipReturn[5] = ipDataset.Last().getLastHost();
            // ipReturn[6] = ipDataset.Last().getBroadcast();
            return ipReturn;
        }
    }


}
