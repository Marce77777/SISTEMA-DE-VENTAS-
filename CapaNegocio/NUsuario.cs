using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NUsuario
    {
        //metodo insertar que llama al metodo insertar 
        public static string Insertar(string nombre, string apellido, string direccion, string telefono, string acceso, string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Insertar(Obj);
        }

        //metodo editar que llama al metodo editar
        public static string Editar(int id_usuario, string nombre, string apellido, string direccion, string telefono, string acceso, string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = id_usuario;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;  
            Obj.Password = password;
            return Obj.Editar(Obj);
        }

        //metodo Eliminar que llama al metodo eliminar
        public static string Eliminar(int id_usuario)
        {
            DUsuario Obj = new DUsuario();
            Obj.Idusuario = id_usuario;
            return Obj.Eliminar(Obj);
        }

        //metodo Mostrar que llama al metodo mostrar
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();
        }

        //metodo Buscar que llama al metodo buscar
        public static DataTable BuscarApellido(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellido(Obj);
        }

        //METODO LOGIN
        public static DataTable Login(string usuario, string password)
        {
            DUsuario Obj = new DUsuario();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}
