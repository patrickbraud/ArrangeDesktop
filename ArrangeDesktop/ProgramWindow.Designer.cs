namespace ArrangeDesktop
{
    partial class ProgramWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbProcessDropDown = new System.Windows.Forms.ComboBox();
            this.btnApplyButton = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.lblPosX = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnTransparent = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.btnSelectWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbProcessDropDown
            // 
            this.cbProcessDropDown.FormattingEnabled = true;
            this.cbProcessDropDown.Location = new System.Drawing.Point(39, 12);
            this.cbProcessDropDown.Name = "cbProcessDropDown";
            this.cbProcessDropDown.Size = new System.Drawing.Size(200, 21);
            this.cbProcessDropDown.TabIndex = 0;
            this.cbProcessDropDown.DropDown += new System.EventHandler(this.cbProcessDropbdown_close);
            // 
            // btnApplyButton
            // 
            this.btnApplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnApplyButton.Location = new System.Drawing.Point(56, 151);
            this.btnApplyButton.Name = "btnApplyButton";
            this.btnApplyButton.Size = new System.Drawing.Size(80, 30);
            this.btnApplyButton.TabIndex = 1;
            this.btnApplyButton.Text = "Apply";
            this.btnApplyButton.UseVisualStyleBackColor = false;
            this.btnApplyButton.Click += new System.EventHandler(this.btnApplyButton_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(165, 66);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(36, 20);
            this.txtWidth.TabIndex = 2;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(165, 97);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(36, 20);
            this.txtHeight.TabIndex = 3;
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(80, 66);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(36, 20);
            this.txtPosX.TabIndex = 4;
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(80, 97);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(36, 20);
            this.txtPosY.TabIndex = 5;
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(39, 69);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(35, 13);
            this.lblPosX.TabIndex = 6;
            this.lblPosX.Text = "Pos X";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(39, 100);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(35, 13);
            this.lblPosY.TabIndex = 7;
            this.lblPosY.Text = "Pos Y";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(127, 69);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 8;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(124, 100);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 9;
            this.lblHeight.Text = "Height";
            // 
            // btnTransparent
            // 
            this.btnTransparent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnTransparent.Location = new System.Drawing.Point(100, 187);
            this.btnTransparent.Name = "btnTransparent";
            this.btnTransparent.Size = new System.Drawing.Size(80, 30);
            this.btnTransparent.TabIndex = 10;
            this.btnTransparent.Text = "Transparent";
            this.btnTransparent.UseVisualStyleBackColor = false;
            this.btnTransparent.Click += new System.EventHandler(this.btnTransparent_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSnap.Location = new System.Drawing.Point(142, 151);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(80, 30);
            this.btnSnap.TabIndex = 11;
            this.btnSnap.Text = "Snap";
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // btnSelectWindow
            // 
            this.btnSelectWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSelectWindow.Location = new System.Drawing.Point(80, 223);
            this.btnSelectWindow.Name = "btnSelectWindow";
            this.btnSelectWindow.Size = new System.Drawing.Size(120, 30);
            this.btnSelectWindow.TabIndex = 12;
            this.btnSelectWindow.Text = "Select Window";
            this.btnSelectWindow.UseVisualStyleBackColor = false;
            this.btnSelectWindow.Click += new System.EventHandler(this.btnSelectWindow_Click);
            // 
            // ProgramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSelectWindow);
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.btnTransparent);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblPosY);
            this.Controls.Add(this.lblPosX);
            this.Controls.Add(this.txtPosY);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.btnApplyButton);
            this.Controls.Add(this.cbProcessDropDown);
            this.Name = "ProgramWindow";
            this.Text = "NewWindow";
            this.Load += new System.EventHandler(this.ProgramWindow_Load);
            this.Move += new System.EventHandler(this.ProgramWindow_Move);
            this.Resize += new System.EventHandler(this.ProgramWindow_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProcessDropDown;
        private System.Windows.Forms.Button btnApplyButton;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnTransparent;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.Button btnSelectWindow;
    }
}