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
    public partial class ProductChange : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public ProductChange()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(materialTextBox21.Text);
            string name = materialTextBox22.Text;
            string kat = materialComboBox1.Text;
            string price = materialTextBox23.Text;
            int kol = Convert.ToInt32(materialTextBox24.Text);



            // Запрос на обновление данных в SQL
            string updateQuery = "UPDATE Товары SET НазваниеТовара = @name, КатегорияТовара = @kat, Цена = @price, НаличиеНаСкладе = @kol  WHERE ИдентификаторТовара = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@kat", kat);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@kol", kol);
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
