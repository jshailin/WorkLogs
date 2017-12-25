using System.Collections.Generic;
using WorkLogsWin.Dal;
using WorkLogsWin.Model;

namespace WorkLogsWin.Bll
{
    public partial class AddressBookBll
    {
        private readonly AddressBookDal _dal = new AddressBookDal();

        #region 我的方法

        public bool Add(AddressBook address)
        {
            return _dal.Insert(address) > 0;
        }

        public bool Edit(AddressBook address)
        {
            return _dal.Update(address) > 0;
        }

        public List<AddressBook> GetList(Dictionary<string, string> dic)
        {
            return _dal.GetList(dic);
        }


        #endregion
    }
}
