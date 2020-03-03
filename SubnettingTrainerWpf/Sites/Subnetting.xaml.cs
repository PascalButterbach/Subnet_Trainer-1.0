using IP_LIBRARY;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SubnettingTrainerWpf.Sites
{
    /// <summary>
    /// Interaction logic for Subnetting.xaml
    /// </summary>
    public partial class Subnetting : Page
    {
        IpManager ipManager = new IpManager();
        Subnet subnet; 
        public Subnetting()
        {
            InitializeComponent();
            Update();
            ClearInput();
            btn_random.IsEnabled = false;
        }

        private void btn_random_Click(object sender, RoutedEventArgs e)
        {

            ClearInput();
            Update();
            btn_random.IsEnabled = false;
            btn_solution.IsEnabled = true;
            btn_solution.Foreground = Brushes.WhiteSmoke;
            btn_random.Foreground = Brushes.White;
        }

        private void btn_solution_Click(object sender, RoutedEventArgs e)
        {
            CompareUserInput();
            btn_random.IsEnabled = true;
            btn_solution.IsEnabled = false;
            btn_solution.Foreground = Brushes.White;
            btn_random.Foreground = Brushes.WhiteSmoke;
        }
               

        private void CompareUserInput()
        {
            if(tb_first_subnet.Text == subnet.subnetArr[0])
            {
                tb_first_subnet.Foreground = Brushes.Green;
            }else
            {
                tb_first_subnet.Foreground = Brushes.Red;
                tb_first_subnet.Text = subnet.subnetArr[0];
            }

            if (tb_last_subnet.Text == subnet.subnetArr[subnet.subnetArr.Length - 1])
            {
                tb_last_subnet.Foreground = Brushes.Green;
            }
            else
            {
                tb_last_subnet.Foreground = Brushes.Red;
                tb_last_subnet.Text = subnet.subnetArr[subnet.subnetArr.Length - 1];
            }

            if (tb_subnet_total.Text == Convert.ToString(subnet.subnetCount))
            {
                tb_subnet_total.Foreground = Brushes.Green;
            }
            else
            {
                tb_subnet_total.Foreground = Brushes.Red;
                tb_subnet_total.Text = Convert.ToString(subnet.subnetCount);
            }

        }

        private void ClearInput()
        {
            tb_first_subnet.Foreground = Brushes.LightGray;
            tb_last_subnet.Foreground = Brushes.LightGray;
            tb_subnet_total.Foreground = Brushes.LightGray;
            tb_first_subnet.Text = "0.0.0.0/0";
            tb_last_subnet.Text = "0.0.0.0/0";
            tb_subnet_total.Text = "128";
        }
        private void Update()
        {
            subnet = ipManager.GetRandomSubnet();            
       

            lbl_calculate.Content = $"Das Netzwerk: {subnet.IpAdress}/{subnet.CidrOld} ist gegeben. CIDR neu : {subnet.CidrNew}";


        }
    }
}
