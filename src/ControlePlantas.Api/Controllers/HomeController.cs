using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControlePlantas.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index() => Ok("Bem vindo ao gerenciamento de plantações!");
    }
}
