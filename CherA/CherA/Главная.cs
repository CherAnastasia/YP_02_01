using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CherA
{
    public partial class Главная : Form
    {
        private int id;
        private int role;
        private string name;
        public Главная(string UserID, int UserRole)
        {
            id=Convert.ToInt32(UserID);
            role = UserRole;
            InitializeComponent();
        }
        public Главная()
        {
            InitializeComponent();
        }
        private void Главная_Load(object sender, EventArgs e)
        {
            try
            {
                оПРОСToolStripMenuItem.Visible = false;
                if (role==4)
                {
                    оПРОСToolStripMenuItem.Visible = true;
                }
                SqlDataReader Reader1;
                name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
                //name = @"Data Source=LAPTOP-RIOBEMI6; Initial catalog=CherA;Integrated Security=True";
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                string ComDel = $"select Surname,Name from Users where UserID=N\'{id}\'";
                SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                Reader1 = cmd1.ExecuteReader();
                while (Reader1.Read())
                {
                    label1.Text = Reader1[0].ToString();
                    label1.Text += " " + Reader1[1].ToString();
                }
                MyConnection.Close();
                MyConnection = new SqlConnection(name);
                MyConnection.Open();
                ComDel = $"select Type from Users where UserID=N\'{id}\'";
                cmd1 = new SqlCommand(ComDel, MyConnection);
                int d = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                string ComDel1 = $"select Type from Type where TypeID=N\'{d}\'";
                SqlCommand cmd11 = new SqlCommand(ComDel1, MyConnection);
                label2.Text = cmd11.ExecuteScalar().ToString();
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void Главная_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ЗАЯВКИ req = new ЗАЯВКИ(id, role);
            this.Dispose();
            req.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ИсторияВхода his = new ИсторияВхода(id, role);
            this.Dispose();
            his.Show();
        }

        private void нАЗАДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            this.TopMost = true;
        }

        private void оПРОСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Опрос add = new Опрос(id, role);
            this.Dispose();
            add.Show();
        }
    }
}
