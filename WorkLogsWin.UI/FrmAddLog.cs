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

namespace WorkLogsWin.UI
{
    public partial class FrmAddLog : Form
    {
        private FrmAddLog()
        {
            InitializeComponent();
        }
        //实现窗体的单例
        private static FrmAddLog _frm;
        public static FrmAddLog Create()
        {
            if (_frm == null)
            {
                _frm = new FrmAddLog();
            }
            return _frm;
        }

        private void frmAddLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //与单例保持一致
            //出现这种代码的原因：Form的close()会释放当前窗体对象
            _frm = null;
        }

        ProjectBll projectBll=new ProjectBll();
        WorkLogsBll workLogsBll=new WorkLogsBll();
        private void FrmAddLog_Load(object sender, EventArgs e)
        {
            lblCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            lblCreateDate.Left = txtLog.Right-lblCreateDate.Width;
        }
        private void txtPNumber_Leave(object sender, EventArgs e)
        {
            txtPName.Text = projectBll.GetPNmameByPnumber(txtPNumber.Text,txtItem.Text);
        }

        private void btnAddLog_Click(object sender, EventArgs e)
        {
            if (workLogsBll.Add(txtPNumber.Text, txtItem.Text, txtPName.Text, txtLog.Text))
                this.Close();
            else
                MessageBox.Show("提交失败，请稍后再试");
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar!='\b'&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
