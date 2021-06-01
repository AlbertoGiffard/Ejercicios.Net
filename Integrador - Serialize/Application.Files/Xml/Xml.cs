using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Files.Xml
{
    public class Xml<T> : IFile<T>
    {
        public bool Read(string file, out T data)
        {
            bool result = false;

            try
            {
                using (XmlTextReader xmlTextReader = new XmlTextReader(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    data = (T)serializer.Deserialize(xmlTextReader);
                    result = true;
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("No se encontro el archivo", e);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("No se encontro el directorio", e);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException("La ruta de acceso es Null ", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Es una cadena de longitud cero, contiene sólo espacios en blanco, o contiene caracteres no válidos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al intentar escribir en la ruta", e);
            }

            return result;
        }

        public bool Save(string file, T data)
        {
            bool result = false;

            try
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(file, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(xmlTextWriter, data);
                    result = true;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException("Sin los permisos necesarios", e);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException("La ruta de acceso es Null ", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Es una cadena de longitud cero, contiene sólo espacios en blanco, o contiene caracteres no válidos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al intentar escribir en la ruta", e);
            }

            return result;
        }
    }
}
