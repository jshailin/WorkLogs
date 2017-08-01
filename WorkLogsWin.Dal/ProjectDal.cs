using System;
using System.Collections.Generic;
using System.Data;
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
	    #region 我的方法

	    /// <summary>
	    /// 根据生产编号查询客户名称
	    /// </summary>
	    /// <param name="pNumber">生产号</param>
	    /// <param name="item"></param>
	    /// <returns>项目名称</returns>
	    public string GetPNmameByPnumber(string pNumber,int item)
	    {
            //构造sql语句及参数
            string sql = "SELECT PName FROM Project WHERE Pnumber = @Pnumber AND Item = @Item ";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@Pnumber", pNumber),
                new MySqlParameter("@Item",item), 
            };
	        //执行并返回
	        return (string)MySQLHelper.ExecuteScalar(sql, ps);
	    }

        /// <summary>
        /// 查询到列表
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
	    public List<Project> GetList(Dictionary<string, string> dic)
	    {
            //构造查询sql语句
            string sql = "SELECT ID, Pnumber, Item, Pname, CustomerID, CustomerName, Description, MProperty, DDepartment1, DDepartment2, Design1, Design2 FROM Project WHERE DelFlag=0 ";
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
            DataTable dt = MySQLHelper.GetDataTable(sql, listP.ToArray());
            //定义list，完成转存
            List<Project> list = new List<Project>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Project()
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Pnumber = row["Pnumber"].ToString(),
                    Item = Convert.ToInt32(row["Item"]),
                    Pname = row["Pname"].ToString(),
                    CustomerID = row["CustomerID"].ToString(),
                    CustomerName = row["CustomerName"].ToString(),
                    DDepartment1 = row["DDepartment1"].ToString(),
                    DDepartment2 = row["DDepartment2"].ToString(),
                    Description = row["Description"].ToString(),
                    MProperty = row["MProperty"].ToString(),
                    Design1 = row["Design1"].ToString(),
                    Design2 = row["Design2"].ToString(),
                });
            }
            return list;
	    }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
	    public int Insert(Project project)
	    {
            //构造insert语句
            string sql = "INSERT INTO Project (Pnumber, Item, Pname, CustomerID, CustomerName, Description, MProperty, DDepartment1, DDepartment2, Design1, Design2, DelFlag) VALUES (@Pnumber,@Item,@Pname,@CustomerID,@CustomerName,@Description,@MProperty,@DDepartment1,@DDepartment2,@Design1,@Design2,0 )";
            //构造sql语句的参数
            MySqlParameter[] ps = //使用数组初始化器
	        {
	            new MySqlParameter("@Pnumber", project.Pnumber),
	            new MySqlParameter("@Item", project.Item),
	            new MySqlParameter("@Pname", project.Pname),
                new MySqlParameter("@CustomerID",project.CustomerID),
                new MySqlParameter("@CustomerName",project.CustomerName),
                new MySqlParameter("@Description",project.Description),
                new MySqlParameter("@MProperty",project.MProperty),
                new MySqlParameter("@DDepartment1",project.DDepartment1),
                new MySqlParameter("@DDepartment2",project.DDepartment2),
                new MySqlParameter("@Design1",project.Design1),
                new MySqlParameter("@Design2",project.Design2), 
	        };
            //执行插入操作
            return MySQLHelper.ExecuteNonQuery(sql, ps);
	    }

	    #endregion


	}
}

