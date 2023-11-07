using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class AdminForm : MaterialForm
    {
        bool sidebarExpand;

        public AdminForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public void loadform(object Form)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(f);
            this.panel3.Tag = f;
            f.Show();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            loadform(new Product());
        }

        private void materialButton10_Click_1(object sender, EventArgs e)
        {
            Auth avt = new Auth();
            avt.ShowDialog();
            this.Close();
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            loadform(new Employees());
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            loadform(new JobTitles());
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            loadform(new Supplies());
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            loadform(new Divisions());
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            loadform(new Clients());
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            loadform(new OrderHistory());
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            loadform(new Orders());
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            loadform(new Users());
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            backup.ShowDialog();  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loadform(new Orders());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            loadform(new OrderHistory());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            loadform(new Clients());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            loadform(new Divisions());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            loadform(new Supplies());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            loadform(new JobTitles());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            loadform(new Employees());
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            loadform(new Product());
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            backup.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            loadform(new Users());
        }
    }
}
