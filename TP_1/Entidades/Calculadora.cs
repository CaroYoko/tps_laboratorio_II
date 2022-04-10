using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida si el operador ingresado es +, -, * o /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Si el operador es válido, retorna el operador. Sino '+'</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                return '+';
            }
            else
            {
                return operador;
            }
        }

        /// <summary>
        /// Realiza una operación autorizada (+,-,*,/) entre dos objetos de clase Operando.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operación en tipo double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;

            }

            return resultado;
        }
    }
}
