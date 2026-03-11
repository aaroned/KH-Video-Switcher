namespace KH_Video_Switcher
{
    partial class frmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnZoom = new System.Windows.Forms.Button();
            this.btnOnlyM = new System.Windows.Forms.Button();
            this.btnJWLibrary = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWiki = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.serverStatusMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnZoom, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOnlyM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnJWLibrary, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 116);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnZoom
            // 
            this.btnZoom.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoom.FlatAppearance.BorderSize = 0;
            this.btnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoom.ForeColor = System.Drawing.Color.White;
            this.btnZoom.Image = global::KH_Video_Switcher.Properties.Resources.iconZoom;
            this.btnZoom.Location = new System.Drawing.Point(314, 3);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(148, 107);
            this.btnZoom.TabIndex = 2;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnZoom.UseVisualStyleBackColor = false;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnOnlyM
            // 
            this.btnOnlyM.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOnlyM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOnlyM.FlatAppearance.BorderSize = 0;
            this.btnOnlyM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnlyM.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnlyM.ForeColor = System.Drawing.Color.White;
            this.btnOnlyM.Image = global::KH_Video_Switcher.Properties.Resources.iconOnlyM;
            this.btnOnlyM.Location = new System.Drawing.Point(160, 3);
            this.btnOnlyM.Name = "btnOnlyM";
            this.btnOnlyM.Size = new System.Drawing.Size(148, 107);
            this.btnOnlyM.TabIndex = 1;
            this.btnOnlyM.Text = "OnlyM";
            this.btnOnlyM.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOnlyM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOnlyM.UseVisualStyleBackColor = false;
            this.btnOnlyM.Click += new System.EventHandler(this.btnOnlyM_Click);
            // 
            // btnJWLibrary
            // 
            this.btnJWLibrary.BackColor = System.Drawing.Color.Firebrick;
            this.btnJWLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJWLibrary.FlatAppearance.BorderSize = 0;
            this.btnJWLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJWLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJWLibrary.ForeColor = System.Drawing.Color.White;
            this.btnJWLibrary.Image = global::KH_Video_Switcher.Properties.Resources.iconJW;
            this.btnJWLibrary.Location = new System.Drawing.Point(6, 3);
            this.btnJWLibrary.Name = "btnJWLibrary";
            this.btnJWLibrary.Size = new System.Drawing.Size(148, 107);
            this.btnJWLibrary.TabIndex = 0;
            this.btnJWLibrary.Text = "JW Library";
            this.btnJWLibrary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJWLibrary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJWLibrary.UseVisualStyleBackColor = false;
            this.btnJWLibrary.Click += new System.EventHandler(this.btnJWLibrary_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemHelp,
            this.serverStatusMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(468, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUpdate,
            this.menuItemSettings,
            this.toolStripMenuItem1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 22);
            this.menuItemFile.Text = "File";
            // 
            // menuItemUpdate
            // 
            this.menuItemUpdate.Image = global::KH_Video_Switcher.Properties.Resources.refresh_square;
            this.menuItemUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemUpdate.Name = "menuItemUpdate";
            this.menuItemUpdate.Size = new System.Drawing.Size(180, 22);
            this.menuItemUpdate.Text = "Check for Updates...";
            this.menuItemUpdate.Click += new System.EventHandler(this.menuItemUpdate_Click);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Image = global::KH_Video_Switcher.Properties.Resources.settings;
            this.menuItemSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(180, 22);
            this.menuItemSettings.Text = "Settings";
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::KH_Video_Switcher.Properties.Resources.close_square;
            this.menuItemExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExit.Size = new System.Drawing.Size(180, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLog,
            this.menuItemWiki,
            this.menuItemAbout});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 22);
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemLog
            // 
            this.menuItemLog.Image = global::KH_Video_Switcher.Properties.Resources.document_text;
            this.menuItemLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemLog.Name = "menuItemLog";
            this.menuItemLog.Size = new System.Drawing.Size(135, 22);
            this.menuItemLog.Text = "View Log";
            this.menuItemLog.Click += new System.EventHandler(this.menuItemLog_Click);
            // 
            // menuItemWiki
            // 
            this.menuItemWiki.Image = global::KH_Video_Switcher.Properties.Resources.question_circle_16;
            this.menuItemWiki.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemWiki.Name = "menuItemWiki";
            this.menuItemWiki.Size = new System.Drawing.Size(135, 22);
            this.menuItemWiki.Text = "Online Wiki";
            this.menuItemWiki.Click += new System.EventHandler(this.menuItemWiki_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Image = global::KH_Video_Switcher.Properties.Resources.info_circle;
            this.menuItemAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(135, 22);
            this.menuItemAbout.Text = "About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // serverStatusMenu
            // 
            this.serverStatusMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.serverStatusMenu.BackColor = System.Drawing.Color.MistyRose;
            this.serverStatusMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverStatusMenu.ForeColor = System.Drawing.Color.Firebrick;
            this.serverStatusMenu.Image = global::KH_Video_Switcher.Properties.Resources.off_status_8px;
            this.serverStatusMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.serverStatusMenu.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.serverStatusMenu.Name = "serverStatusMenu";
            this.serverStatusMenu.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.serverStatusMenu.Size = new System.Drawing.Size(122, 22);
            this.serverStatusMenu.Text = "OBS Disconnected";
            this.serverStatusMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(468, 140);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(484, 179);
            this.Name = "frmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "KH Switcher (Media)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Button btnOnlyM;
        private System.Windows.Forms.Button btnJWLibrary;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem serverStatusMenu;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemWiki;
    }
}

