using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBoxs.Auth.Demo.FormPath
{
    public partial class Card : Form
    {
        public Card()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string card = textBox1.Text.Trim();
            if (card.Length < 5)
            {
                MessageBox.Show("卡密不能为空");
                return;
            }
            string msg;
            if (MainForm.authApi.UseCard(card, Common.Userkey, out msg))
            {
                MessageBox.Show("兑换成功");
            }
            else
            {
                MessageBox.Show(msg);
            }
        }
    }
}
