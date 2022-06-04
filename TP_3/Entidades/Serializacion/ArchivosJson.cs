using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ArchivosJson<T> where T : class
    {   
        /// <summary>
        /// Método genérico que serializa un objeto en formato json 
        /// </summary>
        /// <param name="datos"></param>
        /// <param name="nombre"></param>
        /// <param name="path"></param>
        /// <exception cref="Exception"></exception>
        public static void Escribir(T datos, string nombre, string path)
        {
            path += @"Datos\";
            string nombreArchivo = path + nombre + ".json";
           
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.WriteAllText(nombreArchivo, JsonSerializer.Serialize(datos));

            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }
        }

        /// <summary>
        /// Método genérico que deserializa en formato json    
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="path"></param>
        /// <returns> Retorna el objeto</returns>
        /// <exception cref="Exception"></exception>
        public static T Leer(string nombre, string path)
         {           
            string archivo = string.Empty;            
            T datosRecuperados = default;
            path += @"\Datos\";
         
            try
            {
                if (Directory.Exists(path))
                {                    
                    string[] archivosEnElPath = Directory.GetFiles(path);
                    
                    foreach (string archivoPath in archivosEnElPath)
                    {
                        if (archivoPath.Contains(nombre))
                        {
                            archivo = archivoPath;
                            break;
                        }
                    }

                    if (archivo != null)
                    {
                        datosRecuperados = JsonSerializer.Deserialize<T>(File.ReadAllText(archivo));
                    }
                }

                return datosRecuperados;
            }
            
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }

        }
    }
}
