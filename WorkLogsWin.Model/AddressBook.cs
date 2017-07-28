using System;

namespace WorkLogsWin.Model
{
    /// <summary>
    /// AddressBook:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AddressBook
    {
        public AddressBook()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _phone1;
        private string _phone2;
        private string _email;
        private string _company;
        private string _remark;
        private int _delflag = 0;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone1
        {
            set { _phone1 = value; }
            get { return _phone1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone2
        {
            set { _phone2 = value; }
            get { return _phone2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DelFlag
        {
            set { _delflag = value; }
            get { return _delflag; }
        }
        #endregion Model

    }
}
