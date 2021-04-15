using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrimerFormulario.Modelos
{
    class Conexion
    {
        private string error = "";
        private string cadenaConexion = "Server=localhost;port=3306;Database=ecotec;User id=root;Password=";
        private bool estaConectado = true;
        private MySqlConnection conexion;

        public string Error { get => error; set => error = value; }

        public Conexion()
        {
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                Console.WriteLine("Exito al conectarse");
            }
            catch (Exception e)
            {
                Error = e.Message;
                estaConectado = false;
                Console.WriteLine(e.Message);
            }
        }

        protected bool EjecutarConsulta(string consulta)
        {
            if (estaConectado)
            {
                try { 
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.ExecuteNonQuery();
                    return true;
                }catch(Exception e)
                {
                    error = e.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected MySqlDataReader ObtenerRegistros(string consulta)
        {
            if (estaConectado)
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                return comando.ExecuteReader();
            }
            else
            {
                return null;
            }
        }

        ~Conexion()
        {
            if (estaConectado)
            {
                conexion.Close();
            }
        }

    }
}
