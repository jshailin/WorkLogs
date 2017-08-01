using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WorkLogsWin.Bll;
using WorkLogsWin.Common;
using WorkLogsWin.Model;

namespace WorkLogsWin.UI
{
    public partial class FrmAddressBook : Form
    {
        private FrmAddressBook()
        {
            InitializeComponent();
        }

        private AddressBookBll _addressBookBll = new AddressBookBll();
        
        #region 实现窗体的单例
        private static FrmAddressBook _frm;
        public static FrmAddressBook Create()
        {
            if (_frm == null)
            {
                _frm = new FrmAddressBook();
            }
            return _frm;
        }
        private void FrmAddressBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            //与单例保持一致
            //出现这种代码的原因：Form的close()会释放当前窗体对象
            _frm = null;
        } 
        #endregion

        #region 列序的本地存储
        
        private string oldColumnsFile = "columns.dll";

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


        private void FrmAddressBook_Load(object sender, EventArgs e)
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

            //if (txtNameSearch.Text != "")
            //{
            //    dic.Add("Name", txtNameSearch.Text);
            //}


            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = new BindingCollection<AddressBook>(_addressBookBll.GetList(dic));

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //恢复控件的值
            RestControls();
        }

        /// <summary>
        /// 恢复控件的值
        /// </summary>
        private void RestControls()
        {
            txtId.Text = "添加时无编号";
            txtName.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtEmail.Text = "";
            txtCompany.Text = "";
            txtRemark.Text = "";
            btnSave.Text = "添加";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取双击的行数据
            var row = dgvList.Rows[e.RowIndex];
            //将行中的数据显示到控件中
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtPhone1.Text = row.Cells[2].Value.ToString();
            txtCompany.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
            txtRemark.Text = row.Cells[5].Value.ToString();
            txtPhone2.Text = row.Cells[6].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //判断输入有效性
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入姓名");
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone1.Text))
            {
                MessageBox.Show("请输入电话号码");
                txtPhone1.Focus();
                return;
            }
            //接收用户输入数据
            AddressBook address = new AddressBook()
            {
                Name = txtName.Text,
                Phone1 = txtPhone1.Text,
                Phone2 = txtPhone2.Text,
                Company = txtCompany.Text,
                Email = txtEmail.Text,
                Remark = txtRemark.Text
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                //添加操作
                if (_addressBookBll.Add(address))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍候重试");
                }
            }
            else
            {
                //修改操作
                address.ID = int.Parse(txtId.Text);
                if (_addressBookBll.Edit(address))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍候重试");
                }
            }

            //恢复控件的值
            RestControls();
        }

        private void dgvList_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //保存列序
            SaveColumnOrder((DataGridView)sender);
        }

        




    }
}
