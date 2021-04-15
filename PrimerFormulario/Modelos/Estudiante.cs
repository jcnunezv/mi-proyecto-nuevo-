using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PrimerFormulario.Modelos
{
    class Estudiante : Conexion
    {
        private string nombreTabla = "estudiantes";
        private string cedula, id, nombre, edad;

        public Estudiante(string cedula, string nombre, string edad)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
        }

        public Estudiante()
        {
        }

        public Estudiante(string id,string cedula,  string nombre, string edad) : this(id, cedula, nombre)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Id { get => id; set => id = value; }

        public void Agregar()
        {
            string consulta = "INSERT INTO " + nombreTabla + " (cedula, nombre, edad)  VALUES (' " + cedula + "', '" + nombre + "', '" + edad + "') ";
            base.EjecutarConsulta(consulta);

        }

public void editar()
        {
            string consulta = " UPDATE " + nombreTabla + " SET cedula=' " + cedula + ", nombre= '" + nombre + "', edad ='" + edad + "' WHERE id = '" + id + "'";
            base.EjecutarConsulta(consulta);
        }
        public List<Estudiante> ObtenerRegistros()
        {
            List<Estudiante> estudiantes =new List<Estudiante>();
            string consulta = "SELECT id, cedula, nombre, edad FROM " + nombreTabla;
            MySqlDataReader reader = base.ObtenerRegistros(consulta);
            if (reader != null)
            {
                while (reader.Read())
                {
                    estudiantes.Add(new Estudiante (Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3])));
                }
            }
            return estudiantes;
            }

        }
    }


