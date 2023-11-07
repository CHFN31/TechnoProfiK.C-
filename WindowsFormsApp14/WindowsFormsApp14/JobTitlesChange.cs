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
    public partial class JobTitlesChange : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public JobTitlesChange()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void JobTitlesChange_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(materialTextBox23.Text);
            string name = materialTextBox26.Text;
            string kon = materialTextBox22.Text;
            string mail = materialTextBox21.Text;
            string tel = materialTextBox24.Text;
            string adress = materialTextBox25.Text;

            // Запрос на обновление данных в SQL
            string updateQuery = "UPDATE Поставщики SET НазваниеКомпании = @name, КонтактноеЛицо = @kon, ЭлектроннаяПочта = @mail, Телефон = @tel, Адрес = @adress  WHERE ИдентификаторПоставщика = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@kon", kon);
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
