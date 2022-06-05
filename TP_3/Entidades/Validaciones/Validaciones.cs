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
        /// <summary>
        /// Método encargado de validar que el string pasado por parámetro
        /// sean solamente letras
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Si cumple con la expresión regular devuelve true, sino false</returns>
        /// <exception cref="ArgumentoNoValidoException"></exception>
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

        /// <summary>
        /// Método encargado de validar que el string pasado por parámetro
        /// tenga el formato de email, Ej: diario@mail.com
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Si cumple con la expresión regular devuelve true, sino false</returns>
        /// <exception cref="ArgumentoNoValidoException"></exception>
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

        /// <summary>
        /// Método encargado de validar que el string pasado por parámetro
        /// sean solo ocho números
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Si cumple con la expresión regular devuelve true, sino false</returns>
        /// <exception cref="ArgumentoNoValidoException"></exception>
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

        /// <summary>
        /// Método encargado de validar que el string pasado por parámetro
        /// sean once numeros que pueden estar separados con guiones. Ej: 456-456-4567
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Si cumple con la expresión regular devuelve true, sino false</returns>
        /// <exception cref="ArgumentoNoValidoException"></exception>
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
