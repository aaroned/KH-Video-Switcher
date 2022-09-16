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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnZoom = new System.Windows.Forms.Button();
            this.btnOnlyM = new System.Windows.Forms.Button();
            this.btnJWLibrary = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 119);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnZoom
            // 
            this.btnZoom.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoom.ForeColor = System.Drawing.Color.White;
            this.btnZoom.Image = global::KH_Video_Switcher.Properties.Resources.Zoom;
            this.btnZoom.Location = new System.Drawing.Point(315, 3);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(151, 113);
            this.btnZoom.TabIndex = 2;
            this.btnZoom.Text = "Zoom (Talk/Demo)";
            this.btnZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnZoom.UseVisualStyleBackColor = false;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnOnlyM
            // 
            this.btnOnlyM.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOnlyM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOnlyM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnlyM.ForeColor = System.Drawing.Color.White;
            this.btnOnlyM.Image = global::KH_Video_Switcher.Properties.Resources.OnlyM;
            this.btnOnlyM.Location = new System.Drawing.Point(159, 3);
            this.btnOnlyM.Name = "btnOnlyM";
            this.btnOnlyM.Size = new System.Drawing.Size(150, 113);
            this.btnOnlyM.TabIndex = 1;
            this.btnOnlyM.Text = "OnlyM";
            this.btnOnlyM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOnlyM.UseVisualStyleBackColor = false;
            this.btnOnlyM.Click += new System.EventHandler(this.btnOnlyM_Click);
            // 
            // btnJWLibrary
            // 
            this.btnJWLibrary.BackColor = System.Drawing.Color.DarkRed;
            this.btnJWLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJWLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJWLibrary.ForeColor = System.Drawing.Color.White;
            this.btnJWLibrary.Image = global::KH_Video_Switcher.Properties.Resources.JWLibrary;
            this.btnJWLibrary.Location = new System.Drawing.Point(3, 3);
            this.btnJWLibrary.Name = "btnJWLibrary";
            this.btnJWLibrary.Size = new System.Drawing.Size(150, 113);
            this.btnJWLibrary.TabIndex = 0;
            this.btnJWLibrary.Text = "JW Library";
            this.btnJWLibrary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJWLibrary.UseVisualStyleBackColor = false;
            this.btnJWLibrary.Click += new System.EventHandler(this.btnJWLibrary_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 119);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "KH Switcher (Media)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Button btnOnlyM;
        private System.Windows.Forms.Button btnJWLibrary;
    }
}

