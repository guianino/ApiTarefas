using Microsoft.EntityFrameworkCore;
using ApiTarefas.Models;

namespace ApiTarefas.Database;


public class TasksContext : DbContext {
    #nullable disable

    public TasksContext (DbContextOptions<TasksContext> options) : base (options){

    }

    public DbSet<MyTask> Tasks {get; set;}
}