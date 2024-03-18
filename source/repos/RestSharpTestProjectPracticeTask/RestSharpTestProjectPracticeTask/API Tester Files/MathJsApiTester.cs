using RestSharp;
using RestSharpTestProjectPracticeTask.Configuration_Files;
using RestSharpTestProjectPracticeTask.Helpers;

namespace RestSharpTestProjectPracticeTask.StepDefinitions
{
    public class MathJsApiTester
    {
        private readonly string _baseUrl;
        private readonly IRestSharpClient _restSharpClient;

        public MathJsApiTester(IRestSharpClient restSharpClient)
        {
            _baseUrl = "http://api.mathjs.org/v4/";
            _restSharpClient = restSharpClient;
        }

        public async Task<IRestResponse> Multiply(double num1, double num2)
        {
            var body = new { args = new[] { num1, num2 } };
            return await _restSharpClient.PostAsync("POST", "eval", body);
        }

        public async Task<IRestResponse> Divide(double num1, double num2)
        {
            var body = new { args = new[] { num1, num2 } };
            return await _restSharpClient.PostAsync("POST", "eval", body);
        }

        public async Task<IRestResponse> Add(double num1, double num2)
        {
            var body = new { args = new[] { num1, num2 } };
            return await _restSharpClient.PostAsync("POST", "eval", body);
        }

        public async Task<IRestResponse> Subtract(double num1, double num2)
        {
            var body = new { args = new[] { num1, num2 } };
            return await _restSharpClient.PostAsync("POST", "eval", body);
        }

        public async Task<IRestResponse> SquareRoot(double num)
        {
            var body = new { args = new[] { num } };
            return await _restSharpClient.PostAsync("POST", "eval", body);
        }
    }
}