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
    public partial class ProductDelete : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public ProductDelete()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Получите название проекта для удаления
            string projectNameToDelete = materialTextBox21.Text;

            // Создайте SQL-запрос для удаления проекта
            string query = "DELETE FROM Товары WHERE ИдентификаторТовара = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Параметризованный SQL-запрос для безопасности
                    cmd.Parameters.AddWithValue("@id", projectNameToDelete);

                    // Выполните SQL-запрос
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MaterialMessageBox.Show("Товар успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                    else
                    {
                        MaterialMessageBox.Show("Товар с указанным названием не был найден или произошла ошибка при удалении!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
