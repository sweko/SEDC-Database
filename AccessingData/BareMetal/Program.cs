using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BareMetal
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();

            var pname = Console.ReadLine();

            var cs = ConfigurationManager.ConnectionStrings["TheBase"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select * from Products where Name like '%"+pname+"%'";

                cmd.CommandText = "select * from Products where Name like '%'+@name+'%'";
                cmd.Parameters.AddWithValue("@name", pname);
                cmd.Connection = cnn;

                Console.WriteLine(cmd.CommandText);
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    string name = dataReader.GetString(1);
                    string description = dataReader.IsDBNull(2)
                        ? string.Empty
                        : dataReader.GetString(2);
                    var price = dataReader.GetDecimal(3);
                    var category = dataReader.GetInt32(4);

                    Product product = new Product
                    {
                        ID = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        CategoryID = category
                    };

                    products.Add(product);
                }
                
           }

            ProductLister.ListProducts(products);
        }
    }
}
