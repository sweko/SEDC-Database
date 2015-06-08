using System;
using System.Collections.Generic;

namespace BareMetal
{
    internal class ProductLister
    {
        internal static void ListProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}