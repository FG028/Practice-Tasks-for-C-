namespace RestSharpTestProjectPracticeTask.Helpers
{
    public static class ServiceContainer
    {
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        public static void RegisterService<T>(T service)
        {
            Services.Add(typeof(T), service);
        }

        public static T GetService<T>()
        {
            if (!Services.TryGetValue(typeof(T), out object service))
            {
                throw new ArgumentException($"Service of type {typeof(T)} is not registered.");
            }
            return (T)service;
        }
    }
}