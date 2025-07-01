namespace Villa.Logging
{
    public class Logging:ILogging
    {
        public void Log(string message, string type)
        {
            Console.WriteLine($"Log Type: {type}, Message: {message}");
        }
    }
}
