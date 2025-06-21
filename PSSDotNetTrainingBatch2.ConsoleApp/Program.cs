// See https://aka.ms/new-console-template for more information
using PSSDotNetTrainingBatch2.ConsoleApp;

Console.WriteLine("Sql Client");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit();
//adoDotNetExample.Create();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
//dapperExample.Delete();

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
eFCoreExample.Edit();
//eFCoreExample.Create();
//eFCoreExample.Update();
//eFCoreExample.Delete();

Console.ReadKey();