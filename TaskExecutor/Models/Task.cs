using Microsoft.OpenApi.Extensions;
using static TaskExecutor.Models.Enums;

namespace TaskExecutor.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public TaskExecutionStatus Status { get; set; }
        public string StatusValue => Status.GetDisplayName();
    }
}
