using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CherA
{
    public partial class Редактирование : Form
    {
        private string name;
        private int id;
        private int role;
        private int requestsID;
        private string sql;
        public Редактирование(int UserID, int UserRole, int RequestsID)
        {
            id = UserID;
            role = UserRole;
            requestsID = RequestsID;
            InitializeComponent();
        }
        public Редактирование()
        {
            InitializeComponent();
        }
        private void Редактирование_Load(object sender, EventArgs e)
        {
            try
            {
                name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
                //name = @"Data Source=LAPTOP-RIOBEMI6; Initial catalog=CherA;Integrated Security=True";
                label4.Visible = false;
                maskedTextBox1.Visible = false;
                if (role == 1||role == 3)
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label6.Visible = false;
                    textBox1.Visible = false;
                    comboBox3.Visible = false;
                    comboBox2.Visible = false;
                    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    SqlConnection MyConnection = new SqlConnection(name);
                    MyConnection.Open();
                    sql = $"SELECT Surname from Users where Type=2";
                    SqlDataReader Reader1;
                    SqlCommand cmd1 = new SqlCommand(sql, MyConnection);
                    Reader1 = cmd1.ExecuteReader();
                    while (Reader1.Read())
                    {
                        comboBox1.Items.Add(Reader1[0].ToString());
                    }
                    MyConnection.Close();
                    if(role == 1)
                    {
                        label4.Visible = true;
                        maskedTextBox1.Visible = true;
                    }
                }
                if (role == 2)
                {
                    label5.Visible = false;
                    comboBox1.Visible = false;
                    this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                    SqlConnection MyConnection = new SqlConnection(name);
                    MyConnection.Open();
                    sql = $"SELECT RequestStatus from RequestStatus";
                    SqlDataReader Reader1;
                    SqlCommand cmd1 = new SqlCommand(sql, MyConnection);
                    Reader1 = cmd1.ExecuteReader();
                    while (Reader1.Read())
                    {
                        comboBox2.Items.Add(Reader1[0].ToString());
                    }
                    MyConnection.Close();
                    MyConnection.Open();
                    sql = $"SELECT Parts from Parts";
                    cmd1 = new SqlCommand(sql, MyConnection);
                    Reader1 = cmd1.ExecuteReader();
                    while (Reader1.Read())
                    {
                        comboBox3.Items.Add(Reader1[0].ToString());
                    }
                    MyConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
   
        }
        private void Редактирование_FormClosing(object sender, FormClosingEventArgs e)
        {
            ЗАЯВКИ req = new ЗАЯВКИ(id, role);
            this.Dispose();
            req.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                if(role == 1)
                {
                    if (comboBox1.Text != "")
                    {
                        string ComDel = $"select UserID from Users where Surname=N\'{comboBox1.Text}\'";
                        SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                        int masterlID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                        MyConnection.Close();
                        MyConnection.Open();
                        ComDel = $"update Requests set MasterID=N\'{masterlID}\' where [RequestID]=N\'{requestsID}\'";
                        cmd1 = new SqlCommand(ComDel, MyConnection);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Мастер добавлен!", "Сообщение",
MessageBoxButtons.OK,
MessageBoxIcon.Information);
                    }
                    if(maskedTextBox1.Text != "  .  .")
                    {
                        string ComDel = $"select CompletionData from Requests where [RequestID]=N\'{requestsID}\'";
                        SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                        string data = cmd1.ExecuteScalar() == null ? string.Empty : cmd1.ExecuteScalar().ToString();
                        MyConnection.Close();
                        if(data!="")
                        {
                            if (Convert.ToDateTime(data) < Convert.ToDateTime(maskedTextBox1.Text))
                            {
                                MyConnection.Open();
                                ComDel = $"update Requests set CompletionData=N\'{Convert.ToDateTime(maskedTextBox1.Text)}\' where [RequestID]=N\'{requestsID}\'";
                                cmd1 = new SqlCommand(ComDel, MyConnection);
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Дата отредаетирована!", "Сообщение",
MessageBoxButtons.OK,
MessageBoxIcon.Information);
                            }
                            else MessageBox.Show("Новая дата не может быть меньше предыдущей!", "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Мастер еще не назначил дату окончания!", "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Заполните поля!", "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                }
                if (role == 3)
                {
                    if (comboBox1.Text != "")
                    {
                        string ComDel = $"select UserID from Users where Surname=N\'{comboBox1.Text}\'";
                        SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                        int masterlID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                        MyConnection.Close();
                        MyConnection.Open();
                        ComDel = $"update Requests set MasterID=N\'{masterlID}\' where [RequestID]=N\'{requestsID}\'";
                        cmd1 = new SqlCommand(ComDel, MyConnection);
                        cmd1.ExecuteNonQuery();
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
                if (role == 2)
                {
                    if (comboBox2.Text != "" && textBox1.Text != "")
                    {
                        string ComDel = $"select RequestStatusID from RequestStatus where RequestStatus=N\'{comboBox2.Text}\'";
                        SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                        int requestStatusID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                        MyConnection.Close();
                        if (comboBox3.Text != "")
                        {
                            MyConnection.Open();
                            ComDel = $"select PartsID from Parts where Parts=N\'{comboBox3.Text}\'";
                            cmd1 = new SqlCommand(ComDel, MyConnection);
                            int partsID = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                            MyConnection.Close();
                            MyConnection.Open();
                            ComDel = $"update Requests set RequestStatusID=N\'{requestStatusID}\', RepairPartsID=N'{partsID}' where [RequestID]=N\'{requestsID}\'";
                            cmd1 = new SqlCommand(ComDel, MyConnection);
                            cmd1.ExecuteNonQuery();
                            MyConnection.Close();
                        }
                        else
                        {
                            MyConnection.Open();
                            ComDel = $"update Requests set RequestStatusID=N\'{requestStatusID}\' where [RequestID]=N\'{requestsID}\'";
                            cmd1 = new SqlCommand(ComDel, MyConnection);
                            cmd1.ExecuteNonQuery();
                            MyConnection.Close();
                        }
                        if (requestStatusID == 2)
                        {
                            MyConnection.Open();
                            ComDel = $"update Requests set CompletionData=N\'{DateTime.Today}\' where [RequestID]=N\'{requestsID}\'";
                            cmd1 = new SqlCommand(ComDel, MyConnection);
                            cmd1.ExecuteNonQuery();
                            MyConnection.Close();
                        }
                        MyConnection.Open();
                        ComDel = $"select count(*) from Comments where RequestID=N\'{requestsID}\'";
                        cmd1 = new SqlCommand(ComDel, MyConnection);
                        int countComment = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                        MyConnection.Close();
                        MyConnection.Open();
                        if (countComment == 0)
                            ComDel = $"Insert into Comments values (N\'{textBox1.Text}\',N\'{requestsID}\')";
                        else ComDel = $"update Comments set Message=N'{textBox1.Text}\'where [RequestID]=N\'{requestsID}\'";
                        cmd1 = new SqlCommand(ComDel, MyConnection);
                        cmd1.ExecuteNonQuery();
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
                MyConnection.Close();
            }
            catch (Exception ex)
            {
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
    }
}
