using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace WorkLogsWin.Dal
{
    /// <summary>
    /// 数据访问抽象基础类
    /// </summary>
    public abstract class MySqlHelper
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.	
	    public static string ConnStr;

        static MySqlHelper()
        {
            using (StreamReader sr=new StreamReader(@"d:\sever", Encoding.Default))
            {
                ConnStr = sr.ReadLine();
            }
        }

        #region 我的方法

        //params：可变参数，目的是省略了手动构造数组的过程，直接指定对象，编译器会帮助我们构造数组，并将对象加入数组中，传递过来
        /// <summary>
        /// 执行命令的方法：insert,update,delete
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] ps)
        {
            //创建连接对象
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                //创建命令对象
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //添加参数
                cmd.Parameters.AddRange(ps);
                //打开连接
                conn.Open();
                //执行命令，并返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取首行首列值的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>

        public static object ExecuteScalar(string sql, params MySqlParameter[] ps)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();
                //执行命令，获取查询结果中的首行首列的值，返回
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 获取结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>

        public static DataTable GetDataTable(string sql, params MySqlParameter[] ps)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                //构造适配器对象
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                //构造数据表，用于接收查询结果
                DataTable dt = new DataTable();
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(ps);
                //执行结果
                adapter.Fill(dt);
                //返回结果集
                return dt;
            }
        }

        #endregion

        #region 公用方法
        ///// <summary>
        ///// 得到最大值
        ///// </summary>
        ///// <param name="FieldName"></param>
        ///// <param name="TableName"></param>
        ///// <returns></returns>
        //public static int GetMaxID(string FieldName, string TableName)
        //{
        //    string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        //    object obj = GetSingle(strsql);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}
        ///// <summary>
        ///// 是否存在
        ///// </summary>
        ///// <param name="strSql"></param>
        ///// <returns></returns>
        //public static bool Exists(string strSql)
        //{
        //    object obj = GetSingle(strSql);
        //    int cmdresult;
        //    if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
        //    {
        //        cmdresult = 0;
        //    }
        //    else
        //    {
        //        cmdresult = int.Parse(obj.ToString());
        //    }
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}    
        ///// <summary>
        ///// 是否存在（基于MySqlParameter）
        ///// </summary>
        ///// <param name="strSql"></param>
        ///// <param name="cmdParms"></param>
        ///// <returns></returns>
        //public static bool Exists(string strSql, params MySqlParameter[] cmdParms)
        //{
        //    object obj = GetSingle(strSql, cmdParms);
        //    int cmdresult;
        //    if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
        //    {
        //        cmdresult = 0;
        //    }
        //    else
        //    {
        //        cmdresult = int.Parse(obj.ToString());
        //    }
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //#endregion

        //#region  执行简单SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string SQLString)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (MySqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}

        //public static int ExecuteSqlByTime(string SQLString, int Times)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                cmd.CommandTimeout = Times;
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (MySqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}
      

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">多条SQL语句</param>		
        //public static int ExecuteSqlTran(List<String> SQLStringList)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = conn;
        //        MySqlTransaction tx = conn.BeginTransaction();
        //        cmd.Transaction = tx;
        //        try
        //        {
        //            int count = 0;
        //            for (int n = 0; n < SQLStringList.Count; n++)
        //            {
        //                string strsql = SQLStringList[n];
        //                if (strsql.Trim().Length > 1)
        //                {
        //                    cmd.CommandText = strsql;
        //                    count += cmd.ExecuteNonQuery();
        //                }
        //            }
        //            tx.Commit();
        //            return count;
        //        }
        //        catch
        //        {
        //            tx.Rollback();
        //            return 0;
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string SQLString, string content)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        MySqlCommand cmd = new MySqlCommand(SQLString, connection);
        //        MySqlParameter myParameter = new MySqlParameter("@content", SqlDbType.NText);
        //        myParameter.Value = content;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows;
        //        }
        //        catch (MySqlException e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static object ExecuteSqlGet(string SQLString, string content)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        MySqlCommand cmd = new MySqlCommand(SQLString, connection);
        //        MySqlParameter myParameter = new MySqlParameter("@content", SqlDbType.NText);
        //        myParameter.Value = content;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            object obj = cmd.ExecuteScalar();
        //            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                return obj;
        //            }
        //        }
        //        catch (MySqlException e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        ///// </summary>
        ///// <param name="strSQL">SQL语句</param>
        ///// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        MySqlCommand cmd = new MySqlCommand(strSQL, connection);
        //        MySqlParameter myParameter = new MySqlParameter("@fs", SqlDbType.Image);
        //        myParameter.Value = fs;
        //        cmd.Parameters.Add(myParameter);
        //        try
        //        {
        //            connection.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows;
        //        }
        //        catch (MySqlException e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            cmd.Dispose();
        //            connection.Close();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(string SQLString)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                object obj = cmd.ExecuteScalar();
        //                if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (MySqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}
        //public static object GetSingle(string SQLString, int Times)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                cmd.CommandTimeout = Times;
        //                object obj = cmd.ExecuteScalar();
        //                if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (MySqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>MySqlDataReader</returns>
        //public static MySqlDataReader ExecuteReader(string strSQL)
        //{
        //    MySqlConnection connection = new MySqlConnection(connStr);
        //    MySqlCommand cmd = new MySqlCommand(strSQL, connection);
        //    try
        //    {
        //        connection.Open();
        //        MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        return myReader;
        //    }
        //    catch (MySqlException e)
        //    {
        //        throw e;
        //    }   

        //}
        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
        //            command.Fill(ds, "ds");
        //        }
        //        catch (MySqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}
        //public static DataSet Query(string SQLString, int Times)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            connection.Open();
        //            MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
        //            command.SelectCommand.CommandTimeout = Times;
        //            command.Fill(ds, "ds");
        //        }
        //        catch (MySqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}



        #endregion

        #region 执行带参数的SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(string SQLString, params MySqlParameter[] cmdParms)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //                int rows = cmd.ExecuteNonQuery();
        //                cmd.Parameters.Clear();
        //                return rows;
        //            }
        //            catch (MySqlException e)
        //            {
        //                throw e;
        //            }
        //        }
        //    }
        //}


        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的MySqlParameter[]）</param>
        //public static void ExecuteSqlTran(Hashtable SQLStringList)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (MySqlTransaction trans = conn.BeginTransaction())
        //        {
        //            MySqlCommand cmd = new MySqlCommand();
        //            try
        //            {
        //                //循环
        //                foreach (DictionaryEntry myDE in SQLStringList)
        //                {
        //                    string cmdText = myDE.Key.ToString();
        //                    MySqlParameter[] cmdParms = (MySqlParameter[])myDE.Value;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的MySqlParameter[]）</param>
        //public static int ExecuteSqlTran(List<CommandInfo> cmdList)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (MySqlTransaction trans = conn.BeginTransaction())
        //        {
        //            MySqlCommand cmd = new MySqlCommand();
        //            try
        //            { int count = 0;
        //                //循环
        //                foreach (CommandInfo myDE in cmdList)
        //                {
        //                    string cmdText = myDE.CommandText;
        //                    MySqlParameter[] cmdParms = (MySqlParameter[])myDE.Parameters;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                           
        //                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
        //                    {
        //                        if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }

        //                        object obj = cmd.ExecuteScalar();
        //                        bool isHave = false;
        //                        if (obj == null && obj == DBNull.Value)
        //                        {
        //                            isHave = false;
        //                        }
        //                        isHave = Convert.ToInt32(obj) > 0;

        //                        if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }
        //                        if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }
        //                        continue;
        //                    }
        //                    int val = cmd.ExecuteNonQuery();
        //                    count += val;
        //                    if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
        //                    {
        //                        trans.Rollback();
        //                        return 0;
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //                return count;
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的MySqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(List<CommandInfo> SQLStringList)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (MySqlTransaction trans = conn.BeginTransaction())
        //        {
        //            MySqlCommand cmd = new MySqlCommand();
        //            try
        //            {
        //                int indentity = 0;
        //                //循环
        //                foreach (CommandInfo myDE in SQLStringList)
        //                {
        //                    string cmdText = myDE.CommandText;
        //                    MySqlParameter[] cmdParms = (MySqlParameter[])myDE.Parameters;
        //                    foreach (MySqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.InputOutput)
        //                        {
        //                            q.Value = indentity;
        //                        }
        //                    }
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    foreach (MySqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.Output)
        //                        {
        //                            indentity = Convert.ToInt32(q.Value);
        //                        }
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的MySqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (MySqlTransaction trans = conn.BeginTransaction())
        //        {
        //            MySqlCommand cmd = new MySqlCommand();
        //            try
        //            {
        //                int indentity = 0;
        //                //循环
        //                foreach (DictionaryEntry myDE in SQLStringList)
        //                {
        //                    string cmdText = myDE.Key.ToString();
        //                    MySqlParameter[] cmdParms = (MySqlParameter[])myDE.Value;
        //                    foreach (MySqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.InputOutput)
        //                        {
        //                            q.Value = indentity;
        //                        }
        //                    }
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    foreach (MySqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.Output)
        //                        {
        //                            indentity = Convert.ToInt32(q.Value);
        //                        }
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(string SQLString, params MySqlParameter[] cmdParms)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //                object obj = cmd.ExecuteScalar();
        //                cmd.Parameters.Clear();
        //                if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }
        //            }
        //            catch (MySqlException e)
        //            {
        //                throw e;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>MySqlDataReader</returns>
        //public static MySqlDataReader ExecuteReader(string SQLString, params MySqlParameter[] cmdParms)
        //{
        //    MySqlConnection connection = new MySqlConnection(connStr);
        //    MySqlCommand cmd = new MySqlCommand();
        //    try
        //    {
        //        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //        MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Parameters.Clear();
        //        return myReader;
        //    }
        //    catch (MySqlException e)
        //    {
        //        throw e;
        //    }
        //    //			finally
        //    //			{
        //    //				cmd.Dispose();
        //    //				connection.Close();
        //    //			}	

        //}

        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(string SQLString, params MySqlParameter[] cmdParms)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connStr))
        //    {
        //        MySqlCommand cmd = new MySqlCommand();
        //        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        //        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                da.Fill(ds, "ds");
        //                cmd.Parameters.Clear();
        //            }
        //            catch (MySqlException ex)
        //            {
        //                throw new Exception(ex.Message);
        //            }
        //            return ds;
        //        }
        //    }
        //}


        //private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (trans != null)
        //        cmd.Transaction = trans;
        //    cmd.CommandType = CommandType.Text;//cmdType;
        //    if (cmdParms != null)
        //    {


        //        foreach (MySqlParameter parameter in cmdParms)
        //        {
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            cmd.Parameters.Add(parameter);
        //        }
        //    }
        //}

        #endregion

        

    }

}
