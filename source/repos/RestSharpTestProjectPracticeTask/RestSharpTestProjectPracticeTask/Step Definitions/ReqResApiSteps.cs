using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpTestProjectPracticeTask.Configuration_Files;
using RestSharpTestProjectPracticeTask.Helpers;
using System.Net;
using TechTalk.SpecFlow;

namespace RestSharpTestProjectPracticeTask.Step_Definitions
{
    [Binding]
    public class ReqResApiSteps
    {
        private readonly string _baseUrl = "https://reqres.in/api/";
        private readonly IRestSharpClient _restSharpClient;
        private IRestResponse _response;
        private readonly CustomTimer _timer;

        public ReqResApiSteps(CustomTimer timer, IRestSharpClient restSharpClient)
        {
            _restSharpClient = restSharpClient;
            _timer = timer;
        }

        [Given(@"The application is prepared")]
        public async void GivenTheApplicationIsPrepared()
        {
            await _restSharpClient.GetAsync("GET", "");
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

        [When(@"I send a (.*) request to ""(.*)"" with the following user data:")]
        public async Task GivenISendARequestToWithTheFollowingUserData(string method, string endpoint, object userData)
        {
            _response = await _restSharpClient.ExecuteAsync(method, endpoint, userData);
        }

        [When(@"I send a (.*) request to ""(.*)""")]
        public async Task GivenISendARequestTo(string method, string endpoint)
        {
            _response = await _restSharpClient.GetAsync(method, endpoint);
        }

        [Then(@"the status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.AreEqual((HttpStatusCode)expectedStatusCode, _response.StatusCode);
        }

        [Then(@"the response body should contain a list of users")]
        public void ThenTheResponseBodyShouldContainAListOfUsers()
        {
            Assert.That(_response.IsSuccessful);
            Assert.NotNull(_response.Content);
        }

        [Then(@"the response body should contain the newly created user details")]
        public async Task ThenTheResponseBodyShouldContainTheNewlyCreatedUserDetails()
        {
            if (_response.IsSuccessful)
            {
                var json = await Task.Run(() => JsonConvert.DeserializeObject<Dictionary<string, string>>(_response.Content));
                Assert.That(json.ContainsKey("id"), "Response body does not contain 'id' field for newly created user.");
            }
        }

        [Then(@"the response body should contain the updated user details")]
        public async Task ThenTheResponseBodyShouldContainTheUpdatedUserDetails()
        {
            if (_response.IsSuccessful)
            {
                var json = await Task.Run(() => JsonConvert.DeserializeObject<Dictionary<string, string>>(_response.Content));
                Assert.That(json.ContainsKey("id"), "Response body does not contain 'id' field for updated user.");
            }
        }

        [Then(@"the response body should contain a token")]
        public async Task ThenTheResponseBodyShouldContainAToken()
        {
            if (_response.IsSuccessful)
            {
                var json = await Task.Run(() => JsonConvert.DeserializeObject<Dictionary<string, string>>(_response.Content));
                Assert.That(json.ContainsKey("token"), "Response body does not contain a 'token' field.");
            }
        }

        [Then(@"the response time should be greater than 2 seconds")]
        public async Task ThenTheResponseTimeShouldBeGreaterThan2Seconds()
        {
            _timer.Start();
            await _restSharpClient.GetAsync("GET", "users/delayed");
            _timer.Stop();

            var elapsedTime = _timer.GetElapsedSeconds();
            Assert.That(elapsedTime > 2, $"Response time was {elapsedTime} seconds, which is not greater than 2 seconds.");
        }

        [Then(@"the response body should contain the following user details")]
        public void ThenTheResponseBodyShouldContainTheFollowingUserDetailsIfSuccessful(Table table)
        {
            if (!_response.IsSuccessful)
            { 
                Console.WriteLine($"Response was not successful. Status code: {_response.StatusCode}");
                return;
            }

            var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(_response.Content);

            foreach (var row in table.Rows)
            {
                string fieldName = row["Field"];
                string expectedValue = row["Expected Value"];

                if (!json.TryGetValue(fieldName, out var actualValue))
                {
                    Assert.Fail($"Field '{fieldName}' not found in response body.");
                    continue;
                }

                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
        }
    }
}