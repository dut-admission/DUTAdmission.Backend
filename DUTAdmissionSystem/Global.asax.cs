using DUTAdmissionSystem.Database;
using DUTAdmissionSystem.Database.Schema.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Z.EntityFramework.Plus;

namespace DUTAdmissionSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            #region config_audit_trail

            //Add by AnTM to config the audit trail for database
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
                (context as DataContext)?.AuditEntries.AddRange(audit.Entries);
            //AuditManager.DefaultConfiguration.Exclude<TokenLogin>();
            AuditManager.DefaultConfiguration.ExcludeProperty<Table>(x =>
                new { x.CreatedAt, x.CreatedBy, x.UpdatedAt, x.UpdatedBy });
            //End add by AnTM to config the audit trail for database

            #endregion config_audit_trail

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
