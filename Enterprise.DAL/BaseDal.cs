using Enterprise.IDAL;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.DAL
{
    public class BaseDal<T> where T:class,new()
    {
        DbContext Db = DbContextFactory.CreateDbContext();

        /**
         * Fn: public T AddEntity(T entity)
         *
         * 添加实体，返回插入的实体
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Parameters:
         * entity -  The entity.
         *
         * Returns: An T.
         */

        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }

        /**
         * Fn: public bool DeleteEntity(T entity)
         *
         * 删除实体
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Parameters:
         * entity -  The entity.
         *
         * Returns: True if it succeeds, false if it fails.
         */

        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return true;
        }

        /**
         * Fn: public bool EditEntity(T entity)
         *
         * 修改实体
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Parameters:
         * entity -  The entity.
         *
         * Returns: True if it succeeds, false if it fails.
         */

        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return true;
        }

        /**
         * Fn: public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
         *
         * 查询所有数据
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Parameters:
         * whereLambda -  The where lambda.
         *
         * Returns: The entities.
         */

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }

        /**
         * Fn: public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize,
         * out int totalCount, Expression<Func<T, bool>> whereLambda,
         * Expression<Func<T, s>> orderbyLambda, bool isAsc)
         *
         * 分页查询数据
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Typeparams:
         * s -  Type of the s.
         * Parameters:
         * pageIndex -      Zero-based index of the page.
         * pageSize -       Size of the page.
         * totalCount -     [out] Number of totals.
         * whereLambda -    The where lambda.
         * orderbyLambda -  The orderby lambda.
         * isAsc -          True if this object is ascending.
         *
         * Returns: The page entities.
         */

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderByLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}
