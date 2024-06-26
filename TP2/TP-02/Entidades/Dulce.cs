﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {

        #region Constructores

        /// <summary>
        /// Constructor que inicializa los tres parametros de un producto de tipo dulce
        /// </summary>
        /// <param name="marca">Marca del producto de tipo Dulce</param>
        /// <param name="codigo">Código de barras del producto de tipo Dulce</param>
        /// <param name="color">Color del empaque del producto de tipo Dulce</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color):base(codigo,marca,color)
        {

        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        ///  Muestra el contenido del producto Dulce
        /// </summary>
        /// <returns>Retorna un string con los datos de Dulce</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");

            sb.AppendLine(base.Mostrar());

            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
