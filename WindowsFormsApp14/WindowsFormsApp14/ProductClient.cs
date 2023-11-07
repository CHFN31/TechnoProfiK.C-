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
    public partial class ProductClient : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";
        private DataTable dataTable; // Объявляем dataTable как поле класса, чтобы она была доступна везде

        public ProductClient()
        {
            InitializeComponent();
            // Вызов загрузки данных при загрузке формы
            LoadDataFromDatabase();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void LoadDataFromDatabase()
        {
            materialListView1.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT ИдентификаторТовара, НазваниеТовара, КатегорияТовара, Цена, НаличиеНаСкладе FROM Товары";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable = new DataTable();

                    // Создайте столбцы в DataTable с названиями из SQL-запроса
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataTable.Columns.Add(reader.GetName(i));
                    }

                    // Добавьте данные из SQL в DataTable
                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        dataTable.Rows.Add(row);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem lv = new ListViewItem(row[0].ToString());
                        for (int i = 1; i < dataTable.Columns.Count; i++)
                        {
                            lv.SubItems.Add(row[i].ToString());
                        }
                        materialListView1.Items.Add(lv);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            ProductClientBuy pcb = new ProductClientBuy();
            pcb.ShowDialog();
        }
    }
}
