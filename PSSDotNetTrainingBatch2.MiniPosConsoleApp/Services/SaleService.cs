using PSSDotNetTrainingBatch2.MiniPosConsoleApp.Models;
using System.Globalization;

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Services
{
    public class SaleService
    {
        public void Read()
        {
            Console.WriteLine("Retrive All Sales \n");
            AppDbContext db = new AppDbContext();
            db.Sales.Where(s => !s.DeleteFlag).ToList().ForEach(DisplaySaleRecord);
        }

        public void Edit()
        {
        FindProductById:
            Console.WriteLine("Edit Sale by Id \n");
            AppDbContext db = new AppDbContext();
            int saleId = GetSaleIdFromUser();
            Sale? sale = GetSaleRecordById(saleId, db);
            if (sale is null)
            {
                Console.WriteLine("Sale record not found for Sale Id: " + saleId);
                goto FindProductById;
            }
            DisplaySaleRecord(sale);
        }

        public void Create()
        {
            Console.WriteLine("Create Sale Record \n");
            DateTime saleDate = GetSaleDateFromUser();
            string voucherNo = GetVoucherNoFromUser();
            decimal totalAmount = GetTotalAmountFromUser();

            Sale sale = new Sale()
            {
                SaleDate = saleDate,
                VoucherNo = voucherNo,
                TotalAmount = totalAmount
            };

            AppDbContext db = new AppDbContext();
            db.Sales.Add(sale);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Sale Record creation successful!" : "Sale Record creation failed!");
        }

        public static void DisplaySaleRecord(Sale sale)
        {
            Console.WriteLine("Sale Id => " + sale.SaleId);
            Console.WriteLine("Sale Date => " + sale.SaleDate);
            Console.WriteLine("Voucher No => " + sale.VoucherNo);
            Console.WriteLine("Total Amount  => " + sale.TotalAmount + "\n");
        }

        public static int GetSaleIdFromUser()
        {
            while (true)
            {
                Console.Write("Enter Sale Id: ");
                string input = Console.ReadLine()!;
                bool isInteger = int.TryParse(input, out int saleId);
                if (!isInteger)
                {
                    Console.WriteLine("Invalid Id. Please enter a valid Id!");
                    continue;
                }
                return saleId;
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

        public static Sale? GetSaleRecordById(int id, AppDbContext db)
        {
            Sale? sale = db.Sales.FirstOrDefault(s => s.SaleId == id && !s.DeleteFlag);
            return sale;
        }
    }
}
