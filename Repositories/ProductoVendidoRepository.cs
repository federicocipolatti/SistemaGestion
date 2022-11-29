using SistemaGestion.Models;
using System.ComponentModel;
using System.Data.SqlClient;

namespace SistemaGestion.Repositories
{
    public class ProductoVendidoRepository
    {
        private SqlConnection? conexion;
        private String cadenaConexion =
                "Server=sql.bsite.net\\MSSQL2016;" +
                "Database=fedecipo_C#Coder;" +
                "User Id=fedecipo_C#Coder;" +
                "Password=Hearmyroar14;";

        public ProductoVendidoRepository()
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

        public List<ProductoVendido> listarProductoVendido()
        {
            List<ProductoVendido> listaProductoVendido = new List<ProductoVendido>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = long.Parse(reader["Id"].ToString());
                                productoVendido.Stock = int.Parse(reader["Stock"].ToString());
                                productoVendido.IdProducto = long.Parse(reader["IdProducto"].ToString());
                                productoVendido.IdVenta = long.Parse(reader["IdVenta"].ToString());
                                listaProductoVendido.Add(productoVendido);
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
            return listaProductoVendido;
        }
    }
}