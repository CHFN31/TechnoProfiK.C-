namespace WindowsFormsApp14
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialButton10 = new MaterialSkin.Controls.MaterialButton();
            this.sidebar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.materialButton9 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(210, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 589);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox13);
            this.panel2.Controls.Add(this.materialButton10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(210, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 100);
            this.panel2.TabIndex = 4;
            // 
            // materialButton10
            // 
            this.materialButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton10.AutoSize = false;
            this.materialButton10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton10.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton10.Depth = 0;
            this.materialButton10.HighEmphasis = true;
            this.materialButton10.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton10.Icon")));
            this.materialButton10.Location = new System.Drawing.Point(565, 28);
            this.materialButton10.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton10.Name = "materialButton10";
            this.materialButton10.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton10.Size = new System.Drawing.Size(95, 44);
            this.materialButton10.TabIndex = 12;
            this.materialButton10.Text = "Выйти";
            this.materialButton10.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton10.UseAccentColor = false;
            this.materialButton10.UseVisualStyleBackColor = true;
            this.materialButton10.Click += new System.EventHandler(this.materialButton10_Click);
            // 
            // sidebar
            // 
            this.sidebar.Controls.Add(this.pictureBox1);
            this.sidebar.Controls.Add(this.menuButton);
            this.sidebar.Controls.Add(this.pictureBox9);
            this.sidebar.Controls.Add(this.pictureBox2);
            this.sidebar.Controls.Add(this.materialButton9);
            this.sidebar.Controls.Add(this.materialButton2);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(3, 64);
            this.sidebar.MaximumSize = new System.Drawing.Size(207, 1189);
            this.sidebar.MinimumSize = new System.Drawing.Size(55, 689);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(207, 689);
            this.sidebar.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuButton
            // 
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.Location = new System.Drawing.Point(6, 28);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(44, 44);
            this.menuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuButton.TabIndex = 11;
            this.menuButton.TabStop = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(6, 252);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(43, 44);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 19;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 202);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // materialButton9
            // 
            this.materialButton9.AutoSize = false;
            this.materialButton9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton9.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton9.Depth = 0;
            this.materialButton9.HighEmphasis = true;
            this.materialButton9.Icon = null;
            this.materialButton9.Location = new System.Drawing.Point(60, 252);
            this.materialButton9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton9.Name = "materialButton9";
            this.materialButton9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton9.Size = new System.Drawing.Size(138, 36);
            this.materialButton9.TabIndex = 9;
            this.materialButton9.Text = "Товары";
            this.materialButton9.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton9.UseAccentColor = false;
            this.materialButton9.UseVisualStyleBackColor = true;
            this.materialButton9.Click += new System.EventHandler(this.materialButton9_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(60, 207);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(138, 36);
            this.materialButton2.TabIndex = 2;
            this.materialButton2.Text = "Мои заказы";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hierarchicalstructure_78922.png");
            this.imageList1.Images.SetKeyName(1, "relief_goods_box_icon_148329.png");
            this.imageList1.Images.SetKeyName(2, "construction_constructor_hat_helmet_protection_worker_icon_153245.png");
            this.imageList1.Images.SetKeyName(3, "shipment_shipments_package_delivery_box_ecommerce_icon_224941.png");
            this.imageList1.Images.SetKeyName(4, "effective_employees_users_team_group_icon_152042.png");
            this.imageList1.Images.SetKeyName(5, "usersgroup_99737.png");
            this.imageList1.Images.SetKeyName(6, "Past_icon-icons.com_55841.png");
            this.imageList1.Images.SetKeyName(7, "ic-past-orders_97638.png");
            this.imageList1.Images.SetKeyName(8, "find_users_applications_search_2908.png");
            this.imageList1.Images.SetKeyName(9, "round-account-button-with-user-inside_icon-icons.com_72596.png");
            // 
            // pictureBox13
            // 
            this.pictureBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox13.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(667, 28);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(43, 44);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 26;
            this.pictureBox13.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 756);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТехноПрофи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.panel2.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialButton materialButton10;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialButton materialButton9;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox13;
    }
}