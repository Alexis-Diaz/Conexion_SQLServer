using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Espacios de nombre importados
using System.Data.SqlClient; //para crear conexion a SQL server



namespace ConexionSQLServer
{
    class EjecutarSentenciasSQL
    {
        //COMO CREAR UNA CONEXION A SQL SERVER PASO A PASO

        //PASO 2: EJECUTAR SENTENCIAS SQL

        //Para poder ejecutar consultas como un SELECT, INSERT, UPDATE O DELETE
        //en la base de datos debemos de contar primero con una conexión estable-
        //cida con la base de datos. En este caso usaremos de manera simple, sin
        //captura de errores la conexion creada en el paso 1 para facilitar la 
        //compresion. La conexión creada quedaría así:

        public void EjecutarComando()
        {
            SqlConnection connection = new SqlConnection(@"Server = DELL-PC\SQLEXPRESS; database = DBConexionSQLServer; integrated security = true");
            connection.Open();
            Console.WriteLine("Se abrió la conexión con SQL Server");

            //Como vemos de una forma muy sencilla se ha creado una conexion con
            //SQL server. Claro, esto no es recomendable porque no hay capturas
            //de errores pero en esencia es lo que necesitamos.

            //Ahora para enviar instrucciones de sql al servidor necesitamos hacer
            //lo siguiente:
            //PRIMERO Crear un string que contenga una instruccion sql válida que pueda
            //ejecutarse en el servidor. 

            //SEGUNDO Crear una instancia de la clase SqlCommand que hace de puente para
            //nosotros y ejecutar el comando en el servidor.
            
            //TERCERO Invocar uno de los método que dispone la clase SqlCommand para ejecutar
            //la instrucción sql contra la base de datos.


            //PASO 1
            //El siguiente texto contiene un comando válido, para fines de ejemplo no se
            //hace uso de parámetros.
            string comandoInsert = @"INSERT INTO Persona (NombrePersona) VALUES ('Alexis Diaz')";
            string comandoSelect = @"SELECT NombrePersona FROM Persona";

            //PASO 2
            //Se crea la instancia de SqlCommand, esta clase recibe uno a cuatro parámetros
            //en el constructor. Aqui se usaran dos.
            //Parametro 1: indica la intrucción sql.
            //Parametro 2: indica la referencia de la conexión abierta a utilizar.
            SqlCommand sqlComandoInsert = new SqlCommand(comandoInsert, connection);
            SqlCommand sqlComandoSelect = new SqlCommand(comandoSelect, connection);

            //PASO 3
            //La clase Sqlcommand tiene varios métodos para ejecutar comandos sql contra la 
            //base de datos. El seleccionado dependerá de lo que queramos conseguir.

            //METODO 1 ExecuteNonQuery() 'Ejecutar sin consulta'
            //Cuando lo que deseamos es hacer un INSER, DELETE O UPDATE podemos usar el
            //metodo ExecuteNonQuery() ya que este no devuelte nada, únicamente las filas
            //afectadas por la instrucción.
            Console.WriteLine("Ejecutando consulta con ExecuteNonQuery");
            int filasAfectadas = sqlComandoInsert.ExecuteNonQuery();


            if(filasAfectadas > 0)
            {
                Console.WriteLine($"Comando ejecutado correctamente con ExecuteNonQuery. Filas afectadas: {filasAfectadas}");
            }
            else
            {
                Console.WriteLine($"No se pudo realizar insert con ExecuteNonQuery. Filas afectadas: {filasAfectadas}");
            }





            //METODO 2 ExecuteReader() 'Ejecutar con lectura'
            //Este método es apropiado cuando lo que queremos es traer uno o todos los registros de una tabla.
            //La respuesta que devuelve es un objeto SqlDataReader. Para acceder a la información contenida en
            //este objeto debemos usar una estructura repetitiva como un for o while y usar el método de la 
            //clase SqlDataReader Read() para leer cada valor.
            Console.WriteLine("Ejecutando consulta con ExecuteReader");
            SqlDataReader response = sqlComandoSelect.ExecuteReader();

            List<string> personas = new List<string>();
            //El metodo Read() desplaza la lectura a la siguiente posición, devuelve true si hay más filas,
            //de lo contrario false.
            while (response.Read())
            {
                //response siempre trae un solo objeto. Para acceder a sus propiedades, lo hacemos indicando
                //entre corchetes el mismo nombre de campo que se encuetra en la tabla consultada.
                string persona = response["NombrePersona"].ToString();
                personas.Add(persona);//se asigna el valor a una lista 
                Console.WriteLine(persona);
            }




            //No debemos olvidar que SIEMPRE debemos cerrar la conexión para mantener la
            //seguridad en la comunicacion de la aplicacion y el servidor. Esto se hace despues de 
            //cada comando ejecutado. Aqui por fines didacticos se deja al final.
            connection.Close();
            Console.WriteLine("Se cerró la conexión con SQL Server");
        }

    }
}
