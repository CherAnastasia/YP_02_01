using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CherA
{
    public partial class ЗАЯВКИ : Form
    {
        private int id;
        private string name;
        private int role;
        int k;
        DataTable ds;
        public ЗАЯВКИ(int UserID, int UserRole)
        {
            id = UserID;
            role = UserRole;
            InitializeComponent();
        }
        public ЗАЯВКИ()
        {
            InitializeComponent();
        }

        private void ЗАЯВКИ_Load(object sender, EventArgs e)
        {
            try
            {
                if (role != 4)
                {
                    button1.Visible = false;
                }
                 name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
                //name = @"Data Source=LAPTOP-RIOBEMI6; Initial catalog=CherA;Integrated Security=True";
                this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                SqlDataReader Reader1;
                string sql;
                if (role == 4)
                {
                    sql = $"SELECT * FROM Request where clientID=N\'{id}\'";
                }
                else if (role == 2)
                {
                    sql = $"SELECT * FROM Request where MasterID=N'{id}'";
                }
                else
                {
                    sql = $"SELECT * FROM Request";
                }
                SqlCommand cmd1 = new SqlCommand(sql, MyConnection);
                Reader1 = cmd1.ExecuteReader();
                while (Reader1.Read())
                {
                    comboBox1.Items.Add(Reader1[0].ToString());
                }
                MyConnection.Close();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
        private void ЗАЯВКИ_FormClosing(object sender, FormClosingEventArgs e)
        {
            Главная home = new Главная(Convert.ToString(id), role);
            this.Dispose();
            home.Show();
        }
        public void LoadData()
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                string sql;
                if (role == 4)
                {
                    sql = $"SELECT * FROM Request where clientID=N\'{id}\'";
                }
                else if (role == 2)
                {
                    sql = $"SELECT * FROM Request where MasterID=N'{id}'";
                }
                else
                {
                    sql = $"SELECT * FROM Request";
                }
                SqlCommand cmd1 = new SqlCommand(sql, MyConnection);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                 ds = new DataTable();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                k = dataGridView1.Rows.Count;
                statusStrip1.Items[0].Text = "Всего записей: " + dataGridView1.Rows.Count + " из " + k;
                dataGridView1.Columns["RequestID"].HeaderText = "Номер заявки";
                dataGridView1.Columns["StartDate"].HeaderText = "Дата заявки";
                dataGridView1.Columns["ClimateTechModel"].HeaderText = "Модель оборудования";
                dataGridView1.Columns["ClimateTechType"].HeaderText = "Тип оборудования";
                dataGridView1.Columns["ProblemDescryption"].HeaderText = "Проблема";
                dataGridView1.Columns["RequestStatus"].HeaderText = "Статус заявки";
                dataGridView1.Columns["CompletionData"].HeaderText = "Дата окончания работ";
                dataGridView1.Columns["Parts"].HeaderText = "Купленные запчасти";
                dataGridView1.Columns["MasterID"].HeaderText = "Номер мастера";
                dataGridView1.Columns["masterSurname"].HeaderText = "Фамилия мастера";
                dataGridView1.Columns["clientID"].HeaderText = "Номер клиента";
                dataGridView1.Columns["clientSurname"].HeaderText = "Фамилия клиента";
                dataGridView1.Columns["Message"].HeaderText = "Сообщение мастера";
                MyConnection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Добавление add = new Добавление(id, role);
            this.Dispose();
            add.Show();
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
                    if (keyword.Length == 2) continue;
                    if (filter.Length > 0) filter += " AND ";
                    DateTime dateValue;
                    if (DateTime.TryParse(keyword, out dateValue)) filter += $"[StartDate]='{dateValue:yyyy-MM-dd}' OR [CompletionData]='{dateValue:yyyy-MM-dd}'";
                    else filter += $"[ClimateTechModel] LIKE '%{keyword}%' OR " +
                            $"[ClimateTechType] LIKE '%{keyword}%' OR " +
                            $"[ProblemDescryption] LIKE '%{keyword}%' OR " +
                            $"[RequestStatus] LIKE '%{keyword}%' OR " +
                            $"[Parts] LIKE '%{keyword}%' OR " +
                            $"[masterSurname] LIKE '%{keyword}%' OR " +
                            $"[clientSurname] LIKE '%{keyword}%' OR " +
                            $"[Message] LIKE '%{keyword}%'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (role != 4)
                {
                    if (comboBox1.Text != "")
                    {
                        Редактирование red = new Редактирование(id, role, Convert.ToInt32(comboBox1.Text));
                        this.Dispose();
                        red.Show();
                    }
                    else MessageBox.Show("Заполните поля!", "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                else
                {
                    Добавление add = new Добавление(id, role, Convert.ToInt32(comboBox1.Text));
                    this.Dispose();
                    add.Show();
                }
            }
            catch
            {
                MessageBox.Show("Выберите номер заявки!", "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }
        }
    }
}
