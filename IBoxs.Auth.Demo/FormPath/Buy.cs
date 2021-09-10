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
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }

        List<SDK.result.AppGrade> appGrades = new List<SDK.result.AppGrade>();
        Dictionary<string, string> Times = new Dictionary<string, string>
        {
            {"1个月","1M" },
            {"3个月","3M" }
        };
        Dictionary<string, int> Grades = new Dictionary<string, int>();

        private void Buy_Load(object sender, EventArgs e)
        {
            appGrade();
            comboBox3.SelectedIndex = 0;
        }

        private void appGrade()
        {
            comboBox1.Items.Clear();
            appGrades = MainForm.authApi.GetGradeList();
            if (appGrades == null) return;
            for(int i=0;i<appGrades.Count;i++)
            {
                Grades.Add(appGrades[i].name, appGrades[i].grade);
                comboBox1.Items.Add(appGrades[i].name);
            }
            comboBox1.SelectedIndex = 0;
            /************************/
            comboBox2.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in Times)
            {
                comboBox2.Items.Add(kvp.Key);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            newPrice();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            newPrice();
        }

        private void newPrice()
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                return;
            string msg;
            SDK.result.AppPrice price= MainForm.authApi.GetPrice(Times[comboBox2.SelectedItem.ToString()], out msg, Grades[comboBox1.SelectedItem.ToString()]);
            if(price==null)
            {
                MessageBox.Show(msg);
                return;
            }
            label4.Text = price.price.ToString() + "元";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg;
            button1.Enabled = false;
            SDK.result.PayCode payCode= MainForm.authApi.GetPayCode(Common.Userkey, Times[comboBox2.SelectedItem.ToString()], (SDK.dataEnum.PayType)comboBox3.SelectedIndex, out msg, Grades[comboBox1.SelectedItem.ToString()]);
            if(msg!=null)
            {
                MessageBox.Show(msg);
                button1.Enabled = true;
                return;
            }
            Pay pay = new Pay(payCode);
            pay.ShowDialog();
            button1.Enabled = true;
        }
    }
}
