using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace autoclicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("hi");
            List<String> windowlist = new List<String>();
            windowselector.ItemsSource = windowlist;
                foreach (String Window in Windows.Titles())
            {
                 windowlist.Add(Window);
             }
            //logbox.SetBinding(Logger.LogMessages);
        }


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (randombox.IsChecked == true)
            {
                randomizerpanel.Visibility = Visibility.Visible;
                settime.Visibility = Visibility.Collapsed;
            }
            else if (randombox.IsChecked == false)
            {
                timemin.Text = "";
                timemax.Text = "";
                randomizerpanel.Visibility = Visibility.Collapsed;
                settime.Visibility = Visibility.Visible;
            }
        }

        private void startbutton(object sender, RoutedEventArgs e)
        { 
            logbox.Items.Add("starting...");
            if (timemin.Text != "" & timemax.Text != "")
            {
                if (randombox.IsChecked == true) { 
                    logbox.Items.Add(timemin.Text + timemax.Text); 
                }
            }
        }
        
        

        private void stopbutton(object sender, RoutedEventArgs e)
        {
            logbox.Items.Add("stopping...");

            foreach (int Window in Windows.procids()) {
                logbox.Items.Add(Window);
            }
            
        }
    }
}
