using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArgumentoNoValidoException : Exception
    {
        public ArgumentoNoValidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
