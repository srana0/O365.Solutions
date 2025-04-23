using Microsoft.SharePoint.Client;

namespace O365.Services.Rest.Repositories.Interfaces
{
    /// <summary>
    /// Interface for SPCOntext
    /// </summary>
    public interface ISPRepository
    {
        ClientContext GetContext(string WebUrl);

        ClientContext GetContext(string WebUrl, bool useServiceAccount);
    }
}