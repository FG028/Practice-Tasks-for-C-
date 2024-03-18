using RestSharp;
using RestSharpTestProjectPracticeTask.Configuration_Files;

namespace RestSharpTestProjectPracticeTask.Helpers
{

    public class RestSharpClient : IRestSharpClient
    {
        private readonly Configuration _configuration;
        private readonly Logging _logging;
        private readonly string _baseUrl;

        public RestSharpClient(string baseUrl, Configuration configuration, Logging logging)
        {
            _baseUrl = baseUrl;
            _configuration = configuration;
            _logging = logging;
        }

        public async Task<IRestResponse> GetAsync(string method, string resource)
        {
            var client = new RestClient(_configuration.BaseUrl);
            var request = new RestRequest(resource, GetRequestMethod(method));
            request.AddHeader("User-Agent", "Learning RestSharp");

            _logging.LogRequest(request, _configuration.BaseUrl);

            var response = await client.ExecuteAsync(request);
            _logging.LogResponse(response);

            return response;
        }

        public async Task<IRestResponse> PostAsync(string method, string resource, object body)
        {
            var client = new RestClient(_configuration.BaseUrl);
            var request = new RestRequest(resource, GetRequestMethod(method));
            request.AddHeader("User-Agent", "Learning RestSharp");
            request.AddJsonBody(body);

            _logging.LogRequest(request, _configuration.BaseUrl);

            var response = await client.ExecuteAsync(request);

            _logging.LogResponse(response);

            return response;
        }

        public async Task<IRestResponse> PutAsync(string method, string resource, object body)
        {
            var client = new RestClient(_configuration.BaseUrl);
            var request = new RestRequest(resource, GetRequestMethod(method));
            request.AddHeader("User-Agent", "Learning RestSharp");
            request.AddJsonBody(body);

            _logging.LogRequest(request, _configuration.BaseUrl);

            var response = await client.ExecuteAsync(request);

            _logging.LogResponse(response);

            return response;
        }

        public async Task<IRestResponse> DeleteAsync(string method, string resource)
        {
            var client = new RestClient(_configuration.BaseUrl);
            var request = new RestRequest(resource, GetRequestMethod(method));
            request.AddHeader("User-Agent", "Learning RestSharp");

            _logging.LogRequest(request, _configuration.BaseUrl);

            var response = await client.ExecuteAsync(request);

            _logging.LogResponse(response);

            return response;
        }
    
        public async Task<IRestResponse> PatchAsync(string method, string resource, object body)
        {
            var client = new RestClient(_configuration.BaseUrl);
            var request = new RestRequest(resource, GetRequestMethod(method));
            request.AddHeader("User-Agent", "Learning RestSharp");
            request.AddJsonBody(body);

            _logging.LogRequest(request, _configuration.BaseUrl);

            var response = await client.ExecuteAsync(request);

            _logging.LogResponse(response);

            return response;
        }

        public async Task<IRestResponse> ExecuteAsync(string method, string resource, object body)
        {
            IRestClient client = new RestClient(_configuration.BaseUrl);
            IRestRequest request = new RestRequest(resource, GetRequestMethod(method));
            request.AddHeader("User-Agent", "Learning RestSharp");

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            _logging.LogRequest(request, _configuration.BaseUrl);

            var response = await client.ExecuteAsync(request);

            _logging.LogResponse(response);

            return response;
        }

        private Method GetRequestMethod(string method)
        {
            switch (method.ToLower())
            {
                case "get":
                    return Method.GET;
                case "post":
                    return Method.POST;
                case "put":
                    return Method.PUT;
                case "delete":
                    return Method.DELETE;
                default:
                    throw new ArgumentException($"Invalid HTTP method: {method}");
            }
        }
    }
}