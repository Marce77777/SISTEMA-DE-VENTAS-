using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Microsoft.Data.SqlClient;  // Cambio de namespace

namespace CapaDatos
{
    public class DMarca
    {
        // ATRIBUTOS DE LA TABLA MARCA
        private int _Idmarca;
        private string _Nombre_marca;
        private string _Descripcion;

        // PARA FILTRAR LOS REGISTROS
        private string _TextoBuscar;

        public int Idmarca { get => _Idmarca; set => _Idmarca = value; }
        public string Nombre_marca { get => _Nombre_marca; set => _Nombre_marca = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        // CONSTRUCTOR VACIO
        public DMarca() { }

        public DMarca(int id_marca, string nombre_marca, string descripcion, string textoBuscar)
        {
            this.Idmarca = id_marca;
            this.Nombre_marca = nombre_marca;
            this.Descripcion = descripcion;
            this.TextoBuscar = textoBuscar;
        }

        // Metodo Insertar
        public string Insertar(DMarca Marca)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            // Capturador de errores
            try
            {
                // Código 
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // Establecer comando
                SqlCommand SqlCmd = new SqlCommand();

                // SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmarca = new SqlParameter();
                ParIdmarca.ParameterName = "@id_marca";
                ParIdmarca.SqlDbType = SqlDbType.Int;
                ParIdmarca.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdmarca);

                SqlParameter ParNombre_marca = new SqlParameter();
                ParNombre_marca.ParameterName = "@nombre_marca";
                ParNombre_marca.SqlDbType = SqlDbType.VarChar;
                ParNombre_marca.Size = 50;
                ParNombre_marca.Value = Marca.Nombre_marca; // Corregido: Marca.Nombre
                SqlCmd.Parameters.Add(ParNombre_marca);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion"; // Corregido
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Marca.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // Ejecutar el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        // Metodo Editar
        public string Editar(DMarca Marca)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            // Capturador de errores
            try
            {
                // Código 
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // Establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmarca = new SqlParameter();
                ParIdmarca.ParameterName = "@id_marca";
                ParIdmarca.SqlDbType = SqlDbType.Int;
                ParIdmarca.Value = Marca.Idmarca;
                SqlCmd.Parameters.Add(ParIdmarca);

                SqlParameter ParNombre_marca = new SqlParameter();
                ParNombre_marca.ParameterName = "@nombre_marca";
                ParNombre_marca.SqlDbType = SqlDbType.VarChar;
                ParNombre_marca.Size = 50;
                ParNombre_marca.Value = Marca.Nombre_marca; // Corregido
                SqlCmd.Parameters.Add(ParNombre_marca);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion"; // Corregido
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Marca.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // Ejecutar el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        // Metodo Eliminar
        public string Eliminar(DMarca Marca)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            // Capturador de errores
            try
            {
                // Código 
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // Establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmarca = new SqlParameter();
                ParIdmarca.ParameterName = "@id_marca";
                ParIdmarca.SqlDbType = SqlDbType.Int;
                ParIdmarca.Value = Marca.Idmarca;
                SqlCmd.Parameters.Add(ParIdmarca);

                // Ejecutar el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ELIMINO el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        // Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("marca");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Metodo Buscar
        public DataTable BuscarNombre(DMarca Marca)
        {
            DataTable DtResultado = new DataTable("marca");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_marca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50; // Corregido: Size en lugar de Sise
                ParTextoBuscar.Value = Marca.TextoBuscar; // Corregido: Marca.TextoBuscar
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

     






    }
}
