using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.DAL
{
   public class DbContextFactory
    {
        /**
         * Fn: public static DbContext CreateDbContext()
         *
         * 负责创建EF数据操作上下文实例，必须保证线程内唯一
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Returns: The new database context.
         */

        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext==null)
            {
                dbContext = new EnterpriseEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
