using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SleepMyCompy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int hours = 0;
        int mins = 0;
        int total = 0;
        bool isSet = false;

        public MainWindow()
        {
            InitializeComponent();
            tbMins.Text = mins.ToString();
            tbHours.Text = hours.ToString();
        }

        private void btnSetSleep_Click(object sender, RoutedEventArgs e)
        {
            if (!isSet)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = "cmd.exe";
                total = 3600 * hours + 60 * mins;
                startInfo.Arguments = "/C shutdown -s -t " + total;
                process.StartInfo = startInfo;
                process.Start();
                isSet = true;
            }
            else
            { btnAbortSleep_Click(this, new RoutedEventArgs()); btnSetSleep_Click(this, new RoutedEventArgs()); }
            
        }

        private void tbHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (!int.TryParse(tbHours.Text,out hours))
            {
                tbHours.Text = "0";
            }
            else
            {
                if (hours>23)
                {
                    hours = 23;
                    tbHours.Text = hours.ToString();
                } else if (hours < 0)
                {
                    hours = 0;
                    tbHours.Text = hours.ToString();
                }
            }
            if (!int.TryParse(tbMins.Text, out mins))
            {
                tbMins.Text = "0";
            }
            else
            {
                if (mins > 59)
                {
                    mins = 59;
                    tbMins.Text = mins.ToString();
                }
                else if (hours < 0)
                {
                    mins = 0;
                    tbMins.Text = mins.ToString();
                }
            }
        }

        private void btnAbortSleep_Click(object sender, RoutedEventArgs e)
        {
            if (isSet)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = "cmd.exe";
                
                startInfo.Arguments = "/C shutdown -a";
                process.StartInfo = startInfo;
                process.Start();
            }
            isSet = false;
        }
    }
}
