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
    public partial class ClientsChange : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public ClientsChange()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void ClientsChange_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(materialTextBox21.Text);
            string name = materialTextBox22.Text;
            string surname = materialTextBox23.Text;
            string mail = materialTextBox26.Text;
            string tel = materialTextBox25.Text;
            string adress = materialTextBox24.Text;

            // Запрос на обновление данных в SQL
            string updateQuery = "UPDATE Клиенты SET Имя = @name, Фамилия = @surname, ЭлектроннаяПочта = @mail, Телефон = @tel, Адрес = @adress WHERE ИдентификаторКлиента = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@tel", tel);
                    cmd.Parameters.AddWithValue("@adress", adress);
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
