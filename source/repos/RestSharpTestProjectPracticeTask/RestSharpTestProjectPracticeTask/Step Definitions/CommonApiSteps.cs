using RestSharp;
using RestSharpTestProjectPracticeTask.Helpers;

public class CommonApiSteps
{
    private readonly IRestSharpClient _restSharpClient;
    private readonly NavigatorHelper _navigator;

    public CommonApiSteps(IRestSharpClient restSharpClient, NavigatorHelper navigator)
    {
        _restSharpClient = restSharpClient;
        _navigator = navigator;
    }

    public async Task<IRestResponse> SendRequest(string method, string path, object body = null)
    {
        var url = _navigator.GetUrl(path);
        return await _restSharpClient.ExecuteAsync(method, url, body);
    }
}