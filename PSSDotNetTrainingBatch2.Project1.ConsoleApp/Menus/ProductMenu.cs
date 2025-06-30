using PSSDotNetTrainingBatch2.Project1.ConsoleApp.Sevices;

namespace PSSDotNetTrainingBatch2.Project1.ConsoleApp.Menus
{
    public class ProductMenu
    {
        public void Execute()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ShowProductMenu();
                Console.Write("Choose Product Menu: ");
                string input = Console.ReadLine()!;
                int.TryParse(input, out int menuNumber);
                isRunning = HandleProductMenuChoice((EnumProductMenu) menuNumber);
            }
        }

        private void ShowProductMenu()
        {
            Console.WriteLine("\nProduct Menu");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. New Product");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine("------------------------------");
        }

        private bool HandleProductMenuChoice(EnumProductMenu menu)
        {
            switch (menu)
            {
                case EnumProductMenu.NewProduct:
                    Console.WriteLine("This menu is For Createing New Product.");
                    new ProductService().Create();
                    break;
                case EnumProductMenu.ProductList:
                    Console.WriteLine("This menu is For Getting ProductList.");
                    new ProductService().Read();
                    break;
                case EnumProductMenu.EditProdut:
                    Console.WriteLine("This menu is For Editing Produt.");
                    new ProductService().Update();
                    break;
                case EnumProductMenu.DeleteProduct:
                    Console.WriteLine("This menu is For Deleting Product.");
                    new ProductService().Delete();
                    break;
                case EnumProductMenu.Exit:
                    Console.WriteLine("Exiting Product Menu...\n");
                    return false;   // will stop "Product menu loop (isRunning = false)"
                case EnumProductMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu. Please choose 1 to 5.");
                    break;
            }
            return true;
        }

        public enum EnumProductMenu
        {
            None,
            NewProduct,
            ProductList,
            EditProdut,
            DeleteProduct,
            Exit
        }
    }
}
