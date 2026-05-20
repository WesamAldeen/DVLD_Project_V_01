namespace DVLD.Test
{
    partial class ctrlScheduleTest
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbTestType = new System.Windows.Forms.GroupBox();
            this.dtpTestDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblRetakeTestAppID = new System.Windows.Forms.Label();
            this.lblRetakeAppFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblTrial = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDClass = new System.Windows.Forms.Label();
            this.lblDLAppID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.pbTesttypeImg = new System.Windows.Forms.PictureBox();
            this.gbTestType.SuspendLayout();
            this.gbRetakeTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTesttypeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(153, 130);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Schedule Test";
            // 
            // gbTestType
            // 
            this.gbTestType.Controls.Add(this.dtpTestDate);
            this.gbTestType.Controls.Add(this.btnSave);
            this.gbTestType.Controls.Add(this.gbRetakeTest);
            this.gbTestType.Controls.Add(this.lblFees);
            this.gbTestType.Controls.Add(this.lblTrial);
            this.gbTestType.Controls.Add(this.lblName);
            this.gbTestType.Controls.Add(this.lblDClass);
            this.gbTestType.Controls.Add(this.lblDLAppID);
            this.gbTestType.Controls.Add(this.label8);
            this.gbTestType.Controls.Add(this.label7);
            this.gbTestType.Controls.Add(this.label6);
            this.gbTestType.Controls.Add(this.label5);
            this.gbTestType.Controls.Add(this.label4);
            this.gbTestType.Controls.Add(this.label3);
            this.gbTestType.Controls.Add(this.lblUserMessage);
            this.gbTestType.Controls.Add(this.lblTitle);
            this.gbTestType.Controls.Add(this.pbTesttypeImg);
            this.gbTestType.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestType.Location = new System.Drawing.Point(3, 3);
            this.gbTestType.Name = "gbTestType";
            this.gbTestType.Size = new System.Drawing.Size(421, 524);
            this.gbTestType.TabIndex = 1;
            this.gbTestType.TabStop = false;
            this.gbTestType.Text = "Test Type";
            // 
            // dtpTestDate
            // 
            this.dtpTestDate.Location = new System.Drawing.Point(103, 303);
            this.dtpTestDate.Name = "dtpTestDate";
            this.dtpTestDate.Size = new System.Drawing.Size(200, 24);
            this.dtpTestDate.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(308, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 39);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lblTotalFees);
            this.gbRetakeTest.Controls.Add(this.lblRetakeTestAppID);
            this.gbRetakeTest.Controls.Add(this.lblRetakeAppFees);
            this.gbRetakeTest.Controls.Add(this.label11);
            this.gbRetakeTest.Controls.Add(this.label10);
            this.gbRetakeTest.Controls.Add(this.label9);
            this.gbRetakeTest.Location = new System.Drawing.Point(6, 369);
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.Size = new System.Drawing.Size(409, 84);
            this.gbRetakeTest.TabIndex = 14;
            this.gbRetakeTest.TabStop = false;
            this.gbRetakeTest.Text = "Retake Test Info";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFees.Location = new System.Drawing.Point(298, 25);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(33, 19);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "----";
            // 
            // lblRetakeTestAppID
            // 
            this.lblRetakeTestAppID.AutoSize = true;
            this.lblRetakeTestAppID.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeTestAppID.ForeColor = System.Drawing.Color.Black;
            this.lblRetakeTestAppID.Location = new System.Drawing.Point(116, 55);
            this.lblRetakeTestAppID.Name = "lblRetakeTestAppID";
            this.lblRetakeTestAppID.Size = new System.Drawing.Size(33, 19);
            this.lblRetakeTestAppID.TabIndex = 18;
            this.lblRetakeTestAppID.Text = "----";
            // 
            // lblRetakeAppFees
            // 
            this.lblRetakeAppFees.AutoSize = true;
            this.lblRetakeAppFees.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeAppFees.ForeColor = System.Drawing.Color.Black;
            this.lblRetakeAppFees.Location = new System.Drawing.Point(106, 25);
            this.lblRetakeAppFees.Name = "lblRetakeAppFees";
            this.lblRetakeAppFees.Size = new System.Drawing.Size(33, 19);
            this.lblRetakeAppFees.TabIndex = 15;
            this.lblRetakeAppFees.Text = "----";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(225, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "Total Fees:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(23, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 19);
            this.label10.TabIndex = 16;
            this.label10.Text = "Re.Test.App ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(23, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Re.App Fees:";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.ForeColor = System.Drawing.Color.Black;
            this.lblFees.Location = new System.Drawing.Point(90, 338);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(33, 19);
            this.lblFees.TabIndex = 13;
            this.lblFees.Text = "----";
            // 
            // lblTrial
            // 
            this.lblTrial.AutoSize = true;
            this.lblTrial.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrial.ForeColor = System.Drawing.Color.Black;
            this.lblTrial.Location = new System.Drawing.Point(99, 277);
            this.lblTrial.Name = "lblTrial";
            this.lblTrial.Size = new System.Drawing.Size(33, 19);
            this.lblTrial.TabIndex = 12;
            this.lblTrial.Text = "----";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(99, 248);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(33, 19);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "----";
            // 
            // lblDClass
            // 
            this.lblDClass.AutoSize = true;
            this.lblDClass.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDClass.ForeColor = System.Drawing.Color.Black;
            this.lblDClass.Location = new System.Drawing.Point(99, 220);
            this.lblDClass.Name = "lblDClass";
            this.lblDClass.Size = new System.Drawing.Size(33, 19);
            this.lblDClass.TabIndex = 10;
            this.lblDClass.Text = "----";
            // 
            // lblDLAppID
            // 
            this.lblDLAppID.AutoSize = true;
            this.lblDLAppID.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLAppID.ForeColor = System.Drawing.Color.Black;
            this.lblDLAppID.Location = new System.Drawing.Point(99, 189);
            this.lblDLAppID.Name = "lblDLAppID";
            this.lblDLAppID.Size = new System.Drawing.Size(33, 19);
            this.lblDLAppID.TabIndex = 9;
            this.lblDLAppID.Text = "----";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(47, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Fees:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(47, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(50, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Trial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(40, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "D. Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "D.L.App ID:";
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUserMessage.Location = new System.Drawing.Point(89, 153);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(120, 23);
            this.lblUserMessage.TabIndex = 2;
            this.lblUserMessage.Text = "Control Schedule";
            // 
            // pbTesttypeImg
            // 
            this.pbTesttypeImg.Location = new System.Drawing.Point(157, 19);
            this.pbTesttypeImg.Name = "pbTesttypeImg";
            this.pbTesttypeImg.Size = new System.Drawing.Size(110, 95);
            this.pbTesttypeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTesttypeImg.TabIndex = 0;
            this.pbTesttypeImg.TabStop = false;
            // 
            // ctrlScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTestType);
            this.Name = "ctrlScheduleTest";
            this.Size = new System.Drawing.Size(427, 530);
            this.gbTestType.ResumeLayout(false);
            this.gbTestType.PerformLayout();
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTesttypeImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbTestType;
        private System.Windows.Forms.PictureBox pbTesttypeImg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblTrial;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDClass;
        private System.Windows.Forms.Label lblDLAppID;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblRetakeTestAppID;
        private System.Windows.Forms.Label lblRetakeAppFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpTestDate;
    }
}
