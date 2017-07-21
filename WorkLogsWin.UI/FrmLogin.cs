using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkLogsWin.Bll;
using WorkLogsWin.Common;
using WorkLogsWin.Model;

namespace WorkLogsWin.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //获取用户输入的信息
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            //调用代码
            UsersBll usersBll = new UsersBll();
            Users user = usersBll.GetByName(name);
            if (user==null)
            {
                MessageBox.Show("用户名错误");
            }
            else
            {
                if (user.UPwd.Equals(Md5Helper.EncryptString(pwd)))
                {
                    FrmMain main = new FrmMain();
                    main.Tag = user;    //将登陆者传递给主窗口
                    main.Show();
                    //将登陆窗口隐藏
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            
        }
    }
}
