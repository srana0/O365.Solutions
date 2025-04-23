
using O365.Services.Rest.Repositories.Interfaces;
using System;
using System.IO;
using System.Web.Script.Serialization;
using O365.Models;

namespace O365.Services.Rest.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private ISPRepository _spRepository;

        public SampleRepository(ISPRepository spRepository)
        {
            _spRepository = spRepository;
        }

        public string SampleGetRESTResponse(Stream inputStream)
        {
            string response = string.Empty;
            SampleModel sampleModel = null;
            try
            {
                StreamReader reader = new StreamReader(inputStream);
                string text = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                //Deserialize the json string and convert to Known type Custom object SampleModel
                sampleModel = (js.Deserialize<SampleModel>(text));
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}