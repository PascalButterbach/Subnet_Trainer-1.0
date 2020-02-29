using IP_LIBRARY;
using System.Windows;

namespace SubnettingTrainerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            IpManager ipManager = new IpManager();

            // generiere random IP
            ipManager.RandomIp();
             string[] blaTest = ipManager.ReturnQuestion();
        }
    }
}
