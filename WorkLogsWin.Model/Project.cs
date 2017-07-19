using System;

namespace WorkLogsWin.Model
{
	/// <summary>
	/// Project:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Project
	{
		public Project()
		{}
		#region Model
		private int _id;
		private string _pnumber;
		private int? _item;
		private string _pname;
		private string _customerid;
		private string _customername;
		private string _description;
		private string _mproperty;
		private string _ddepartment1;
		private string _ddepartment2;
		private string _design1;
		private string _design2;
		private int _delflag;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pnumber
		{
			set{ _pnumber=value;}
			get{return _pnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Item
		{
			set{ _item=value;}
			get{return _item;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pname
		{
			set{ _pname=value;}
			get{return _pname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerID
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MProperty
		{
			set{ _mproperty=value;}
			get{return _mproperty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDepartment1
		{
			set{ _ddepartment1=value;}
			get{return _ddepartment1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DDepartment2
		{
			set{ _ddepartment2=value;}
			get{return _ddepartment2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Design1
		{
			set{ _design1=value;}
			get{return _design1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Design2
		{
			set{ _design2=value;}
			get{return _design2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DelFlag
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

