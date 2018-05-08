/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 17:04:11 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: 7643bf31-4462-486d-85d1-5430af360812 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiCai.Entity;

namespace WeiCai.IBLL
{
    public partial interface IUserInfoService : IBaseService<userinfo>
    {
        bool DeleteEnities(List<int> list);

        void FindUserPwd(userinfo userInfo);
    }
}
