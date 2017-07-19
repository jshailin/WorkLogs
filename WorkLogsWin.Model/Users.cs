using System;

namespace WorkLogsWin.Model
{
	/// <summary>
	/// Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Users
	{
		public Users()
		{}
		#region Model
		private int _id;
		private string _uname;
		private string _upwd;
		private DateTime _regtime;
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
		public string UName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UPwd
		{
			set{ _upwd=value;}
			get{return _upwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
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

