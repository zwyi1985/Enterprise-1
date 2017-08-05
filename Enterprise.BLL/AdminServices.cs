using Enterprise.IBLL;
using Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.BLL
{
    public class AdminServices : BaseService<Admin>,IAdminServices
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.AdminDal;
        }        
    }
}
