using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //CrearConexionConSQLServer crear = new CrearConexionConSQLServer();
            //crear.CrearConexion();
            //Console.ReadKey();

            //EjecutarSentenciasSQL ejecutar = new EjecutarSentenciasSQL();
            //ejecutar.EjecutarComando();
            //Console.ReadKey();

            //EjecutarSentenciasSQL_ComandoInsert insert = new EjecutarSentenciasSQL_ComandoInsert();
            //insert.Ejecutar();
            //Console.ReadKey();

            //EjecutarSentenciasSQL_ComandoSelect select_list = new EjecutarSentenciasSQL_ComandoSelect();
            //select_list.Ejecutar();
            //Console.ReadKey();

            EjecutarSentenciasSQL_ComandoSelect_Item select_item = new EjecutarSentenciasSQL_ComandoSelect_Item();
            select_item.Ejecutar();
            Console.ReadKey();
        }
    }
}
