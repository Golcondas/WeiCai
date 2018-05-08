/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 14:18:58 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: 97581d5d-4f6d-4ff4-9b19-7e9133f5c7e0 
** 描述： 尚未编写描述 
*******************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiCai.Core;

namespace WeiCai.Test
{
    [TestClass]
    public class RedisHelperTest
    {
        [TestMethod]
        public void TestGetRedis()
        {
            //var keyA = RedisHelper.GetString("a");
            //var keyB = RedisHelper.SetString("a","宝山");
            for (int i = 1; i < 10000; i++)
            {
                string key = i + "";
                var keyC = RedisHelper.SetStringTime(key, "宝山", DateTime.Now.AddMinutes(1));
            }

        }
    }
}
