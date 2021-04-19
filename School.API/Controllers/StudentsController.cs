using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.API.Data;
using School.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-all-students")]
        public IActionResult GetAllStudents()
        {
            var allStudents = _context.Students.ToList();
            return Ok(allStudents);
        }

        [HttpPost("add-new-student")]
        public IActionResult AddNewStudent([FromBody]Student payload)
        {

            _context.Students.Add(payload);
            _context.SaveChanges();

            return Created("", null);
        }
    }
}
