using SteamKit2.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTLauncher.src.controls.titleBar
{
    /// <summary>
    /// Interaction logic for TitleBarControl.xaml
    /// </summary>
    public partial class TitleBarControl : UserControl
    {
        private ImageSource loginServerImage { get; set; } = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + ";component/" + "images/connected_true.png", UriKind.Absolute));
        public ImageSource LoginServerImage { get { return loginServerImage; } set { loginServerImage = value; } }
        public TitleBarControl()
        {
            InitializeComponent();
            DataContext = this;

            UpdateLoginServerStatus();
        }

        private void UpdateLoginServerStatus()
        {
            bool loginServerUp = PingHost("ProjectTorque.Racing");
            string loginImage = loginServerUp ? "images/connected_true.png" : "images/connected_false.png";
            LoginServerImage = new BitmapImage(new Uri(@"pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + ";component/" + loginImage, UriKind.Absolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            { }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}
