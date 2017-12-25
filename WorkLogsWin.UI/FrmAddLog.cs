using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkLogsWin.Bll;
using WorkLogsWin.Model;

namespace WorkLogsWin.UI
{
    public partial class FrmAddLog : Form
    {
        private FrmAddLog()
        {
            InitializeComponent();
        }

        public event Action RefreshMain;
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

        ProjectBll _projectBll=new ProjectBll();
        WorkLogsBll _workLogsBll=new WorkLogsBll();
        private void FrmAddLog_Load(object sender, EventArgs e)
        {
            lblCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            lblCreateDate.Left = txtLog.Right-lblCreateDate.Width;
        }
        private void txtPNumber_Leave(object sender, EventArgs e)
        {
            txtPName.Text = _projectBll.GetPNmameByPnumber(txtPNumber.Text,txtItem.Text);
        }

        private void btnAddLog_Click(object sender, EventArgs e)
        {
            if (Add(txtPNumber.Text, txtItem.Text, txtPName.Text, txtLog.Text))
            {
                RefreshMain();
                this.Close();
            }
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

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="strPnumber"></param>
        /// <param name="strItem"></param>
        /// <param name="strPname"></param>
        /// <param name="strLog"></param>
        /// <returns></returns>
        private bool Add(string strPnumber, string strItem, string strPname, string strLog)
        {
            if (string.IsNullOrWhiteSpace(strLog))
            {
                MessageBox.Show("请输入日志内容");
                return false;
            }
            WorkLogs workLogs = new WorkLogs();

            #region 其它日志

            workLogs.Pnumber = "888888";
            workLogs.Item = 8;
            workLogs.Pname = "与项目无关";

            #endregion

            if (strPname != "无此项目" && !string.IsNullOrEmpty(strPname))
            {
                workLogs.Pnumber = strPnumber;
                workLogs.Item = Convert.ToInt32(strItem);
                workLogs.Pname = strPname;
            }
            workLogs.LogDesc = strLog;
            workLogs.Uid = (int)this.Tag;
            workLogs.CreateTime = DateTime.Now;
            WorkLogs exixsWorkLog = GetWorkLogByDate_Pnum_Item(workLogs.CreateTime.ToString("yyyy-MM-dd"),
                workLogs.Pnumber, workLogs.Item.ToString());
            if (exixsWorkLog != null)
            {
                if (btnAddLog.Text != "更新")
                {
                    btnAddLog.Text = "更新";
                    txtLog.Text = exixsWorkLog.LogDesc + Environment.NewLine + strLog;
                    MessageBox.Show("已存在此日志，请修改更新");
                    return false;
                }
                else
                {
                    workLogs.Id = exixsWorkLog.Id;
                    return _workLogsBll.Edit(workLogs);
                }
            }
            else
                return _workLogsBll.Add(workLogs);
        }

        /// <summary>
        /// 获取ID，根据日期和项目号及品目
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pNum"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public WorkLogs GetWorkLogByDate_Pnum_Item(string date, string pNum, string item)
        {
            //定义键值对，存放查询条件
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("CreateTime", date);
            dic.Add("Pnumber", pNum);
            dic.Add("Item", item);
            dic.Add("UID",((int)this.Tag).ToString());
            return _workLogsBll.GetList(dic).Count>0?_workLogsBll.GetList(dic)[0]:null;
        }
    }
}
