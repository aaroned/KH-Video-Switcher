namespace KH_Video_Switcher
{
    partial class frmSettingsClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingsClient));
            this.tabServer = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupExportImport = new System.Windows.Forms.GroupBox();
            this.btnImportSettings = new System.Windows.Forms.Button();
            this.btnExportSettings = new System.Windows.Forms.Button();
            this.labelExportDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupView = new System.Windows.Forms.GroupBox();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabServerConnection = new System.Windows.Forms.TabPage();
            this.groupServer = new System.Windows.Forms.GroupBox();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.picServerStatus = new System.Windows.Forms.PictureBox();
            this.btnTestServer = new System.Windows.Forms.Button();
            this.textBoxServerURL = new System.Windows.Forms.TextBox();
            this.labelServerURL = new System.Windows.Forms.Label();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxUpdateStart = new System.Windows.Forms.CheckBox();
            this.btnGithub = new System.Windows.Forms.Button();
            this.btnUpdates = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabServer.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupExportImport.SuspendLayout();
            this.groupView.SuspendLayout();
            this.tabServerConnection.SuspendLayout();
            this.groupServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServerStatus)).BeginInit();
            this.tabUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.tabGeneral);
            this.tabServer.Controls.Add(this.tabServerConnection);
            this.tabServer.Controls.Add(this.tabUpdate);
            this.tabServer.ItemSize = new System.Drawing.Size(49, 18);
            this.tabServer.Location = new System.Drawing.Point(24, 23);
            this.tabServer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabServer.Name = "tabServer";
            this.tabServer.SelectedIndex = 0;
            this.tabServer.Size = new System.Drawing.Size(720, 688);
            this.tabServer.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupExportImport);
            this.tabGeneral.Controls.Add(this.groupView);
            this.tabGeneral.Location = new System.Drawing.Point(8, 26);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabGeneral.Size = new System.Drawing.Size(704, 654);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupExportImport
            // 
            this.groupExportImport.Controls.Add(this.btnImportSettings);
            this.groupExportImport.Controls.Add(this.btnExportSettings);
            this.groupExportImport.Controls.Add(this.labelExportDescription);
            this.groupExportImport.Controls.Add(this.label2);
            this.groupExportImport.Location = new System.Drawing.Point(12, 194);
            this.groupExportImport.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupExportImport.Name = "groupExportImport";
            this.groupExportImport.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupExportImport.Size = new System.Drawing.Size(680, 217);
            this.groupExportImport.TabIndex = 2;
            this.groupExportImport.TabStop = false;
            this.groupExportImport.Text = "Export/Import Settings";
            // 
            // btnImportSettings
            // 
            this.btnImportSettings.Location = new System.Drawing.Point(206, 108);
            this.btnImportSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnImportSettings.Name = "btnImportSettings";
            this.btnImportSettings.Size = new System.Drawing.Size(150, 44);
            this.btnImportSettings.TabIndex = 8;
            this.btnImportSettings.Text = "Import";
            this.btnImportSettings.UseVisualStyleBackColor = true;
            this.btnImportSettings.Click += new System.EventHandler(this.btnImportSettings_Click);
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.Location = new System.Drawing.Point(42, 108);
            this.btnExportSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(150, 44);
            this.btnExportSettings.TabIndex = 7;
            this.btnExportSettings.Text = "Export";
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            // 
            // labelExportDescription
            // 
            this.labelExportDescription.AutoSize = true;
            this.labelExportDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExportDescription.Location = new System.Drawing.Point(38, 31);
            this.labelExportDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelExportDescription.Name = "labelExportDescription";
            this.labelExportDescription.Size = new System.Drawing.Size(600, 50);
            this.labelExportDescription.TabIndex = 6;
            this.labelExportDescription.Text = "Backup your settings to a file or restore them from a previous \r\nbackup. Useful w" +
    "hen migrating to a new computer.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 0;
            // 
            // groupView
            // 
            this.groupView.Controls.Add(this.checkBoxTopMost);
            this.groupView.Controls.Add(this.label1);
            this.groupView.Location = new System.Drawing.Point(12, 12);
            this.groupView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupView.Name = "groupView";
            this.groupView.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupView.Size = new System.Drawing.Size(680, 171);
            this.groupView.TabIndex = 0;
            this.groupView.TabStop = false;
            this.groupView.Text = "View Options";
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Checked = true;
            this.checkBoxTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTopMost.Location = new System.Drawing.Point(44, 63);
            this.checkBoxTopMost.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(410, 29);
            this.checkBoxTopMost.TabIndex = 1;
            this.checkBoxTopMost.Text = "Keep KH Switcher on top of other apps";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.Click += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Window Settings:";
            // 
            // tabServerConnection
            // 
            this.tabServerConnection.Controls.Add(this.groupServer);
            this.tabServerConnection.Location = new System.Drawing.Point(8, 26);
            this.tabServerConnection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabServerConnection.Name = "tabServerConnection";
            this.tabServerConnection.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabServerConnection.Size = new System.Drawing.Size(704, 654);
            this.tabServerConnection.TabIndex = 1;
            this.tabServerConnection.Text = "Server Connection";
            this.tabServerConnection.UseVisualStyleBackColor = true;
            // 
            // groupServer
            // 
            this.groupServer.Controls.Add(this.labelServerStatus);
            this.groupServer.Controls.Add(this.picServerStatus);
            this.groupServer.Controls.Add(this.btnTestServer);
            this.groupServer.Controls.Add(this.textBoxServerURL);
            this.groupServer.Controls.Add(this.labelServerURL);
            this.groupServer.Location = new System.Drawing.Point(12, 12);
            this.groupServer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupServer.Name = "groupServer";
            this.groupServer.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupServer.Size = new System.Drawing.Size(680, 615);
            this.groupServer.TabIndex = 0;
            this.groupServer.TabStop = false;
            this.groupServer.Text = "Server Connection";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.Location = new System.Drawing.Point(320, 190);
            this.labelServerStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(143, 25);
            this.labelServerStatus.TabIndex = 4;
            this.labelServerStatus.Text = "Disconnected";
            // 
            // picServerStatus
            // 
            this.picServerStatus.Image = global::KH_Video_Switcher.Properties.Resources.off_status_8px;
            this.picServerStatus.Location = new System.Drawing.Point(284, 196);
            this.picServerStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picServerStatus.Name = "picServerStatus";
            this.picServerStatus.Size = new System.Drawing.Size(16, 15);
            this.picServerStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picServerStatus.TabIndex = 3;
            this.picServerStatus.TabStop = false;
            // 
            // btnTestServer
            // 
            this.btnTestServer.Location = new System.Drawing.Point(70, 181);
            this.btnTestServer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTestServer.Name = "btnTestServer";
            this.btnTestServer.Size = new System.Drawing.Size(188, 44);
            this.btnTestServer.TabIndex = 2;
            this.btnTestServer.Text = "Test Connection";
            this.btnTestServer.UseVisualStyleBackColor = true;
            this.btnTestServer.Click += new System.EventHandler(this.btnTestServer_Click);
            // 
            // textBoxServerURL
            // 
            this.textBoxServerURL.Location = new System.Drawing.Point(70, 88);
            this.textBoxServerURL.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxServerURL.Name = "textBoxServerURL";
            this.textBoxServerURL.Size = new System.Drawing.Size(488, 31);
            this.textBoxServerURL.TabIndex = 1;
            // 
            // labelServerURL
            // 
            this.labelServerURL.AutoSize = true;
            this.labelServerURL.Location = new System.Drawing.Point(64, 56);
            this.labelServerURL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelServerURL.Name = "labelServerURL";
            this.labelServerURL.Size = new System.Drawing.Size(129, 25);
            this.labelServerURL.TabIndex = 0;
            this.labelServerURL.Text = "Server URL:";
            // 
            // tabUpdate
            // 
            this.tabUpdate.Controls.Add(this.label3);
            this.tabUpdate.Controls.Add(this.checkBoxUpdateStart);
            this.tabUpdate.Controls.Add(this.btnGithub);
            this.tabUpdate.Controls.Add(this.btnUpdates);
            this.tabUpdate.Controls.Add(this.labelVersion);
            this.tabUpdate.Location = new System.Drawing.Point(8, 26);
            this.tabUpdate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabUpdate.Size = new System.Drawing.Size(704, 654);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "Update";
            this.tabUpdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 398);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 7;
            // 
            // checkBoxUpdateStart
            // 
            this.checkBoxUpdateStart.AutoSize = true;
            this.checkBoxUpdateStart.Checked = true;
            this.checkBoxUpdateStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpdateStart.Location = new System.Drawing.Point(190, 360);
            this.checkBoxUpdateStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkBoxUpdateStart.Name = "checkBoxUpdateStart";
            this.checkBoxUpdateStart.Size = new System.Drawing.Size(321, 29);
            this.checkBoxUpdateStart.TabIndex = 6;
            this.checkBoxUpdateStart.Text = "Check for updates on startup";
            this.checkBoxUpdateStart.UseVisualStyleBackColor = true;
            this.checkBoxUpdateStart.Click += new System.EventHandler(this.checkBoxUpdateStart_CheckedChanged);
            // 
            // btnGithub
            // 
            this.btnGithub.Image = global::KH_Video_Switcher.Properties.Resources.GitHub_16;
            this.btnGithub.Location = new System.Drawing.Point(320, 271);
            this.btnGithub.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(64, 62);
            this.btnGithub.TabIndex = 5;
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // btnUpdates
            // 
            this.btnUpdates.Image = global::KH_Video_Switcher.Properties.Resources.refresh_square;
            this.btnUpdates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdates.Location = new System.Drawing.Point(222, 200);
            this.btnUpdates.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.Size = new System.Drawing.Size(260, 44);
            this.btnUpdates.TabIndex = 4;
            this.btnUpdates.Text = "Check for Updates...";
            this.btnUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdates.UseVisualStyleBackColor = true;
            this.btnUpdates.Click += new System.EventHandler(this.btnUpdates_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelVersion.Location = new System.Drawing.Point(230, 152);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(246, 25);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Installed version: 0.0.0.0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(594, 725);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 44);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSettingsClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 790);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(794, 861);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(794, 861);
            this.Name = "frmSettingsClient";
            this.Text = "KH Switcher (Zoom) Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettingsClient_FormClosing);
            this.Load += new System.EventHandler(this.frmSettingsClient_Load);
            this.tabServer.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupExportImport.ResumeLayout(false);
            this.groupExportImport.PerformLayout();
            this.groupView.ResumeLayout(false);
            this.groupView.PerformLayout();
            this.tabServerConnection.ResumeLayout(false);
            this.groupServer.ResumeLayout(false);
            this.groupServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServerStatus)).EndInit();
            this.tabUpdate.ResumeLayout(false);
            this.tabUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabServer;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabServerConnection;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabUpdate;
        private System.Windows.Forms.GroupBox groupView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.GroupBox groupExportImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelExportDescription;
        private System.Windows.Forms.Button btnImportSettings;
        private System.Windows.Forms.Button btnExportSettings;
        private System.Windows.Forms.GroupBox groupServer;
        private System.Windows.Forms.TextBox textBoxServerURL;
        private System.Windows.Forms.Label labelServerURL;
        private System.Windows.Forms.Button btnTestServer;
        private System.Windows.Forms.PictureBox picServerStatus;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button btnUpdates;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxUpdateStart;
    }
}