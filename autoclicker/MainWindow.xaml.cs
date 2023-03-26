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
        public static bool stopping = true;
        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("hi");
            foreach (String Window in Windows.Titles())
            {
                windowselector.Items.Add(Window);
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
                if (randombox.IsChecked == true)
                {
                    logbox.Items.Add(timemin.Text +","+ timemax.Text);
                }
            }
            if (windowselector.SelectedItem != null)
            {
                if (stopping == true)
                {


                    stopping = false;
#pragma warning disable CS8604 // Possible null reference argument.
                    Process process = Windows.Processbyname(windowselector.SelectedItem.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
                    if (randombox.IsChecked == true && randombox.IsChecked.HasValue)
                    {
                        try
                        {
                            float mintime = float.Parse(timemin.Text);
                            float maxtime = float.Parse(timemax.Text);
                            Loop.Clickyloop(stopping, process.Id, false, timemin: mintime, timemax: maxtime);
                        }
                        catch (FormatException)
                        {
                            logbox.Items.Add("time must be a float (eg: 1.2)");
                        }
                    }
                    else
                    {
                        try
                        {
                            float time = float.Parse(timeset.Text);
                            Loop.Clickyloop(stopping, process.Id, false, time: time);
                        }
                        catch (FormatException)
                        {
                            logbox.Items.Add("time must be a float (eg: 1.2");
                        }
                    }
                }
                logbox.Items.Add(windowselector.SelectedItem.ToString());
            }
        }



        private void stopbutton(object sender, RoutedEventArgs e)
        {
            logbox.Items.Add("stopping...");
            Loop.cstop = true;
            stopping = true;

        }

        private void Refreshwindows(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("refreshing windows");
            logbox.Items.Add("refreshing window titles");
            List<String> windowlist = new List<String>();
           
            windowselector.Items.Clear();
            foreach (String Window in Windows.Titles())
            {
                windowselector.Items.Add(Window);
            }
        }
    }
}
