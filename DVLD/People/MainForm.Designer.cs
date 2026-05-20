namespace DVLD
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForLostOrDameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInternationalLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesServicesToolStripMenuItem,
            this.allToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem,
            this.detainLicensesToolStripMenuItem,
            this.showInternationalLicensesToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 36);
            this.toolStripMenuItem1.Text = "Application Types";
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            this.drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicensesToolStripMenuItem,
            this.renewDrivingLicensesToolStripMenuItem,
            this.replacementForLostOrDameToolStripMenuItem,
            this.releasToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicensesServicesToolStripMenuItem.Image = global::DVLD.Properties.Resources.LicenseView_400;
            this.drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            this.drivingLicensesServicesToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            this.drivingLicensesServicesToolStripMenuItem.Click += new System.EventHandler(this.drivingLicensesServicesToolStripMenuItem_Click);
            // 
            // newDrivingLicensesToolStripMenuItem
            // 
            this.newDrivingLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicensesToolStripMenuItem,
            this.internationalLicensesToolStripMenuItem});
            this.newDrivingLicensesToolStripMenuItem.Name = "newDrivingLicensesToolStripMenuItem";
            this.newDrivingLicensesToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.newDrivingLicensesToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicensesToolStripMenuItem
            // 
            this.localLicensesToolStripMenuItem.Name = "localLicensesToolStripMenuItem";
            this.localLicensesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.localLicensesToolStripMenuItem.Text = "Local License";
            this.localLicensesToolStripMenuItem.Click += new System.EventHandler(this.localLicensesToolStripMenuItem_Click);
            // 
            // internationalLicensesToolStripMenuItem
            // 
            this.internationalLicensesToolStripMenuItem.Name = "internationalLicensesToolStripMenuItem";
            this.internationalLicensesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.internationalLicensesToolStripMenuItem.Text = "International Licenses";
            this.internationalLicensesToolStripMenuItem.Click += new System.EventHandler(this.internationalLicensesToolStripMenuItem_Click);
            // 
            // renewDrivingLicensesToolStripMenuItem
            // 
            this.renewDrivingLicensesToolStripMenuItem.Name = "renewDrivingLicensesToolStripMenuItem";
            this.renewDrivingLicensesToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.renewDrivingLicensesToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicensesToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicensesToolStripMenuItem_Click);
            // 
            // replacementForLostOrDameToolStripMenuItem
            // 
            this.replacementForLostOrDameToolStripMenuItem.Name = "replacementForLostOrDameToolStripMenuItem";
            this.replacementForLostOrDameToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.replacementForLostOrDameToolStripMenuItem.Text = "Replacement For Lost Or Damaged  License";
            this.replacementForLostOrDameToolStripMenuItem.Click += new System.EventHandler(this.replacementForLostOrDameToolStripMenuItem_Click);
            // 
            // releasToolStripMenuItem
            // 
            this.releasToolStripMenuItem.Name = "releasToolStripMenuItem";
            this.releasToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.releasToolStripMenuItem.Text = "Release Detained Driving License";
            this.releasToolStripMenuItem.Click += new System.EventHandler(this.releasToolStripMenuItem_Click);
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationToolStripMenuItem});
            this.allToolStripMenuItem.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.allToolStripMenuItem.Text = "Manage Applications";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // localDrivingLicenseApplicationToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.LicenseView_4002;
            this.localDrivingLicenseApplicationToolStripMenuItem.Name = "localDrivingLicenseApplicationToolStripMenuItem";
            this.localDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
            this.localDrivingLicenseApplicationToolStripMenuItem.Text = "Local Driving License Application";
            this.localDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_Type_64;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.detainLicensesToolStripMenuItem1,
            this.releaseDetainedLicensesToolStripMenuItem});
            this.detainLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_64;
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            this.detainLicensesToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            this.detainLicensesToolStripMenuItem.Click += new System.EventHandler(this.detainLicensesToolStripMenuItem_Click);
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem1
            // 
            this.detainLicensesToolStripMenuItem1.Image = global::DVLD.Properties.Resources.Detain_32;
            this.detainLicensesToolStripMenuItem1.Name = "detainLicensesToolStripMenuItem1";
            this.detainLicensesToolStripMenuItem1.Size = new System.Drawing.Size(230, 38);
            this.detainLicensesToolStripMenuItem1.Text = "Detain Licenses";
            this.detainLicensesToolStripMenuItem1.Click += new System.EventHandler(this.detainLicensesToolStripMenuItem1_Click);
            // 
            // releaseDetainedLicensesToolStripMenuItem
            // 
            this.releaseDetainedLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainedLicensesToolStripMenuItem.Name = "releaseDetainedLicensesToolStripMenuItem";
            this.releaseDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.releaseDetainedLicensesToolStripMenuItem.Text = "Release Detained Licenses";
            this.releaseDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicensesToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::DVLD.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(87, 36);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_Main;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(87, 36);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::DVLD.Properties.Resources.users_64;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(79, 36);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.sToolStripMenuItem});
            this.accountSettingToolStripMenuItem.Image = global::DVLD.Properties.Resources.account_settings_64;
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(136, 36);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            this.accountSettingToolStripMenuItem.Click += new System.EventHandler(this.accountSettingToolStripMenuItem_Click);
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.Question_32;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.currentUserInfoToolStripMenuItem.Text = "Current user info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::DVLD.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Image = global::DVLD.Properties.Resources.SignOut_64;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sToolStripMenuItem.Text = "Sign Out";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // showInternationalLicensesToolStripMenuItem
            // 
            this.showInternationalLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.showInternationalLicensesToolStripMenuItem.Name = "showInternationalLicensesToolStripMenuItem";
            this.showInternationalLicensesToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.showInternationalLicensesToolStripMenuItem.Text = "Show International Licenses";
            this.showInternationalLicensesToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicensesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::DVLD.Properties.Resources.wp2769175_full_hd_wide_ferrari_wallpapers;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLostOrDameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicensesToolStripMenuItem;
    }
}

