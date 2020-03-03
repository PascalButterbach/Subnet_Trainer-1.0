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
            btn_solution.IsEnabled = true;
            btn_random.IsEnabled = false;
            btn_custom.IsEnabled = false;
        }

        private void btn_random_Click(object sender, RoutedEventArgs e)
        {
            dataSet = ipManager.GetRandomData();
            tb_ip_entry.Text = dataSet[0] + "/" + dataSet[7];
            lbl_calculate.Content = "Berechne: " + dataSet[0] + "/" + dataSet[7];
            ClearSolution();
            ResetUserInput();
            btn_solution.IsEnabled = true;
            btn_random.IsEnabled = false;
            btn_custom.IsEnabled = false;
            btn_solution.Foreground = Brushes.WhiteSmoke;
            btn_random.Foreground = Brushes.Gainsboro;
            btn_custom.Foreground = Brushes.Gainsboro;
        }



        private void btn_solution_Click(object sender, RoutedEventArgs e)
        {
            // Lösung zeigen
            CompareUserInput();
            ShowSolution();
            btn_solution.IsEnabled = false;
            btn_random.IsEnabled = true;
            btn_custom.IsEnabled = true;
            btn_solution.Foreground = Brushes.Gainsboro;
            btn_random.Foreground = Brushes.WhiteSmoke;
            btn_custom.Foreground = Brushes.WhiteSmoke;
        }
        void CompareUserInput()
        {
            tb_networkid.Foreground = (tb_networkid.Text == dataSet[2]) ? Brushes.Green : Brushes.Red;
            tb_firsthost.Foreground = (tb_firsthost.Text == dataSet[3]) ? Brushes.Green : Brushes.Red;
            tb_lasthost.Foreground = (tb_lasthost.Text == dataSet[4]) ? Brushes.Green : Brushes.Red;
            tb_hosttotal.Foreground = (tb_hosttotal.Text == dataSet[6]) ? Brushes.Green : Brushes.Red;
            tb_broadcast.Foreground = (tb_broadcast.Text == dataSet[5]) ? Brushes.Green : Brushes.Red;
            tb_subnetmask.Foreground = (tb_subnetmask.Text == dataSet[1]) ? Brushes.Green : Brushes.Red;
        }
        void ResetUserInput()
        {
            tb_networkid.Foreground = Brushes.LightGray;
            tb_firsthost.Foreground = Brushes.LightGray;
            tb_lasthost.Foreground = Brushes.LightGray;
            tb_hosttotal.Foreground = Brushes.LightGray;
            tb_broadcast.Foreground = Brushes.LightGray;
            tb_subnetmask.Foreground = Brushes.LightGray;
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
