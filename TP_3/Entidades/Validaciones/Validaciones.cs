using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Validaciones
    {
        public static bool EsNombreApellidoValido(string texto)
        {
            try
            {
                return Regex.IsMatch(texto, @"^[a-zA-ZñÑ]+$");
            }
            catch (Exception)
            {
                throw new ArgumentoNoValidoException("El argumento no es válido");
            }

        }

        public static bool EsMailValido(string texto)
        {
            try
            {
                return Regex.IsMatch(texto, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            }
            catch (Exception)
            {
                throw new ArgumentoNoValidoException("El argumento no es válido");
            }

        }

        public static bool EsDNIValido(int texto)
        {
            try
            {
                return Regex.IsMatch(texto.ToString(), @"[0-9]{8}(\.[0-9]{0,2})?$");
            }
            catch (Exception)
            {
                throw new ArgumentoNoValidoException("El argumento no es válido");
            }

        }

        public static bool EsCelularValido(string texto)
        {
            try
            {             

                return Regex.IsMatch(texto, @"^\d{3}\-?\d{3}\-?\d{4}");
            }
            catch (Exception)
            {
                throw new ArgumentoNoValidoException("El argumento no es válido");
            }


        }

    }
}
