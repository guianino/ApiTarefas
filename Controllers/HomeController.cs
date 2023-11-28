using Microsoft.AspNetCore.Mvc;
using ApiTarefas.ModelViews;
using System.Xml.Schema;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
   
    public HomeController()
    {
    }

    [HttpGet]
    public HomeView Index()
    {
        return new HomeView{
            Message = "Welcome to the API of tasks",
            Documentation = "/swagger"
        };
    }
}
