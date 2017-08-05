using Enterprise.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.DalFactory
{
  public  class DbSessionFactory
    {
        /**
         * Fn: public static IDbSession CreateDbSession()
         *
         * 数据操作类创建者本身在线程中唯一
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Returns: The new database session.
         */

        public static IDbSession CreateDbSession()
        {
            IDbSession dbSession = (IDbSession)CallContext.GetData("dbSession");
            if (dbSession == null)
            {
                dbSession = new DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }
}
