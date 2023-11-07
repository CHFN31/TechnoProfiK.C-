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
    public partial class EmployeesAdd : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public EmployeesAdd()
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

        private void EmployeesAdd_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string name = materialTextBox21.Text;
            string surname = materialTextBox22.Text;
            string job = materialComboBox1.Text;
            string mail = materialTextBox24.Text;
            string tel = materialTextBox25.Text;
            DateTime date = dateTimePicker1.Value;
            string money = materialTextBox27.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Сотрудники ( Имя, Фамилия, Должность, ЭлектроннаяПочта, Телефон, ДатаПриемаНаРаботу, Зарплата) " +
                                    "VALUES (@name, @surname, @job, @mail, @tel, @date, @money)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@job", job);
                        command.Parameters.AddWithValue("@mail", mail);
                        command.Parameters.AddWithValue("@tel", tel);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@money", money);


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
