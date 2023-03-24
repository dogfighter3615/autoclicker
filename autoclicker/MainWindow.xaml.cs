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
                if (randombox.IsChecked == true)
                {
                    logbox.Items.Add(timemin.Text +","+ timemax.Text);
                }
            }
            if (windowselector.SelectedItem != null)
            {
                if (stopping == true)
                {
                    if (xcoords.Text == "" || ycoords.Text == "")
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
                                Loop.Clickyloop(stopping, process.Id, false, true, time: 7);
                            }
                            catch (FormatException)
                            {
                                logbox.Items.Add("time must be a float (eg: 1.2)");
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            int x = Int32.Parse(xcoords.Text);
                            int y = Int32.Parse(ycoords.Text);
                        }
                        catch (FormatException)
                        {
                            logbox.Items.Add("coordinates must be integers");
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
    }
}
