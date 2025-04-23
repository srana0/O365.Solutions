using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;
using System.Configuration;
using System.Net;



namespace RESTAPI.Repositories
{
    public class SPContext : ISPContext
    {

        ClientContext ctx;
        public SPContext()
        {
        }

        public ClientContext GetContext(string webUrl)
        {
            if (ctx == null || !ctx.Url.Equals(webUrl))
            {
                ctx = new ClientContext(webUrl);
            }

            return ctx;
        }

        public ClientContext GetSPContext(string webUrl, bool useServiceAccount)
        {
            ctx = GetContext(webUrl);

            if (useServiceAccount)
            {
                //TODO : Implement try catch
                string svcUsername = ConfigurationManager.AppSettings["SPSvcAccount"];
                string svcPassword = ConfigurationManager.AppSettings["SPSvcAccountPass"];
                ctx.Credentials = new NetworkCredential(svcUsername, svcPassword);
            }

            return ctx;
        }
    }
}