/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 15:15:57 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: 733bed4a-14a8-42bc-870e-52a3876e80e5 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiCai.IDAL;

namespace WeiCai.DalAbstratFactory
{
    public partial interface IDbSession
    {
        IUserDal GetUserDal { get; set; }
        bool SaveChangesDbSession();
    }
}
