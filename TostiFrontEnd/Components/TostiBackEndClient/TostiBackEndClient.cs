using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestSharp;
using TostiBusinessEntities;

namespace TostiFrontEnd.Components.TostiBackEndClient
{
    
    public class TostiBackEndClient
    {

        private readonly RestClient _client;
        private readonly TostiBackEndClientOptions _options;

        public TostiBackEndClient(IOptionsMonitor<TostiBackEndClientOptions> optionsAccessor)
        {
            _options = optionsAccessor.CurrentValue;
            _client = new RestClient(_options.TostiBackEnd_URL);
        }

        public List<Tosti> GetAllTostis()
        {
            var request = new RestRequest("tosti", Method.GET);
            request.AddHeader("content-type", @"application/json");

            var response = _client.Execute<List<Tosti>>(request);

            return response.Data;
        }
    }
}
