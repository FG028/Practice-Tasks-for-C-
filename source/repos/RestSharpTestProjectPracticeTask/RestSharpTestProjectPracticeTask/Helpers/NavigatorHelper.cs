namespace RestSharpTestProjectPracticeTask.Helpers
{
    public class NavigatorHelper
    {
        private readonly string _baseUrl;
        public NavigatorHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string GetUrl(string path)
        {
            return $"{_baseUrl}{path}";
        }
    }
}