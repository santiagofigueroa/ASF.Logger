using ASF.Logger.Models;

namespace ASF.Logger
{
    public static class ASFLogger 
    {
        public static Action<Entry>? ExternalLogger { get; set; }

        public static void Log(string message, Severity severity = Severity.Info, string? user = null, string? context = null, Exception? ex = null)
        {
            var logEntry = new Entry
            {
                Message = message,
                Severity = severity,
                User = user,
                Context = context,
                Exception =  ex?.Message + ex?.InnerException + ex?.StackTrace // Only included information essential for debugging
            };

            // Write to Console output
            Console.WriteLine($"[{logEntry.Timestamp:u}] [{logEntry.Severity}] {logEntry.Message}");

            // Forward to custom external logger (e.g., PostgreSQL)
            ExternalLogger?.Invoke(logEntry);
        }

        public static void LogException(Exception ex, string context = "", string? user = null)
        {
            Log(ex.Message, Severity.Error, user, context, ex);
        }

    }
}
