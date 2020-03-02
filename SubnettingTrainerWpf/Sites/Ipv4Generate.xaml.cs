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
        List<Subnet> subnetList = new List<Subnet>();
        int counter;
        int result = 0;
        public Ipv4Generate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (rb_anal.IsChecked == true)
            {
                Anal();
            }
            else if (rb_split.IsChecked == true)
            {
                Split();
            }

        }

        private void Split()
        {
            if (int.TryParse(tb_ammount.Text, out result))
            {
                subnetList = ipManager.GetSubnetList(result);
            }
            else
            {
                subnetList = ipManager.GetSubnetList(20);
            }
            FillQuestions(subnetList);
            FillSolutions(subnetList);

        }

        private void Anal()
        {

            if (int.TryParse(tb_ammount.Text, out result))
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


        private void FillQuestions(List<Subnet> subnetList)
        {
            counter = 1;
            tb_solve.Clear();
            foreach (var subnet in subnetList)
            {
                tb_solve.AppendText("(" + counter + ") BERECHNE FÜR IP:" + subnet.IpAdress + "/" + subnet.CidrOld + "\n");
                tb_solve.AppendText("CIDR NEU: /" + subnet.CidrNew + "\n");
                tb_solve.AppendText("1. Subnetz:\n");
                tb_solve.AppendText("letztes Subnetz:\n");
                tb_solve.AppendText("Subnetze total:\n\n");
                counter++;
            }
        }

        private void FillSolutions(List<Subnet> subnetList)
        {
            counter = 1;
            tb_solution.Clear();
            foreach (var subnet in subnetList)
            {
                tb_solution.AppendText("(" + counter + ") LÖSUNG FÜR IP:" + subnet.IpAdress + "/" + subnet.CidrOld + "\n");
                tb_solution.AppendText("CIDR NEU: /" + subnet.CidrNew + "\n");
                tb_solution.AppendText("1. Subnetz :" + subnet.subnetArr[0] + "\n");
                tb_solution.AppendText("letztes Subnetz :" + subnet.subnetArr[subnet.subnetArr.Length - 1] + "\n");
                tb_solution.AppendText("Subnetze total :" + subnet.subnetCount + "\n\n");
                counter++;
            }
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
