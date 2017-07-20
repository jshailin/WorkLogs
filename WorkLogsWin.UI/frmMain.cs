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
    public partial class FrmMain : Form
    {
        WorkLogsBll workLogsBll=new WorkLogsBll();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void menuAddLog_Click(object sender, EventArgs e)
        {
            FrmAddLog frmAddLog=FrmAddLog.Create();
            frmAddLog.Show();
            frmAddLog.Focus();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtShow.Text = workLogsBll.GetLogs(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtShow.Text = workLogsBll.GetLogs(txtPNumber.Text, false);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtShow.Text = workLogsBll.GetLogs(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), true);
        }

    }
}
