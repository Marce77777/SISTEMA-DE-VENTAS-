using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        //metodo insertar que llama al metodo insertar 
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen , int id_marca)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idmarca = id_marca;
            return Obj.Insertar(Obj);
        }

        //metodo editar que llama al metodo editar
        public static string Editar(int id_articulo, string codigo, string nombre, string descripcion, byte[] imagen, int id_marca)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = id_articulo;
            Obj.Codigo= codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idmarca= id_marca;
            return Obj.Editar(Obj);
        }

        //metodo Eliminar que llama al metodo eliminar
        public static string Eliminar(int id_articulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = id_articulo;
            return Obj.Eliminar(Obj);
        }

        //metodo Mostrar que llama al metodo mostrar
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //metodo Buscar que llama al metodo buscar
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        //metodo Buscar que llama al metodo buscar codigo
        public static DataTable BuscarCodigo(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCodigo(Obj);
        } 

        /* public static string Insertar(string v1, string v2, string v3, byte[] imagen, int v4, int v5)
         {
             throw new NotImplementedException();
         }*/
    }
}
