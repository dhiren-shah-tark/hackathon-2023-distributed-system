using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TaskExecutor.Models;
using TaskExecutor.Repo;
using Task = TaskExecutor.Models.Task;

namespace TaskExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private TaskExecutorRepo _executorRepo;
        public NodesController(IConfiguration configuration)
        {
            _executorRepo = new TaskExecutorRepo(configuration);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterNode([FromBody] NodeRegistrationRequest node)
        {
            _executorRepo.RegisterNode(node);
            return Ok();
        }
        
        [HttpDelete]
        [Route("unregister/{name}")]
        public IActionResult UnregisterNode(string name)
        {
            _executorRepo.UnregisterNode(name);
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public List<Node> GetNodes()
        {
            return _executorRepo.GetNodes();
        }

        [HttpGet]
        [Route("task/{status}")]
        public List<Task> GetTaskByStatus(string status)
        {
            return _executorRepo.GetTasksByStatus(status);
        }

        [HttpGet]
        [Route("task/queue")]
        public List<Task> GetTaskQueue()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("task/submit")]
        public IActionResult RegisterTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
