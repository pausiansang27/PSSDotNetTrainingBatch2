﻿using PSSDotNetTrainingBatch2.Project1.Database.AppDbContextModels;
using System.Globalization;

namespace PSSDotNetTrainingBatch2.Project1.ConsoleApp.Sevices
{
    public class ProductService
    {
        public void Read()
        {
            Console.WriteLine("Retrieve All Products \n");
            AppDbContext db = new AppDbContext();
            db.TblProducts.Where(p => !p.DeleteFlag).ToList().ForEach(DisplayProductDetail);
        }

        public void Edit()
        {
            Console.WriteLine("Edit Product by Id \n");
        FindProductById:
            AppDbContext db = new AppDbContext();
            int productId = GetProductIdFromUser();
            TblProduct? product = GetProductById(productId, db);
            if (product is null)
            {
                Console.WriteLine("Product not found for Product Id: " + productId + "\n");
                goto FindProductById;
            }
            DisplayProductDetail(product);
        }

        public void Create()
        {
            Console.WriteLine("Create Product \n");
            string name = GetProductNameFromUser();
            decimal price = GetProductPriceFromUser();
            DateTime createdAt = GetCreatedDateFromUser();

            TblProduct product = new TblProduct()
            {
                PName = name,
                Price = price,
                Createat = createdAt
            };

            AppDbContext db = new AppDbContext();
            db.TblProducts.Add(product);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Product creation successful!" : "Product creation failed!");
        }

        public void Update()
        {
            Console.WriteLine("Update Product by Id \n");
        FindProductById:
            AppDbContext db = new AppDbContext();
            int productId = GetProductIdFromUser();
            TblProduct? product = GetProductById(productId, db);
            if (product is null)
            {
                Console.WriteLine("Product not found for Product Id: " + productId + "\n");
                goto FindProductById;
            }

            DisplayProductDetail(product);
            string name = GetProductNameFromUser();
            decimal price = GetProductPriceFromUser();
            DateTime createdAt = GetCreatedDateFromUser();

            product.PName = name;
            product.Price = price;
            product.Createat = createdAt;

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating product success!" : "Update Failed!");
        }

        public void Delete()
        {
            Console.WriteLine("Delete Product by Id \n");
        FindProductById:
            AppDbContext db = new AppDbContext();
            int productId = GetProductIdFromUser();
            TblProduct? product = GetProductById(productId, db);
            if (product is null)
            {
                Console.WriteLine("Product not found for Product Id: " + productId + "\n");
                goto FindProductById;
            }

            DisplayProductDetail(product);
            product.DeleteFlag = true;
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Product deletion successful!" : "Product deletion Failed!");
        }

        public static int GetProductIdFromUser()
        {
            while (true)
            {
                Console.Write("Enter Product Id: ");
                string input = Console.ReadLine()!;
                bool isInteger = int.TryParse(input, out int productId);
                if (!isInteger)
                {
                    Console.WriteLine("Invalid Id. Please enter a valid Id!\n");
                    continue;
                }
                return productId;
            }
        }

        public static string GetProductNameFromUser()
        {
            while (true)
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Product name cannot be empty!\n");
                    continue;
                }
                return name;
            }
        }

        public static decimal GetProductPriceFromUser()
        {
            while (true)
            {
                Console.Write("Enter Product Price: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !decimal.TryParse(input, out decimal price))
                {
                    Console.WriteLine("Please enter a valid price!\n");
                    continue;
                }
                return price;
            }
        }

        public static DateTime GetCreatedDateFromUser()
        {
            while (true)
            {
                Console.Write("Enter Created Date (MM/DD/YYYY): ");
                string input = Console.ReadLine()!;
                bool isDateTime = DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                if (string.IsNullOrWhiteSpace(input) || !isDateTime)
                {
                    Console.WriteLine("Please enter valid date (MM/DD/YYYY)!\n");
                    continue;
                }
                return date;
            }
        }

        public static int GetQuantityFromUser()
        {
            while (true)
            {
                Console.Write("Enter Quantity: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int quantity))
                {
                    Console.WriteLine("Please enter a valid quantity!\n");
                    continue;
                }
                return quantity;
            }
        }

        public static TblProduct? GetProductById(int id, AppDbContext db)
        {
            TblProduct? product = db.TblProducts.FirstOrDefault(p => p.ProductId == id && !p.DeleteFlag);
            return product;
        }

        public static void DisplayProductDetail(TblProduct product)
        {
            Console.WriteLine("Product Id => " + product.ProductId);
            Console.WriteLine("Product name => " + product.PName);
            Console.WriteLine("Product Price => " + product.Price);
            Console.WriteLine("Created At => " + product.Createat + "\n");
        }
    }
}
