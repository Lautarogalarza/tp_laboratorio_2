﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        #region Propiedades

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que inicializa los parametros de producto
        /// </summary>
        /// <param name="codigo">codigo del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">color del producto</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
            this.codigoDeBarras = codigo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        /// 
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Devuelve un string con los datos de un producto determinado
        /// </summary>
        /// <param name="p">Producto </param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Producto 1</param>
        /// <param name="v2">Producto 2</param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Producto 1</param>
        /// <param name="v2">Producto 2</param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }

        #endregion

    }
}
