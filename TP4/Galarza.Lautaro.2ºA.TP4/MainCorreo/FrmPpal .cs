using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        /// <summary>
        /// constructor del formulario que instancia el objeto de tipo correo
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// actualiza las listBox mostrando el pasaje del paquete por sus estados
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Carga la informacion del objeto al formulario y lo guarda en un archivo de salida
        /// </summary>
        /// <typeparam name="T">tipo de objeto generico</typeparam>
        /// <param name="elemento">elemento a mostrar</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string cadena = "";

            if (Object.Equals(elemento, null) == false)
            {

                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try
                {
                    cadena = elemento.MostrarDatos(elemento);
                    cadena.Guardar("salida.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }

        }

        /// <summary>
        /// agrega el paquete a la la lista de correos y invoca al evento informaEstado y luego llama al metodo ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            nuevoPaquete.informaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);

            try
            {
                correo += nuevoPaquete;
            }
            catch (TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            this.ActualizarEstados();

        }

        /// <summary>
        /// llamada al metodo generico mostrarInformacion que va a mostrar un paquete y guardarlo en una archivo de salida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// llamada al metodo generico mostrarInformacion que va a mostrar la lista de paquetes y guardarlos en una archivo de salida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// invoca al metodo actualizarEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// cierra todos los hilos abiertos del correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
    }
}
