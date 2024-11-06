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
using System.Xml.Linq;

namespace CherA
{
    public partial class Запчасти : Form
    {
        private int id;
        public Запчасти(int UserID)
        {
            id = UserID;
            InitializeComponent();
        }
        public Запчасти()
        {
            InitializeComponent();
        }
        private void Запчасти_Load(object sender, EventArgs e)
        {
            try
            {
                string name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                string sql = $"SELECT * FROM Parts";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MyConnection.Close();
                dataGridView1.DataSource = ds.Tables[0];
                MyConnection.Open();
                string ComDel = $"SELECT count(*) FROM  Parts";
                SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                string d = cmd1.ExecuteScalar().ToString();
                statusStrip1.Items[0].Text = "Всего записей: " + d;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
        private void Запчасти_FormClosing(object sender, FormClosingEventArgs e)//метод закрытия формы
        {
           /* Главная home = new Главная(Convert.ToString(id));
            this.Dispose();
            home.Show();*/
        }
        private void нАЗАДToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Главная home = new Главная(Convert.ToString(id));
            this.Dispose();
            home.Show();*/
        }
    }
}
