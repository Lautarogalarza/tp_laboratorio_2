using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar <T>
    {
        /// <summary>
        /// Interfaz generico que se encargara de mostrar los datos de un elemento
        /// </summary>
        /// <param name="elemento">tipo de dato genereico a mostrar</param>
        /// <returns>retorna una cadena con los datos del elemento</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
