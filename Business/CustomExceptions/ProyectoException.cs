using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class ProyectoException : Exception
    {
        public ProyectoException() { }

        public ProyectoException(string message) : base(message) { }

        public ProyectoException(string message, Exception inner) : base(message, inner) { }
    }
}
