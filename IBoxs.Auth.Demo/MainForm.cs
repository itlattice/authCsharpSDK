using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBoxs.Auth.SDK;
using IBoxs.Auth.SDK.result;

namespace IBoxs.Auth.Demo
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 授权系统接口
        /// </summary>
        public static AuthApi authApi;

        /// <summary>
        /// 用户信息，实际项目中可以自己定义具体生成规则
        /// userkey为用户在该应用中的识别码，可以是用户电脑机器码、QQ号、手机号等，验证授权、购买授权均使用它进行，购买授权后发放到该识别码上，验证授权也是依赖它来确认该用户是否有授权
        /// 识别码规则一旦确定，不要改动规则，一旦改动，原用户的授权也将验证为无授权信息
        /// 
        /// 附注：本Demo取的userkey为获取用户机器码的md5值（您可以选择其他的），若用户使用挂机宝或虚拟机等情况时，该规则中的userkey有重复可能，故请自行解决该用户识别码生成规则。
        /// </summary>
        public class UserInfo
        {
            public static string userkey = Common.Userkey;
        }

        public MainForm()
        {
            InitializeComponent();
            authApi = new AuthApi(apiConfig.AppID, apiConfig.AppSecret);  //初始化
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string a = UserInfo.userkey;
            NewAuthInfo();
        }

        private void NewAuthInfo()
        {
            string msg = "";
            AuthResult result = authApi.Auth(UserInfo.userkey, out msg);
            if (result.authStatus == SDK.dataEnum.authStatus.normal)
            {
                toolStripStatusLabel1.Text = "授权到期时间：" + result.stop_time;
            }
            else
            {
                toolStripStatusLabel1.Text = msg;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://auth.itgz8.com");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://auth.itgz8.com/doc/index.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg;
            AuthResult result = authApi.Auth(UserInfo.userkey, out msg);
            if(result.authStatus==SDK.dataEnum.authStatus.normal)
            {
                MessageBox.Show(msg+"\n 授权到期时间："+result.stop_time);
                return;
            }
            MessageBox.Show(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPath.Buy buy = new FormPath.Buy();
            buy.ShowDialog();
            NewAuthInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPath.Card card = new FormPath.Card();
            card.ShowDialog();
            NewAuthInfo();
        }
    }
}
