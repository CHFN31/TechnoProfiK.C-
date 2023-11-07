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
    public partial class SuppliesDelete : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public SuppliesDelete()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void SuppliesDelete_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Получите название проекта для удаления
            string projectNameToDelete = materialTextBox21.Text;

            // Создайте SQL-запрос для удаления проекта
            string query = "DELETE FROM Поставки WHERE ИдентификаторПоставки = @id";

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
                        MaterialMessageBox.Show("Поставка успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                    else
                    {
                        MaterialMessageBox.Show("Поставка с указанным идентификатором не была найдена или произошла ошибка при удалении!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
