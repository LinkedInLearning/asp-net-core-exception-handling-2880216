using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Exceptions
{
    public class StudentNameException:Exception
    {
        public string StudentName { get; set; }

        public StudentNameException()
        {
        }

        public StudentNameException(string message):base(message)
        {

        }

        public StudentNameException(string message, Exception innerException):base(message, innerException)
        {

        }
        
        public StudentNameException(string message, string studentName): base(message)
        {
            StudentName = studentName;
        }
    }
}
