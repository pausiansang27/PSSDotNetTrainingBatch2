// See https://aka.ms/new-console-template for more information
using PSSDotNetTrainingBatch2.MiniPosConsoleApp.Services;

Console.WriteLine("MINI POS");

ProductService productService = new ProductService();
//productService.Read();
//productService.Edit();
//productService.Create();
productService.Update();
//productService.Delete();
