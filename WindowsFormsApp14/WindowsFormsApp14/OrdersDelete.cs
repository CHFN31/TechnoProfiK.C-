﻿using MaterialSkin;
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
    public partial class OrdersDelete : MaterialForm
    {
        private string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=BuisnessProcess;Integrated Security=True";

        public OrdersDelete()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void OrdersDelete_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Получите название проекта для удаления
            string projectNameToDelete = materialTextBox21.Text;

            // Создайте SQL-запрос для удаления проекта
            string query = "DELETE FROM Заказы WHERE ИдентификаторЗаказа = @iz";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Параметризованный SQL-запрос для безопасности
                    cmd.Parameters.AddWithValue("@iz", projectNameToDelete);

                    // Выполните SQL-запрос
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заказ успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Заказ с указанным идентификатором не был найден или произошла ошибка при удалении!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
