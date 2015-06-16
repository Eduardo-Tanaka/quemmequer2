using AM_QMQ.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AM_QMQ
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<QMQContext>(new DropCreateDatabaseAlways<QMQContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<QMQContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<QMQContext>());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
