using PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Services
{
    public class ProductService
    {
        public void Read()
        {
            Console.WriteLine("Retrive All Products \n");
            AppDbContext db = new AppDbContext();
            db.Products.Where(p => !p.DeleteFlag).ToList().ForEach(DisplayProductDetail);
        }

        public void Edit()
        {
            Console.WriteLine("Edit Product by Id \n");
        FindProductById:
            AppDbContext db = new AppDbContext();
            int productId = GetProductIdFromUser();
            Product? product = GetProductById(productId, db);
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
            int quantity = GetQuantityFromUser();

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

        public void Update()
        {
            Console.WriteLine("Update Product by Id \n");
        FindProductById:
            AppDbContext db = new AppDbContext();
            int productId = GetProductIdFromUser();
            Product? product = GetProductById(productId, db);
            if (product is null)
            {
                Console.WriteLine("Product not found for Product Id: " + productId + "\n");
                goto FindProductById;
            }

            DisplayProductDetail(product);
            string name = GetProductNameFromUser();
            decimal price = GetProductPriceFromUser();
            int quantity = GetQuantityFromUser();

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating product success!" : "Update Failed!");
        }

        public void Delete()
        {
            Console.WriteLine("Delete Product by Id \n");
        FindProductById:
            AppDbContext db = new AppDbContext();
            int productId = GetProductIdFromUser();
            Product? product = GetProductById(productId, db);
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

        public static int GetQuantityFromUser()
        {
            while (true)
            {
                Console.Write("Enter Product Quantity: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int quantity))
                {
                    Console.WriteLine("Please enter a valid quantity!\n");
                    continue;
                }
                return quantity;
            }
        }

        public static Product? GetProductById(int id, AppDbContext db)
        {
            Product? product = db.Products.FirstOrDefault(p => p.ProductId == id && !p.DeleteFlag);
            return product;
        }
    }
}
