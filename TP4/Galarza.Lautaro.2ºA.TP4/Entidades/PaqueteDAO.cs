using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor estatico de la clase que inicializa la conexion y el comando para la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.connect);
            comando = new SqlCommand();

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que inserta el objeto pasado en la base de datos validando que la conexion es correcta
        /// </summary>
        /// <param name="p">objeto a insertar</param>
        /// <returns>retorna true si se puso insertar y false si no se pudo</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] ([direccionEntrega],[trackingID],[alumno])" + " VALUES (@direccion, @tracking, @alumno)";
                comando.Parameters.AddWithValue("@direccion", p.DireccionEntrega);
                comando.Parameters.AddWithValue("@tracking", p.TrackingID);
                comando.Parameters.AddWithValue("@alumno", "Galarza Lautaro");
                comando.ExecuteNonQuery();
                retorno = true;

            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conexion.Close();
            }

            return retorno;
        }

        #endregion

    }
}
