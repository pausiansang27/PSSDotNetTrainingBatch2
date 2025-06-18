using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace PSSDotNetTrainingBatch2.ConsoleApp
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                List<BlogDto> blogList = db.Query<BlogDto>("SELECT * FROM Tbl_Blog").ToList();
                foreach (var blog in blogList)
                {
                    Console.WriteLine("Blog Id => " + blog.BlogId);
                    Console.WriteLine("Blog Title => " + blog.BlogTitle);
                    Console.WriteLine("Blog Author => " + blog.BlogAuthor);
                    Console.WriteLine("Blog Content => " + blog.BlogContent + "\n");
                }
            }
        }

        public void Edit()
        {
        FirstPage:
            Console.Write("Enter Blog Id to Edit: ");
            string input = Console.ReadLine()!;
            bool isInteger = int.TryParse(input, out int blogId);
            if (!isInteger)
            {
                Console.WriteLine("Invalid Id. Please enter a valid Id!");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var blog = db.QueryFirstOrDefault<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId = @blogId", new BlogDto() { BlogId = blogId });
                if (blog == null)
                {
                    Console.WriteLine("Blog not found for Blog Id: " + blogId);
                    return;
                }

                Console.WriteLine("Blog Id => " + blog.BlogId);
                Console.WriteLine("Blog Title => " + blog.BlogTitle);
                Console.WriteLine("Blog Author => " + blog.BlogAuthor);
                Console.WriteLine("Blog Content => " + blog.BlogContent);
            }
        }
    }
}
