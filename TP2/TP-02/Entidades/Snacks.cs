using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks:Producto
    {

       #region Constructores

        /// <summary>
        /// Constructor que inicializa los tres parametros de un producto de tipo Snack
        /// </summary>
        /// <param name="marca">Marca del producto de tipo Snacks</param>
        /// <param name="codigo">codigo del producto de tipo Snacks</param>
        /// <param name="color">color del producto de tipo Snacks</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color):base(codigo, marca, color)
        {


        }

        #endregion

       #region Propiedades

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Muestra el contenido de el producto Snack
        /// </summary>
        /// <returns>Retorna un string con los datos de Snack</returns>
        public override sealed string Mostrar()
        {         
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");

            sb.AppendLine(base.Mostrar());

            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
