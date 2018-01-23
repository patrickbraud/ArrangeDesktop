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

        //Controls.

        //Other code
        private List<Process> _processList = new List<Process>();
        private List<string> _dropDownSource = new List<string>();
        private bool _isTransparent = false;

        public ProgramWindow()
        {
            InitializeComponent();
        }

        private void NewWindow_Load(object sender, EventArgs e)
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
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);

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
        private void NewWindow_Move(object sender, EventArgs e)
        {
            txtPosX.Text = Location.X.ToString();
            txtPosY.Text = Location.Y.ToString();
        }

        /// <summary>
        /// Updates the text boxes with the correct window size
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void NewWindow_Resize(object sender, EventArgs e)
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
            LoadRunningProcesses();

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
            foreach (Process proc in _processList)
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
        /// Refreshes the datasource for the list of running process windows
        /// </summary>
        private void LoadRunningProcesses()
        {
            Process[] processList = Process.GetProcesses();
            // Get the list of running proccesses
            foreach (Process proc in processList)
            {
                // We only want ones that are running window applications
                if (!string.IsNullOrEmpty(proc.MainWindowTitle) && !proc.MainWindowTitle.Contains("ArrangeDesktop"))
                {
                    _processList.Add(proc);
                }
            }

            
            // Add the window names to the dropdown source
            foreach (Process proc in _processList)
            {
                _dropDownSource.Add($"{proc.ProcessName} - {proc.MainWindowTitle}");
            }

            //cbProcessDropDown.DataSource = _dropDownSource;

            // TEST SHIT
            List<IntPtr> windowPtrList = new List<IntPtr>();
            List<string> windowTitleList = new List<string>();
            //updatedProcList = ImportFunctions.GetWindows().Where(windowName => !(windowName.Contains("ArrangeDesktop"))).ToList();
            OpenWindows.GetDesktopWindowHandlesAndTitles(out windowPtrList, out windowTitleList);

            // Associate windows with running processes
            foreach (Process proc in processList)
            {
                // We only want ones that are running window applications
                foreach(string title in windowTitleList)
                {
                    if (proc.MainWindowTitle.Equals(title))
                    {
                        _processList.Add(proc);
                        break;
                    }
                }
            }

            cbProcessDropDown.DataSource = windowTitleList;
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
            foreach (Process proc in _processList)
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
        /// Refresh the datasource when it closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbProcessDropbdown_close(object sender, EventArgs e)
        {
            LoadRunningProcesses();
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
