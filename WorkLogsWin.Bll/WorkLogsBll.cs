using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WorkLogsWin.Common;
using WorkLogsWin.Dal;
using WorkLogsWin.Model;

namespace WorkLogsWin.Bll
{
	/// <summary>
	/// WorkLogsBll
	/// </summary>
	public partial class WorkLogsBll
	{
		private readonly WorkLogsDal dal=new WorkLogsDal();
		public WorkLogsBll()
		{}

	    #region 我的方法

	    public bool Add(string strPnumber,string strItem,string strPname,string strLog)
	    {
            WorkLogs workLogs=new WorkLogs();
	        if (string.IsNullOrWhiteSpace(strLog))
	        {
	            MessageBox.Show("请输入日志内容");
                return false;
	        }

	        #region 其它日志

	        workLogs.Pnumber = "888888";
	        workLogs.Item = 8;
	        workLogs.Pname = "与项目无关";

	        #endregion
            if (strPname != "无此项目"&&!string.IsNullOrEmpty(strPname))
            {
                workLogs.Pnumber = strPnumber;
                workLogs.Item = Convert.ToInt32(strItem);
                workLogs.Pname = strPname;
            }
	        workLogs.LogDesc = strLog;
	        workLogs.UID = 1;
	        workLogs.CreateTime = DateTime.Now;
	        return dal.Insert(workLogs)>0;
	    }
        /// <summary>
        /// 查询日志内容
        /// </summary>
        /// <param name="strCondition">条件字符</param>
        /// <param name="byDate">1--日期查询，0--按订单查询</param>
        /// <returns></returns>
	    public string GetLogs(string strCondition, bool byDate)
        {
            //定义键值对，存放查询条件
	        Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(byDate ? "CreateTime" : "Pnumber", strCondition);
            DataTable dt = dal.GetDataTable(dic);
            if (dt.Rows.Count <= 0) return "未找到";
            StringBuilder sb=new StringBuilder();
            foreach (DataRow row  in dt.Rows)
            {
                sb.AppendLine(Convert.ToDateTime(row["CreateTime"]).ToString("yyyy年MM月dd日") + ":   " + row["Pnumber"].ToString() + "-" + row["Item"].ToString());
                sb.AppendLine(row["LogDesc"].ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }

	    #endregion

        #region  BasicMethod

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //    return dal.GetMaxId();
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int ID)
        //{
        //    return dal.Exists(ID);
        //}

        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public bool Add(WorkLogs model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(WorkLogs model)
        //{
        //    return dal.Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int ID)
        //{
			
        //    return dal.Delete(ID);
        //}
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string IDlist )
        //{
        //    return dal.DeleteList(PageValidate.SafeLongFilter(IDlist,0) );
        //}

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public WorkLogs GetModel(int ID)
        //{
			
        //    return dal.GetModel(ID);
        //}


        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    return dal.GetList(strWhere);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<WorkLogs> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<WorkLogs> DataTableToList(DataTable dt)
        //{
        //    List<WorkLogs> modelList = new List<WorkLogs>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        WorkLogs model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = dal.DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    return dal.GetRecordCount(strWhere);
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        ////public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        ////{
        //    //return dal.GetList(PageSize,PageIndex,strWhere);
        ////}

        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

