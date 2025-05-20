using ASF.Logger.Models;

namespace ASF.Logger.Interface
{
    public interface IASFLogger
    {
        Task LogAsync(string message, Severity severity = Severity.Info, string? user = null, string? context = null, Exception? ex = null);
        Task LogExceptionAsync(Exception ex, string context = "", string? user = null);
    }
}