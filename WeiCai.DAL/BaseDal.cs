﻿/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 17:13:23 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: bac47541-9291-4759-ad2b-df570264b7d2 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeiCai.DalAbstratFactory;
using WeiCai.Entity;

namespace WeiCai.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        DbContext db = DbContextFactory.CreateDbContext();

        //查找
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> lambdaWehre)
        {
            //EntityState.Unchanged ObjectStateManager 中已存在具有同一键的对象。ObjectSta

            //ObjectStateManager 中已存在具有同一键的对象。ObjectStateManager 无法跟踪具有相同键的多个对象。
            return db.Set<T>().AsNoTracking().Where<T>(lambdaWehre);
        }

        //按条件查找排序分页
        public IQueryable<T> LoadEntitiesWhere<S>(
            System.Linq.Expressions.Expression<Func<T, bool>> lambdaWhere,
            System.Linq.Expressions.Expression<Func<T, S>> orderByWhere, bool isAsc, out int totalCount, int pageIndex, int pageSize)
        {
            var temp = db.Set<T>().AsNoTracking().Where(lambdaWhere);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByWhere).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByWhere).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp;
        }

        /// <summary>
        /// 根据条件获取多个实体
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllEntity(Expression<Func<T, bool>> condition, int pageIndex, int pageSize, out long total, params OrderModelField[] orderByExpression)
        {
            //条件过滤
            var query = db.Set<T>().AsNoTracking().Where(condition);

            //创建表达式变量参数
            var parameter = Expression.Parameter(typeof(T), "o");

            if (orderByExpression != null && orderByExpression.Length > 0)
            {
                for (int i = 0; i < orderByExpression.Length; i++)
                {
                    //根据属性名获取属性
                    var property = typeof(T).GetProperty(orderByExpression[i].propertyName);
                    //创建一个访问属性的表达式
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);

                    string OrderName = "";
                    if (i > 0)
                    {
                        OrderName = orderByExpression[i].IsDESC ? "ThenByDescending" : "ThenBy";
                    }
                    else
                        OrderName = orderByExpression[i].IsDESC ? "OrderByDescending" : "OrderBy";


                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), OrderName, new Type[] { typeof(T), property.PropertyType }, query.Expression, Expression.Quote(orderByExp));

                    query = query.Provider.CreateQuery<T>(resultExp);
                }
            }

            total = query.Count();
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        //添加
        public bool AddEntities(T model)
        {
            try
            {
                db.Set<T>().Add(model);
                // db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        //更新
        public bool UpdateEntities(T model, params string[] proNames)
        {
            /*
             * Product attachedProduct = set.Local.SingleOrDefault(p => p.Id == item.Id);
                    //如果已经被上下文追踪
                    if (attachedProduct != null)
                    {
                        var attachedEntry = db.Entry(attachedProduct);
                        attachedEntry.CurrentValues.SetValues(item);
                    }
             * 
             * 
             * 
            */

            DbEntityEntry entry = db.Entry<T>(model);
            entry.State = EntityState.Unchanged;
            foreach (string proName in proNames)
            {
                entry.Property(proName).IsModified = true;
            }
            return db.SaveChanges() > 0;
            //return true;
        }

        //删除
        public bool DeleteByModel(T model)
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            return db.SaveChanges() > 0;
            //return true;
        }
    }
}