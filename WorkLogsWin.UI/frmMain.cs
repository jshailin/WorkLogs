using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkLogsWin.UI
{
    public partial class FrmMain : Form
    {
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

    }
}
