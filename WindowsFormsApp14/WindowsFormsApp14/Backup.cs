using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Backup : MaterialForm
    {
        public Backup()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL Server Backup Files (.bak)|.bak";
            saveFileDialog.FileName = "DatabaseBuisnessProcess.bak";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";
                string backupPath = saveFileDialog.FileName;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"BACKUP DATABASE BuisnessProcess TO DISK = '{backupPath}'";

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MaterialMessageBox.Show("Резервная копия успешно создана.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MaterialMessageBox.Show("Ошибка при создании резервной копии: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
