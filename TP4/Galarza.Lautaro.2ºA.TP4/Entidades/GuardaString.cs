using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension de string que guarda dicha string en un archivo de texto
        /// </summary>
        /// <param name="texto">cadena a guardar</param>
        /// <param name="archivo">ruta del archivo</param>
        /// <returns>retorna true si se pudo guardar y false si no</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool retorno = false;
         
            try
            {

                using (StreamWriter nuevoTexto = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true))
                {
                    nuevoTexto.Write(texto);
                    retorno = true;

                }
            }
            catch (Exception e)
            {
                throw  e;
            }

            return retorno;

        }

    }
}
