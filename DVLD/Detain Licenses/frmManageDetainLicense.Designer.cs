namespace DVLD.Detain_Licenses
{
    partial class frmManageDetainLicense
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblRecordCounts = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbFilterby = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.showPersonInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(318, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Detained Licenses";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(14, 156);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(905, 300);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonInformationToolStripMenuItem,
            this.showLicenseInformationToolStripMenuItem,
            this.showLicensesHistoryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // lblRecordCounts
            // 
            this.lblRecordCounts.AutoSize = true;
            this.lblRecordCounts.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCounts.ForeColor = System.Drawing.Color.Red;
            this.lblRecordCounts.Location = new System.Drawing.Point(13, 469);
            this.lblRecordCounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordCounts.Name = "lblRecordCounts";
            this.lblRecordCounts.Size = new System.Drawing.Size(67, 28);
            this.lblRecordCounts.TabIndex = 3;
            this.lblRecordCounts.Text = "label2";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(832, 464);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbFilterby
            // 
            this.cbFilterby.FormattingEnabled = true;
            this.cbFilterby.Items.AddRange(new object[] {
            "LicenseID",
            "FineFees",
            "NationalNo",
            "FullName"});
            this.cbFilterby.Location = new System.Drawing.Point(96, 121);
            this.cbFilterby.Name = "cbFilterby";
            this.cbFilterby.Size = new System.Drawing.Size(121, 27);
            this.cbFilterby.TabIndex = 5;
            this.cbFilterby.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(223, 121);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(114, 27);
            this.txtFilterValue.TabIndex = 6;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filter By :";
            // 
            // button3
            // 
            this.button3.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.button3.Location = new System.Drawing.Point(863, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 50);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::DVLD.Properties.Resources.Detain_32;
            this.button2.Location = new System.Drawing.Point(799, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 50);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // showPersonInformationToolStripMenuItem
            // 
            this.showPersonInformationToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showPersonInformationToolStripMenuItem.Name = "showPersonInformationToolStripMenuItem";
            this.showPersonInformationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.showPersonInformationToolStripMenuItem.Text = "Show Person Information";
            this.showPersonInformationToolStripMenuItem.Click += new System.EventHandler(this.showPersonInformationToolStripMenuItem_Click);
            // 
            // showLicenseInformationToolStripMenuItem
            // 
            this.showLicenseInformationToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseInformationToolStripMenuItem.Name = "showLicenseInformationToolStripMenuItem";
            this.showLicenseInformationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.showLicenseInformationToolStripMenuItem.Text = "Show License Information";
            this.showLicenseInformationToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInformationToolStripMenuItem_Click);
            // 
            // showLicensesHistoryToolStripMenuItem
            // 
            this.showLicensesHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showLicensesHistoryToolStripMenuItem.Name = "showLicensesHistoryToolStripMenuItem";
            this.showLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.showLicensesHistoryToolStripMenuItem.Text = "Show Licenses History";
            this.showLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicensesHistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_64;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // frmManageDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 514);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterby);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRecordCounts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmManageDetainLicense";
            this.Text = "frmManageDetainLicense";
            this.Load += new System.EventHandler(this.frmManageDetainLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblRecordCounts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem showPersonInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFilterby;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}