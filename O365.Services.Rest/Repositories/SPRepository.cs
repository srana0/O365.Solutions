namespace O365.Services.Rest.Repositories
{
    using Interfaces;
    using Microsoft.SharePoint.Client;
    using System.Configuration;
    using System.Net;

    public class SPRepository : ISPRepository
    {
        private ClientContext ctx;

        public SPRepository()
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

        public ClientContext GetContext(string WebUrl, bool useServiceAccount)
        {
            ctx = GetContext(WebUrl);

            if (useServiceAccount)
            {
              
                ctx.Credentials = GetCredentials();
            }

            return ctx;
        }

        public static NetworkCredential GetCredentials()
        {
            string svcUsername = ConfigurationManager.AppSettings["SPSvcAccount"];
            string svcPassword = ConfigurationManager.AppSettings["SPSvcAccountPass"];
            return new NetworkCredential(svcUsername, svcPassword);
        }
    }
}