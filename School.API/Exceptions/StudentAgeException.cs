using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Exceptions
{
    public class StudentAgeException:Exception
    {
        public StudentAgeException(string message):base(message)
        {

        }
    }
}
