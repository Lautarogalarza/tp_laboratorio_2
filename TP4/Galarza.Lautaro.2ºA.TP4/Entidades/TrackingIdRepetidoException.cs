using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException:Exception
    {
        /// <summary>
        /// Exception que valida salta cuando el trackingID se repite
        /// </summary>
        /// <param name="mensaje">mensaje de la excepcion</param>
        public TrackingIdRepetidoException(string mensaje):base(mensaje)
        {

        }

        /// <summary>
        /// Exception que valida salta cuando el trackingID se repite
        /// </summary>
        /// <param name="mensaje">mensaje de la excepcion</param>
        /// <param name="inner">tipo de excepcion</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner):base(mensaje,inner.InnerException)
        {

        }


    }
}
