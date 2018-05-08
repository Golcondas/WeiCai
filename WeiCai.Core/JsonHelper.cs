/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 14:35:20 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: d988a1fe-2b06-490b-bbfd-76726aa5cb03 
** 描述： 尚未编写描述 
*******************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiCai.Core
{
    public class JsonHelper
    {
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息
        public static T JsonToObject<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
