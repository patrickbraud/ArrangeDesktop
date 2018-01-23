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
using System.Windows.Forms;

namespace ArrangeDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ProgramWindow> _windowList = new List<ProgramWindow>();
        private int _numberOfWindows = 0;

        private bool _isTansparent = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewWindow_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow newWindow = new ProgramWindow();
            _windowList.Add(newWindow);

            newWindow.TopMost = true;
            newWindow.Show();

            _numberOfWindows++;
        }

        private void btnCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnTransparent_Click(object sender, RoutedEventArgs e)
        {            
            if (_isTansparent)
            {
                Background = new SolidColorBrush(Colors.Black);
                btnTransparent.Content = "Transparent";
                _isTansparent = false;
            }
            else
            {
                Background = new SolidColorBrush(Colors.Transparent);
                btnTransparent.Content = "Solid";
                _isTansparent = true;
            }
        }
    }
}
