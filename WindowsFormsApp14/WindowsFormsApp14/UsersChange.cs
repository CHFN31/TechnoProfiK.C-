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
    public partial class UsersChange : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public UsersChange()
        {
            InitializeComponent();

            // Устанавливаем формат DateTimePicker на "DateTime"
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy"; // Можно выбрать нужный формат
            dateTimePicker1.ShowUpDown = true;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void UsersChange_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(materialTextBox26.Text);
            string login = materialTextBox25.Text;
            string pass = materialTextBox24.Text;
            string role = materialComboBox1.Text;
            string name = materialTextBox21.Text;
            string surname = materialTextBox22.Text;
            string patronymic = materialTextBox23.Text;
            DateTime date = dateTimePicker1.Value;

            // Запрос на обновление данных в SQL
            string updateQuery = "UPDATE Пользователи SET Логин = @login, Пароль = @pass, Роль = @role Имя = @name, Фамилия = @surname, Отчество = @patronymic, ДатаРождения = @date WHERE ИдентификаторПользователя = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@patronymic", patronymic);
                    cmd.Parameters.AddWithValue("@date", date);
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
