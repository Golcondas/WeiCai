/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 15:15:42 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: b1602a98-2dbf-4512-a3ac-a26e07aadc31 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiCai.IDAL;

namespace WeiCai.DalAbstratFactory
{
    public partial class DbSession : IDbSession
    {
        public IUserDal _UserDal;
        public IUserDal GetUserDal
        {
            get
            {
                if (_UserDal == null)
                {
                    _UserDal = DALAbstractFactory.CreatNewDal();
                }
                return _UserDal;
            }
            set
            {
                _UserDal = value;
            }
        }

        DbContext db = DbContextFactory.CreateDbContext();
        public bool SaveChangesDbSession()
        {
            return db.SaveChanges() > 0;
        }
    }
}
