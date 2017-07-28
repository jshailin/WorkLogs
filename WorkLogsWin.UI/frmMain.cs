using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WorkLogsWin.Bll;
using WorkLogsWin.Common;
using WorkLogsWin.Model;

namespace WorkLogsWin.UI
{
    public partial class FrmMain : Form
    {
        readonly WorkLogsBll _workLogsBll=new WorkLogsBll();
        private Users _logUser = null;
        public FrmMain()
        {
            InitializeComponent();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtShow.Text = GetLogs(txtPNumber.Text, false);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            _logUser = (Users) this.Tag;
            Text += _logUser.UName;
            LoadLogs();
        }

        private void LoadLogs()
        {
            txtShow.Text = GetLogs(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), true);
        }

        /// <summary>
        /// 查询日志内容
        /// </summary>
        /// <param name="strCondition">条件字符</param>
        /// <param name="byDate">1--日期查询，0--按订单查询</param>
        /// <returns></returns>
        private string GetLogs(string strCondition, bool byDate)
        {
            //定义键值对，存放查询条件
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(byDate ? "CreateTime" : "Pnumber", strCondition);
            dic.Add("UID",_logUser.ID.ToString());
            List<WorkLogs> list = new List<WorkLogs>( _workLogsBll.GetList(dic));
            if (list.Count <= 0) return "未找到";
            StringBuilder sb = new StringBuilder();
            foreach (WorkLogs workLog in list)
            {
                sb.AppendLine(workLog.CreateTime.ToString("yyyy年MM月dd日") + ":   " + workLog.Pnumber + "-" + workLog.Item);
                sb.AppendLine(workLog.LogDesc);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState== FormWindowState.Minimized )
            {
                //隐藏任务栏区图标 
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState== FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                notifyIcon1.Visible = false;
            }
        }
        private void menuAddLog_Click(object sender, EventArgs e)
        {
            FrmAddLog frmAddLog=FrmAddLog.Create();
            frmAddLog.RefreshMain += LoadLogs;
            frmAddLog.Tag = _logUser.ID;
            frmAddLog.ShowDialog();
 //           frmAddLog.Focus();
        }

        private void menuOpenAddressBook_Click(object sender, EventArgs e)
        {
            FrmAddressBook frmAddress = new FrmAddressBook();
            frmAddress.Tag = _logUser.ID;
            frmAddress.ShowDialog();
        }

    }
}
