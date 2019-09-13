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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {


        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase FormCalculadora 
       /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Text = "+";
            this.lblResultado.Text = "0";
        }

        #endregion

        #region Botones

        /// <summary>
        /// Llama al metodo operar que realiza la operacion y muestra la misma en la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Llama al metodo limpiar que deja los campos de la calculadora en default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cierra la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Realiza la instancia de clase y convierte el resultado en decimal a binario y lo muestra por la pantalla de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero Binario = new Numero();

            this.lblResultado.Text = Binario.DecimalBinario(this.lblResultado.Text);

        }

        /// <summary>
        /// Realiza la instancia de clase y convierte el resultado en binario a decimal y lo muestra por la pantalla de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero Decimal = new Numero();

            this.lblResultado.Text = Decimal.BinarioDecimal(this.lblResultado.Text);

        }

        #endregion

        #region Metodos 

        /// <summary>
        /// Metodo que se encargara de limpiar la calculadora y dejarla en valores default
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.cmbOperador.Text = "+";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.txtNumero1.Focus();

        }

        /// <summary>
        /// Metodo que realiza las instancias de clases y la operacion deseada entre "numero1" y "numero2"
        /// </summary>
        /// <param name="numero1">  Recibe el primero operando en formato string </param>
        /// <param name="numero2">  Recibe el segundo operando en formato string </param>
        /// <param name="operador"> Recibe el operador que decidira que operacion se realizara </param>
        /// <returns> retorna el resultado de la operacion entra los dos atributos </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {

            Numero Numero1 = new Numero(numero1);
            Numero Numero2 = new Numero(numero2);

            return Calculadora.Operar(Numero1, Numero2, operador);
        }


        #endregion

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
