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
        /// <summary>
        /// List containing all of our active ProgramWindow objects that we have created
        /// </summary>
        public List<ProgramWindow> WindowList = new List<ProgramWindow>();

        private bool _isTansparent = false;
        private bool _selectWindowActivated = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new ProgramWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewWindow_Click(object sender, EventArgs e)
        {
            ProgramWindow newWindow = new ProgramWindow();
            WindowList.Add(newWindow);

            newWindow.FormClosed += new FormClosedEventHandler(ProgramWindow_Closed);

            // Create another click event for the Select Window button for our new ProgramWindow
            System.Windows.Forms.Control selectWindowButton = newWindow.Controls.Find("btnSelectWindow", false).FirstOrDefault();
            if (selectWindowButton != null)
            {
                selectWindowButton.Click += SelectWindowActivated;
            }

            newWindow.TopMost = true;
            newWindow.Show();
        }

        /// <summary>
        /// When a ProgramWindow is closed we must remove it from our list of Windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramWindow_Closed(object sender, FormClosedEventArgs e)
        {
            WindowList.Remove((ProgramWindow)sender);
        }

        /// <summary>
        /// Closes the MainWindow (and entire application)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Minimize the main window and set all of our ProgramWindows to hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState.Minimized;

            // Minimize all of our windows as well
            foreach (ProgramWindow ourWindow in WindowList)
            {
                ourWindow.Hide();
            }
        }

        /// <summary>
        /// Makes the main window transparent and can be clicked through
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransparent_Click(object sender, EventArgs e)
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

        /// <summary>
        /// The 'Select Window' button on an open ProgramWindow has been selected. 
        /// Make the main window transparent and prepare for mouse hover shit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectWindowActivated(object sender, EventArgs e)
        {
            _selectWindowActivated = true;
            btnTransparent_Click(sender, e);
        }

        /// <summary>
        /// Gets triggered when the main window is maximized. If our windows are hidden, sets the to visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState.Equals(WindowState.Maximized))
            {
                foreach (ProgramWindow ourWindow in WindowList)
                {
                    if (ourWindow.Visible == false && !_selectWindowActivated)
                    {
                        ourWindow.Show();
                    }
                }
            }
            else if (WindowState.Equals(WindowState.Minimized))
            {
                // Do Stuff Here
            }
        }
    }
}
