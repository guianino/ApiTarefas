using Microsoft.AspNetCore.Mvc;
using ApiTarefas.Database;
using ApiTarefas.Models;
using ApiTarefas.ModelViews;

namespace ApiTarefas.Controllers.TasksController;

[ApiController]
[Route("/tasks")]
public class TasksController : ControllerBase {

    public TasksController(TasksContext db){

        _db = db;
    }

    private TasksContext _db;
    [HttpGet]
    public IActionResult Index(){
        
        var tasks = _db.Tasks.ToList();
        return StatusCode(200, tasks);
        }
        
    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id){

        var taskDB = _db.Tasks.Find(id);
        if(taskDB == null)

            return StatusCode(404, new ErrorView { Message = $"Tarefa não encontrado, ID: ({id})"});


        return StatusCode(200, taskDB);
        }
    
    [HttpPost]
    public IActionResult Create( [FromBody] MyTask task){

        if(string.IsNullOrEmpty(task.Title)){

            return StatusCode(400, new ErrorView { Message = "O Título é obrigatório"});

        }
        
        _db.Tasks.Add(task);
        _db.SaveChanges();
        return StatusCode(201, task);
        }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] MyTask task){

        if(string.IsNullOrEmpty(task.Title))

            return StatusCode(400, new ErrorView { Message = "O Título é obrigatório"});

        var taskDB = _db.Tasks.Find(id);
        if(taskDB == null)

            return StatusCode(404, new ErrorView { Message = $"Tarefa não encontrado, ID: ({id})"});

        taskDB.Title = task.Title;
        taskDB.description = task.description;
        taskDB.completed = task.completed;

        _db.Tasks.Update(task);
        _db.SaveChanges();
        return StatusCode(200, task);
        }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id){

        var taskDB = _db.Tasks.Find(id);
        if(taskDB == null)

            return StatusCode(404, new ErrorView { Message = $"Tarefa não encontrado, ID: ({id})"});

        _db.Tasks.Remove(taskDB);
        _db.SaveChanges();
        return StatusCode(204);
        }
}
