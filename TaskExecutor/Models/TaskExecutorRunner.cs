namespace TaskExecutor.Models
{
    public class TaskExecutorRunner
    {
        public TaskExecutorRunner()
        {
            Nodes = new List<Node>();
        }
        public List<Node> Nodes { get; set; }
    }
}
