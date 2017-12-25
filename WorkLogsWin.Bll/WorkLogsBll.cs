using System.Collections.Generic;
using WorkLogsWin.Dal;
using WorkLogsWin.Model;

namespace WorkLogsWin.Bll
{
	/// <summary>
	/// WorkLogsBll
	/// </summary>
	public partial class WorkLogsBll
	{
		private readonly WorkLogsDal _dal=new WorkLogsDal();

	    #region 我的方法

	    public bool Add(WorkLogs workLog)
	    {
	        return _dal.Insert(workLog) > 0;
	    }

	    public bool Edit(WorkLogs workLog)
	    {
	        return _dal.Update(workLog) > 0;
	    }

	    public List<WorkLogs> GetList(Dictionary<string, string> dic)
	    {
	        return _dal.GetList(dic);
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

