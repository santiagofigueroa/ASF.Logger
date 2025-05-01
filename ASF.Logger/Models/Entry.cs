using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Logger.Models
{
    public class Entry
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Message { get; set; } = string.Empty;
        public Severity Severity { get; set; } = Severity.Info;
        public string? User { get; set; }
        public string? Context { get; set; }
        public string? Exception { get; set; }
    }
}
