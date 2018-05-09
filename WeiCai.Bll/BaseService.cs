/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 16:57:43 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: f5c04fcf-92ea-44c1-bd2e-bec05fae3298 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeiCai.Core;
using WeiCai.DalAbstratFactory;
using WeiCai.Entity;

namespace WeiCai.Bll
{
    public abstract class BaseService<T> where T : class, new()
    {
        private static readonly LogHelper log = LogHelper.GetLogger(typeof(T));
        public IDbSession DbSession { get { return new DalAbstratFactory.DbSession(); } }

        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }

        public static IDAL.IBaseDal<T> GetCurrentDal { get; set; }

        #region 查询 LoadEntities
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> lambdaWehre)
        {
            IQueryable<T> result = null;
            log.DebugFormat("查询: FullName:{0} lambdaWehre:{1}", typeof(T).FullName , lambdaWehre.ToString());
            try
            {
                result = LoadEntitie(lambdaWehre);
                log.DebugFormat("查询 FullName:{0} lambdaWehre:{1} linq:{2}", typeof(T).FullName, lambdaWehre.ToString(), result.ToString().Replace("\r\n", ""));
                log.Debug("查询结果: " + JsonHelper.ObjectToJson(result));
            }
            catch (Exception ex)
            {
                log.ErrorFormat("查询异常 FullName:{0} lambdaWehre:{1} ex:{2}", typeof(T).FullName, lambdaWehre.ToString(), ex);
            }
            return result;
        }

        private IQueryable<T> LoadEntitie(System.Linq.Expressions.Expression<Func<T, bool>> lambdaWehre)
        {
            return GetCurrentDal.LoadEntities(lambdaWehre);
        }
        #endregion

        #region 分页查询 LoadEntitiesWhere<S>
        public IQueryable<T> LoadEntitiesWhere<S>(
            System.Linq.Expressions.Expression<Func<T, bool>> lambdaWhere,
            System.Linq.Expressions.Expression<Func<T, S>> orderByWhere, bool isAsc, out int totalCount, int pageIndex, int pageSize)
        {
            return LoadEntitiesWheres(lambdaWhere, orderByWhere, isAsc, out totalCount, pageIndex, pageSize);
        }

        //按条件查找排序分页
        private IQueryable<T> LoadEntitiesWheres<S>(
            System.Linq.Expressions.Expression<Func<T, bool>> lambdaWhere,
            System.Linq.Expressions.Expression<Func<T, S>> orderByWhere, bool isAsc, out int totalCount, int pageIndex, int pageSize)
        {
            return GetCurrentDal.LoadEntitiesWhere<S>(lambdaWhere, orderByWhere, isAsc, out totalCount, pageIndex, pageSize);
        }
        #endregion

        public IQueryable<T> GetAllEntity(Expression<Func<T, bool>> condition, int pageIndex, int pageSize, out long total, params OrderModelField[] orderByExpression)
        {
            return GetCurrentDal.GetAllEntity(condition, pageIndex, pageSize, out total, orderByExpression);
        }

        //添加
        public bool AddEntities(T model)
        {
            GetCurrentDal.AddEntities(model);
            return this.DbSession.SaveChangesDbSession();
        }

        //更新
        public bool UpdateEntities(T model, params string[] proNames)
        {
            GetCurrentDal.UpdateEntities(model, proNames);
            return this.DbSession.SaveChangesDbSession();
        }

        //删除
        public bool DeleteByModel(T model)
        {
            GetCurrentDal.DeleteByModel(model);
            return this.DbSession.SaveChangesDbSession();
        }

    }
}
