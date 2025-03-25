using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Microsoft.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
   public class NMarca
    {
        //metodo insertar que llama al metodo insertar 
        public static string Insertar(string nombre, string descripcion)
        {
            DMarca Obj = new DMarca();
            Obj.Nombre_marca = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);

        }

        //metodo editar que llama al metodo insertar 
        public static string Editar(int id_marca, string nombre, string descripcion)
        {
            DMarca Obj = new DMarca();
            Obj.Idmarca = id_marca;
            Obj.Nombre_marca = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //metodo Eliminar que llama al metodo insertar 
        public static string Eliminar(int id_marca)
        {
            DMarca Obj = new DMarca();
            Obj.Idmarca = id_marca;
            return Obj.Eliminar(Obj);
        }

        //metodo Mostrar que llama al metodo insertar 
        public static DataTable Mostrar()
        {
            return new DMarca().Mostrar();
        }

        //metodo Buscar que llama al metodo insertar 
        public static DataTable BuscarNombre(string textobuscar)
        {
            DMarca Obj = new DMarca();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }




    }
}
