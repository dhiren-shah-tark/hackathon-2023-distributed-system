using System.ComponentModel.DataAnnotations;

namespace TaskExecutor.Models
{
    public class Enums
    {
        public enum TaskExecutionStatus
        {
            [Display(Name = "Pending")]
            Pending,
            [Display(Name = "Running")]
            Running,
            [Display(Name = "Completed")]
            Completed,
            [Display(Name = "Failed")]
            Failed
        }
    }
}
