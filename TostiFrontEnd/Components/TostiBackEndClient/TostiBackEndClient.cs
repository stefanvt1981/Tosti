using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestSharp;
using TostiBusinessEntities;

namespace TostiFrontEnd.Components.TostiBackEndClient
{
    
    public class TostiBackEndClient : ITostiBackEndClient
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

            return response.Data ?? new List<Tosti>();
        }

        public Tosti GetTosti(int id)
        {
            var request = new RestRequest("tosti/{id}", Method.GET);
            request.AddHeader("content-type", @"application/json");
            request.AddUrlSegment("id", id);

            var response = _client.Execute<Tosti>(request);

            return response.Data;
        }

        public bool UpsertTosti(Tosti tosti)
        {
            var request = CreateRequest(tosti, Method.POST);

            var response = _client.Execute(request);

            return response.IsSuccessful;
        }

        public bool DeleteTosti(Tosti tosti)
        {
            var request = CreateRequest(tosti, Method.DELETE);

            var response = _client.Execute<Tosti>(request);

            return response.IsSuccessful;
        }

        private static RestRequest CreateRequest(Tosti tosti, Method method)
        {
            var request = new RestRequest("tosti", method);
            request.AddHeader("content-type", @"application/json"); 
                request.AddJsonBody(tosti);
            return request;
        }


    }
}
