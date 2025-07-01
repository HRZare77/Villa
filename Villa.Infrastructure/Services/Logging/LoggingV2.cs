namespace Villa.Logging
{
    public class LoggingV2: ILogging
    {
        public void Log(string message, string type)
        {
            switch (type)
            {
                case "Error":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "Info":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "Debug":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine($"Log Type: {type}, Message: {message}");
        }
    }
}
