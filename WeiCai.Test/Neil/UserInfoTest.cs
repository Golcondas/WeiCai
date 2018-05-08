/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 17:10:21 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: ed24d803-2fc5-42a6-899d-6d6c6f51793e 
** 描述： 尚未编写描述 
*******************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiCai.Core;
using WeiCai.DAL;
using WeiCai.Entity;

namespace WeiCai.Test.Neil
{
    [TestClass]
    public class UserInfoTest
    {
        private static readonly LogHelper log = LogHelper.GetLogger(typeof(UserInfoTest));
        UserDal userDal = new UserDal();
        /// <summary>
        /// 查找
        /// </summary>
        [TestMethod]
        public void Test_LoadEntities()
        {
            //查找
            var result = userDal.LoadEntities(c => c.ID==1).ToList();
        }

        /// <summary>
        /// 添加
        /// </summary>
        [TestMethod]
        public void Test_AddUser()
        {
            for (int i = 1; i <=10; i++)
            {
                userinfo model = new userinfo();
                model.UName = "Web1_Test"+i;
                model.UPwd = "123456";
                model.SubTime = DateTime.Now;
                model.DelFlag = 0;
                model.Email = "123";
                model.Remark = "";
                log.Debug(JsonHelper.ObjectToJson(model));
                var reuslt3 = userDal.AddEntities(model);
            }
            
        }
    }
}
