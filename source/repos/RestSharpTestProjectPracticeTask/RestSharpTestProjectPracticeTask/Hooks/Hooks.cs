using BoDi;
using RestSharpTestProjectPracticeTask.Configuration_Files;
using RestSharpTestProjectPracticeTask.Helpers;
using TechTalk.SpecFlow;

namespace RestSharpTestProjectPracticeTask.Hooks
{
    public class Hooks
    {
        [BeforeTestRun]
        public static void RegisterObjectContainerInstance(IObjectContainer objectContainer)
        {
            objectContainer.RegisterTypeAs<RestSharpClient, IRestSharpClient>();
        }
    }
}
