using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//espacio de nombre agregados
using System.Data.SqlClient;
using System.Data;


namespace ConexionSQLServer
{
    class CrearConexionConSQLServer
    {
        //COMO CREAR UNA CONEXION A SQL SERVER PASO A PASO

        //PASO 1: CREAR LA CONEXION

        //Para conectarnos a la base de datos lo primero que debemos hacer es conectarnos 
        //con el servidor. Para ello .NET pone a disposicion un conjunto de clases. La
        //primer clase que usaremos es SqlConnection. Para usarla debemos importar el espacio
        //de nombres System.Data.SqlClient;

       
        public void CrearConexion()
        {
            //En el constructor de SqlConnection se le puede pasar de uno a más parametros.
            //Si solo es un parametros, entonces se entiende que se trata de la cadena de
            //conexion donde se exige que lleve integrated security = true esto indica que
            //se usara el usuario de windows para el servidor con el que se hara la conexión.

            //Observacion: si integrated security = true, no se necesita usar usuario y
            //contraseña pues se intentará conectar al servidor solo con la autenticación de
            //windows. Si es false, entonces es necesario indicar usuario y contraseña pues
            //se conectará a traves de la auteniticación de sql server.

            //Ejemplo con true
            string cadenaConexionAutenticacionWindows = @"server=DELL-PC\SQLEXPRESS; database=DBConexionSQLServer; integrated security = true";
            
            //Ejemplo con false
            string cadenaConexionAutenticacionSQL = @"server=DELL-PC\SQLEXPRESS; database=DBConexionSQLServer; user=Alexis; password=1234; integrated security = false";

            //A la instancia se le pasa por el constructor la cadena.
            SqlConnection connection = new SqlConnection(cadenaConexionAutenticacionSQL);


            //Para abrir la conexion se usa el metodo Open() de la clase SqlConnection, para cerrarla se usa Close().

            //Extra: para verificar el estado de la conexión se usa la propiedad State de la clase SqlConnection que devuelve
            //un enum ConnectionState con algunos de los siguientes valores:

           // Valores:
           //     La conexión está cerrada.
           //     Closed = 0

           //     La conexión está abierta.
           //     Open = 1
        
           //  
           //     El objeto de conexión se conecta al origen de datos.
           //     Connecting = 2,

           //     El objeto de conexión está ejecutando un comando. (Este valor está reservado
           //     para versiones futuras del producto).
           //     Executing = 4,
        
           //     El objeto de conexión está recuperando datos. (Este valor está reservado para
           //     versiones futuras del producto).
           //     Fetching = 8,
        
           //     Se pierde la conexión al origen de datos. Esto puede ocurrir sólo una vez abierta
           //     la conexión.Una conexión en este estado se puede cerrar y, a continuación, vuelva
           //     a abrir. (Este valor está reservado para versiones futuras del producto).
           //     Broken = 16

            //Ahora bien para poder comparar el valor devuelto por uno de los estados, es necesario
            //importar el espacio de nombre System.Data quien tiene los enum ConnectionState.

            try
            {
                connection.Open();
                Console.WriteLine("Conexion creada exitosamente");

                //Aqui se puede ejecutar comandos sql una vez la conexion esta abierta.
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            try
            {
                //se verifica que existe una conexión abierta para cerrar
                if(connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexion cerrada exitosamente");
                }
                else
                {
                    Console.WriteLine("No se encontró una conexion abierta");
                    Console.WriteLine($"Estado de la conexion: {connection.State}");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                throw;
            }

        }

    }
}
