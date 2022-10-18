using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Bai4ProductName;

namespace Bai4ProductName
{
    internal class Program
    {
        static Product findProductName(Product[] product, string nameProduct)
        {
            for (int i = 0; i < product.Length; i++)
            {
                if (nameProduct == product[i].Name)
                {
                    Console.Write("--> ");
                    return product[i];
                }
            }
            return null;
        }
        static List<Product> findProductByCategory(Product[] product, int categoryID)
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                if (categoryID == product[i].CategoryId)
                {
                    list.Add(product[i]);
                }
            }
            return list;
        }
        static List<Product> findProductByPrice(Product[] product, int price)
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                if (price >= product[i].Price)
                {
                    list.Add(product[i]);
                }
            }
            return list;
        }
        static List<Product> sortByPrice(Product[] product)
        {
            Product a;
            List<Product> list = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                for (int j = i + 1; j < product.Length; j++)
                {
                    if (product[i].Price > product[j].Price)
                    {
                        a = product[i];
                        product[i] = product[j];
                        product[j] = a;
                    }
                }
            }
            for (int i = 0; i < product.Length; i++)
            {
                list.Add(product[i]);
            }
            return list;
        }
        static Product minByPrice(Product[] product)
        {
            Product min = new Product();
            min = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if (min.Price > product[i].Price)
                {
                    min.Price = product[i].Price;
                }
            }
            return min;
            
        }

        static Product maxByPrice(Product[] product)
        {
            Product max = new Product();
            max = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if (max.Price < product[i].Price)
                {
                    max.Price = product[i].Price;  
                }
            }
            return max;
        }

        static List<Product> sortByName(Product[] product)
        {
            List<Product> list = new List<Product>();
            for (int i = 1; i < product.Length; i++)
            {
                Product value = product[i];
                int pos = i;
                while (pos > 0 && product[pos - 1].Name.Count() < value.Name.Count())
                {
                    product[pos] = product[pos - 1];
                    pos--;
                }
                product[pos] = value;
            }

            for (int i = 0; i < product.Length; i++)
            {
                list.Add(product[i]);
            }
            return list;
        }
        static List<Product> IDtoName(string name)
        {
            return null;
        }
        
        static List<Product> sortByCategoryName(Product[] product, Category[] categories)
        {
            List<Product> list = new List<Product>();
            List<Category> listCate = new List<Category>();
            Product a;
            for (int i = 0; i < product.Length; i++)
            {
                for (int j = i + 1; j < product.Length; j++)
                {
                    if (categories[i].Name.Count() > categories[j].Name.Count())
                    {

                    }
                }
            }

            for (int i = 0; i < product.Length; i++)
            {
                {
                    list.Add(product[i]);
                }
            }
            return list;
        }
        public static void Main(string[] args)
        {
            
            Category[] categories = new Category[4];
            categories[0] = new Category { CategoryId = 1, Name = "Computer" };
            categories[1] = new Category { CategoryId = 2, Name = "Memory" };
            categories[2] = new Category { CategoryId = 3, Name = "Card" };
            categories[3] = new Category { CategoryId = 4, Name = "Acsesory" };

            Product[] product = new Product[9];
            product[0] = new Product { Name = "CPU", Price = 750, Quality = "10", CategoryId = 1 };
            product[1] = new Product { Name = "RAM", Price = 50, Quality = "2", CategoryId = 2 };
            product[2] = new Product { Name = "HDD", Price = 70, Quality = "1", CategoryId = 2 };
            product[3] = new Product { Name = "Main", Price = 400, Quality = "3", CategoryId = 1 };
            product[4] = new Product { Name = "Keyboard", Price = 30, Quality = "8", CategoryId = 4 };
            product[5] = new Product { Name = "Mouse", Price = 25, Quality = "50", CategoryId = 4 };
            product[6] = new Product { Name = "VGA", Price = 60, Quality = "35", CategoryId = 3 };
            product[7] = new Product { Name = "Monitor", Price = 120, Quality = "28", CategoryId = 2 };
            product[8] = new Product { Name = "Case", Price = 120, Quality = "28", CategoryId = 4 };

            Product prdName = new Product();
            string name = Console.ReadLine();
            prdName = findProductName(product, name);
            Console.WriteLine(prdName.Name);

            List<Product> prdCategory = new List<Product>();
            int category = Convert.ToInt32(Console.ReadLine());
            prdCategory = findProductByCategory(product, category);
            for (int i = 0; i < prdCategory.Count; i++)
            {
                Console.WriteLine(prdCategory[i].Name + " " + prdCategory[i].Price + " " + prdCategory[i].Quality);
            }

            List<Product> prdPrice = new List<Product>();
            int price = Convert.ToInt32(Console.ReadLine());
            prdPrice = findProductByPrice(product, price);
            for (int i = 0; i < prdPrice.Count; i++)
            {
                Console.WriteLine(prdPrice[i].Name);
            }

            List<Product> sortPrice = new List<Product>();
            sortPrice = sortByPrice(product);
            Console.WriteLine("------------------------ SortByPrice ------------------------");
            for (int i = 0; i < sortPrice.Count; i++)
            {
                Console.WriteLine(sortPrice[i].Name + " " + sortPrice[i].Price);
            }

            List<Product> sortName = new List<Product>();
            sortName = sortByName(product);
            Console.WriteLine("------------------------ SortByName ------------------------");
            for (int i = 0; i < sortName.Count; i++)
            {
                Console.WriteLine(sortName[i].Name);
            }

            Console.WriteLine("------------------------ Min Max ------------------------");
            Product minPrd = new Product();
            minPrd = minByPrice(product);
            Console.WriteLine("Min : " + minPrd.Price + "$");

            Product maxPrd = new Product();
            maxPrd = maxByPrice(product);
            Console.WriteLine("Max : " + maxPrd.Price + "$"); 

            List<Product> sortCategoryName = new List<Product>();
            sortCategoryName = sortByCategoryName(product, categories);
            Console.WriteLine("------------------------ SortByCategoryName ------------------------");
            for (int i = 0; i < sortCategoryName.Count; i++)
            {
                Console.WriteLine(sortCategoryName[i].Name + " " + sortCategoryName[i].CategoryId);
            }

        }
    }
}
