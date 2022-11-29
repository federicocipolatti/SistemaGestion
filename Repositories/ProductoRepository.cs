using SistemaGestion.Models;
using System.ComponentModel;
using System.Data.SqlClient;

namespace SistemaGestion.Repositories
{
    public class ProductoRepository
    {
        private SqlConnection? conexion;
        private String cadenaConexion = 
                "Server=sql.bsite.net\\MSSQL2016;" +
                "Database=fedecipo_C#Coder;" +
                "User Id=fedecipo_C#Coder;" +
                "Password=Hearmyroar14;";

        public ProductoRepository()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch
            {
                throw;
            }
        }

        public List <Producto> listarProducto()
        {
            List<Producto> listaProducto = new List<Producto>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = long.Parse(reader["Id"].ToString());
                                producto.Descripciones = reader["Descripciones"].ToString();       
                                producto.Costo = float.Parse(reader["Costo"].ToString());
                                producto.PrecioVenta = float.Parse(reader["PrecioVenta"].ToString());
                                producto.Stock = int.Parse(reader["Stock"].ToString());
                                producto.IdUsuario = long.Parse(reader["IdUsuario"].ToString());
                                listaProducto.Add(producto);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch
            {
                throw;
            }
            return listaProducto;
        }
    }
}
