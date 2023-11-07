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
    public partial class OrderHistoryChange : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public OrderHistoryChange()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void OrderHistoryChange_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(materialTextBox22.Text);
            int iz = Convert.ToInt32(materialTextBox23.Text);
            int it = Convert.ToInt32(materialTextBox21.Text);
            int kol = Convert.ToInt32(materialTextBox25.Text);
            string sum = materialTextBox24.Text;

            // Запрос на обновление данных в SQL
            string updateQuery = "UPDATE ИсторияЗаказов SET ИдентификаторЗаказа = @iz, ИдентификаторТовара = @it, КоличествоТовара = @kol, Сумма = @sum WHERE ИдентификаторЗаписи = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@iz", iz);
                    cmd.Parameters.AddWithValue("@it", it);
                    cmd.Parameters.AddWithValue("@kol", kol);
                    cmd.Parameters.AddWithValue("@sum", sum);
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Данные успешно обновлены
                            MaterialMessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show("Ошибка при обновлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
