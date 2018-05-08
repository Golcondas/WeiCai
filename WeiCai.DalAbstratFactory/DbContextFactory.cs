/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 15:15:16 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: 77319d1d-9478-4ec9-bae9-596572548897 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WeiCai.Entity;

namespace WeiCai.DalAbstratFactory
{
    public class DbContextFactory
    {
         //<summary>
         //保证线程唯一
         //</summary>
         //<returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContexts = (DbContext)CallContext.GetData("ObjectContext");
            if (dbContexts == null)
            {
                dbContexts = new OAEntities();
                CallContext.SetData("ObjectContext", dbContexts);
            }
            return dbContexts;
        }
    }
}
