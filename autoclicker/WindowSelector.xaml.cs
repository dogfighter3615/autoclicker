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
using System.Windows.Shapes;

namespace autoclicker
{
    /// <summary>
    /// Interaction logic for WindowSelector.xaml
    /// </summary>
    public partial class WindowSelector : Window
    {
        public WindowSelector()
        {
            InitializeComponent();
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.stopping = true;
            Close();
        }
    }
}
