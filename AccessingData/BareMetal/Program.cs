using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BareMetal
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["TheDrumAndBase"].ConnectionString;

            //var products = new List<Product>();
            //var categoryID = Console.ReadLine();

           // using (SqlConnection connection = new SqlConnection(cs))
           // {
           //     connection.Open();

           //     SqlCommand cmd = new SqlCommand("", connection);
           //     cmd.CommandType = CommandType.Text;
           //     cmd.CommandText = "select * from products where categoryId=@p1";
           //     cmd.Parameters.AddWithValue("@p1", categoryID);

           //     Console.WriteLine(cmd.CommandText);
           //     var result = cmd.ExecuteReader();

           //     while (result.Read())
           //     {
           //         var id = result.GetInt32(0);
           //         var name = result.GetString(1);

           //         var description = result.IsDBNull(2) 
           //             ? string.Empty 
           //             : result.GetString(2);

           //         var price = result.GetDecimal(3);
           //         var categoryId = result.GetInt32(4);

           //         var product = new Product
           //         {
           //             ID = id,
           //             Name = name,
           //             Description = description,
           //             CategoryID = categoryId,
           //             Price = price
           //         };

           //         products.Add(product);
           //     }
           //}

           // foreach (var product in products)
           // {
           //     Console.WriteLine(product);
           // }

            var id = Console.ReadLine();
            var price = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update products set price=@price where ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);

                cmd.ExecuteNonQuery();
            }

        }
    }
}
