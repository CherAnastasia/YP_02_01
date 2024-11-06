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
    public partial class Комментарии : Form
    {
        private int id;
        public Комментарии(int UserID)
        {
            id = UserID;
            InitializeComponent();
        }
        public Комментарии()
        {
            InitializeComponent();
        }
        private void Комментарии_Load(object sender, EventArgs e)
        {

        }
        private void Комментарии_FormClosing(object sender, FormClosingEventArgs e)//метод закрытия формы
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
