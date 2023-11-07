using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Auth : MaterialForm
    {
        private bool isPasswordVisible = true;

        private void TogglePasswordVisibility()
        {
            isPasswordVisible = !isPasswordVisible;
            materialTextBox22.UseSystemPasswordChar = !isPasswordVisible;
        }

        private bool IsInputValid(string input)
        {
            string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
            foreach (char c in input)
            {
                if (validCharacters.IndexOf(c) == -1 || !char.IsLetterOrDigit(c))
                {
                    return false; // Найден недопустимый символ
                }
            }
            return true; // Все символы допустимы
        }

        public Auth()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (!materialRadioButton1.Checked && !materialRadioButton2.Checked && !materialRadioButton3.Checked)
            {
                MaterialMessageBox.Show("Пожалуйста, выберите роль пользователя", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string login = materialTextBox21.Text;
            string password = materialTextBox22.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MaterialMessageBox.Show("Пожалуйста, заполните все поля.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsInputValid(login) || !IsInputValid(password))
            {
                MaterialMessageBox.Show("Логин и пароль могут содержать только латинские буквы, цифры и символ подчеркивания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка для администратора
            if (materialRadioButton1.Checked && login == "admin" && password == "admin11")
            {
                MaterialMessageBox.Show("Вход выполнен как: Администратор", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // Действия для администратора
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();
                this.Close(); // Закройте текущую форму
            }

            // Проверка для сотрудника
            else if (materialRadioButton2.Checked && login == "manager" && password == "manager11")
            {
                MaterialMessageBox.Show("Вход выполнен как: Сотрудник", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // Действия для сотрудника
                AdminForm employeeForm = new AdminForm();
                employeeForm.ShowDialog();
                this.Close(); // Закройте текущую форму
            }

            // Проверка для клиента
            if (materialRadioButton3.Checked)
            {
                // Здесь выполните код для подключения к базе данных и проверки пароля
                string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True"; // Замените на свою строку подключения
                string query = "SELECT Пароль FROM Пользователи WHERE Логин = @Login";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        string storedPassword = command.ExecuteScalar() as string;

                        if (storedPassword != null)
                        {
                            if (password == storedPassword)
                            {
                                MaterialMessageBox.Show("Вход выполнен как: Клиент", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                // Действия для клиента
                                ClientForm clientForm = new ClientForm();
                                clientForm.ShowDialog();
                                this.Close(); // Закройте текущую форму
                            }
                            else
                            {
                                MaterialMessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MaterialMessageBox.Show("Пользователь с таким логином не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }
    }
}
