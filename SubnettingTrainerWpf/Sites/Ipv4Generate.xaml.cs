using IP_LIBRARY;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SubnettingTrainerWpf.Sites
{
    /// <summary>
    /// Interaction logic for Ipv4Generate.xaml
    /// </summary>
    public partial class Ipv4Generate : Page
    {
        IpManager ipManager = new IpManager();
        List<Ip> ipList = new List<Ip>();
        int counter;
        public Ipv4Generate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int result = 0;
            if (int.TryParse(tb_ammount.Text,out result))
            {
                ipList = ipManager.GetList(result);
            }
            else
            {
                ipList = ipManager.GetList(20);
            }


            // Aufgaben generieren (liste)

            // Aufgaben als Aufgabe in textbox
            FillQuestions(ipList);
            FillSolutions(ipList);


            // Aufgaben als Lösung in textbox
        }

        private void FillQuestions(List<Ip> ipList)
        {
            counter = 1;
            tb_solve.Clear();
            foreach (var ip in ipList)
            {
                tb_solve.AppendText("(" + counter + ") BERECHNE FÜR IP: " + ip.IpAdress + "/" + ip.Cidr + "\n");
                tb_solve.AppendText("Netzwerk ID: \n");
                tb_solve.AppendText("Erste Hostadresse: \n");
                tb_solve.AppendText("Letzte Hostadresse: \n");
                tb_solve.AppendText("Hostadressen gesamt: \n");
                tb_solve.AppendText("Broadcastadresse: \n");
                tb_solve.AppendText("Subnetzmaske: \n\n");
                counter++;
            }
        }

        private void FillSolutions(List<Ip> ipList)
        {
            counter = 1;
            tb_solution.Clear();
            foreach (var ip in ipList)
            {
                tb_solution.AppendText("(" + counter + ") LÖSUNG FÜR IP: " + ip.IpAdress + "/" + ip.Cidr + "\n");
                tb_solution.AppendText("Netzwerk ID: " + ip.NetworkID + "\n");
                tb_solution.AppendText("Erste Hostadresse: " + ip.FirstUsable + "\n");
                tb_solution.AppendText("Letzte Hostadresse: " + ip.LastUsable + "\n");
                tb_solution.AppendText("Hostadressen gesamt: " + ip.Usable + "\n");
                tb_solution.AppendText("Broadcastadresse: " + ip.Broadcast + "\n");
                tb_solution.AppendText("Subnetzmaske: " + ip.Netmask + "\n\n");
                counter++;
            }
        }
    }
}
