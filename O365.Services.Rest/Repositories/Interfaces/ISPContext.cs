using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace O365.Services.Rest.Repositories.Interfaces
{
    /// <summary>
    /// Interface for SPCOntext
    /// </summary>
    public interface ISPContext
    {

        ClientContext GetContext(string contextURL);
    }
}
