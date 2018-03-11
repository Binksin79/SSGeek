using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        private string connectionString;

        public ProductSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();

            string specificQuery = @"Select * FROM products WHERE product_id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(specificQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product = MapRowToProduct(reader);
                }
            }
            return product;
        }
       
        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();

            string productQuery = @"Select * from products";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(productQuery, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(MapRowToProduct(reader));
                }
            }
            return list;
        }

        private Product MapRowToProduct(SqlDataReader reader)
        {
            return new Product()
            {
                ProductId = Convert.ToInt32(reader["product_id"]),
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Price = Convert.ToDouble(reader["price"]),
                ImageName = Convert.ToString(reader["image_name"])
            };

        }
    }
}