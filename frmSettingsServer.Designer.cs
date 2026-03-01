namespace KH_Video_Switcher
{
    partial class frmSettingsServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingsServer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportSettings = new System.Windows.Forms.Button();
            this.btnExportSettings = new System.Windows.Forms.Button();
            this.labelExportDescription = new System.Windows.Forms.Label();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.labelTopMost = new System.Windows.Forms.Label();
            this.labelBtnDescription = new System.Windows.Forms.Label();
            this.labelChooseBtn = new System.Windows.Forms.Label();
            this.checkBoxOnlyMView = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.comboBoxDisplays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOBS = new System.Windows.Forms.TabPage();
            this.groupBoxOBS = new System.Windows.Forms.GroupBox();
            this.btnTestOBS = new System.Windows.Forms.Button();
            this.labelOBSStatus = new System.Windows.Forms.Label();
            this.labelStatusLight = new System.Windows.Forms.Label();
            this.btnShowOBSPASS = new System.Windows.Forms.Button();
            this.textBoxOBSPASS = new System.Windows.Forms.TextBox();
            this.labelOBSPASS = new System.Windows.Forms.Label();
            this.textBoxOBSURL = new System.Windows.Forms.TextBox();
            this.labelOBSURL = new System.Windows.Forms.Label();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.labelVersion = new System.Windows.Forms.Label();
            this.checkBoxUpdateStart = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.picOBSStatus = new System.Windows.Forms.PictureBox();
            this.btnGithub = new System.Windows.Forms.Button();
            this.btnUpdates = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            this.tabOBS.SuspendLayout();
            this.groupBoxOBS.SuspendLayout();
            this.tabUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOBSStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabOBS);
            this.tabControl1.Controls.Add(this.tabUpdate);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 358);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox1);
            this.tabGeneral.Controls.Add(this.groupBoxView);
            this.tabGeneral.Controls.Add(this.groupBoxDisplay);
            this.tabGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(352, 332);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportSettings);
            this.groupBox1.Controls.Add(this.btnExportSettings);
            this.groupBox1.Controls.Add(this.labelExportDescription);
            this.groupBox1.Location = new System.Drawing.Point(6, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export/Import Settings";
            // 
            // btnImportSettings
            // 
            this.btnImportSettings.Location = new System.Drawing.Point(102, 55);
            this.btnImportSettings.Name = "btnImportSettings";
            this.btnImportSettings.Size = new System.Drawing.Size(75, 23);
            this.btnImportSettings.TabIndex = 7;
            this.btnImportSettings.Text = "Import";
            this.btnImportSettings.UseVisualStyleBackColor = true;
            this.btnImportSettings.Click += new System.EventHandler(this.btnImportSettings_Click);
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.Location = new System.Drawing.Point(21, 55);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(75, 23);
            this.btnExportSettings.TabIndex = 6;
            this.btnExportSettings.Text = "Export";
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            // 
            // labelExportDescription
            // 
            this.labelExportDescription.AutoSize = true;
            this.labelExportDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExportDescription.Location = new System.Drawing.Point(18, 16);
            this.labelExportDescription.Name = "labelExportDescription";
            this.labelExportDescription.Size = new System.Drawing.Size(294, 26);
            this.labelExportDescription.TabIndex = 5;
            this.labelExportDescription.Text = "Backup your settings to a file or restore them from a previous \r\nbackup. Useful w" +
    "hen migrating to a new computer.";
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.checkBoxTopMost);
            this.groupBoxView.Controls.Add(this.labelTopMost);
            this.groupBoxView.Controls.Add(this.labelBtnDescription);
            this.groupBoxView.Controls.Add(this.labelChooseBtn);
            this.groupBoxView.Controls.Add(this.checkBoxOnlyMView);
            this.groupBoxView.Location = new System.Drawing.Point(6, 104);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(340, 119);
            this.groupBoxView.TabIndex = 1;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "View Options";
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Checked = true;
            this.checkBoxTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTopMost.Location = new System.Drawing.Point(21, 94);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(208, 17);
            this.checkBoxTopMost.TabIndex = 6;
            this.checkBoxTopMost.Text = "Keep KH Switcher on top of other apps";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            // 
            // labelTopMost
            // 
            this.labelTopMost.AutoSize = true;
            this.labelTopMost.Location = new System.Drawing.Point(18, 78);
            this.labelTopMost.Name = "labelTopMost";
            this.labelTopMost.Size = new System.Drawing.Size(90, 13);
            this.labelTopMost.TabIndex = 5;
            this.labelTopMost.Text = "Window Settings:";
            // 
            // labelBtnDescription
            // 
            this.labelBtnDescription.AutoSize = true;
            this.labelBtnDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelBtnDescription.Location = new System.Drawing.Point(18, 52);
            this.labelBtnDescription.Name = "labelBtnDescription";
            this.labelBtnDescription.Size = new System.Drawing.Size(299, 13);
            this.labelBtnDescription.TabIndex = 4;
            this.labelBtnDescription.Text = "Unchecking these buttons will remove them from the switcher.\r\n";
            // 
            // labelChooseBtn
            // 
            this.labelChooseBtn.AutoSize = true;
            this.labelChooseBtn.Location = new System.Drawing.Point(18, 16);
            this.labelChooseBtn.Name = "labelChooseBtn";
            this.labelChooseBtn.Size = new System.Drawing.Size(103, 13);
            this.labelChooseBtn.TabIndex = 3;
            this.labelChooseBtn.Text = "Hide/Show Buttons:";
            // 
            // checkBoxOnlyMView
            // 
            this.checkBoxOnlyMView.AutoSize = true;
            this.checkBoxOnlyMView.Checked = true;
            this.checkBoxOnlyMView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnlyMView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxOnlyMView.Location = new System.Drawing.Point(21, 32);
            this.checkBoxOnlyMView.Name = "checkBoxOnlyMView";
            this.checkBoxOnlyMView.Size = new System.Drawing.Size(53, 17);
            this.checkBoxOnlyMView.TabIndex = 1;
            this.checkBoxOnlyMView.Text = "OnlyM";
            this.checkBoxOnlyMView.UseVisualStyleBackColor = true;
            this.checkBoxOnlyMView.CheckedChanged += new System.EventHandler(this.checkBoxOnlyMView_CheckedChanged);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.labelDisplay);
            this.groupBoxDisplay.Controls.Add(this.comboBoxDisplays);
            this.groupBoxDisplay.Controls.Add(this.label1);
            this.groupBoxDisplay.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(340, 92);
            this.groupBoxDisplay.TabIndex = 0;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display Selection";
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDisplay.Location = new System.Drawing.Point(18, 56);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(279, 26);
            this.labelDisplay.TabIndex = 3;
            this.labelDisplay.Text = "Select the display that you use for JW Library, Zoom, ect. \r\nThis will usually be" +
    " the TV monitors inside the hall.";
            // 
            // comboBoxDisplays
            // 
            this.comboBoxDisplays.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxDisplays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDisplays.FormattingEnabled = true;
            this.comboBoxDisplays.Location = new System.Drawing.Point(21, 32);
            this.comboBoxDisplays.Name = "comboBoxDisplays";
            this.comboBoxDisplays.Size = new System.Drawing.Size(313, 21);
            this.comboBoxDisplays.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Media Display:";
            // 
            // tabOBS
            // 
            this.tabOBS.Controls.Add(this.groupBoxOBS);
            this.tabOBS.Location = new System.Drawing.Point(4, 22);
            this.tabOBS.Name = "tabOBS";
            this.tabOBS.Padding = new System.Windows.Forms.Padding(3);
            this.tabOBS.Size = new System.Drawing.Size(352, 332);
            this.tabOBS.TabIndex = 1;
            this.tabOBS.Text = "OBS Connection";
            this.tabOBS.UseVisualStyleBackColor = true;
            // 
            // groupBoxOBS
            // 
            this.groupBoxOBS.Controls.Add(this.btnTestOBS);
            this.groupBoxOBS.Controls.Add(this.picOBSStatus);
            this.groupBoxOBS.Controls.Add(this.labelOBSStatus);
            this.groupBoxOBS.Controls.Add(this.labelStatusLight);
            this.groupBoxOBS.Controls.Add(this.btnShowOBSPASS);
            this.groupBoxOBS.Controls.Add(this.textBoxOBSPASS);
            this.groupBoxOBS.Controls.Add(this.labelOBSPASS);
            this.groupBoxOBS.Controls.Add(this.textBoxOBSURL);
            this.groupBoxOBS.Controls.Add(this.labelOBSURL);
            this.groupBoxOBS.Location = new System.Drawing.Point(6, 6);
            this.groupBoxOBS.Name = "groupBoxOBS";
            this.groupBoxOBS.Size = new System.Drawing.Size(343, 320);
            this.groupBoxOBS.TabIndex = 0;
            this.groupBoxOBS.TabStop = false;
            this.groupBoxOBS.Text = "OBS Websocket Server Settings:";
            // 
            // btnTestOBS
            // 
            this.btnTestOBS.Location = new System.Drawing.Point(23, 151);
            this.btnTestOBS.Name = "btnTestOBS";
            this.btnTestOBS.Size = new System.Drawing.Size(94, 23);
            this.btnTestOBS.TabIndex = 9;
            this.btnTestOBS.Text = "Test Connection";
            this.btnTestOBS.UseVisualStyleBackColor = true;
            this.btnTestOBS.Click += new System.EventHandler(this.btnTestOBS_Click);
            // 
            // labelOBSStatus
            // 
            this.labelOBSStatus.AutoSize = true;
            this.labelOBSStatus.Location = new System.Drawing.Point(142, 156);
            this.labelOBSStatus.Name = "labelOBSStatus";
            this.labelOBSStatus.Size = new System.Drawing.Size(73, 13);
            this.labelOBSStatus.TabIndex = 6;
            this.labelOBSStatus.Text = "Disconnected";
            // 
            // labelStatusLight
            // 
            this.labelStatusLight.AutoSize = true;
            this.labelStatusLight.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusLight.ForeColor = System.Drawing.Color.Red;
            this.labelStatusLight.Location = new System.Drawing.Point(123, 156);
            this.labelStatusLight.Name = "labelStatusLight";
            this.labelStatusLight.Size = new System.Drawing.Size(0, 21);
            this.labelStatusLight.TabIndex = 5;
            this.labelStatusLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowOBSPASS
            // 
            this.btnShowOBSPASS.Location = new System.Drawing.Point(275, 105);
            this.btnShowOBSPASS.Name = "btnShowOBSPASS";
            this.btnShowOBSPASS.Size = new System.Drawing.Size(51, 20);
            this.btnShowOBSPASS.TabIndex = 4;
            this.btnShowOBSPASS.Text = "Show";
            this.btnShowOBSPASS.UseVisualStyleBackColor = true;
            this.btnShowOBSPASS.Click += new System.EventHandler(this.btnShowOBSPASS_Click);
            // 
            // textBoxOBSPASS
            // 
            this.textBoxOBSPASS.Location = new System.Drawing.Point(23, 105);
            this.textBoxOBSPASS.Name = "textBoxOBSPASS";
            this.textBoxOBSPASS.Size = new System.Drawing.Size(246, 20);
            this.textBoxOBSPASS.TabIndex = 3;
            this.textBoxOBSPASS.UseSystemPasswordChar = true;
            // 
            // labelOBSPASS
            // 
            this.labelOBSPASS.AutoSize = true;
            this.labelOBSPASS.Location = new System.Drawing.Point(20, 89);
            this.labelOBSPASS.Name = "labelOBSPASS";
            this.labelOBSPASS.Size = new System.Drawing.Size(163, 13);
            this.labelOBSPASS.TabIndex = 2;
            this.labelOBSPASS.Text = "OBS WebSocket Authentication:";
            // 
            // textBoxOBSURL
            // 
            this.textBoxOBSURL.Location = new System.Drawing.Point(23, 46);
            this.textBoxOBSURL.Name = "textBoxOBSURL";
            this.textBoxOBSURL.Size = new System.Drawing.Size(246, 20);
            this.textBoxOBSURL.TabIndex = 1;
            // 
            // labelOBSURL
            // 
            this.labelOBSURL.AutoSize = true;
            this.labelOBSURL.Location = new System.Drawing.Point(20, 30);
            this.labelOBSURL.Name = "labelOBSURL";
            this.labelOBSURL.Size = new System.Drawing.Size(117, 13);
            this.labelOBSURL.TabIndex = 0;
            this.labelOBSURL.Text = "OBS WebSocket URL:";
            // 
            // tabUpdate
            // 
            this.tabUpdate.Controls.Add(this.btnGithub);
            this.tabUpdate.Controls.Add(this.labelVersion);
            this.tabUpdate.Controls.Add(this.checkBoxUpdateStart);
            this.tabUpdate.Controls.Add(this.btnUpdates);
            this.tabUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdate.Size = new System.Drawing.Size(352, 332);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "Update";
            this.tabUpdate.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelVersion.Location = new System.Drawing.Point(115, 79);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(122, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Installed version: 0.0.0.0";
            // 
            // checkBoxUpdateStart
            // 
            this.checkBoxUpdateStart.AutoSize = true;
            this.checkBoxUpdateStart.Checked = true;
            this.checkBoxUpdateStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpdateStart.Location = new System.Drawing.Point(95, 187);
            this.checkBoxUpdateStart.Name = "checkBoxUpdateStart";
            this.checkBoxUpdateStart.Size = new System.Drawing.Size(163, 17);
            this.checkBoxUpdateStart.TabIndex = 1;
            this.checkBoxUpdateStart.Text = "Check for updates on startup";
            this.checkBoxUpdateStart.UseVisualStyleBackColor = true;
            this.checkBoxUpdateStart.CheckedChanged += new System.EventHandler(this.checkBoxUpdateStart_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 376);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picOBSStatus
            // 
            this.picOBSStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picOBSStatus.Image = global::KH_Video_Switcher.Properties.Resources.off_status_8px;
            this.picOBSStatus.Location = new System.Drawing.Point(128, 159);
            this.picOBSStatus.Name = "picOBSStatus";
            this.picOBSStatus.Size = new System.Drawing.Size(8, 8);
            this.picOBSStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOBSStatus.TabIndex = 8;
            this.picOBSStatus.TabStop = false;
            // 
            // btnGithub
            // 
            this.btnGithub.Image = global::KH_Video_Switcher.Properties.Resources.GitHub_16;
            this.btnGithub.Location = new System.Drawing.Point(160, 141);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(32, 32);
            this.btnGithub.TabIndex = 3;
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
            this.btnUpdates.TabIndex = 0;
            this.btnUpdates.Text = "Check for Updates...";
            this.btnUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdates.UseVisualStyleBackColor = true;
            this.btnUpdates.Click += new System.EventHandler(this.btnUpdates_Click);
            // 
            // frmSettingsServer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettingsServer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KH Switcher (Media) Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettingsServer_FormClosing);
            this.Load += new System.EventHandler(this.frmSettingsServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            this.tabOBS.ResumeLayout(false);
            this.groupBoxOBS.ResumeLayout(false);
            this.groupBoxOBS.PerformLayout();
            this.tabUpdate.ResumeLayout(false);
            this.tabUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOBSStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabOBS;
        private System.Windows.Forms.TabPage tabUpdate;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.ComboBox comboBoxDisplays;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkBoxOnlyMView;
        private System.Windows.Forms.Label labelChooseBtn;
        private System.Windows.Forms.Label labelBtnDescription;
        private System.Windows.Forms.GroupBox groupBoxOBS;
        private System.Windows.Forms.TextBox textBoxOBSPASS;
        private System.Windows.Forms.Label labelOBSPASS;
        private System.Windows.Forms.TextBox textBoxOBSURL;
        private System.Windows.Forms.Label labelOBSURL;
        private System.Windows.Forms.Button btnShowOBSPASS;
        private System.Windows.Forms.Button btnUpdates;
        private System.Windows.Forms.CheckBox checkBoxUpdateStart;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.Label labelStatusLight;
        private System.Windows.Forms.Label labelOBSStatus;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.Label labelTopMost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImportSettings;
        private System.Windows.Forms.Button btnExportSettings;
        private System.Windows.Forms.Label labelExportDescription;
        private System.Windows.Forms.PictureBox picOBSStatus;
        private System.Windows.Forms.Button btnTestOBS;
    }
}