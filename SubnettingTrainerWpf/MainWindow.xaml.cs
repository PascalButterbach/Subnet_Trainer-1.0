using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SubnettingTrainerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sites.TrainerIpv4 siteIPV4 = new Sites.TrainerIpv4();
        Sites.Home siteHome = new Sites.Home();
        Sites.Ipv4Generate siteIpv4Generate = new Sites.Ipv4Generate();
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = siteHome;


        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = siteHome;
        }

        private void btn_ipv4_trainer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = siteIPV4;
        }

        private void btn_ipv4_generate_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = siteIpv4Generate;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
