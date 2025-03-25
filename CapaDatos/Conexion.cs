using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class Conexion
    {
        //public static string Cn = "Data Source=DESKTOP-N5G760G\\SQLEXPRESS; Initial Catalog=DB_SISTEMA_VENTAS; Integrated Security=true";
        //creando variable para la coneccion de la base de datos
        public static string Cn = Properties.Settings.Default.cn;
    }
}
