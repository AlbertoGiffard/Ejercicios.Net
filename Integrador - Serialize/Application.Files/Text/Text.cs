using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Files.Text
{
    public class Text<T> : IFile<T>
    {
        public bool Read(string file, out T data)
        {
            throw new NotImplementedException();
        }

        public bool Save(string file, T data)
        {
            bool result = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(data);
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
