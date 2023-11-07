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
    public partial class OrderHistoryAdd : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public OrderHistoryAdd()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void OrderHistoryAdd_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int iz = Convert.ToInt32(materialTextBox24.Text);
            int it = Convert.ToInt32(materialTextBox21.Text);
            int kol = Convert.ToInt32(materialTextBox22.Text);
            string sum = materialTextBox23.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO ИсторияЗаказов (ИдентификаторЗаказа, ИдентификаторТовара, КоличествоТовара, Сумма) " +
                                    "VALUES (@iz, @it, @kol, @sum)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@iz", iz);
                        command.Parameters.AddWithValue("@it", it);
                        command.Parameters.AddWithValue("@kol", kol);
                        command.Parameters.AddWithValue("@sum", sum);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MaterialMessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            MaterialMessageBox.Show("Ошибка при добавлении данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
