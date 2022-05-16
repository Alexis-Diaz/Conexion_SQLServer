using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Data;

namespace ConexionSQLServer
{
    class EjecutarSentenciasSQL_ComandoSelect
    {
        SqlConnection conexion;
        SqlCommand comando;

        void CrearConexion ()
        {
            string cadena = @"Data source = DELL-PC\SQLEXPRESS; initial catalog = DBConexionSQLServer; user=Alexis; password=1234; integrated security = false";
            this.conexion = new SqlConnection(cadena);
        }

        void OpenConexion()
        {
            try
            {
                this.conexion.Open();
                Console.WriteLine("Conexion abierta con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al intentar abrir conexion: {e.Message}");
                throw;
            }
        }

        void CloseConexion()
        {
            try
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                    Console.WriteLine("La conexion se ha cerrado con exito");
                }
                else
                {
                    Console.WriteLine("No hay conexion abiertas");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                throw;
            }
        }

        void CrearComando()
        {
            string query = "SELECT NombrePersona FROM Persona";
            this.comando = new SqlCommand(query, conexion);
        }

        void EjecutarComando()
        {
            Console.WriteLine("Ejecutando comando en la base de datos");
            SqlDataReader registros = this.comando.ExecuteReader();

            while (registros.Read())
            {
                string Persona = registros["NombrePersona"].ToString();
                Console.WriteLine(Persona);
            }
        }

        public void Ejecutar()
        {
            CrearConexion();
            OpenConexion();
            CrearComando();
            EjecutarComando();
            CloseConexion();
        }
    }
}
