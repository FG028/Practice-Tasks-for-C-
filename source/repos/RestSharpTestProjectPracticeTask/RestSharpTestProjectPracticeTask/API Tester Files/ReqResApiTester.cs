using RestSharp;
using RestSharpTestProjectPracticeTask.Configuration_Files;
using RestSharpTestProjectPracticeTask.Helpers;

namespace RestSharpTestProjectPracticeTask.StepDefinitions
{
    public class ReqResApiTester
    {
        private readonly string _baseUrl;
        private readonly IRestSharpClient _restSharpClient;

        public ReqResApiTester(IRestSharpClient restSharpClient)
        {
            _baseUrl = "https://reqres.in/api/";
            _restSharpClient = restSharpClient;
        }

        public async Task<IRestResponse> GetUserById(int userId)
        {
            return await _restSharpClient.GetAsync("GET", $"users/{userId}");
        }

        public async Task<IRestResponse> GetListOfUsers(int page = 1)
        {
            return await _restSharpClient.GetAsync("GET", $"users?page={page}");
        }

        public async Task<IRestResponse> CreateUser(object user)
        {
            return await _restSharpClient.PostAsync("POST", "users", user);
        }

        public async Task<IRestResponse> UpdateUser(int userId, object user)
        {
            return await _restSharpClient.PutAsync("PUT", $"users/{userId}", user);
        }

        public async Task<IRestResponse> DeleteUser(int userId)
        {
            return await _restSharpClient.DeleteAsync("DELETE", $"users/{userId}");
        }

        public async Task<IRestResponse> RegisterUser(object user)
        {
            return await _restSharpClient.PostAsync("POST", "auth/register", user);
        }

        public async Task<IRestResponse> LoginUser(object user)
        {
            return await _restSharpClient.PostAsync("POST", "auth/login", user);
        }

        public async Task<IRestResponse> GetDelayedResponse()
        {
            return await _restSharpClient.GetAsync("GET", "users/delayed");
        }
    }
}