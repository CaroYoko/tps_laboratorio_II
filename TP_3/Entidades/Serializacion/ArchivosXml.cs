using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class ArchivosXml<T>
    {
        static string path;

        static ArchivosXml()
        {
            path =Environment.GetFolderPath(Environment.SpecialFolder.Desktop);            
            path += @"\Datos\";
        }

        public static void Escribir(T datos, string nombre)
        {
            string nombreArchivo = path + "SerializacionXml_" + nombre +"_"+ DateTime.Now.ToString("dd-MM-yyyy") + ".xml";
           
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter streamWriter = new StreamWriter(nombreArchivo))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, datos);
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }
        }


        

    }
}
