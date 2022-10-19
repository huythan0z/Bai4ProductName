using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
                    return product[i];
                }
            }
            return null;
        }

        static List<Product> findProductByCategoryID(Product[] product, int categoryID)
        {
            List<Product> listProduct = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                if (categoryID == product[i].CategoryId)
                {
                    listProduct.Add(product[i]);
                }
            }
            return listProduct;
        }

        static List<Product> findProductByPrice(Product[] product, int price)
        {
            List<Product> listProduct = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                if (price >= product[i].Price)
                {
                    listProduct.Add(product[i]);
                }
            }
            return listProduct;
        }

        static List<Product> sortByPrice(Product[] product)
        {
            Product temp;
            List<Product> listProduct = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                for (int j = i + 1; j < product.Length; j++)
                {
                    if (product[i].Price > product[j].Price)
                    {
                        temp = product[i];
                        product[i] = product[j];
                        product[j] = temp;
                    }
                }
            }
            for (int i = 0; i < product.Length; i++)
            {
                listProduct.Add(product[i]);
            }
            return listProduct;
        }

        static Product minByPrice(Product[] product)
        {
            Product min = new Product();
            min = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if (min.Price > product[i].Price)
                {
                    min = product[i];
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
                    max = product[i];
                }
            }
            return max;
        }

        static List<Product> sortByName(Product[] product)
        {
            List<Product> listProduct = new List<Product>();
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
                listProduct.Add(product[i]);
            }
            return listProduct;
        }
            

        static List<Product> sortByCategoryName(Product[] product, Category[] categories)
        {
            List<Product> listProduct = new List<Product>();
            //for (int i = 1; i < product.Length; i++)
            //{
            //    Product currentProduct = product[i];
            //    int pos = i;

            //    // Get catgory name
            //    string categoryNameCurrent = GetCategoryNameById(currentProduct.CategoryId, categories);
            //    string categoryNamePost = GetCategoryNameById(product[pos - 1].CategoryId, categories);

            //    while (pos > 0 && categoryNamePost.CompareTo(categoryNameCurrent) > 0)
            //    {
            //        product[pos] = product[pos - 1];
            //        pos--;
            //    }
            //    product[pos] = currentProduct;

            //}
            int temp;
            for (int i = 0; i < product.Length; i++)
            {
                for (int j = i + 1; j < product.Length; j++)
                {
                    string categoryNameCurrent = GetCategoryNameById(product[j].CategoryId, categories);
                    string categoryNamePost = GetCategoryNameById(product[i].CategoryId, categories);
                    if (categoryNamePost.CompareTo(categoryNameCurrent) > 0)
                    {
                        temp = product[i].CategoryId;
                        product[i].CategoryId = product[j].CategoryId;
                        product[j].CategoryId = temp;
                    }
                }
            }
            for (int i = 0; i < product.Length; i++)
            {
                listProduct.Add(product[i]);
            }
            return listProduct;
        }

        static string GetCategoryNameById(int categoryId, Category[] categories)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                if (categoryId == categories[i].CategoryId)
                {
                    return categories[i].Name;
                }
            }
            return null;
        }

        static List<Product> mapProductByCategory(Product[] product, Category[] categories)
        {
            List<Product> listProduct = new List<Product>();

            for (int i = 0; i < product.Length; i++)
            {
                listProduct.Add(product[i]);
            }
            return listProduct;
        }
        public static void Main(string[] args)
        {
            Category[] categories = new Category[4];
            categories[0] = new Category { CategoryId = 1, Name = "Computer" };
            categories[1] = new Category { CategoryId = 2, Name = "Memory" };
            categories[2] = new Category { CategoryId = 3, Name = "GraphicCard" };
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

            //Product prdName = new Product();
            //string name = Console.ReadLine();
            //prdName = findProductName(product, name);
            //Console.WriteLine(prdName.Name);

            //List<Product> prdCategory = new List<Product>();
            //int category = Convert.ToInt32(Console.ReadLine());
            //prdCategory = findProductByCategoryID(product, category);
            //for (int i = 0; i < prdCategory.Count; i++)
            //{
            //    Console.WriteLine(prdCategory[i].Name + " " + prdCategory[i].Price + " " + prdCategory[i].Quality);
            //}

            //List<Product> prdPrice = new List<Product>();
            //int price = Convert.ToInt32(Console.ReadLine());
            //prdPrice = findProductByPrice(product, price);
            //for (int i = 0; i < prdPrice.Count; i++)
            //{
            //    Console.WriteLine(prdPrice[i].Name);
            //}

            //List<Product> sortPrice = new List<Product>();
            //sortPrice = sortByPrice(product);
            //Console.WriteLine("------------------------ SortByPrice ------------------------");
            //for (int i = 0; i < sortPrice.Count; i++)
            //{
            //    Console.WriteLine(sortPrice[i].Name + " " + sortPrice[i].Price);
            //}

            //List<Product> sortName = new List<Product>();
            //sortName = sortByName(product);
            //Console.WriteLine("------------------------ SortByName ------------------------");
            //for (int i = 0; i < sortName.Count; i++)
            //{
            //    Console.WriteLine(sortName[i].Name);
            //}

            //Console.WriteLine("------------------------ Min Max ------------------------");
            //Product minPrd = new Product();
            //minPrd = minByPrice(product);
            //Console.WriteLine("Min : " + minPrd.Price + " " + minPrd.Name);

            //Product maxPrd = new Product();
            //maxPrd = maxByPrice(product);
            //Console.WriteLine("Max : " + maxPrd.Price + " " + maxPrd.Name);

            //List<Category> CategoryName = new List<Category>();
            //CategoryName = ReturnCategoryName(categories);
            //for (int i = 0; i <categories.Length; i++)
            //{
            //    Console.WriteLine(CategoryName[i].Name);
            //}

            List<Product> sortCategoryName = new List<Product>();
            sortCategoryName = sortByCategoryName(product, categories);
            Console.WriteLine("------------------------ SortByCategoryName ------------------------");
            for (int i = 0; i < sortCategoryName.Count; i++)
            {
                Console.WriteLine(sortCategoryName[i].Name + " " + sortCategoryName[i].CategoryId);
            }

            List<Product> name = new List<Product>();
            name = mapProductByCategory(product, categories);
            Console.WriteLine("------------------------ MapProductByCategoryName ------------------------");
            for (int i = 0; i < name.Count; i++)
            {
                string getcategoryName = GetCategoryNameById(product[i].CategoryId, categories);
                Console.WriteLine(name[i].Name + " - " + getcategoryName);
            }
            Console.ReadKey();


        }
    }
}
