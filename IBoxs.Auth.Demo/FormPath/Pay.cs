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
    public partial class Pay : Form
    {
        SDK.result.PayCode payCode;
        public Pay(SDK.result.PayCode p)
        {
            InitializeComponent();
            payCode = p;
            pictureBox1.Image = payCode.payCodeImg;
            label4.Text = p.Order;
            label6.Text = p.Price.ToString();
            this.FormClosed += Pay_FormClosed;
        }

        private void Pay_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }
        static bool payBool = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (payBool) return;  //已支付就不再处理
            string order = payCode.Order;
            string msg, time;
            bool result = MainForm.authApi.GetPayState(order, out msg, out time);  //获取支付状态
            if (result)
            {
                payBool = true;
                MessageBox.Show("您于" + time + "支付成功并获得相应授权");
                this.Close();
                return;
            }
        }
    }
}
