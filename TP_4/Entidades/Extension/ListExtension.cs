using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    public static class ListExtension
    {
        public static void AgregarListado<T>(this List<T> lista) where T : class, IListable
        {
            try
            {
                if (lista is not null)
                {
                    foreach (T item in lista)
                    {
                        item.AgregarAListado();
                    }
                }
            }
            catch (NoEncontradoExcepcion ex)
            {
                throw ex;
            }
        }
    }
}
