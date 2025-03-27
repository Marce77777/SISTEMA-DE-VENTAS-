using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Métodos para comunicarnos con la capa datos
        //Método Insertar que llama al método Insertar de la clase DCliente
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos,
            string tipo_doc, string direccion, string telefono)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Tipo_doc = tipo_doc;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int id_cliente, string nombre, string apellidos, string tipo_doc,
            string direccion, string telefono)
        {
            DCliente Obj = new DCliente();
            Obj.Id_cliente = id_cliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Tipo_doc = tipo_doc;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;

            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int id_cliente)
        {
            DCliente Obj = new DCliente();
            Obj.Id_cliente = id_cliente;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCliente
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DCLiente de la CapaDatos

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //Método BuscarNum_Documento que llama al método BuscarTipo_Documento
        //de la clase DCliente de la CapaDatos

        public static DataTable BuscarTipo_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarTipo_Documento(Obj);
        }


    }
}

