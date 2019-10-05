using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera,
            Descremada
        }

        ETipo tipo;

       #region Constructores

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del producto de tipo Leche</param>
        /// <param name="codigo">codigo del producto de tipo Leche</param>
        /// <param name="color">color del producto de tipo Leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color): this(marca, codigo, color,ETipo.Entera)
        {
            
        }

        /// <summary>
        /// Constructor de Leche que inicializa con parametros los atributos de la clase heradada Producto.
        /// </summary>
        /// <param name="marca">Marca del producto de tipo Leche</param>
        /// <param name="codigo">codigo del producto de tipo Leche</param>
        /// <param name="color">color del producto de tipo Leche</param>
        /// <param name="tipo">tipo del producto de tipo Leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo): base(codigo, marca, color)
        {
            this.tipo = tipo;
        }

        #endregion

       #region Propiedades

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Muestra el contenido del producto Leche
        /// </summary>
        /// <returns>Retorna un string con los datos de Leche</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE"); 

            sb.AppendLine(base.Mostrar());

            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
