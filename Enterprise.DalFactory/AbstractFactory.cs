using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Enterprise.IDAL;

namespace Enterprise.DalFactory
{
    /**
     * Class: AbstractFactory
     *
     * 抽象抽象工厂封装数据操作类实例创建，然后DBSession调用抽象工厂。
     *
     * Author: bishisan
     *
     * Date: 2017/8/4
     */

    public class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];



        public static IAdminDal CreateAdminDal()
        {
            string fullClassName = NameSpace + ".AdminDal";
            return CreateInstance(fullClassName) as IAdminDal;
        }
        #region
        /**
         * Fn: private static Object CreateInstance(string className)
         *
         * 映射
         *
         * Author: bishisan
         *
         * Date: 2017/8/4
         *
         * Parameters:
         * className -  Name of the class.
         *
         * Returns: The new instance.
         */

        private static Object CreateInstance(string className)
        {
            var assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(className);
        }
        #endregion
    }
}
