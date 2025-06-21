using Microsoft.IdentityModel.Tokens;
using PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models;
using System.Reflection.Metadata;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class ProductService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            db.Products.Where(p => !p.DeleteFlag).ToList().ForEach(DisplayProductDetail);
        }

        public void Edit()
        {
        FindProductById:
            int productId = GetProductIdFromUser();
            Product? product = GetProductById(productId);
            if (product is null)
            {
                Console.WriteLine("Blog not found for Blog Id: " + productId);
                goto FindProductById;
            }
            DisplayProductDetail(product);
        }

        public void Create()
        {
            string name = GetProductNameFromUser();
            decimal price = GetProductPriceFromUser();
            int quantity = GetProductQuantityFromUser();

            Product product = new Product()
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            AppDbContext db = new AppDbContext();
            db.Products.Add(product);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Product creation successful!" : "Product creation failed!");
        }

        public static void DisplayProductDetail(Product product)
        {
            Console.WriteLine("Product Id => " + product.ProductId);
            Console.WriteLine("Product name => " + product.Name);
            Console.WriteLine("Product Price => " + product.Price);
            Console.WriteLine("Quantity => " + product.Quantity + "\n");
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
                    Console.WriteLine("Invalid Id. Please enter a valid Id!");
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
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Product name cannot be empty!");
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
                if (string.IsNullOrEmpty(input) || !decimal.TryParse(input, out decimal price))
                {
                    Console.WriteLine("Please enter a valid price!");
                    continue;
                }
                return price;
            }
        }

        public static int GetProductQuantityFromUser()
        {
            while (true)
            {
                Console.Write("Enter Product Quantity: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int quantity))
                {
                    Console.WriteLine("Please enter a valid quantity!");
                    continue;
                }
                return quantity;
            }
        }

        public static Product? GetProductById(int id)
        {
            AppDbContext db = new AppDbContext();
            Product? product = db.Products.FirstOrDefault(p => p.ProductId == id && !p.DeleteFlag);
            return product;
        }
    }
}
