using RestSharp;

namespace RestSharpTestProjectPracticeTask.Configuration_Files
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

        Task<IRestResponse> ExecuteAsync(string method, string resource, object? body);
    }
}
