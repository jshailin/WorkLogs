using System;
using WorkLogsWin.Dal;
using WorkLogsWin.Model;

namespace WorkLogsWin.Bll
{
	/// <summary>
	/// Project
	/// </summary>
	public partial class ProjectBll
	{
		private readonly ProjectDal dal=new ProjectDal();

	    #region 我的方法

	    /// <summary>
	    /// 根据生产编号查询客户名称
	    /// </summary>
	    /// <param name="pNumber">生产号</param>
	    /// <param name="strItem"></param>
	    /// <returns>项目名称</returns>
	    public string GetPNmameByPnumber(string pNumber,string strItem)
	    {
	        string pNmame = dal.GetPNmameByPnumber(pNumber,Convert.ToInt32(strItem));
            return pNmame ?? "无此项目";
	    }

	    public bool Add(Project project)
	    {
	        return dal.Insert(project) > 0;
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
        //public bool Add(Project model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(Project model)
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
        //public Project GetModel(int ID)
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
        //public List<Project> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<Project> DataTableToList(DataTable dt)
        //{
        //    List<Project> modelList = new List<Project>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        Project model;
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

