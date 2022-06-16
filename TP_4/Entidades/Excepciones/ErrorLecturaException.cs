using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ErrorLecturaException : Exception
    {
        public ErrorLecturaException(string mensaje) : base(mensaje)
        {

        }
    }
}
