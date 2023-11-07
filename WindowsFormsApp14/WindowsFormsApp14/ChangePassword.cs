using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class ChangePassword : MaterialForm
    {
        public ChangePassword()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string login = materialTextBox21.Text;
            string mail = materialTextBox22.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(mail))
            {
                MaterialMessageBox.Show("Пожалуйста, заполните все поля.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string senderEmail = "technoprofi31@mail.ru";
            string appPassword = "ps4aJnmJ7cdymbHgBWqx"; // Ваш пароль для приложения
            string recipientEmail = materialTextBox22.Text;
            string newPassword = GenerateRandomPassword();

            // Получите логин из текстового поля
            string loginToReset = materialTextBox21.Text;

            // Здесь вы должны выполнить запрос к базе данных, чтобы проверить существование логина
            // Вам понадобится подключение к базе данных и выполнение SQL-запроса

            // Пример подключения к базе данных
            string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для проверки существования логина
                string query = "SELECT COUNT(*) FROM Пользователи WHERE Логин = @LoginToReset";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoginToReset", loginToReset);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Логин существует в базе данных, продолжите с отправкой письма и обновлением пароля
                        try
                        {
                            using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                            {
                                smtpClient.Port = smtpPort;
                                smtpClient.Credentials = new NetworkCredential(senderEmail, appPassword); // Используйте пароль для приложения
                                smtpClient.EnableSsl = true;

                                using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
                                {
                                    mailMessage.Subject = "Восстановление пароля";
                                    mailMessage.Body = "Ваш новый пароль: " + newPassword;

                                    smtpClient.Send(mailMessage);
                                }

                                // Обновите пароль в базе данных
                                UpdatePasswordInDatabase(loginToReset, newPassword);

                                MaterialMessageBox.Show("Письмо с новым паролем отправлено на указанный адрес электронной почты!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MaterialMessageBox.Show("Ошибка при отправке письма: " + ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MaterialMessageBox.Show("Логин не найден в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdatePasswordInDatabase(string login, string newPassword)
        {
            // Здесь вы должны выполнить SQL-запрос для обновления пароля
            // Например, что-то вроде:
            // UPDATE Пользователи SET Пароль = @NewPassword WHERE Логин = @Login

            // Пример подключения к базе данных
            string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE Пользователи SET Пароль = @NewPassword WHERE Логин = @Login";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.ExecuteNonQuery();
                }
            }
        }

        private string GenerateRandomPassword()
        {
            // Генерируйте случайный пароль из 8 символов
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
