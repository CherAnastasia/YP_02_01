using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CherA
{
    public partial class Опрос : Form
    {
        private int id;
        private string name;
        private int role;
        public Опрос(int UserID, int UserRole)
        {
            id = UserID;
            role = UserRole;
            InitializeComponent();
        }
        public Опрос()
        {
            InitializeComponent();
        }
        private void Опрос_Load(object sender, EventArgs e)
        {
            string url = "https://www.purina.ru/find-a-pet/articles/getting-a-cat/adoption/the-most-beautiful-cats?ysclid=m35nk7rpa7859207845";
            GenerationQRCode(url);
        }
        private void GenerationQRCode(string url)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrCodeGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode=new QRCode(qRCodeData);
            Bitmap qrCodeImage = qRCode.GetGraphic(3);
            pictureBox1.Image = qrCodeImage;
        }
        private void Опрос_FormClosing(object sender, FormClosingEventArgs e)
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


    }
}
