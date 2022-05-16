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
    

    class EjecutarSentenciasSQL_ComandoSelect_Item
    {
        SqlConnection conexion;
        SqlCommand comando;


        private void CrearConexion()
        {
            string cadena = @"Server = DELL-PC\SQLEXPRESS; database = DBConexionSQLServer; integrated security = true";
            this.conexion = new SqlConnection(cadena);
        }

        private void OpenConexion()
        {
            try
            {
                this.conexion.Open();
                Console.WriteLine("Conexion abierta con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al abrir conexion. ERROR: {e.Message}");
                throw;
            }
        }

        private void CloseConexion()
        {
            try
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                    Console.WriteLine("La conexion se ha cerrado con exito");
                }
                else
                {
                    Console.WriteLine("No se encontraron conexiones abiertas");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                throw;
            }
        }

        private void CrearComando(int Id)
        {
            string query = $"SELECT IdPersona, NombrePersona FROM Persona WHERE IdPersona = {Id}";
            this.comando = new SqlCommand(query, conexion);
        }

        private void EjecutarComando ()
        {
            Console.WriteLine("Ejecutando el comando");
            SqlDataReader registro = this.comando.ExecuteReader();

            if (registro.Read())
            {
                string IdPersona = registro["IdPersona"].ToString();
                string Persona = registro["NombrePersona"].ToString();

                Console.WriteLine($"IdPersona: {IdPersona}, Nombre: {Persona}");
            }

        }

        public void Ejecutar()
        {
            CrearConexion();
            CrearComando(4);
            OpenConexion();
            
            EjecutarComando();
            CloseConexion();
        }
    }
}
