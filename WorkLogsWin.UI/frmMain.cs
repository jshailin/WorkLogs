﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WorkLogsWin.Bll;
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

        private void menuAddLog_Click(object sender, EventArgs e)
        {
            FrmAddLog frmAddLog=FrmAddLog.Create();
            frmAddLog.RefreshMain += LoadLogs;
            frmAddLog.Tag = _logUser.ID;
            frmAddLog.Show();
            frmAddLog.Focus();
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
            List<WorkLogs> list = _workLogsBll.GetList(dic);
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

    }
}
