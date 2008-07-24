using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using MidLayer;

namespace UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MidLayerSettings.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            MidLayerSettings.AppPath = Context.Server.MapPath("~/App_Data");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}