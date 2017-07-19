using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WorkLogsWin.Model;

//Please add references
namespace WorkLogsWin.Dal
{
	/// <summary>
	/// 数据访问类:ProjectDal
	/// </summary>
	public partial class ProjectDal
	{
		public ProjectDal()
		{}

	    #region 我的方法

        /// <summary>
        /// 根据生产编号查询客户名称
        /// </summary>
        /// <param name="pNumber">生产号</param>
        /// <returns>项目名称</returns>
	    public string GetPNmameByPnumber(string pNumber)
	    {
            //构造sql语句及参数
            string sql = "SELECT PName FROM Project WHERE Pnumber = @Pnumber";
            MySqlParameter p = new MySqlParameter("@Pnumber", pNumber);
	        //执行并返回
	        return (string)MySQLHelper.ExecuteScalar(sql, p);
	    }

	    #endregion

		#region  BasicMethod

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return MySQLHelper.GetMaxID("ID", "Project"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int ID)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from Project");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@ID", MySqlDbType.Int32)
        //    };
        //    parameters[0].Value = ID;

        //    return MySQLHelper.Exists(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public bool Add(Project model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into Project(");
        //    strSql.Append("Pnumber,Item,Pname,CustomerID,CustomerName,Description,MProperty,DDepartment1,DDepartment2,Design1,Design2,DelFlag)");
        //    strSql.Append(" values (");
        //    strSql.Append("@Pnumber,@Item,@Pname,@CustomerID,@CustomerName,@Description,@MProperty,@DDepartment1,@DDepartment2,@Design1,@Design2,@DelFlag)");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@Pnumber", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Item", MySqlDbType.Int32,11),
        //            new MySqlParameter("@Pname", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@CustomerID", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@CustomerName", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@Description", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@MProperty", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@DDepartment1", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@DDepartment2", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Design1", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Design2", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@DelFlag", MySqlDbType.Int16,6)};
        //    parameters[0].Value = model.Pnumber;
        //    parameters[1].Value = model.Item;
        //    parameters[2].Value = model.Pname;
        //    parameters[3].Value = model.CustomerID;
        //    parameters[4].Value = model.CustomerName;
        //    parameters[5].Value = model.Description;
        //    parameters[6].Value = model.MProperty;
        //    parameters[7].Value = model.DDepartment1;
        //    parameters[8].Value = model.DDepartment2;
        //    parameters[9].Value = model.Design1;
        //    parameters[10].Value = model.Design2;
        //    parameters[11].Value = model.DelFlag;

        //    int rows=MySQLHelper.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(Project model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update Project set ");
        //    strSql.Append("Pnumber=@Pnumber,");
        //    strSql.Append("Item=@Item,");
        //    strSql.Append("Pname=@Pname,");
        //    strSql.Append("CustomerID=@CustomerID,");
        //    strSql.Append("CustomerName=@CustomerName,");
        //    strSql.Append("Description=@Description,");
        //    strSql.Append("MProperty=@MProperty,");
        //    strSql.Append("DDepartment1=@DDepartment1,");
        //    strSql.Append("DDepartment2=@DDepartment2,");
        //    strSql.Append("Design1=@Design1,");
        //    strSql.Append("Design2=@Design2,");
        //    strSql.Append("DelFlag=@DelFlag");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@Pnumber", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Item", MySqlDbType.Int32,11),
        //            new MySqlParameter("@Pname", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@CustomerID", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@CustomerName", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@Description", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@MProperty", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@DDepartment1", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@DDepartment2", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Design1", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Design2", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@DelFlag", MySqlDbType.Int16,6),
        //            new MySqlParameter("@ID", MySqlDbType.Int32,10)};
        //    parameters[0].Value = model.Pnumber;
        //    parameters[1].Value = model.Item;
        //    parameters[2].Value = model.Pname;
        //    parameters[3].Value = model.CustomerID;
        //    parameters[4].Value = model.CustomerName;
        //    parameters[5].Value = model.Description;
        //    parameters[6].Value = model.MProperty;
        //    parameters[7].Value = model.DDepartment1;
        //    parameters[8].Value = model.DDepartment2;
        //    parameters[9].Value = model.Design1;
        //    parameters[10].Value = model.Design2;
        //    parameters[11].Value = model.DelFlag;
        //    parameters[12].Value = model.ID;

        //    int rows=MySQLHelper.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int ID)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from Project ");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@ID", MySqlDbType.Int32)
        //    };
        //    parameters[0].Value = ID;

        //    int rows=MySQLHelper.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ///// <summary>
        ///// 批量删除数据
        ///// </summary>
        //public bool DeleteList(string IDlist )
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from Project ");
        //    strSql.Append(" where ID in ("+IDlist + ")  ");
        //    int rows=MySQLHelper.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Project GetModel(int ID)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ID,Pnumber,Item,Pname,CustomerID,CustomerName,Description,MProperty,DDepartment1,DDepartment2,Design1,Design2,DelFlag from Project ");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@ID", MySqlDbType.Int32)
        //    };
        //    parameters[0].Value = ID;

        //    Project model=new Project();
        //    DataSet ds=MySQLHelper.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Project DataRowToModel(DataRow row)
        //{
        //    Project model=new Project();
        //    if (row != null)
        //    {
        //        if(row["ID"]!=null && row["ID"].ToString()!="")
        //        {
        //            model.ID=int.Parse(row["ID"].ToString());
        //        }
        //        if(row["Pnumber"]!=null)
        //        {
        //            model.Pnumber=row["Pnumber"].ToString();
        //        }
        //        if(row["Item"]!=null && row["Item"].ToString()!="")
        //        {
        //            model.Item=int.Parse(row["Item"].ToString());
        //        }
        //        if(row["Pname"]!=null)
        //        {
        //            model.Pname=row["Pname"].ToString();
        //        }
        //        if(row["CustomerID"]!=null)
        //        {
        //            model.CustomerID=row["CustomerID"].ToString();
        //        }
        //        if(row["CustomerName"]!=null)
        //        {
        //            model.CustomerName=row["CustomerName"].ToString();
        //        }
        //        if(row["Description"]!=null)
        //        {
        //            model.Description=row["Description"].ToString();
        //        }
        //        if(row["MProperty"]!=null)
        //        {
        //            model.MProperty=row["MProperty"].ToString();
        //        }
        //        if(row["DDepartment1"]!=null)
        //        {
        //            model.DDepartment1=row["DDepartment1"].ToString();
        //        }
        //        if(row["DDepartment2"]!=null)
        //        {
        //            model.DDepartment2=row["DDepartment2"].ToString();
        //        }
        //        if(row["Design1"]!=null)
        //        {
        //            model.Design1=row["Design1"].ToString();
        //        }
        //        if(row["Design2"]!=null)
        //        {
        //            model.Design2=row["Design2"].ToString();
        //        }
        //        if(row["DelFlag"]!=null && row["DelFlag"].ToString()!="")
        //        {
        //            model.DelFlag=int.Parse(row["DelFlag"].ToString());
        //        }
        //    }
        //    return model;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ID,Pnumber,Item,Pname,CustomerID,CustomerName,Description,MProperty,DDepartment1,DDepartment2,Design1,Design2,DelFlag ");
        //    strSql.Append(" FROM Project ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    return MySQLHelper.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM Project ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = MySQLHelper.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby );
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.ID desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from Project T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return MySQLHelper.Query(strSql.ToString());
        //}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Project";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return MySQLHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

