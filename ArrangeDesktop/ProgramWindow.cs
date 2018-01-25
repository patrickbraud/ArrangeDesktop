using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace ArrangeDesktop
{
    public partial class ProgramWindow : Form
    {
        private List<Process> _processWindowList = new List<Process>();
        private List<string> _dropDownSource = new List<string>();
        private bool _isTransparent = false;

        public ProgramWindow()
        {
            InitializeComponent();
        }

        private void ProgramWindow_Load(object sender, EventArgs e)
        {
            // Set up the form
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.Gray;
            Size = new System.Drawing.Size(300, 350);

            Text = "";
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.LimeGreen;

            //Format controls. Note: Controls inherit color from parent form.
            CreateProcessDropdown();

            txtPosX.Text = Location.X.ToString();
            txtPosY.Text = Location.Y.ToString();
            txtWidth.Text = Width.ToString();
            txtHeight.Text = Height.ToString();
            
        }

        /// <summary>
        /// Updates the text boxes with the correct window position
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void ProgramWindow_Move(object sender, EventArgs e)
        {
            txtPosX.Text = Location.X.ToString();
            txtPosY.Text = Location.Y.ToString();
        }

        /// <summary>
        /// Updates the text boxes with the correct window size
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void ProgramWindow_Resize(object sender, EventArgs e)
        {
            txtWidth.Text = Width.ToString();
            txtHeight.Text = Height.ToString();
        }

        /// <summary>
        /// Creates the dropdown box that holds list of running programs
        /// </summary>
        private void CreateProcessDropdown()
        {
            cbProcessDropDown.Text = "Select Process";
            // Populate the dropdown
            cbProcessDropDown.DataSource = LoadRunningProcesses();

            cbProcessDropDown.Width = 200;

            //Add control to the form.
            Controls.Add(cbProcessDropDown);
        }

        /// <summary>
        /// Moves the selected process window to match the size and shape of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyButton_Click(object sender, EventArgs e)
        {
            Text = cbProcessDropDown.SelectedItem.ToString();

            Process procToChange = new Process();
            foreach (Process proc in _processWindowList)
            {
                if (proc.MainWindowTitle.Equals(cbProcessDropDown.SelectedItem.ToString()))
                {
                    procToChange = proc;
                    break;
                }
            }

            ImportFunctions.MoveWindow(procToChange.MainWindowHandle, 
                                        Convert.ToInt32(txtPosX.Text), 
                                        Convert.ToInt32(txtPosY.Text), 
                                        Convert.ToInt32(txtWidth.Text),
                                        Convert.ToInt32(txtHeight.Text), 
                                        false);
        }

        /// <summary>
        /// Refreshes the dropdown datasource for the list of running process windows
        /// </summary>
        private List<string> LoadRunningProcesses()
        {
            List<Process> processList = Process.GetProcesses().ToList();            
            // Add the window names to the dropdown 

            //cbProcessDropDown.DataSource = _dropDownSource;

            // TEST SHIT
            List<IntPtr> windowPtrList = new List<IntPtr>();
            List<string> windowTitleList = new List<string>();
            OpenWindows.GetDesktopWindowHandlesAndTitles(out windowPtrList, out windowTitleList);

            // Associate windows with running processes
            foreach (Process proc in processList)
            {
                // We only want ones that are running window applications
                foreach(string title in windowTitleList)
                {
                    if (proc.MainWindowTitle.Equals(title))
                    {
                        _processWindowList.Add(proc);
                        break;
                    }
                }
            }

            return windowTitleList;
        }

        /// <summary>
        /// Toggles form background transparency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransparent_Click(object sender, EventArgs e)
        {
            if (_isTransparent)
            {
                btnTransparent.Text = "Transparent";
                BackColor = Color.Gray;
                HideAllTextBoxes(false);
                _isTransparent = false;
            }
            else
            {
                btnTransparent.Text = "Solid";
                BackColor = Color.LimeGreen;
                HideAllTextBoxes(true);
                _isTransparent = true;
            }
        }

        /// <summary>
        /// Moves the form to match the size and location of the selected process window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSnap_Click(object sender, EventArgs e)
        {
            Text = cbProcessDropDown.SelectedItem.ToString();

            // Check each process to see if it matches the selected dropdown item
            Process procToChange = new Process();
            foreach (Process proc in _processWindowList)
            {
                if (proc.MainWindowTitle.Equals(cbProcessDropDown.SelectedItem.ToString()))
                {
                    procToChange = proc;
                }
            }

            ImportFunctions.RECT newWindowRect = new ImportFunctions.RECT();
            ImportFunctions.GetWindowRect(procToChange.MainWindowHandle, ref newWindowRect);

            Location = new System.Drawing.Point(newWindowRect.Left, newWindowRect.Top);
            Size = new System.Drawing.Size(newWindowRect.Right - newWindowRect.Left, newWindowRect.Bottom - newWindowRect.Top);
            
        }

        /// <summary>
        /// Hide the program window if the go into Window Selection (main window minimizes/hides);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectWindow_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// Refresh the datasource when it closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbProcessDropbdown_close(object sender, EventArgs e)
        {
            cbProcessDropDown.DataSource = LoadRunningProcesses();
        }

        /// <summary>
        /// Hides or show the text boxes and associated labels
        /// </summary>
        /// <param name="hide">whether or not to hide the text boxes</param>
        private void HideAllTextBoxes(bool hide)
        {
            if (hide)
            {
                txtPosX.Hide();
                txtPosY.Hide();
                lblPosX.Hide();
                lblPosY.Hide();

                txtHeight.Hide();
                txtWidth.Hide();
                lblHeight.Hide();
                lblWidth.Hide();
            }
            else
            {
                txtPosX.Show();
                txtPosY.Show();
                lblPosX.Show();
                lblPosY.Show();

                txtHeight.Show();
                txtWidth.Show();
                lblHeight.Show();
                lblWidth.Show();
            }
        }
    }
}
