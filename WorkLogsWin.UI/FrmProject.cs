using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WorkLogsWin.Bll;
using WorkLogsWin.Common;
using WorkLogsWin.Model;

namespace WorkLogsWin.UI
{
    public partial class FrmProject : Form
    {
        private FrmProject()
        {
            InitializeComponent();
        }

        private ProjectBll _projectBll = new ProjectBll();
        
        #region 实现窗体的单例
        private static FrmProject _frm;
        public static FrmProject Create()
        {
            if (_frm == null)
            {
                _frm = new FrmProject();
            }
            return _frm;
        }
        private void FrmProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            //与单例保持一致
            //出现这种代码的原因：Form的close()会释放当前窗体对象
            _frm = null;
        } 
        #endregion

        #region 列序的本地存储
        
        private string oldColumnsFile = "pro_columns.dll";

        /// <summary>
        /// 保存列序
        /// </summary>
        /// <param name="dgView"></param>
        private void SaveColumnOrder(DataGridView dgView)
        {
            using (StreamWriter sw=new StreamWriter(oldColumnsFile,false))
            {
                foreach (DataGridViewColumn column in dgView.Columns)
                {
                    sw.WriteLine(column.DisplayIndex);
                }
            }
        }
        /// <summary>
        /// 读取列序
        /// </summary>
        /// <param name="dgView"></param>
        private void ReadColumnOrder(DataGridView dgView)
        {
            if (File.Exists(oldColumnsFile))
            {
                //文件设置共享模式
                using (FileStream fs=new FileStream(oldColumnsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) 
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        foreach (DataGridViewColumn column in dgView.Columns)
                        {
                            column.DisplayIndex = Convert.ToInt32(sr.ReadLine());
                        }
                    } 
                } 
            }
        }

        #endregion


        private void FrmProject_Load(object sender, EventArgs e)
        {
            //加载通讯录
            LoadList();
            //加载列序
            ReadColumnOrder(dgvList);
        }

        private void LoadList()
        {
            //定义键值对，存放查询条件
            Dictionary<string, string> dic = new Dictionary<string, string>();

            if (txtName.Text != "")
            {
                dic.Add("Pname", txtName.Text);
            }
            if (txtNumber.Text != "")
            {
                dic.Add("Pnumber", txtNumber.Text);
            }


            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = new BindingCollection<Project>(_projectBll.GetList(dic));

        }

        private void dgvList_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //保存列序
            SaveColumnOrder((DataGridView)sender);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtNumber.Text = "";
            LoadList();
        }

        private void txtNumber_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        




    }
}
