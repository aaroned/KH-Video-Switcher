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
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.labelBtnDescription = new System.Windows.Forms.Label();
            this.labelChooseBtn = new System.Windows.Forms.Label();
            this.checkBoxZoomView = new System.Windows.Forms.CheckBox();
            this.checkBoxOnlyMView = new System.Windows.Forms.CheckBox();
            this.checkBoxJWView = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.comboBoxDisplays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOBS = new System.Windows.Forms.TabPage();
            this.groupBoxOBS = new System.Windows.Forms.GroupBox();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.labelStatusOBS = new System.Windows.Forms.Label();
            this.labelStatusLight = new System.Windows.Forms.Label();
            this.btnShowOBSPASS = new System.Windows.Forms.Button();
            this.textBoxOBSPASS = new System.Windows.Forms.TextBox();
            this.labelOBSPASS = new System.Windows.Forms.Label();
            this.textBoxOBSURL = new System.Windows.Forms.TextBox();
            this.labelOBSURL = new System.Windows.Forms.Label();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.btnGithub = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.checkBoxUpdateStart = new System.Windows.Forms.CheckBox();
            this.btnUpdates = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelTopMost = new System.Windows.Forms.Label();
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            this.tabOBS.SuspendLayout();
            this.groupBoxOBS.SuspendLayout();
            this.tabUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabOBS);
            this.tabControl1.Controls.Add(this.tabUpdate);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 308);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBoxView);
            this.tabGeneral.Controls.Add(this.groupBoxDisplay);
            this.tabGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(352, 282);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.checkBoxTopMost);
            this.groupBoxView.Controls.Add(this.labelTopMost);
            this.groupBoxView.Controls.Add(this.labelBtnDescription);
            this.groupBoxView.Controls.Add(this.labelChooseBtn);
            this.groupBoxView.Controls.Add(this.checkBoxZoomView);
            this.groupBoxView.Controls.Add(this.checkBoxOnlyMView);
            this.groupBoxView.Controls.Add(this.checkBoxJWView);
            this.groupBoxView.Location = new System.Drawing.Point(6, 125);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(340, 154);
            this.groupBoxView.TabIndex = 1;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "View Options";
            // 
            // labelBtnDescription
            // 
            this.labelBtnDescription.AutoSize = true;
            this.labelBtnDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelBtnDescription.Location = new System.Drawing.Point(18, 59);
            this.labelBtnDescription.Name = "labelBtnDescription";
            this.labelBtnDescription.Size = new System.Drawing.Size(299, 13);
            this.labelBtnDescription.TabIndex = 4;
            this.labelBtnDescription.Text = "Unchecking these buttons will remove them from the switcher.\r\n";
            // 
            // labelChooseBtn
            // 
            this.labelChooseBtn.AutoSize = true;
            this.labelChooseBtn.Location = new System.Drawing.Point(18, 22);
            this.labelChooseBtn.Name = "labelChooseBtn";
            this.labelChooseBtn.Size = new System.Drawing.Size(85, 13);
            this.labelChooseBtn.TabIndex = 3;
            this.labelChooseBtn.Text = "Choose Buttons:";
            // 
            // checkBoxZoomView
            // 
            this.checkBoxZoomView.AutoSize = true;
            this.checkBoxZoomView.Checked = true;
            this.checkBoxZoomView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZoomView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxZoomView.Location = new System.Drawing.Point(181, 39);
            this.checkBoxZoomView.Name = "checkBoxZoomView";
            this.checkBoxZoomView.Size = new System.Drawing.Size(50, 17);
            this.checkBoxZoomView.TabIndex = 2;
            this.checkBoxZoomView.Text = "Zoom";
            this.checkBoxZoomView.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnlyMView
            // 
            this.checkBoxOnlyMView.AutoSize = true;
            this.checkBoxOnlyMView.Checked = true;
            this.checkBoxOnlyMView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnlyMView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxOnlyMView.Location = new System.Drawing.Point(111, 39);
            this.checkBoxOnlyMView.Name = "checkBoxOnlyMView";
            this.checkBoxOnlyMView.Size = new System.Drawing.Size(53, 17);
            this.checkBoxOnlyMView.TabIndex = 1;
            this.checkBoxOnlyMView.Text = "OnlyM";
            this.checkBoxOnlyMView.UseVisualStyleBackColor = true;
            // 
            // checkBoxJWView
            // 
            this.checkBoxJWView.AutoSize = true;
            this.checkBoxJWView.Checked = true;
            this.checkBoxJWView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxJWView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxJWView.Location = new System.Drawing.Point(21, 38);
            this.checkBoxJWView.Name = "checkBoxJWView";
            this.checkBoxJWView.Size = new System.Drawing.Size(73, 17);
            this.checkBoxJWView.TabIndex = 0;
            this.checkBoxJWView.Text = "JW Library";
            this.checkBoxJWView.UseVisualStyleBackColor = true;
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.labelDisplay);
            this.groupBoxDisplay.Controls.Add(this.comboBoxDisplays);
            this.groupBoxDisplay.Controls.Add(this.label1);
            this.groupBoxDisplay.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(340, 113);
            this.groupBoxDisplay.TabIndex = 0;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display Selection";
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDisplay.Location = new System.Drawing.Point(18, 75);
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
            this.comboBoxDisplays.Location = new System.Drawing.Point(21, 46);
            this.comboBoxDisplays.Name = "comboBoxDisplays";
            this.comboBoxDisplays.Size = new System.Drawing.Size(313, 21);
            this.comboBoxDisplays.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
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
            this.tabOBS.Size = new System.Drawing.Size(352, 282);
            this.tabOBS.TabIndex = 1;
            this.tabOBS.Text = "OBS Connection";
            this.tabOBS.UseVisualStyleBackColor = true;
            // 
            // groupBoxOBS
            // 
            this.groupBoxOBS.Controls.Add(this.labelConnectionStatus);
            this.groupBoxOBS.Controls.Add(this.labelStatusOBS);
            this.groupBoxOBS.Controls.Add(this.labelStatusLight);
            this.groupBoxOBS.Controls.Add(this.btnShowOBSPASS);
            this.groupBoxOBS.Controls.Add(this.textBoxOBSPASS);
            this.groupBoxOBS.Controls.Add(this.labelOBSPASS);
            this.groupBoxOBS.Controls.Add(this.textBoxOBSURL);
            this.groupBoxOBS.Controls.Add(this.labelOBSURL);
            this.groupBoxOBS.Location = new System.Drawing.Point(6, 6);
            this.groupBoxOBS.Name = "groupBoxOBS";
            this.groupBoxOBS.Size = new System.Drawing.Size(343, 270);
            this.groupBoxOBS.TabIndex = 0;
            this.groupBoxOBS.TabStop = false;
            this.groupBoxOBS.Text = "OBS Websocket Server Settings:";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(20, 156);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(97, 13);
            this.labelConnectionStatus.TabIndex = 7;
            this.labelConnectionStatus.Text = "Connection Status:";
            // 
            // labelStatusOBS
            // 
            this.labelStatusOBS.AutoSize = true;
            this.labelStatusOBS.Location = new System.Drawing.Point(64, 187);
            this.labelStatusOBS.Name = "labelStatusOBS";
            this.labelStatusOBS.Size = new System.Drawing.Size(73, 13);
            this.labelStatusOBS.TabIndex = 6;
            this.labelStatusOBS.Text = "Disconnected";
            // 
            // labelStatusLight
            // 
            this.labelStatusLight.AutoSize = true;
            this.labelStatusLight.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusLight.ForeColor = System.Drawing.Color.Red;
            this.labelStatusLight.Location = new System.Drawing.Point(34, 182);
            this.labelStatusLight.Name = "labelStatusLight";
            this.labelStatusLight.Size = new System.Drawing.Size(24, 21);
            this.labelStatusLight.TabIndex = 5;
            this.labelStatusLight.Text = "●";
            this.labelStatusLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowOBSPASS
            // 
            this.btnShowOBSPASS.Location = new System.Drawing.Point(275, 115);
            this.btnShowOBSPASS.Name = "btnShowOBSPASS";
            this.btnShowOBSPASS.Size = new System.Drawing.Size(51, 20);
            this.btnShowOBSPASS.TabIndex = 4;
            this.btnShowOBSPASS.Text = "Show";
            this.btnShowOBSPASS.UseVisualStyleBackColor = true;
            this.btnShowOBSPASS.Click += new System.EventHandler(this.btnShowOBSPASS_Click);
            // 
            // textBoxOBSPASS
            // 
            this.textBoxOBSPASS.Location = new System.Drawing.Point(23, 115);
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
            this.textBoxOBSURL.Location = new System.Drawing.Point(23, 56);
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
            this.tabUpdate.Size = new System.Drawing.Size(352, 282);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "Update";
            this.tabUpdate.UseVisualStyleBackColor = true;
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
            this.checkBoxUpdateStart.Location = new System.Drawing.Point(95, 187);
            this.checkBoxUpdateStart.Name = "checkBoxUpdateStart";
            this.checkBoxUpdateStart.Size = new System.Drawing.Size(163, 17);
            this.checkBoxUpdateStart.TabIndex = 1;
            this.checkBoxUpdateStart.Text = "Check for updates on startup";
            this.checkBoxUpdateStart.UseVisualStyleBackColor = true;
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
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // labelTopMost
            // 
            this.labelTopMost.AutoSize = true;
            this.labelTopMost.Location = new System.Drawing.Point(18, 88);
            this.labelTopMost.Name = "labelTopMost";
            this.labelTopMost.Size = new System.Drawing.Size(90, 13);
            this.labelTopMost.TabIndex = 5;
            this.labelTopMost.Text = "Window Settings:";
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Checked = true;
            this.checkBoxTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTopMost.Location = new System.Drawing.Point(21, 105);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(208, 17);
            this.checkBoxTopMost.TabIndex = 6;
            this.checkBoxTopMost.Text = "Keep KH Switcher on top of other apps";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            // 
            // frmSettingsServer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
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
            this.Load += new System.EventHandler(this.frmSettingsServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            this.tabOBS.ResumeLayout(false);
            this.groupBoxOBS.ResumeLayout(false);
            this.groupBoxOBS.PerformLayout();
            this.tabUpdate.ResumeLayout(false);
            this.tabUpdate.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBoxJWView;
        private System.Windows.Forms.Label labelChooseBtn;
        private System.Windows.Forms.CheckBox checkBoxZoomView;
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
        private System.Windows.Forms.Label labelStatusOBS;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.Label labelTopMost;
    }
}