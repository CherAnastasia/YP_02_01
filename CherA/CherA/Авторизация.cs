using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CherA
{
    public partial class Авторизация : Form
    {
        private string text = String.Empty;
        private int numCAPTCHA = 0;
        public Авторизация()
        {
            InitializeComponent();
        }
        private void Авторизация_Load(object sender, EventArgs e)
        {
            MaximumSize = new System.Drawing.Size(343, 180);
            MinimumSize = new System.Drawing.Size(343, 180);
            textBox2.UseSystemPasswordChar = true;
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            this.TopMost = true;
        }
        private void Авторизация_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Application.Exit();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool valuesLogin = false;
                string name = @"Data Source=ADCLG1; Initial catalog=CherA;Integrated Security=True";
                //string name = @"Data Source=LAPTOP-RIOBEMI6; Initial catalog=CherA;Integrated Security=True";
                SqlConnection MyConnection = new SqlConnection(name);
                MyConnection.Open();
                if ((textBox1.Text == "") || (textBox2.Text == "")) { MessageBox.Show("Заполните поля!","Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly); }
                else
                {
                    string ComDel = $"select UserID from Users where Login=N\'{textBox1.Text}\' and Password = N\'{textBox2.Text}\'";
                    SqlCommand cmd1 = new SqlCommand(ComDel, MyConnection);
                    string id = cmd1.ExecuteScalar()==null ? string.Empty : cmd1.ExecuteScalar().ToString();
                    if (id != "")
                    {
                        ComDel = $"select Type from Users where UserID=N\'{id}\'";
                        SqlCommand cmd3 = new SqlCommand(ComDel, MyConnection);
                        int role = Convert.ToInt32(cmd3.ExecuteScalar().ToString());
                        numCAPTCHA = 0;
                        valuesLogin = true;
                        Главная home = new Главная(id, role);
                        this.Hide();
                        home.Show();
                    }
                    else if (id == "")
                    {
                        numCAPTCHA++;
                        valuesLogin = false;
                        MaximumSize = new System.Drawing.Size(554, 195);
                        MinimumSize = new System.Drawing.Size(554, 195);
                        button1.Enabled = false;
                        MessageBox.Show("Неверный логин или пароль. Напишите в поле символы с картинки.", "Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
                        pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                        if (numCAPTCHA == 2)
                        {
                            MessageBox.Show("Слишком много неудачных попыток. Блокировка системы на 3 минуты.", "Ошибка!",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
                            timer1.Interval = 1000;
                            button3.Enabled = false;
                            timer1.Start();
                        }
                        else if (numCAPTCHA > 2)
                        {
                            DialogResult result = MessageBox.Show("Слишком много неудачных попыток. Полная блокировка системы. Перезапустить систему?", "Ошибка!",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information);
                            if (result == DialogResult.Yes)
                            {
                                Application.Restart();
                                this.TopMost = true;
                            }
                            this.TopMost = true;
                            this.Enabled = false;
                        }
                    }
                     ComDel = $"Insert into HistoryLogin ([Login],[DateLogin],[Suc/NotSuc]) values" +
                        $"(N\'{textBox1.Text}\',N\'{DateTime.Today}\',N\'{valuesLogin}\')";
                    SqlCommand cmd2 = new SqlCommand(ComDel, MyConnection);
                    cmd2.ExecuteNonQuery();
                }
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "Ошибка!", 
                     MessageBoxButtons.OK, 
                     MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }
      private Bitmap CreateImage(int Width, int Height)
        {
              Random rnd = new Random();
            Bitmap result = new Bitmap(Width, Height);
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };
            Graphics g = Graphics.FromImage((Image)result);
            g.Clear(Color.Gray);
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));
            g.DrawLine(Pens.Black,
                          new Point(0, 0),
                          new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }
        private void button3_Click(object sender, EventArgs e)
        {
           if (textBox3.Text == this.text)
            {
                button1.Enabled = true;
                MaximumSize = new System.Drawing.Size(343, 180);
                MinimumSize = new System.Drawing.Size(343, 180);
            }
            else
            {
                MessageBox.Show("Символы введены неверно.", "Ошибка!",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            button3.Enabled = true;
        }
    }
}
