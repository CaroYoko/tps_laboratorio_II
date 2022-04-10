using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{  
    public class Operando
    {
        private double numero;

        public Operando() : this(0)
        {
            
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        public string Numero
        {
            set { numero = this.ValidarOperando(value); }

        }

        /// <summary>
        /// Valida si en el string hay caracteres de números
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> Si hay, devuelve el número sino 0 </returns> 
        private double ValidarOperando(string strNumero)
        {
            double numStr;

            double.TryParse(strNumero, out numStr);

            return numStr;
        }

        /// <summary>
        /// Convierte un número binario a número decimal.
        /// Valida previamente que el string sea número y binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna el numero convertido a decimal en tipo string</returns>
        public static string BinarioDecimal(string binario)
        {
            int resultado = 0;
            string retorno;
            int bit;
            char c;

            if (Operando.EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    c = binario[i];

                    bit = (int)Char.GetNumericValue(binario[i]);

                    resultado += bit * (int)(Math.Pow(2, (binario.Length - 1) - i));

                }

                retorno = resultado.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }

            return retorno;

        }

        /// <summary>
        /// Convierte un numero decimal a numero binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero convertido a binario en tipo string</returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            int div = (int)Math.Abs(numero);

            while (div >= 2)
            {
                retorno = (div % 2).ToString() + retorno;
                div = (div - div % 2) / 2;
            }
            retorno = div + retorno;
            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal a numero binario. 
        /// Valida previamente que el string sea número y binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero convertido a binario en tipo string</returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "";
            double auxiliar;

            if (double.TryParse(numero, out auxiliar))
            {
                retorno = Operando.DecimalBinario(auxiliar);
            }
            else
            {
                retorno = "Valor inválido";
            }

            return retorno;
        }

        /// <summary>
        /// Valida que la cadena ingresada este compuesta por 1 y 0
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Si lo es retorna true, sino false</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;

            foreach (char item in binario)
            {
                if (item != '0' && item != '1')
                {
                    retorno = false;
                    break;
                }

            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga el operador - para restar dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado en tipo double</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        ///  Sobrecarga el operador + para sumar dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado en tipo double</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga el operador / para dividir dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado en tipo double</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }

            return resultado;
        }

        /// <summary>
        /// Sobrecarga el operador * para multiplicar dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado en tipo double</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }




    }
}
