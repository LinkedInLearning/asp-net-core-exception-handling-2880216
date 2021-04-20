using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.API.Data;
using School.API.Data.Models;
using School.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            throw new Exception("This is an unhandled exception test");

            try
            {
                var allStudents = _context.Students.ToList();
                //throw new Exception("Could not get data from the database");
                return Ok(allStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                string stopHere = "Debug";
            }
        }

        [HttpGet("get-student-by-id/{id}")]
        public IActionResult GetStudentById(int id)
        {
            if (id <= 0) throw new ArgumentException("Please, provide an id > 0");

            var allStudents = _context.Students.ToArray();
            var studentPosition5 = allStudents[4];

            var studentInfo = _context.Students.FirstOrDefault(n => n.Id == id);
            var studentFullName = studentInfo.FullName;

            return Ok($"Student name = {studentFullName}");
        }

        [HttpPost("add-new-student")]
        public IActionResult AddNewStudent([FromBody]Student payload)
        {
            try
            {
                if (Regex.IsMatch(payload.FullName, @"^\d")) throw new StudentNameException("Name starts with number", payload.FullName);

                if(StudentIs20OrYounger(payload.DateOfBirth)) throw new StudentAgeException($"{payload.FullName} needs to be older than 20. Birth year: {payload.DateOfBirth.Year}");

                throw new Exception("This is just a test");

                _context.Students.Add(payload);
                _context.SaveChanges();

                return Created("", null);
            }
            catch (StudentAgeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (StudentNameException ex)
            {
                return BadRequest($"{ex.StudentName} starts with a digit");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not add student to the database");
            }
        }

        private bool StudentIs20OrYounger(DateTime dateOfBirth)
        {
            //today's date
            var today = DateTime.Today;

            //calculate the age
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) age--;

            if (age <= 20) return true;

            return false;
        }
    }
}
