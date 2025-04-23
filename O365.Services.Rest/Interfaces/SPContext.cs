using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;
using System.Configuration;
using System.Net;


namespace .RESTWebAPI
{
    public class SPContext : ISPContext
    {
        ClientContext ctx;
        public SPContext()
        {
            //ctx = new ClientContext("http://domain.com/");
            //ctx = new ClientContext("http://domain.com/");
        }

        public ClientContext GetContext(string contextURL)
        {
                return new ClientContext(contextURL);
          

        }

        private ClientContext GetSPContext(string webUrl, bool useServiceAccount)
        {
            ClientContext ctx = new ClientContext(webUrl);

            if (useServiceAccount)
            {
                string svcUsername = ConfigurationManager.AppSettings["SPSvcAccount"];
                string svcPassword = ConfigurationManager.AppSettings["SPSvcAccountPass"];
                ctx.Credentials = new NetworkCredential(svcUsername, svcPassword);
            }
            return ctx;
        }
    }
}