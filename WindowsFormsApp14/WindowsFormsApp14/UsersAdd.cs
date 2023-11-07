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
    public partial class UsersAdd : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public UsersAdd()
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

        private void UsersAdd_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string login = materialTextBox25.Text;
            string pass = materialTextBox24.Text;
            string role = materialComboBox1.Text;
            string name = materialTextBox21.Text;
            string surname = materialTextBox22.Text;
            string patronymic = materialTextBox23.Text;
            DateTime date = dateTimePicker1.Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Пользователи (Логин, Пароль, Роль, Имя, Фамилия, Отчество, ДатаРождения) " +
                                    "VALUES (@login, @pass, @name, @surname, @patronymic, date)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@pass", pass);
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@patronymic", patronymic);
                        command.Parameters.AddWithValue("@date", date);


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
