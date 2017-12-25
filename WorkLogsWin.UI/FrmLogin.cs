using System;
using System.IO;
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

        private string _oldUsersFile = "user.dll";
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
                    SaveUserName();
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

        #region 登陆用户名的存取
        /// <summary>
        /// 将登陆过的用户名存入文件
        /// </summary>
        private void SaveUserName()
        {
            if (!txtName.AutoCompleteCustomSource.Contains(txtName.Text))
            {
                using (StreamWriter sw = new StreamWriter(_oldUsersFile, true))
                {
                    sw.WriteLine(txtName.Text);
                }
            }
        }

        /// <summary>
        /// 读取登陆过的用户名
        /// </summary>
        private void ReadUserName()
        {
            if (File.Exists(_oldUsersFile))
            {
                using (StreamReader sr = new StreamReader(_oldUsersFile, true))
                {
                    string str = sr.ReadLine();
                    while (str != null)
                    {
                        if (!txtName.AutoCompleteCustomSource.Contains(str))
                        {
                            txtName.AutoCompleteCustomSource.Add(str);
                        }
                        str = sr.ReadLine();
                    }
                }
            }
        } 
        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ReadUserName();
        }
    }
}
