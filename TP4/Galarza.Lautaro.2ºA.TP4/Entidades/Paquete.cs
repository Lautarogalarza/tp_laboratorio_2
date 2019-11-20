using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {

        #region Eventos

        /// <summary>
        /// delegado que va a ser usado para el evento informa estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);

        /// <summary>
        /// evento que se va a encargar de informar el estado de los paquetes
        /// </summary>
        public event DelegadoEstado informaEstado;

        #endregion

        #region Enumerados

        /// <summary>
        /// enumerado de tipo EEstado que contiene los estados del paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #endregion

        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades

        /// <summary>
        /// propiedad de lectura y escritura del atributo direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura del enumerado EEstado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura del atributo trackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor del paquete que inicializa sus atributos y inicializa el estado en ingresado
        /// </summary>
        /// <param name="direccionEntrega">direccion del paquete</param>
        /// <param name="trackingID">trackingID del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Cambia los estados del paquete esperando 4 segundos y al final agrega el paquete a la base de datos por medio del metodo Insertar de la clase PaqueteDao
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {

                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        Thread.Sleep(4000);
                        this.Estado = EEstado.EnViaje;
                        this.informaEstado(this,EventArgs.Empty);
                        break;
                    case EEstado.EnViaje:
                        Thread.Sleep(4000);
                        this.Estado = EEstado.Entregado;
                        this.informaEstado(this, EventArgs.Empty);
                        break;
                    default:
                        break;
                }

            }
            try
            {
                PaqueteDAO.Insertar(this);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        /// <summary>
        /// muestra todos los datos del paquete usando la interfas MostrarDatos
        /// </summary>
        /// <param name="elemento">objeto a mostrar</param>
        /// <returns>retorna una cadena con los datos del objeto</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine(string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega));

            return cadena.ToString();
        }

        /// <summary>
        /// Sobreescritura del metodo ToString que llama al metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);

        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// sobrecarga del operador == que valida si un paquete es igual a otro comparando su trackingID
        /// </summary>
        /// <param name="p1">paquete1</param>
        /// <param name="p2">paquete2</param>
        /// <returns>retorna true si son iguales y false si no</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if (Object.Equals(p1, null) == false && Object.Equals(p2, null) == false)
            {

                if (p1.TrackingID == p2.trackingID)
                {
                    retorno = true;
                }

            }
            else
            {
                if (Object.Equals(p1, null) && Object.Equals(p2, null))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;


        }

        /// <summary>
        /// sobrecarga del operador != que valida si un paquete es distinto a otro comparando su trackingID
        /// </summary>
        /// <param name="p1">paquete1</param>
        /// <param name="p2">paquete2</param>
        /// <returns>retorna true si son distintos y false si no</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion


    }
}
