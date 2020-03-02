using IP_LIBRARY;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SubnettingTrainerWpf.Sites
{
    /// <summary>
    /// Interaction logic for TrainerIpv4.xaml
    /// </summary>
    public partial class TrainerIpv4 : Page
    {
        IpManager ipManager = new IpManager();
        string[] dataSet;
        public TrainerIpv4()
        {
            InitializeComponent();
            Loaded += TrainerIpv4_Loaded;
        }

        private void TrainerIpv4_Loaded(object sender, RoutedEventArgs e)
        {
            dataSet = ipManager.GetRandomData();
            tb_ip_entry.Text = dataSet[0] + "/" + dataSet[7];
            lbl_calculate.Content = "Berechne: " + dataSet[0] + "/" + dataSet[7];
        }

        private void btn_custom_Click(object sender, RoutedEventArgs e)
        {
            dataSet = ipManager.GetDataByIp(tb_ip_entry.Text);
            lbl_calculate.Content = "Berechne: " + dataSet[0] + "/" + dataSet[7];
            ClearSolution();
            ResetUserInput();
        }

        private void btn_random_Click(object sender, RoutedEventArgs e)
        {
            dataSet = ipManager.GetRandomData();
            tb_ip_entry.Text = dataSet[0] + "/" + dataSet[7];
            lbl_calculate.Content = "Berechne: " + dataSet[0] + "/" + dataSet[7];
            ClearSolution();
            ResetUserInput();
        }

       

        private void btn_solution_Click(object sender, RoutedEventArgs e)
        {
            // Lösung zeigen
            CompareUserInput();
            ShowSolution();
        }
        void CompareUserInput()
        {
            lbl_networkid.Foreground = (tb_networkid.Text == dataSet[2]) ? Brushes.Green : Brushes.Red;
            lbl_firsthost.Foreground = (tb_firsthost.Text == dataSet[3]) ? Brushes.Green : Brushes.Red;
            lbl_lasthost.Foreground = (tb_lasthost.Text == dataSet[4]) ? Brushes.Green : Brushes.Red;
            lbl_hosttotal.Foreground = (tb_hosttotal.Text == dataSet[6]) ? Brushes.Green : Brushes.Red;
            lbl_broadcast.Foreground = (tb_broadcast.Text == dataSet[5]) ? Brushes.Green : Brushes.Red;
            lbl_subnetmask.Foreground = (tb_subnetmask.Text == dataSet[1]) ? Brushes.Green : Brushes.Red;
        }
        void ResetUserInput()
        {
            lbl_networkid.Foreground = Brushes.White;
            lbl_firsthost.Foreground = Brushes.White;
            lbl_lasthost.Foreground = Brushes.White;
            lbl_hosttotal.Foreground = Brushes.White;
            lbl_broadcast.Foreground = Brushes.White;
            lbl_subnetmask.Foreground = Brushes.White;
            tb_networkid.Text = "0.0.0.0";
            tb_firsthost.Text = "0.0.0.0";
            tb_lasthost.Text = "0.0.0.0";
            tb_hosttotal.Text = "254";
            tb_broadcast.Text = "0.0.0.0";
            tb_subnetmask.Text = "255.255.255.255";
        }


        void ShowSolution()
        {
            tb_solution_networkid.Text = dataSet[2];
            tb_solution_firsthost.Text = dataSet[3];
            tb_solution_lasthost.Text = dataSet[4];
            tb_solution_hosttotal.Text = dataSet[6];
            tb_solution_broadcast.Text = dataSet[5];
            tb_solution_subnetmask.Text = dataSet[1];
        }
        void ClearSolution()
        {
            tb_solution_networkid.Text = "0.0.0.0";
            tb_solution_firsthost.Text = "0.0.0.0";
            tb_solution_lasthost.Text = "0.0.0.0";
            tb_solution_hosttotal.Text = "254";
            tb_solution_broadcast.Text = "0.0.0.0";
            tb_solution_subnetmask.Text = "255.255.255.255";
        }
    }
}
