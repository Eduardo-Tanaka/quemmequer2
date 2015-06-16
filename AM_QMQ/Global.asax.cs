using AM_QMQ.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AM_QMQ
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<QMQContext>(new DropCreateDatabaseAlways<QMQContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<QMQContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<QMQContext>());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
