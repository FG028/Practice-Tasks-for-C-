public class Analyzer 
{
    public static double analyzeLog(string logFilePath) // Create a class
    {
        //Variable to store error messages and total messages
        List<string> errorMessages = new List<string>();
        int totalMessages = 0;
        //Try-catch-finally block to handle file operations
        try
        {
            //Open the log file for reading
            using (StreamReader reader = new StreamReader(logFilePath))
            {
                //Read each line form the title
                string? line;
                while ((line = reader.ReadLine()) != null)
        {
            string message;
            if (line.Contains("error") || line.Contains("Error") || line.Contains("ERROR"))
            {
                message = line;
                errorMessages.Add(message);
            } else if (line.Contains("CRITICAL ERROR"))
            {
                throw new MyCriticalErrorException("Found CRITICAL ERROR in log");
            }

            totalMessages++;
        }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: File not found - " + logFilePath);
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
            return -1;
        }
        // Write error message to errors.log file
        try
        {
            using (StreamWriter writer = new StreamWriter("errors.log"))
            {
                foreach (string message in errorMessages)
                {
                    writer.WriteLine(message);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: Could not open errors.log file for writing.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        // Handle CRITICAL ERRORs and thrown my own custom exception
        foreach (string message in errorMessages)
        {
            if (message.Contains("CRITICAL ERROR"))
            {
                throw new MyCriticalErrorException("Found CRITICAL ERROR in log");
            }
        }
        //Calculate and return the ratio
        if (totalMessages == 0)
        {
            return 0;
        }
        else
        {
            return (double)totalMessages / errorMessages.Count;
        }
    }
    public class MyCriticalErrorException : Exception
    {
        public MyCriticalErrorException(string message) : base(message) { }
    }
    public static void Main(string[] args)
    {
        try
        {
            double ratio = analyzeLog("yupdate.log");
            Console.WriteLine("Ratio of total messages to error messages: {0:0.0.}", ratio);
        }
        catch (MyCriticalErrorException ex)
        {
            Console.WriteLine("Found CRITICAL ERROR: " + ex.Message);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Log file is empty");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}