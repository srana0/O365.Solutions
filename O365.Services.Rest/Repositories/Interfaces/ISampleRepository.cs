using System.IO;

namespace O365.Services.Rest.Repositories.Interfaces
{
    public interface ISampleRepository
    {
        string SampleGetRESTResponse(Stream inputStream);
    }
}