using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form2 : MaterialForm
    {
        private const string ConnectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

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

        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            // Создать и отобразить новую форму Form1
            Auth mainForm = new Auth();
            mainForm.Show();

            // Закрыть текущую форму Form2
            this.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string login = materialTextBox21.Text;
            string password = materialTextBox22.Text;
            string surname = materialTextBox23.Text;
            string name = materialTextBox24.Text;
            string patronymic = materialTextBox25.Text;
            DateTime dateofbirth = dateTimePicker1.Value; // Замените это на актуальную дату рождения

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(patronymic))
            {
                MaterialMessageBox.Show("Пожалуйста, заполните все поля.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (login.Length < 5)
            {
                MaterialMessageBox.Show("Логин слишком короткий. Минимальная длина - 5 символов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка наличия недопустимых символов в логине или пароле
            if (!IsInputValid(login) || !IsInputValid(password))
            {
                MaterialMessageBox.Show("Логин и пароль могут содержать только латинские буквы, цифры и символ подчеркивания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Пользователи (Логин, Пароль, Фамилия, Имя, Отчество, ДатаРождения) VALUES (@login, @password, @surname, @name, @patronymic, @dateofbirth)";
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@patronymic", patronymic);
                    cmd.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MaterialMessageBox.Show("Пользователь успешно зарегистрирован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        materialTextBox21.Clear();
                        materialTextBox22.Clear();
                        materialTextBox23.Clear();
                        materialTextBox24.Clear();
                        materialTextBox25.Clear();
                        this.Close();
                    }
                    else
                    {
                        MaterialMessageBox.Show("Не удалось зарегистрировать пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Перейти на Form1
            Auth mainForm = new Auth();
            mainForm.Show();

            // Закрыть текущую Form2
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }
    }
}
