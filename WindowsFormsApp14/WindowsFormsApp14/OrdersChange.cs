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
    public partial class OrdersChange : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public OrdersChange()
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

        private void OrdersChange_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int iz = Convert.ToInt32(materialTextBox23.Text);
            DateTime date = dateTimePicker1.Value;
            string emp = materialTextBox25.Text;
            string sum = materialTextBox24.Text;

            // Запрос на обновление данных в SQL
            string updateQuery = "UPDATE Заказы SET ДатаЗаказа = @date, СотрудникОформившийЗаказ = @emp, ОбщаяСуммаЗаказа = @sum WHERE ИдентификаторЗаказа = @iz";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@emp", emp);
                    cmd.Parameters.AddWithValue("@sum", sum);
                    cmd.Parameters.AddWithValue("@iz", iz);

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
