using PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models;
using PSSDotNetTrainingBatch2.MiniPosConsoleApp.Services;
using System.Globalization;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Services
{
    public class SaleDetailService
    {
        public void Read()
        {
            Console.WriteLine("Retrive All SaleDetail Records \n");
            AppDbContext db = new AppDbContext();
            db.SaleDetails.Where(s => !s.DeleteFlag).ToList().ForEach(DisplaySaleDetail);
        }

        public void Edit()
        {
        FindSaleDetailById:
            Console.WriteLine("Edit SaleDetail by Id \n");
            AppDbContext db = new AppDbContext();
            int saleDetailId = GetSaleDetailIdFromUser();
            SaleDetail? saleDetail = GetSaleDetailRecordById(saleDetailId, db);
            if (saleDetail is null)
            {
                Console.WriteLine("SaleDetail record not found for SaleDetail Id: " + saleDetailId);
                goto FindSaleDetailById;
            }
            DisplaySaleDetail(saleDetail);
        }

        public void Create()
        {
            Console.WriteLine("Create SaleDetail Record \n");
            int saleId = SaleService.GetSaleIdFromUser();
            int productId = ProductService.GetProductIdFromUser();
            decimal price = GetSalePriceFromUser();
            int quantity = ProductService.GetQuantityFromUser();

            SaleDetail saleDetail = new SaleDetail()
            {
                SaleId = saleId,
                ProductId = productId,
                Price = price,
                Quantity = quantity
            };

            AppDbContext db = new AppDbContext();
            db.SaleDetails.Add(saleDetail);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "SaleDetail Record creation successful!" : "SaleDetail Record creation failed!");
        }

        public static void DisplaySaleDetail(SaleDetail saleDetail)
        {
            Console.WriteLine("SaleDetail Id => " + saleDetail.SaleDetailId);
            Console.WriteLine("SaleDetail Id => " + saleDetail.SaleDetailId);
            Console.WriteLine("Product Id => " + saleDetail.ProductId);
            Console.WriteLine("Price => " + saleDetail.Price);
            Console.WriteLine("Quantity => " + saleDetail.Quantity + "\n");
        }

        public static int GetSaleDetailIdFromUser()
        {
            while (true)
            {
                Console.Write("Enter SaleDetail Id: ");
                string input = Console.ReadLine()!;
                bool isInteger = int.TryParse(input, out int saleDetailId);
                if (!isInteger)
                {
                    Console.WriteLine("Invalid Id. Please enter a valid Id!");
                    continue;
                }
                return saleDetailId;
            }
        }

        public static decimal GetSalePriceFromUser()
        {
            while (true)
            {
                Console.Write("Enter Sale Price: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !decimal.TryParse(input, out decimal price))
                {
                    Console.WriteLine("Please enter a valid price!");
                    continue;
                }
                return price;
            }
        }

        public static DateTime GetSaleDateFromUser()
        {
            while (true)
            {
                Console.Write("Enter Sale Date (MM/DD/YYYY): ");
                string input = Console.ReadLine()!;
                bool isDateTime = DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                if (string.IsNullOrWhiteSpace(input) || !isDateTime)
                {
                    Console.WriteLine("Please enter valid date (MM/DD/YYYY)!");
                    continue;
                }
                return date;
            }
        }

        public static string GetVoucherNoFromUser()
        {
            while (true)
            {
                Console.Write("Enter Voucer No (V-xxxx): ");
                string voucher = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(voucher))
                {
                    Console.WriteLine("Please enter a valid voucher (V-xxxx)!");
                    continue;
                }
                return voucher;
            }
        }

        public static decimal GetTotalAmountFromUser()
        {
            while (true)
            {
                Console.Write("Enter Total Amount: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !decimal.TryParse(input, out decimal totalAmount))
                {
                    Console.WriteLine("Please enter a valid amount!");
                    continue;
                }
                return totalAmount;
            }
        }

        public static SaleDetail? GetSaleDetailRecordById(int id, AppDbContext db)
        {
            SaleDetail? saleDetail = db.SaleDetails.FirstOrDefault(s => s.SaleDetailId == id && !s.DeleteFlag);
            return saleDetail;
        }
    }
}
