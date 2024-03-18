using RestSharp;

namespace RestSharpTestProjectPracticeTask.Configuration_Files
{
    public class Logging
    {
        private readonly bool _useConsole;

        public Logging(bool useConsole = true)
        {
            _useConsole = useConsole;
        }

        public void LogRequest(IRestRequest request, string baseUrl)
        {
            if (_useConsole)
            {
                Console.WriteLine("**Request:**");
                Console.WriteLine($" Method: {request.Method}");
                Console.WriteLine($" URL: {baseUrl}{request.Resource}");
                Console.WriteLine($" Headers:");

                foreach (var header in request.Parameters)
                {
                    if (header.Type == ParameterType.HttpHeader)
                    {
                        Console.WriteLine($"  {header.Name}: {header.Value}");
                    }
                }
                if (request.Body != null)
                {
                    Console.WriteLine($" Body: {request.Body}");
                }
            }
        }

        public void LogResponse(IRestResponse response)
        {
            if (_useConsole)
            {
                Console.WriteLine("**Response:**");
                Console.WriteLine($" Status Code: {response.StatusCode}");
                Console.WriteLine($" Content: {response.Content}");
            }
        }
    }
}