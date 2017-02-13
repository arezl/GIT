using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /////test liya
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/TestEnbeddedConfig.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
            ILog logger= log4net.LogManager.GetLogger("Alog");
            logger.Error("1");
        }
    }
}
