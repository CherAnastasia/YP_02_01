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
    public partial class ТипПользователя : Form
    {
        private int id;
        public ТипПользователя(int UserID)
        {
            id = UserID;
            InitializeComponent();
        }
        public ТипПользователя()
        {
            InitializeComponent();
        }
        private void ТипПользователя_Load(object sender, EventArgs e)
        {

        }
        private void ТипПользователя_FormClosing(object sender, FormClosingEventArgs e)//метод закрытия формы
        {
            /*Главная home = new Главная(Convert.ToString(id));
            this.Hide();
            home.Show();*/
        }
        private void нАЗАДToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Главная home = new Главная(Convert.ToString(id));
            this.Hide();
            home.Show();*/
        }
    }
}
