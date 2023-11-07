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
    public partial class DivisionsAdd : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public DivisionsAdd()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void DivisionsAdd_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string namediv = materialTextBox21.Text;
            string empldiv = materialTextBox22.Text;
            string desc = materialTextBox23.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Подразделения (НазваниеПоздразделения, РуководительПодразделения, Описание) " +
                                    "VALUES (@namediv, @empldiv, @desc)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@namediv", namediv);
                        command.Parameters.AddWithValue("@empldiv", empldiv);
                        command.Parameters.AddWithValue("@desc", desc);


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
