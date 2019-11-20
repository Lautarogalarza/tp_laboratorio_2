using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// propiedad de tipo lectura y escritura de la lista de paquetes de correo
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// constructor sin parametros de la clsae que inicializa las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que recorre la lista de hilos de correo y cierra todos los hilos vivos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }

            }
        }

        /// <summary>
        /// muestra todos los datos del correo usando la interfas MostrarDatos
        /// </summary>
        /// <param name="elemento">objeto a mostrar</param>
        /// <returns>retorna una cadena con los datos del objeto</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder cadena = new StringBuilder();

            foreach (Paquete item in ((Correo)elementos).Paquetes)
            {
                cadena.AppendLine(string.Format("{0} para {1} ({2}) ", item.TrackingID, item.DireccionEntrega, item.Estado));
            }

            return cadena.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// sobrecarga del operador + que agraga un nuevo paquete a la lista de correos y agrega un nuevo hilo a la lista
        /// </summary>
        /// <param name="c">correo1</param>
        /// <param name="p">paquete1</param>
        /// <returns>retorna el correo con el paquete agregado si se pudo agregar y el correo sin cambios si no</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = false;

            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    flag = true;
                    break;
                }

            }
            if (flag != true)
            {
                c.Paquetes.Add(p);
                Thread nuevoHilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(nuevoHilo);
                nuevoHilo.Start();
            }
            else
            {
                throw new TrackingIdRepetidoException("el Tracking ID " + p.TrackingID.ToString() + " ya figura en la lista de envios");
            }

            return c;
        }

        #endregion

    }
}
