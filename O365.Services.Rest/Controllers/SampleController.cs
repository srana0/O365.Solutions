

namespace O365.Services.Rest.Controllers
{
    using O365.Services.Rest.Repositories.Interfaces;
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.OData;

    public class SampleController : ApiController
    {
        private ISampleRepository _sampleRepository;

        public SampleController(ISampleRepository samepleRepository)
        {
            _sampleRepository = samepleRepository;
        }

        [EnableQuery]
        [HttpPost]
        public string SampleGetRESTResponse()
        {
            string result = "";
            try
            {
                var resolveRequest = HttpContext.Current.Request;
                Stream inputStream = resolveRequest.InputStream;
                result = _sampleRepository.SampleGetRESTResponse(inputStream);
            }
            catch (Exception ex)
            {
                Exception finalEx = new Exception("Exception:" + ex.Message);
                throw finalEx;
            }

            return result;
        }
    }
}