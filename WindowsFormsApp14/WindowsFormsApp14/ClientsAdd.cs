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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class ClientsAdd : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public ClientsAdd()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private bool IsNameValid(string name)
        {
            // Регулярное выражение для валидации имени и фамилии на русском
            string pattern = "^[А-Яа-яЁё\\s]+$";
            return Regex.IsMatch(name, pattern);
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) // Проверка на пустую строку
            {
                return false;
            }

            // Удаление из строки все символы, кроме цифр
            string numericPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Проверка, что номер телефона содержит от 1 до 11 цифр
            return numericPhoneNumber.Length >= 1 && numericPhoneNumber.Length <= 11;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string name = materialTextBox22.Text;
            string surname = materialTextBox23.Text;
            string mail = materialTextBox26.Text;
            string tel = materialTextBox25.Text;
            string adress = materialTextBox24.Text;

            bool hasError = false; // Переменная для отслеживания ошибок

            if (!IsNameValid(name))
            {
                MaterialMessageBox.Show("Введите корректное имя на русском", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                materialTextBox22.BackColor = Color.Red; // Установка красного фона
                return;
            }
            else
            {
                materialTextBox22.BackColor = Color.White; // Восстановление фона по умолчанию
            }

            if (!IsNameValid(surname))
            {
                MaterialMessageBox.Show("Введите корректную фамилию на русском", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                materialTextBox23.BackColor = Color.Red;
                return;
            }
            else
            {
                materialTextBox23.BackColor = Color.White;
            }

            if (!IsEmailValid(mail))
            {
                MaterialMessageBox.Show("Введите корректный адрес электронной почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                materialTextBox26.BackColor = Color.Red;
                return;
            }
            else
            {
                materialTextBox26.BackColor = Color.White;
            }

            if (!IsPhoneNumberValid(tel))
            {
                MaterialMessageBox.Show("Введите корректный номер телефона (до 11 цифр)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                materialTextBox25.BackColor = Color.Red;
                return;
            }
            else
            {
                materialTextBox25.BackColor = Color.White;
            }

            if (hasError)
            {
                MaterialMessageBox.Show("Пожалуйста, введите корректные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Клиенты (Имя, Фамилия, ЭлектроннаяПочта, Телефон, Адрес) " +
                                    "VALUES (@name, @surname, @mail, @tel, @adress)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@mail", mail);
                        command.Parameters.AddWithValue("@tel", tel);
                        command.Parameters.AddWithValue("@adress", adress);


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
