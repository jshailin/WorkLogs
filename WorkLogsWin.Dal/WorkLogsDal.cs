using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WorkLogsWin.Model;

//Please add references
namespace WorkLogsWin.Dal
{
	/// <summary>
	/// 数据访问类:WorkLogsWin.Dal
	/// </summary>
	public partial class WorkLogsDal
	{
		public WorkLogsDal()
		{}

	    #region 我的方法
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="workLog"></param>
        /// <returns></returns>
        public int Insert(WorkLogs workLog)
        {
            //构造insert语句
            string sql = "INSERT INTO WorkLogs (Pnumber, Item, Pname, UID, CreateTime, LogDesc, DelFlag) VALUES(@Pnumber,@Item,@Pname,@UID,@CreateTime,@LogDesc,0)";
            //构造sql语句的参数
            MySqlParameter[] ps = //使用数组初始化器
	        {
	            new MySqlParameter("@Pnumber",workLog.Pnumber),
	            new MySqlParameter("@Item",workLog.Item),
	            new MySqlParameter("@Pname",workLog.Pname),
	            new MySqlParameter("@UID",workLog.UID),
	            new MySqlParameter("@CreateTime",workLog.CreateTime),
	            new MySqlParameter("@LogDesc",workLog.LogDesc)
	        };
            //执行插入操作
            return MySQLHelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 查询到数据表
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
	    public DataTable GetDataTable(Dictionary<string, string> dic)
	    {
	        //构造查询sql语句
	        string sql = "SELECT ID, Pnumber, Item, Pname, UID, CreateTime, LogDesc FROM WorkLogs WHERE DelFlag=0 ";
	        //拼接查询条件
	        List<MySqlParameter> listP=new List<MySqlParameter>();
	        if (dic.Count>0)
	        {
	            foreach (var pair in dic)
	            {
	                //sql+=" AND "+pair.Key+" LIKE '%"+pair.Value+"%'";
	                //写成参数化，防注入
	                sql += " AND " + pair.Key + " LIKE @" + pair.Key ;
	                listP.Add(new MySqlParameter("@"+pair.Key,"%"+pair.Value+"%"));
	            }
	        }
	        //执行查询
	        return  MySQLHelper.GetDataTable(sql,listP.ToArray());
	    }
        /// <summary>
        /// 查询ID
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>条件
	    public int GetId(Dictionary<string, string> dic)
	    {
            //构造查询sql语句
            string sql = "SELECT ID FROM WorkLogs WHERE DelFlag=0 ";
            //拼接查询条件
            List<MySqlParameter> listP = new List<MySqlParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    //sql+=" AND "+pair.Key+" LIKE '%"+pair.Value+"%'";
                    //写成参数化，防注入
                    sql += " AND " + pair.Key + " LIKE @" + pair.Key;
                    listP.Add(new MySqlParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }
            //执行查询
            return (int)(MySQLHelper.ExecuteScalar(sql, listP.ToArray())??"-1");
	    }
	    #endregion

        #region  BasicMethod

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return MySQLHelper.GetMaxID("ID", "WorkLogs"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int ID)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from WorkLogs");
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
        //public bool Add(WorkLogs model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into WorkLogs(");
        //    strSql.Append("Pnumber,Item,Pname,UID,CreateTime,LogDesc,DelFlag)");
        //    strSql.Append(" values (");
        //    strSql.Append("@Pnumber,@Item,@Pname,@UID,@CreateTime,@LogDesc,@DelFlag)");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@Pnumber", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Item", MySqlDbType.Int32,10),
        //            new MySqlParameter("@Pname", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@UID", MySqlDbType.Int32,10),
        //            new MySqlParameter("@CreateTime", MySqlDbType.DateTime),
        //            new MySqlParameter("@LogDesc", MySqlDbType.Text),
        //            new MySqlParameter("@DelFlag", MySqlDbType.Int16,6)};
        //    parameters[0].Value = model.Pnumber;
        //    parameters[1].Value = model.Item;
        //    parameters[2].Value = model.Pname;
        //    parameters[3].Value = model.UID;
        //    parameters[4].Value = model.CreateTime;
        //    parameters[5].Value = model.LogDesc;
        //    parameters[6].Value = model.DelFlag;

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
        //public bool Update(WorkLogs model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update WorkLogs set ");
        //    strSql.Append("Pnumber=@Pnumber,");
        //    strSql.Append("Item=@Item,");
        //    strSql.Append("Pname=@Pname,");
        //    strSql.Append("UID=@UID,");
        //    strSql.Append("CreateTime=@CreateTime,");
        //    strSql.Append("LogDesc=@LogDesc,");
        //    strSql.Append("DelFlag=@DelFlag");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@Pnumber", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@Item", MySqlDbType.Int32,10),
        //            new MySqlParameter("@Pname", MySqlDbType.VarChar,255),
        //            new MySqlParameter("@UID", MySqlDbType.Int32,10),
        //            new MySqlParameter("@CreateTime", MySqlDbType.DateTime),
        //            new MySqlParameter("@LogDesc", MySqlDbType.Text),
        //            new MySqlParameter("@DelFlag", MySqlDbType.Int16,6),
        //            new MySqlParameter("@ID", MySqlDbType.Int32,10)};
        //    parameters[0].Value = model.Pnumber;
        //    parameters[1].Value = model.Item;
        //    parameters[2].Value = model.Pname;
        //    parameters[3].Value = model.UID;
        //    parameters[4].Value = model.CreateTime;
        //    parameters[5].Value = model.LogDesc;
        //    parameters[6].Value = model.DelFlag;
        //    parameters[7].Value = model.ID;

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
        //    strSql.Append("delete from WorkLogs ");
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
        //    strSql.Append("delete from WorkLogs ");
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
        //public WorkLogs GetModel(int ID)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ID,Pnumber,Item,Pname,UID,CreateTime,LogDesc,DelFlag from WorkLogs ");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@ID", MySqlDbType.Int32)
        //    };
        //    parameters[0].Value = ID;

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
        //public WorkLogs DataRowToModel(DataRow row)
        //{
        //    WorkLogs model=new WorkLogs();
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
        //        if(row["UID"]!=null && row["UID"].ToString()!="")
        //        {
        //            model.UID=int.Parse(row["UID"].ToString());
        //        }
        //        if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
        //        {
        //            model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
        //        }
        //        if(row["LogDesc"]!=null)
        //        {
        //            model.LogDesc=row["LogDesc"].ToString();
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
        //    strSql.Append("select ID,Pnumber,Item,Pname,UID,CreateTime,LogDesc,DelFlag ");
        //    strSql.Append(" FROM WorkLogs ");
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
        //    strSql.Append("select count(1) FROM WorkLogs ");
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
        //    strSql.Append(")AS Row, T.*  from WorkLogs T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return MySQLHelper.Query(strSql.ToString());
        //}

        ///*
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
        //            new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
        //            new MySqlParameter("@PageSize", MySqlDbType.Int32),
        //            new MySqlParameter("@PageIndex", MySqlDbType.Int32),
        //            new MySqlParameter("@IsReCount", MySqlDbType.Bit),
        //            new MySqlParameter("@OrderType", MySqlDbType.Bit),
        //            new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
        //            };
        //    parameters[0].Value = "WorkLogs";
        //    parameters[1].Value = "ID";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;	
        //    return MySQLHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        //}*/

        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

