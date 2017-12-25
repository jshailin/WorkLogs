using System;

namespace WorkLogsWin.Model
{
	/// <summary>
	/// WorkLogs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WorkLogs
	{
	    #region Model
		private int _id;
		private string _pnumber;
		private int? _item;
		private string _pname;
		private int _uid;
		private DateTime _createtime;
		private string _logdesc;
		private int _delflag;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int Id
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
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogDesc
		{
			set{ _logdesc=value;}
			get{return _logdesc;}
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

