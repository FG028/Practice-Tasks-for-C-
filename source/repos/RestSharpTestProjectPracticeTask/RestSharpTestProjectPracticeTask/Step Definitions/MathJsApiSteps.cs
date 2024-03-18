using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using RestSharpTestProjectPracticeTask.Configuration_Files;
using System.Net;

namespace YourProjectName.MathJsApiSteps
{
    [Binding]
    public class MathJsApiSteps
    {
        private readonly string _baseUrl = "http://api.mathjs.org/v4/";
        private readonly IRestSharpClient _restSharpClient;
        private IRestResponse _response;

        public MathJsApiSteps(IRestSharpClient restSharpClient)
        {
            _restSharpClient = restSharpClient;
        }

        [Given(@"The application is put together")]
        public async void GivenTheApplicationIsPrepared()
        {
            await _restSharpClient.GetAsync("GET", "");
            Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
        }

        [When(@"I send a POST request to ""(.*)"" with the following expression")]
        public async Task WhenISendAPostRequestToWithTheFollowingExpression(string endpoint, string expression)
        {
            var body = new { args = new[] { expression } };
            _response = await _restSharpClient.PostAsync("POST", $"{_baseUrl}{endpoint}", body);
        }

        [When(@"I send a POST request to ""(.*)"" with the following invalid expression")]
        public async Task WhenISendAPostRequestWithAnInvalidExpression(string endpoint, string expression)
        {
            _response = null;
            await _restSharpClient.PostAsync("POST", $"{_baseUrl}{endpoint}", new { args = new[] { expression } });
        }

        [Then(@"The status code should be the next (.*)")]
        public void ThenTheStatusCodeShouldBe(HttpStatusCode expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, _response.StatusCode);
        }

        [Then(@"the response body should contain the following result:")]
        public void ThenTheResponseBodyShouldContainTheFollowingResult(Table table)
        {
            var json = JObject.Parse(_response.Content);

            foreach (var row in table.Rows)
            {
                string fieldName = row["Field"];
                string expectedValue = row["Expected Value"];

                var token = json.SelectToken(fieldName);
                if (token == null)
                {
                    Assert.Fail($"Field '{fieldName}' not found in response body.");
                    continue;
                }

                string actualValue = token.ToString();
                Assert.That(actualValue, Is.EqualTo(expectedValue));
            }
        }

        // [ScenarioOutline]
        public async Task PerformMathJsOperation(string expression, string expectedResult)
        {
            await WhenISendAPostRequestToWithTheFollowingExpression("eval", expression);
            
            ThenTheStatusCodeShouldBe((HttpStatusCode) 200);
            ThenTheResponseBodyShouldContainTheFollowingResult(CreateResultTable(expectedResult));
        }

        private Table CreateResultTable(string expectedResult)
        {
            var table = new Table("Field", "Expected Value");
            table.AddRow("result", expectedResult);
            return table;
        }

        // [Scenario]
        public async Task InvalidExpression()
        {
            await WhenISendAPostRequestWithAnInvalidExpression("eval", "abc");
            ThenTheStatusCodeShouldBe((HttpStatusCode) 400);
        }
    }
}