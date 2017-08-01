using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using WorkLogsWin.Model;

namespace WorkLogsWin.Dal
{
    public partial class AddressBookDal
    {

        #region 我的方法

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Insert(AddressBook address)
        {
            //构造insert语句
            string sql = "INSERT INTO AddressBook (Name,Phone1,Phone2,Email,Company,Remark,DelFlag) VALUES(@Name,@Phone1,@Phone2,@Email,@Company,@Remark,0)";
            //构造sql语句的参数
            MySqlParameter[] ps = //使用数组初始化器
            {
                new MySqlParameter("@Name",address.Name),
                new MySqlParameter("@Phone1",address.Phone1),
                new MySqlParameter("@Phone2",address.Phone2),
                new MySqlParameter("@Email",address.Email),
                new MySqlParameter("@Company",address.Company),
                new MySqlParameter("@Remark",address.Remark)
            };
            //执行插入操作
            return MySQLHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Update(AddressBook address)
        {
            //构造sql语句及参数
            string sql = "UPDATE AddressBook SET Name=@Name,Phone1=@Phone1,Phone2=@Phone2,Email=@Email,Company=@Company,Remark=@Remark,DelFlag=0 WHERE ID= @ID";
            MySqlParameter[] ps =
            {
                new MySqlParameter("@Name",address.Name),
                new MySqlParameter("@Phone1",address.Phone1),
                new MySqlParameter("@Phone2",address.Phone2),
                new MySqlParameter("@Email",address.Email),
                new MySqlParameter("@Company",address.Company),
                new MySqlParameter("@Remark",address.Remark) ,
                new MySqlParameter("@ID",address.ID), 
            };
            //执行并返回
            return MySQLHelper.ExecuteNonQuery(sql, ps);
        }

        public List<AddressBook> GetList(Dictionary<string, string> dic)
        {
            //构造查询sql语句
            string sql = "SELECT ID,Name,Phone1,Phone2,Email,Company,Remark FROM AddressBook WHERE DelFlag=0 ";
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
            List<AddressBook> list = new List<AddressBook>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new AddressBook()
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = row["Name"].ToString(),
                    Phone1 = row["Phone1"].ToString(),
                    Phone2 = row["Phone2"].ToString(),
                    Email = row["Email"].ToString(),
                    Company = row["Company"].ToString(),
                    Remark = row["Remark"].ToString()
                });
            }
            return list;
        }

        #endregion
    }
}
