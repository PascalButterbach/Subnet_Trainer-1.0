using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_LIBRARY
{
    public class Ip
    {
        public string ipAdress { get; set; }

        public int cidr { get; set; }
        public Ip(string ipAdress, int cidr)
        {
            this.ipAdress = ipAdress;
            this.cidr = cidr;
        }


        public uint getBinary()
        {
            throw new System.NotImplementedException();
        }

        public void getOctets()
        {
            throw new System.NotImplementedException();
        }

        public string getSubnetmask()
        {
            string[] elements = new string[] { "0", "128", "192", "224", "240", "248", "252", "254", "255" };
            string subnetMask = "";

            for (int i = 0; i < cidr / 8; i++)
            {
                subnetMask += "255.";
            }
            subnetMask += elements[cidr % 8];

            return subnetMask;

        }
    }
}
