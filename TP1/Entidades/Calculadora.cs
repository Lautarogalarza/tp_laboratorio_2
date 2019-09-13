using System;

namespace Entidades
{
    public static class Calculadora
    {

        #region Metodos

        /// <summary>
        ///Metodo que realizara la operacion debida entre los dos objetos de tipo Numero dependiendo del caso 
        /// </summary>
        /// <param name="num1"> Recibe el primero operando </param> 
        /// <param name="num2"> Recibe el segundo operando </param> 
        /// <param name="operador"> Recibe el operador que decidira que operacion se realizara </param> 
        /// <returns> Retorna el resultado de la operacion entre el primer y segundo operando </returns>  
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            string miOperador;

            miOperador = ValidarOperador(operador);

            switch (miOperador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;

            }

            return retorno;
        }

        #endregion

        #region Validaciones

        /// <summary> 
        /// Metodo que va a validar si el operador recibido es correcto 
        /// </summary>
        /// <param name="operador"> string que contiene el operador </param> 
        /// <returns> Retorna el operador recibido si es correcto, y si no retorna el operador "+" </returns> 
        private static string ValidarOperador(string operador)
        {
            string retorno = operador;

            if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
            {
                retorno = "+";
            }

            return retorno;
        }

        #endregion

    }
}
