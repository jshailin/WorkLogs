using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkLogsWin.Dal;
using WorkLogsWin.Model;

namespace WorkLogsWin.Bll
{
    public partial class AddressBookBll
    {
        private readonly AddressBookDal dal = new AddressBookDal();

        #region 我的方法

        public bool Add(AddressBook address)
        {
            return dal.Insert(address) > 0;
        }

        public bool Edit(AddressBook address)
        {
            return dal.Update(address) > 0;
        }

        public List<AddressBook> GetList(Dictionary<string, string> dic)
        {
            return dal.GetList(dic);
        }


        #endregion
    }
}
