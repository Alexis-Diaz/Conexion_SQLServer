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
    class EjecutarSentenciasSQL_ComandoInsert
    {
        //Ja ja ja si no le entendés ahorita que lo estás revisando, el Alexis del pasado 08/01/2022
        //te recomienda repasar apartir de el tema 78 en adelante. Te dejo link https://www.tutorialesprogramacionya.com/csharpya/detalleconcepto.php?codigo=202&inicio=60
        //aunque creeria que no lo vas a necesitar. Tambien queda la evidencia de los codigos en esta
        //misma solicion.

        SqlConnection conexion;
        SqlCommand comando;
        void CrearConexion()
        {
            //Se crea una conexion a SQL server
            string cadena = @"Server=DELL-PC\SQLEXPRESS; database=DBConexionSQLServer; user=Alexis; password=1234; integrated security= false";
            conexion = new SqlConnection(cadena);

        }
      
        void OpenConexion()
        {
            try
            {
                this.conexion.Open();
                Console.WriteLine("Conexión abierta exitosamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
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
                    Console.WriteLine("Conexión cerrada exitosamente.");
                }
                else
                {
                    Console.WriteLine("No hay conexiones abiertas");
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                throw;
            }
        }

        void CrearComando(string valor)
        {
            string query = $"INSERT INTO Persona (NombrePersona) VALUES ('{valor}')";
            this.comando = new SqlCommand(query, this.conexion);
        }

        void EjecutarComando()
        {
            int rowAffect = this.comando.ExecuteNonQuery();
            Console.WriteLine($"Comando ejecutado exitosamente. Filas afectadas {rowAffect}");
        }


        public void Ejecutar()
        {
            CrearConexion();
            OpenConexion();
            CrearComando("Osmin Diaz");
            EjecutarComando();
            CloseConexion();
        }
    }
}
