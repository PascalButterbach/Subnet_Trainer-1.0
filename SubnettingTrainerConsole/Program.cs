using System;
using IP_LIBRARY;

namespace SubnettingTrainerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            IpManager ipManager = new IpManager();

            // generiere random IP
            ipManager.RandomIp();
            foreach (var item in ipManager.ReturnQuestion())
            {
                Console.WriteLine(item);
            }
        }
    }
}
