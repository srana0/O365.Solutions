using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace RESTWebAPI
{
    public interface ISPContext
    {

        ClientContext GetContext(string contextURL);
    }
}
