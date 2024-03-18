using RestSharp;
using RestSharpTestProjectPracticeTask.Configuration_Files;

namespace RestSharpTestProjectPracticeTask.Helpers
{
    public interface IRestSharpClient 
    {
        /// <summary>
        /// Sends an asynchronous GET request to the specified resource.
        /// </summary>
        /// <param name="resource">The resource path relative to the base URL.</param>
        /// <returns>A Task representing the asynchronous operation, containing the RestResponse object.</returns>
        Task<IRestResponse> GetAsync(string method, string resource);

        /// <summary>
        /// Sends an asynchronous POST request to the specified resource with a JSON body.
        /// </summary>
        /// <param name="resource">The resource path relative to the base URL.</param>
        /// <param name="body">The object to be serialized into JSON and sent in the request body.</param>
        /// <returns>A Task representing the asynchronous operation, containing the RestResponse object.</returns>
        Task<IRestResponse> PostAsync(string method, string resource, object body);

        /// <summary>
        /// Sends an asynchronous PUT request to the specified resource with a JSON body.
        /// </summary>
        /// <param name="resource">The resource path relative to the base URL.</param>
        /// <param name="body">The object to be serialized into JSON and sent in the request body.</param>
        /// <returns>A Task representing the asynchronous operation, containing the RestResponse object.</returns>
        Task<IRestResponse> PutAsync(string method, string resource, object body);

        /// <summary>
        /// Sends an asynchronous DELETE request to the specified resource.
        /// </summary>
        /// <param name="resource">The resource path relative to the base URL.</param>
        /// <returns>A Task representing the asynchronous operation, containing the RestResponse object.</returns>
        Task<IRestResponse> DeleteAsync(string method, string resource);

        Task<IRestResponse> ExecuteAsync(string method, string resource, object? body = null);
    }

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

        public async Task<IRestResponse> ExecuteAsync(string method, string resource, object body = null)
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