using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{

    public class Numero
    {
        private double numero;

        #region Constructores
        
        /// <summary>
        /// Constructor de Numero por defecto. Inicializa el atributo this.numero en 0
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Constructor de Numero con parametro. Le pasa el numero recibido al atributo this.numero
        /// </summary>
        /// <param name="numero"></param> el valor de tipo string que se le dara a this.numero
        public Numero(string numero)
        {
            SetNumero = numero;

        }

        /// <summary>
        /// Constructor de Numero con parametro. Le pasa el numero recibido al atributo this.numero
        /// </summary> 
        /// <param name="numero"></param> el valor de tipo double que se le dara a this.numero
        public Numero(double numero) : this(numero.ToString())
        {

        }

        #endregion

        #region Conversores

        /// <summary>
        /// Metodo que va a convertir si es posible un numero binario a decimal
        /// </summary>
        /// <param name="binario"> string que contiene el numero binario a convertir </param> 
        /// <returns> retorna el numero entero convertido si fue posible, y si no retornara "Valor invalido" </returns> 
        public string BinarioDecimal(string binario)
        {
            string retornoDecimal = "";
            char[] arrayString = binario.ToCharArray();

            for (int i = 0; i < arrayString.Length; i++)
            {
                if (arrayString[i] == '1' || arrayString[i] == '0')
                {
                    retornoDecimal += arrayString[i];
                }
                else
                {
                    retornoDecimal = "Valor invalido";
                    break;
                }
            }

            if (retornoDecimal != "Valor invalido")
            {
                retornoDecimal = Convert.ToInt32(binario, 2).ToString();
            }


            return retornoDecimal;
        }


        /// <summary>
        /// Metodo que va a convertir si es posible un numero decimal a binario
        /// </summary>
        /// <param name="numero"> string que contiene el numero decimal a convertir </param> 
        /// <returns> retorna el numero binario convertido si fue posible, y si no retornara "Valor invalido" </returns>  
        public string DecimalBinario(string numero)
        {
            string retorno = "";
            int numeroInt;
            int resto;

            if (Int32.TryParse(numero, out numeroInt))
            {

                while (numeroInt > 0)
                {
                    resto = (numeroInt % 2);

                    if (resto == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }

                    numeroInt = numeroInt / 2;
                }

            }

            else
            {
                retorno = "Valor invalido";
            }


            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo "DecimalBinario"
        /// </summary>
        /// <param name="numero"> El numero decimal a convertir </param>
        /// <returns> Retornara el numero binario si el numero era valido, caso contrario retornara Valor invalido </returns>
        public string DecimalBinario(Double numero)
        {

            return DecimalBinario(numero.ToString());
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador "+" que permitira sumar los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"></param> primer operador
        /// <param name="n2"></param> segundo operador
        /// <returns></returns> retorna la suma de los atrubutos de tipo Numero 
        public static double operator +(Numero n1, Numero n2)
        {

            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "-" que permitira restar los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"></param> primer operador
        /// <param name="n2"></param> segundo operador
        /// <returns></returns> retorna la resta de los atrubutos de tipo Numero 
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        ///  Sobrecarga del operador "/" que permitira restar los atributos entre los distintos objetos del tipo Numero y valida que el segundo operador sea distinto de 0
        /// </summary>
        /// <param name="n1"></param> primer operador
        /// <param name="n2"></param> segundo operador
        /// <returns></returns> retorna la division de los atrubutos de tipo Numero, y si el segundo operando es 0 retorna "double.MinValue"
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador "*" que permitira restar los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"></param> primer operador
        /// <param name="n2"></param> segundo operador
        /// <returns></returns> retorna la multiplicacion de los atrubutos de tipo Numero 
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Metodo que va a validar si el string recibido es numerico entero, y si lo es va a parsearlo a double
        /// </summary>
        /// <param name="strNumero"> Recibe el string con el valor a validar  </param> 
        /// <returns> retorna el numero parseado si es entero o 0 si no lo es </returns> 
        private double ValidarNumero(string strNumero)
        {
            double retorno;

            bool isNum = double.TryParse(strNumero, out retorno);

            if (isNum == false)
            {
                retorno = 0;
            }

            return retorno;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad encargada de setear el valor al atributo this.numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);

            }
        }

        #endregion


    }

}
