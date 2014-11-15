namespace ChromeUnlocker
{
    partial class frmMain
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
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Patch = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProfileDir = new System.Windows.Forms.TextBox();
            this.chkCustomProfile = new System.Windows.Forms.CheckBox();
            this.chkCustomProfileName = new System.Windows.Forms.CheckBox();
            this.txtCustomProfileName = new System.Windows.Forms.TextBox();
            this.btnSelectProfileDir = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(12, 12);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 23);
            this.btn_Copy.TabIndex = 0;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Patch
            // 
            this.btn_Patch.Location = new System.Drawing.Point(93, 12);
            this.btn_Patch.Name = "btn_Patch";
            this.btn_Patch.Size = new System.Drawing.Size(75, 23);
            this.btn_Patch.TabIndex = 1;
            this.btn_Patch.Text = "Patch";
            this.btn_Patch.UseVisualStyleBackColor = true;
            this.btn_Patch.Click += new System.EventHandler(this.btn_Patch_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(176, 12);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(106, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run MyChrome";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(176, 41);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(104, 23);
            this.btn_Remove.TabIndex = 3;
            this.btn_Remove.Text = "Remove Copy";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 70);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(268, 198);
            this.txtLog.TabIndex = 4;
            this.txtLog.Text = "Ready to go.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Logs:";
            // 
            // txtProfileDir
            // 
            this.txtProfileDir.Location = new System.Drawing.Point(12, 297);
            this.txtProfileDir.Name = "txtProfileDir";
            this.txtProfileDir.Size = new System.Drawing.Size(237, 20);
            this.txtProfileDir.TabIndex = 7;
            // 
            // chkCustomProfile
            // 
            this.chkCustomProfile.AutoSize = true;
            this.chkCustomProfile.Location = new System.Drawing.Point(12, 274);
            this.chkCustomProfile.Name = "chkCustomProfile";
            this.chkCustomProfile.Size = new System.Drawing.Size(237, 17);
            this.chkCustomProfile.TabIndex = 8;
            this.chkCustomProfile.Text = "Custom Profile Directory (W/N drive for sync)";
            this.chkCustomProfile.UseVisualStyleBackColor = true;
            // 
            // chkCustomProfileName
            // 
            this.chkCustomProfileName.AutoSize = true;
            this.chkCustomProfileName.Location = new System.Drawing.Point(12, 323);
            this.chkCustomProfileName.Name = "chkCustomProfileName";
            this.chkCustomProfileName.Size = new System.Drawing.Size(124, 17);
            this.chkCustomProfileName.TabIndex = 10;
            this.chkCustomProfileName.Text = "Custom Profile Name";
            this.chkCustomProfileName.UseVisualStyleBackColor = true;
            // 
            // txtCustomProfileName
            // 
            this.txtCustomProfileName.Location = new System.Drawing.Point(12, 346);
            this.txtCustomProfileName.Name = "txtCustomProfileName";
            this.txtCustomProfileName.Size = new System.Drawing.Size(268, 20);
            this.txtCustomProfileName.TabIndex = 9;
            this.txtCustomProfileName.Text = "Default";
            // 
            // btnSelectProfileDir
            // 
            this.btnSelectProfileDir.Location = new System.Drawing.Point(256, 297);
            this.btnSelectProfileDir.Name = "btnSelectProfileDir";
            this.btnSelectProfileDir.Size = new System.Drawing.Size(24, 23);
            this.btnSelectProfileDir.TabIndex = 11;
            this.btnSelectProfileDir.Text = "...";
            this.btnSelectProfileDir.UseVisualStyleBackColor = true;
            this.btnSelectProfileDir.Click += new System.EventHandler(this.btnSelectProfileDir_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(93, 41);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 375);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnSelectProfileDir);
            this.Controls.Add(this.chkCustomProfileName);
            this.Controls.Add(this.txtCustomProfileName);
            this.Controls.Add(this.chkCustomProfile);
            this.Controls.Add(this.txtProfileDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.btn_Patch);
            this.Controls.Add(this.btn_Copy);
            this.Name = "frmMain";
            this.Text = "Chrome Unlocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Patch;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfileDir;
        private System.Windows.Forms.CheckBox chkCustomProfile;
        private System.Windows.Forms.CheckBox chkCustomProfileName;
        private System.Windows.Forms.TextBox txtCustomProfileName;
        private System.Windows.Forms.Button btnSelectProfileDir;
        private System.Windows.Forms.Button btnClearLog;
    }
}

