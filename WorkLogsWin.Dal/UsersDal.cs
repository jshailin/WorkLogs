using System.Data;
using MySql.Data.MySqlClient;
using WorkLogsWin.Model;

//Please add references
namespace WorkLogsWin.Dal
{
	/// <summary>
	/// 数据访问类:UsersDal
	/// </summary>
	public partial class UsersDal
	{
	    #region 我的方法

        /// <summary>
        /// 根据名字查询用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Users GetByName(string name)
        {
            //定义一个对象
            Users user = null;
            //构造要查询的sql语句
            string sql = "SELECT ID, UName, UPwd FROM Users WHERE DelFlag=0 AND UName=@UName";
            MySqlParameter p = new MySqlParameter("@UName", name);
            //使用helper进行查询,得到结果
            DataTable dt = MySQLHelper.GetDataTable(sql, p);
            //判断是否查找到了
            if (dt.Rows.Count > 0)
            {
                //用户名是存在的
                user = new Users()
                {
                    ID = int.Parse(dt.Rows[0]["ID"].ToString()),
                    UName = name,
                    UPwd = dt.Rows[0]["UPwd"].ToString(),
                    
                };
            }
            return user;
        }
	    

	    #endregion

        #region  BasicMethod

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return MySQLHelper.GetMaxID("ID", "Users"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int ID)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from Users");
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
        //public bool Add(Users model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into Users(");
        //    strSql.Append("UName,UPwd,RegTime,DelFlag)");
        //    strSql.Append(" values (");
        //    strSql.Append("@UName,@UPwd,@RegTime,@DelFlag)");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@UName", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@UPwd", MySqlDbType.VarChar,16),
        //            new MySqlParameter("@RegTime", MySqlDbType.DateTime),
        //            new MySqlParameter("@DelFlag", MySqlDbType.Int16,6)};
        //    parameters[0].Value = model.UName;
        //    parameters[1].Value = model.UPwd;
        //    parameters[2].Value = model.RegTime;
        //    parameters[3].Value = model.DelFlag;

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
        //public bool Update(Users model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update Users set ");
        //    strSql.Append("UName=@UName,");
        //    strSql.Append("UPwd=@UPwd,");
        //    strSql.Append("RegTime=@RegTime,");
        //    strSql.Append("DelFlag=@DelFlag");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@UName", MySqlDbType.VarChar,32),
        //            new MySqlParameter("@UPwd", MySqlDbType.VarChar,16),
        //            new MySqlParameter("@RegTime", MySqlDbType.DateTime),
        //            new MySqlParameter("@DelFlag", MySqlDbType.Int16,6),
        //            new MySqlParameter("@ID", MySqlDbType.Int32,10)};
        //    parameters[0].Value = model.UName;
        //    parameters[1].Value = model.UPwd;
        //    parameters[2].Value = model.RegTime;
        //    parameters[3].Value = model.DelFlag;
        //    parameters[4].Value = model.ID;

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
        //    strSql.Append("delete from Users ");
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
        //    strSql.Append("delete from Users ");
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
        //public Users GetModel(int ID)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ID,UName,UPwd,RegTime,DelFlag from Users ");
        //    strSql.Append(" where ID=@ID");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@ID", MySqlDbType.Int32)
        //    };
        //    parameters[0].Value = ID;

        //    Users model=new Users();
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
        //public Users DataRowToModel(DataRow row)
        //{
        //    Users model=new Users();
        //    if (row != null)
        //    {
        //        if(row["ID"]!=null && row["ID"].ToString()!="")
        //        {
        //            model.ID=int.Parse(row["ID"].ToString());
        //        }
        //        if(row["UName"]!=null)
        //        {
        //            model.UName=row["UName"].ToString();
        //        }
        //        if(row["UPwd"]!=null)
        //        {
        //            model.UPwd=row["UPwd"].ToString();
        //        }
        //        if(row["RegTime"]!=null && row["RegTime"].ToString()!="")
        //        {
        //            model.RegTime=DateTime.Parse(row["RegTime"].ToString());
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
        //    strSql.Append("select ID,UName,UPwd,RegTime,DelFlag ");
        //    strSql.Append(" FROM Users ");
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
        //    strSql.Append("select count(1) FROM Users ");
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
        //    strSql.Append(")AS Row, T.*  from Users T ");
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
        //    parameters[0].Value = "Users";
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

