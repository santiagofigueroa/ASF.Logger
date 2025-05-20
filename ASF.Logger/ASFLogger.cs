using ASF.Logger.Interface;
using ASF.Logger.Models;
using System.Runtime.CompilerServices;

namespace ASF.Logger
{
    public class ASFLogger : IASFLogger
    {
        public static Action<Entry>? ExternalLogger { get; set; }

        public async Task LogAsync(string message, Severity severity = Severity.Info, string? user = null, string? context = null, Exception? ex = null)
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

        
        public async Task LogExceptionAsync(Exception ex, string context = "", string? user = null)
        {
            await LogAsync(ex.Message, Severity.Error, user, context, ex);
        }
    }
}
