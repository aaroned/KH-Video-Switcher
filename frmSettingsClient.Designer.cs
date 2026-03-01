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
            this.tabServer.Location = new System.Drawing.Point(12, 12);
            this.tabServer.Name = "tabServer";
            this.tabServer.SelectedIndex = 0;
            this.tabServer.Size = new System.Drawing.Size(360, 358);
            this.tabServer.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupExportImport);
            this.tabGeneral.Controls.Add(this.groupView);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(352, 332);
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
            this.groupExportImport.Location = new System.Drawing.Point(6, 101);
            this.groupExportImport.Name = "groupExportImport";
            this.groupExportImport.Size = new System.Drawing.Size(340, 113);
            this.groupExportImport.TabIndex = 2;
            this.groupExportImport.TabStop = false;
            this.groupExportImport.Text = "Export/Import Settings";
            // 
            // btnImportSettings
            // 
            this.btnImportSettings.Location = new System.Drawing.Point(103, 56);
            this.btnImportSettings.Name = "btnImportSettings";
            this.btnImportSettings.Size = new System.Drawing.Size(75, 23);
            this.btnImportSettings.TabIndex = 8;
            this.btnImportSettings.Text = "Import";
            this.btnImportSettings.UseVisualStyleBackColor = true;
            this.btnImportSettings.Click += new System.EventHandler(this.btnImportSettings_Click);
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.Location = new System.Drawing.Point(21, 56);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(75, 23);
            this.btnExportSettings.TabIndex = 7;
            this.btnExportSettings.Text = "Export";
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            // 
            // labelExportDescription
            // 
            this.labelExportDescription.AutoSize = true;
            this.labelExportDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExportDescription.Location = new System.Drawing.Point(19, 16);
            this.labelExportDescription.Name = "labelExportDescription";
            this.labelExportDescription.Size = new System.Drawing.Size(294, 26);
            this.labelExportDescription.TabIndex = 6;
            this.labelExportDescription.Text = "Backup your settings to a file or restore them from a previous \r\nbackup. Useful w" +
    "hen migrating to a new computer.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 0;
            // 
            // groupView
            // 
            this.groupView.Controls.Add(this.checkBoxTopMost);
            this.groupView.Controls.Add(this.label1);
            this.groupView.Location = new System.Drawing.Point(6, 6);
            this.groupView.Name = "groupView";
            this.groupView.Size = new System.Drawing.Size(340, 89);
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
            this.checkBoxTopMost.Location = new System.Drawing.Point(22, 33);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(208, 17);
            this.checkBoxTopMost.TabIndex = 1;
            this.checkBoxTopMost.Text = "Keep KH Switcher on top of other apps";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.Click += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Window Settings:";
            // 
            // tabServerConnection
            // 
            this.tabServerConnection.Controls.Add(this.groupServer);
            this.tabServerConnection.Location = new System.Drawing.Point(4, 22);
            this.tabServerConnection.Name = "tabServerConnection";
            this.tabServerConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerConnection.Size = new System.Drawing.Size(352, 332);
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
            this.groupServer.Location = new System.Drawing.Point(6, 6);
            this.groupServer.Name = "groupServer";
            this.groupServer.Size = new System.Drawing.Size(340, 320);
            this.groupServer.TabIndex = 0;
            this.groupServer.TabStop = false;
            this.groupServer.Text = "Server Connection";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.Location = new System.Drawing.Point(160, 99);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(73, 13);
            this.labelServerStatus.TabIndex = 4;
            this.labelServerStatus.Text = "Disconnected";
            // 
            // picServerStatus
            // 
            this.picServerStatus.Image = global::KH_Video_Switcher.Properties.Resources.off_status_8px;
            this.picServerStatus.Location = new System.Drawing.Point(142, 102);
            this.picServerStatus.Name = "picServerStatus";
            this.picServerStatus.Size = new System.Drawing.Size(8, 8);
            this.picServerStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picServerStatus.TabIndex = 3;
            this.picServerStatus.TabStop = false;
            // 
            // btnTestServer
            // 
            this.btnTestServer.Location = new System.Drawing.Point(35, 94);
            this.btnTestServer.Name = "btnTestServer";
            this.btnTestServer.Size = new System.Drawing.Size(94, 23);
            this.btnTestServer.TabIndex = 2;
            this.btnTestServer.Text = "Test Connection";
            this.btnTestServer.UseVisualStyleBackColor = true;
            this.btnTestServer.Click += new System.EventHandler(this.btnTestServer_Click);
            // 
            // textBoxServerURL
            // 
            this.textBoxServerURL.Location = new System.Drawing.Point(35, 46);
            this.textBoxServerURL.Name = "textBoxServerURL";
            this.textBoxServerURL.Size = new System.Drawing.Size(246, 20);
            this.textBoxServerURL.TabIndex = 1;
            // 
            // labelServerURL
            // 
            this.labelServerURL.AutoSize = true;
            this.labelServerURL.Location = new System.Drawing.Point(32, 29);
            this.labelServerURL.Name = "labelServerURL";
            this.labelServerURL.Size = new System.Drawing.Size(66, 13);
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
            this.tabUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdate.Size = new System.Drawing.Size(352, 332);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "Update";
            this.tabUpdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // checkBoxUpdateStart
            // 
            this.checkBoxUpdateStart.AutoSize = true;
            this.checkBoxUpdateStart.Checked = true;
            this.checkBoxUpdateStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpdateStart.Location = new System.Drawing.Point(95, 187);
            this.checkBoxUpdateStart.Name = "checkBoxUpdateStart";
            this.checkBoxUpdateStart.Size = new System.Drawing.Size(163, 17);
            this.checkBoxUpdateStart.TabIndex = 6;
            this.checkBoxUpdateStart.Text = "Check for updates on startup";
            this.checkBoxUpdateStart.UseVisualStyleBackColor = true;
            this.checkBoxUpdateStart.Click += new System.EventHandler(this.checkBoxUpdateStart_CheckedChanged);
            // 
            // btnGithub
            // 
            this.btnGithub.Image = global::KH_Video_Switcher.Properties.Resources.GitHub_16;
            this.btnGithub.Location = new System.Drawing.Point(160, 141);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(32, 32);
            this.btnGithub.TabIndex = 5;
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // btnUpdates
            // 
            this.btnUpdates.Image = global::KH_Video_Switcher.Properties.Resources.refresh_square;
            this.btnUpdates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdates.Location = new System.Drawing.Point(111, 104);
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.Size = new System.Drawing.Size(130, 23);
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
            this.labelVersion.Location = new System.Drawing.Point(115, 79);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(122, 13);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Installed version: 0.0.0.0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 377);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSettingsClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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