/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 15:14:49 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: cbf7fa9e-b000-4617-b35f-cdbf00b94911 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeiCai.IDAL;

namespace WeiCai.DalAbstratFactory
{
    public partial class DALAbstractFactory
    {
        public static readonly string assemblyFullName = ConfigurationManager.ConnectionStrings["dalFullName"].ConnectionString;
        public static readonly string assembly = ConfigurationManager.ConnectionStrings["assemblyName"].ConnectionString;

        public static IUserDal CreatNewDal()
        {
            string fullNameSpace = assemblyFullName + ".UserDal";
            return GetIntence(fullNameSpace, assembly) as IUserDal;
        }

        public static object GetIntence(string assemblyFullName, string assembly)
        {
            var assemblyName = Assembly.Load(assembly);
            return assemblyName.CreateInstance(assemblyFullName);
        }

        public static object CreateInstance(string assemblyFullName, string assembly)
        {
            var assemblyName = Assembly.Load(assembly);
            return assemblyName.CreateInstance(assemblyFullName);
        }
    }
}
