/**
 * File: DBSession.cs.
 *
 * 工厂类，负责所有数据操作类的创建
 */

using Enterprise.DAL;
using Enterprise.IDAL;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.DalFactory
{
    public class DBSession:IDbSession
    {
        //EnterpriseEntities Db = new EnterpriseEntities();

        public DbContext Db {
            get {
                return DbContextFactory.CreateDbContext();
            }
        }

        private IAdminDal _adminDal;
        public IAdminDal AdminDal
        {
            get
            {
                if (_adminDal == null)
                {
                    _adminDal = AbstractFactory.CreateAdminDal();
                }
                return _adminDal;
            }
            set
            {
                _adminDal = value;
            }
        }

        /**
         * Fn: public bool SaveChanges()
         *
         * 工作单元模式，处理多表的操作
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Returns: True if it succeeds, false if it fails.
         */

        public bool SaveChanges()
        {
            return Db.SaveChanges()>0;
        }
    }
}
