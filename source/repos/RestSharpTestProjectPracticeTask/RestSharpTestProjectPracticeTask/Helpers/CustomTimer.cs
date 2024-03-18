using System.Diagnostics;

namespace RestSharpTestProjectPracticeTask.Helpers
{
    public class CustomTimer
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        public double GetElapsedMilliseconds()
        {
            return _stopwatch.ElapsedMilliseconds;
        }

        public double GetElapsedSeconds()
        {
            return GetElapsedMilliseconds() / 1000.0;
        }
    }
}