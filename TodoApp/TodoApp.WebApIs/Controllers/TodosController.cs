using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.WebApIs.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;
        public TodosController()
        {
            _repository = new TodoRepositoryJson(@"D:\temp\Todos.json");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // return Content("안녕하세요");

            return Ok(_repository.GetAll());
            

        }


        [HttpPost]
        public IActionResult Add([FromBody] Todo dto)
        {
            _repository.Add(dto);
            return Ok(dto);
        }

    }
}
