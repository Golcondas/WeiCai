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
using WeiCai.DalAbstratFactory;
using WeiCai.Entity;

namespace WeiCai.Bll
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDbSession DbSession { get { return new DalAbstratFactory.DbSession(); } }

        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }

        public static IDAL.IBaseDal<T> GetCurrentDal { get; set; }

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> lambdaWehre)
        {
            return GetCurrentDal.LoadEntities(lambdaWehre);
        }

        //按条件查找排序分页
        public IQueryable<T> LoadEntitiesWhere<S>(
            System.Linq.Expressions.Expression<Func<T, bool>> lambdaWhere,
            System.Linq.Expressions.Expression<Func<T, S>> orderByWhere, bool isAsc, out int totalCount, int pageIndex, int pageSize)
        {
            return GetCurrentDal.LoadEntitiesWhere<S>(lambdaWhere, orderByWhere, isAsc, out totalCount, pageIndex, pageSize);
        }

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
