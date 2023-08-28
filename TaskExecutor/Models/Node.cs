namespace TaskExecutor.Models
{
    public class Node: NodeRegistrationRequest
    {
        public Guid Id { get; set; }
        public List<Task> Tasks{ get; set; }
    }
}
