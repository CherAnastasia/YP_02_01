using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CherA
{
    public partial class ИсторияВхода : Form
    {
        private int id;
        private int role;
        private string name;
        int k;
        DataTable ds;
        public ИсторияВхода(int UserID, int UserRole)
        {
            id = UserID;
            role = UserRole;
            InitializeComponent();
        }
        public ИсторияВхода()
        {
            InitializeComponent();
        }
        private void ИсторияВхода_Load(object sender, EventArgs e)
        {  
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
                //name = @"Data Source=LAPTOP-RIOBEMI6; Initial catalog=CherA;Integrated Security=True";
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                string sql = $"SELECT * FROM HistoryLogin";
                SqlCommand cmd1 = new SqlCommand(sql, MyConnection);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                 ds = new DataTable();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                k=dataGridView1.Rows.Count;
                statusStrip1.Items[0].Text = "Всего записей: " + dataGridView1.Rows.Count + " из " + k;
                dataGridView1.Columns["Login"].HeaderText = "Логин";
                dataGridView1.Columns["DateLogin"].HeaderText = "Дата входа";
                dataGridView1.Columns["Suc/NotSuc"].HeaderText = "Удачная?";
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
        private void ИсторияВхода_FormClosing(object sender, FormClosingEventArgs e)
        {
            Главная home = new Главная(Convert.ToString(id), role);
            this.Dispose();
            home.Show();
        }
        private void нАЗАДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Главная home = new Главная(Convert.ToString(id), role);
            this.Dispose();
            home.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string filter = "";
                string[] keywords = textBox1.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var keyword in keywords)
                {
                    if (filter.Length > 0) filter += " AND ";
                    filter += $"[Login] LIKE '%{keyword}%'";
                }
                DataView dataView = new DataView(ds);
                dataView.RowFilter = filter;
                dataGridView1.DataSource = dataView;
                statusStrip1.Items[0].Text = "Всего записей: " + dataGridView1.Rows.Count + " из " + k;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
    }
}
