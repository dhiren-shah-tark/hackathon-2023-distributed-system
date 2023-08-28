using NuGet.Protocol;
using System.Text.Json;
using TaskExecutor.Models;

namespace TaskExecutor.Repo
{
    public class TaskExecutorRepo
    {
        private HttpClient _httpClient;
        private TaskExecutorRunner _executorRunner;
        private const int MaxTaskCapacityPerNode = 5;
        private List<Task> _tasks;
        
        public TaskExecutorRepo(IConfiguration configuration)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration.GetSection("MemeURL").Value)
            };
            _executorRunner = new TaskExecutorRunner();
            while (true)
            {
                CheckPendingTasks();
            }
        }

        public async void ExecuteTask()
        {
            var json = (await this._httpClient.GetAsync("")).Content;
            var data = JsonSerializer.Deserialize<MemeImage>(json.ToJson());

            //pending
        }

        public void CheckPendingTasks()
        {
            if (_executorRunner.Nodes.Any())
            {
                if(_executorRunner.Nodes.SelectMany(x => x.Tasks).Any())
                {


                    var tasks = _executorRunner.Nodes.SelectMany(x => x.Tasks).ToList();
                    var completedTasks = tasks.Where(x => x.Status == Enums.TaskExecutionStatus.Completed).ToList();
                    tasks = tasks.Except(completedTasks).ToList();


                }
            }
        }

        public List<Node> GetNodes()
        {
            return this._executorRunner.Nodes;
        }

        public void RegisterNode(NodeRegistrationRequest request)
        {
            this._executorRunner.Nodes.Add(new Node()
            {
                Id = Guid.NewGuid(),
                Address = request.Address,
                Name = request.Name,
                Tasks = new List<Models.Task>()
            });
        }

        public void UnregisterNode(string name)
        {
            var node = this._executorRunner.Nodes.FirstOrDefault(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
            if(node != null)
                _executorRunner.Nodes.Remove(node);
        }

        public List<Models.Task> GetTasksByStatus(string status)
        {
            var tasks = this._executorRunner.Nodes.SelectMany(x => x.Tasks).ToList();
            return tasks.Where(x => x.StatusValue.Equals(status, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public void RegisterTask(Models.Task task)
        {
            _tasks.Add(task);
        }
    }
}
