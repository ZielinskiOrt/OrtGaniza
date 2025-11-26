using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class TareaException : Exception
    {
        public TareaException() { }

        public TareaException(string message) : base(message) { }

        public TareaException(string message, Exception inner) : base(message, inner) { }
    }
}
