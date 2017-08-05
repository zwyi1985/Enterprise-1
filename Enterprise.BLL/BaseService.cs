using Enterprise.DalFactory;
using Enterprise.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IDbSession CurrentDbSession {
            get {
                return DbSessionFactory.CreateDbSession();
            }
        }

        /**
         * Property: public IDAL.IBaseDal<T> CurrentDal
         *
         * 当前的基类
         *
         * Returns: The current dal.
         */

        public IDAL.IBaseDal<T> CurrentDal { get; set; }

        /**
         * Fn: public abstract void SetCurrentDal();
         *
         * 虚方法，子类复写方法
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         */

        public abstract void SetCurrentDal();

        /**
         * Fn: public BaseService()
         *
         * 构造函数
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         */

        public BaseService()
        {
            SetCurrentDal();//子类一定要实现抽象方法。
        }

        /**
         * Fn: public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
         *
         * 加载所有实体
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

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        /**
         * Fn: public IQueryable<T> LoadPageEntites<s>(int pageIndex, int pageSize, out int totalCount,
         * System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
         * System.Linq.Expressions.Expression<Func<T, s>> orderByLambda, bool isAsc)
         *
         * 分页加载实体
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
         * orderByLambda -  The order by lambda.
         * isAsc -          True if this object is ascending.
         *
         * Returns: The page entites.
         */

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderByLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount, whereLambda, orderByLambda, isAsc);
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
            CurrentDal.DeleteEntity(entity);
            return CurrentDbSession.SaveChanges();
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
            CurrentDal.EditEntity(entity);
            return CurrentDbSession.SaveChanges();
        }

        /**
         * Fn: public T AddEntity(T entity)
         *
         * 添加实体
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Parameters:
         * entity -  The entity.
         *
         * Returns: A T.
         */

        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            CurrentDbSession.SaveChanges();
            return entity;
        }
    }
}
