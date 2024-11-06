using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CAPTCHA_lib;

namespace CherA
{
    public partial class Добавление : Form
    {
        private string name;
        private int id;
        private int role;
        private int requestsID;
        public Добавление(int UserID, int UserRole)
        {
            id = UserID;
            role = UserRole;

            InitializeComponent();
            button2.Visible = false;
        }
        public Добавление(int UserID, int UserRole, int RequestsID)
        {
            id = UserID;
            role = UserRole;
            requestsID = RequestsID;
            InitializeComponent();
            button1.Visible = false;
        }
        public Добавление()
        {
            InitializeComponent();
        }

        private void Добавление_Load(object sender, EventArgs e)
        {
            try
            {
                name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
               // name = @"Data Source=LAPTOP-RIOBEMI6; Initial catalog=CherA;Integrated Security=True";
                this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.Enabled = false;
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                string sql = $"SELECT ProblemDescryption FROM ProblemDescryption";
                SqlCommand cmd2 = new SqlCommand(sql, MyConnection);
                SqlDataReader Reader1 = cmd2.ExecuteReader();
                while (Reader1.Read())
                {
                    comboBox2.Items.Add(Reader1[0].ToString());
                }
                MyConnection.Close();
                MyConnection.Open();
                sql = $"SELECT ClimateTechType FROM ClimateTechType";
                SqlCommand cmd3 = new SqlCommand(sql, MyConnection);
                Reader1 = cmd3.ExecuteReader();
                while (Reader1.Read())
                {
                    comboBox3.Items.Add(Reader1[0].ToString());
                }
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
        private void Добавление_FormClosing(object sender, FormClosingEventArgs e)
        {
            ЗАЯВКИ req = new ЗАЯВКИ(id, role);
            this.Dispose();
            req.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    SqlConnection MyConnection = new SqlConnection(name);
                    MyConnection.Open();
                    string ComDel = $"select ClimateTechModelID from ClimateTechModel where ClimateTechModel=N\'{comboBox1.Text}\'";
                    SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                    int modelID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                    MyConnection.Close();
                    MyConnection.Open();
                    string ComDel1 = $"select ProblemDescryptionID from ProblemDescryption where ProblemDescryption=N\'{comboBox2.Text}\'";
                    SqlCommand cmd2 = new SqlCommand(ComDel1, MyConnection);
                    int problemlID = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
                    MyConnection.Close();
                    MyConnection.Open();
                    string ComDel2 = $"Insert into Requests ([StartDate],[ClimateTechModelID],[ProblemDescryptionID], [RequestStatusID],[clientID]) values " +
                        $"(N\'{DateTime.Today}\',N\'{modelID}\',N\'{problemlID}\',N\'{3}\',N\'{id}\')";
                    SqlCommand cmd3 = new SqlCommand(ComDel2, MyConnection);
                    cmd3.ExecuteNonQuery();
                    MyConnection.Close();
                    MessageBox.Show("Успешно добавлено!", "Сообщение",
MessageBoxButtons.OK,
MessageBoxIcon.Information);
                    ЗАЯВКИ req = new ЗАЯВКИ(id, role);
                    this.Dispose();
                    req.Show();
                }
                else MessageBox.Show("Заполните поля!", "Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }

        }

        private void нАЗАДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ЗАЯВКИ req = new ЗАЯВКИ(id, role);
            this.Dispose();
            req.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Enabled = true;
                comboBox1.Items.Clear();
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                string ComDel = $"select ClimateTechTypeID from ClimateTechType where ClimateTechType=N\'{comboBox3.Text}\'";
                SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                int modelTypeID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                MyConnection.Close();
                MyConnection.Open();
                SqlDataReader Reader1;
                string sql = $"SELECT ClimateTechModel FROM ClimateTechModel where ClimateTechTypeID=N\'{modelTypeID}\'";
                SqlCommand cmd2 = new SqlCommand(sql, MyConnection);
                Reader1 = cmd2.ExecuteReader();
                while (Reader1.Read())
                {
                    comboBox1.Items.Add(Reader1[0].ToString());
                }
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {

                    SqlConnection MyConnection = new SqlConnection(name);
                    MyConnection.Open();
                    string ComDel = $"select ClimateTechModelID from ClimateTechModel where ClimateTechModel=N\'{comboBox1.Text}\'";
                    SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                    int modelID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                    MyConnection.Close();
                    MyConnection.Open();
                    string ComDel1 = $"select ProblemDescryptionID from ProblemDescryption where ProblemDescryption=N\'{comboBox2.Text}\'";
                    SqlCommand cmd2 = new SqlCommand(ComDel1, MyConnection);
                    int problemlID = Convert.ToInt32(cmd2.ExecuteScalar().ToString());
                    MyConnection.Close();
                    MyConnection.Open();
                    string ComDel2 = $"update Requests  set [ClimateTechModelID]=N'{modelID}',[ProblemDescryptionID]=N'{problemlID}' where [RequestID]=N\'{requestsID}\'";
                    SqlCommand cmd3 = new SqlCommand(ComDel2, MyConnection);
                    cmd3.ExecuteNonQuery();
                    MyConnection.Close();
                    MessageBox.Show("Успешно отредактированно!", "Сообщение",
MessageBoxButtons.OK,
MessageBoxIcon.Information);
                    ЗАЯВКИ req = new ЗАЯВКИ(id, role);
                    this.Dispose();
                    req.Show();
                }
                else MessageBox.Show("Заполните поля!", "Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
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
