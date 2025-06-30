namespace PSSDotNetTrainingBatch2.Project1.ConsoleApp.Menus
{
    public class StartMenu
    {
        public void Execute()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ShowStartMenu();
                Console.Write("Choose Menu: ");
                string input = Console.ReadLine()!;
                int.TryParse(input, out int menuNumber);
                isRunning = HandleMenuChoice((EnumMenu) menuNumber);
            }
        }

        private void ShowStartMenu()
        {
            Console.WriteLine("Menus");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Product");
            Console.WriteLine("2. Sale");
            Console.WriteLine("3. Sale Details");
            Console.WriteLine("4. Exit");
            Console.WriteLine("------------------------------");
        }

        private bool HandleMenuChoice(EnumMenu menu)
        {
            switch (menu)
            {
                case EnumMenu.Product:
                    new ProductMenu().Execute();
                    Execute();
                    return false;
                case EnumMenu.Sale:
                    break;
                case EnumMenu.SaleDetail:
                    break;
                case EnumMenu.Exit:
                    Console.WriteLine("Exiting Start Menu...");
                    return false;
                case EnumMenu.None:
                default:
                    Console.WriteLine("Invalid Menu. Please choose 1 to 4.");
                    break;
            }
            return true;
        }

        public enum EnumMenu
        {
            None,
            Product,
            Sale,
            SaleDetail,
            Exit
        }
    }
}
