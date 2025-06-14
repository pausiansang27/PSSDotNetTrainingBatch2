// See https://aka.ms/new-console-template for more information
using PSSDotNetTrainingBatch2.ConsoleApp;

Console.WriteLine("Sql Client");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit();
adoDotNetExample.Create();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

Console.ReadKey();