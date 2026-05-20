namespace DVLD.Drivers
{
    partial class ctrlDriver
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tb1 = new System.Windows.Forms.TabControl();
            this.tbLocal = new System.Windows.Forms.TabPage();
            this.lblLocalRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.ctmLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInternational = new System.Windows.Forms.TabPage();
            this.lblInterNatRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInterNat = new System.Windows.Forms.DataGridView();
            this.ctmInternational = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb1.SuspendLayout();
            this.tbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            this.ctmLocal.SuspendLayout();
            this.tbInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterNat)).BeginInit();
            this.ctmInternational.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Controls.Add(this.tbLocal);
            this.tb1.Controls.Add(this.tbInternational);
            this.tb1.Location = new System.Drawing.Point(3, 3);
            this.tb1.Name = "tb1";
            this.tb1.SelectedIndex = 0;
            this.tb1.Size = new System.Drawing.Size(717, 240);
            this.tb1.TabIndex = 0;
            // 
            // tbLocal
            // 
            this.tbLocal.Controls.Add(this.lblLocalRecord);
            this.tbLocal.Controls.Add(this.label3);
            this.tbLocal.Controls.Add(this.dgvLocal);
            this.tbLocal.Location = new System.Drawing.Point(4, 22);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocal.Size = new System.Drawing.Size(709, 214);
            this.tbLocal.TabIndex = 0;
            this.tbLocal.Text = "Local";
            this.tbLocal.UseVisualStyleBackColor = true;
            // 
            // lblLocalRecord
            // 
            this.lblLocalRecord.AutoSize = true;
            this.lblLocalRecord.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecord.Location = new System.Drawing.Point(6, 187);
            this.lblLocalRecord.Name = "lblLocalRecord";
            this.lblLocalRecord.Size = new System.Drawing.Size(46, 23);
            this.lblLocalRecord.TabIndex = 1;
            this.lblLocalRecord.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Local License History";
            // 
            // dgvLocal
            // 
            this.dgvLocal.AllowUserToAddRows = false;
            this.dgvLocal.AllowUserToDeleteRows = false;
            this.dgvLocal.AllowUserToOrderColumns = true;
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.ContextMenuStrip = this.ctmLocal;
            this.dgvLocal.Location = new System.Drawing.Point(-4, 36);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.ReadOnly = true;
            this.dgvLocal.Size = new System.Drawing.Size(713, 148);
            this.dgvLocal.TabIndex = 0;
            // 
            // ctmLocal
            // 
            this.ctmLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.ctmLocal.Name = "ctmLocal";
            this.ctmLocal.Size = new System.Drawing.Size(170, 26);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // tbInternational
            // 
            this.tbInternational.Controls.Add(this.lblInterNatRecord);
            this.tbInternational.Controls.Add(this.label2);
            this.tbInternational.Controls.Add(this.dgvInterNat);
            this.tbInternational.Location = new System.Drawing.Point(4, 22);
            this.tbInternational.Name = "tbInternational";
            this.tbInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternational.Size = new System.Drawing.Size(709, 214);
            this.tbInternational.TabIndex = 1;
            this.tbInternational.Text = "International";
            this.tbInternational.UseVisualStyleBackColor = true;
            // 
            // lblInterNatRecord
            // 
            this.lblInterNatRecord.AutoSize = true;
            this.lblInterNatRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblInterNatRecord.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterNatRecord.Location = new System.Drawing.Point(3, 186);
            this.lblInterNatRecord.Name = "lblInterNatRecord";
            this.lblInterNatRecord.Size = new System.Drawing.Size(50, 23);
            this.lblInterNatRecord.TabIndex = 3;
            this.lblInterNatRecord.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "International License History";
            // 
            // dgvInterNat
            // 
            this.dgvInterNat.AllowUserToAddRows = false;
            this.dgvInterNat.AllowUserToDeleteRows = false;
            this.dgvInterNat.AllowUserToOrderColumns = true;
            this.dgvInterNat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterNat.ContextMenuStrip = this.ctmInternational;
            this.dgvInterNat.Location = new System.Drawing.Point(0, 29);
            this.dgvInterNat.Name = "dgvInterNat";
            this.dgvInterNat.ReadOnly = true;
            this.dgvInterNat.Size = new System.Drawing.Size(710, 154);
            this.dgvInterNat.TabIndex = 0;
            // 
            // ctmInternational
            // 
            this.ctmInternational.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalLicenseInfoToolStripMenuItem});
            this.ctmInternational.Name = "ctmInternational";
            this.ctmInternational.Size = new System.Drawing.Size(240, 26);
            // 
            // showInternationalLicenseInfoToolStripMenuItem
            // 
            this.showInternationalLicenseInfoToolStripMenuItem.Name = "showInternationalLicenseInfoToolStripMenuItem";
            this.showInternationalLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.showInternationalLicenseInfoToolStripMenuItem.Text = "Show International License Info";
            this.showInternationalLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb1);
            this.Name = "ctrlDriver";
            this.Size = new System.Drawing.Size(717, 251);
            this.tb1.ResumeLayout(false);
            this.tbLocal.ResumeLayout(false);
            this.tbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            this.ctmLocal.ResumeLayout(false);
            this.tbInternational.ResumeLayout(false);
            this.tbInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterNat)).EndInit();
            this.ctmInternational.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tb1;
        private System.Windows.Forms.TabPage tbInternational;
        private System.Windows.Forms.Label lblLocalRecord;
        private System.Windows.Forms.DataGridView dgvInterNat;
        private System.Windows.Forms.TabPage tbLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInterNatRecord;
        private System.Windows.Forms.ContextMenuStrip ctmLocal;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctmInternational;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicenseInfoToolStripMenuItem;
    }
}
