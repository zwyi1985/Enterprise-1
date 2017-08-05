using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.IDAL
{
   public interface IDbSession
    {
        DbContext Db { get; }

        IAdminDal AdminDal { get; set; }

        bool SaveChanges();

    }
}
