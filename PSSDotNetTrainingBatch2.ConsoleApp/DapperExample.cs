using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
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
                List<BlogDto> blogList = db.Query<BlogDto>("SELECT * FROM Tbl_Blog").OrderByDescending(x => x.BlogId).ToList();
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

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogTitle
                                   ,@BlogAuthor
                                   ,@BlogContent)";

            BlogDto blog = new BlogDto()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "Saving blog success!" : "Saving Failed!");
            }
        }

        public void Update()
        {
        FirstPage:
            Console.Write("Enter Blog Id to Update: ");
            string input = Console.ReadLine()!;
            bool isInteger = int.TryParse(input, out int blogId);
            if (!isInteger)
            {
                Console.WriteLine("Invalid Id. Please enter a valid Id!");
                goto FirstPage;
            }

            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogId = blogId,
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };

            string query = $@"UPDATE Tbl_Blog
                    SET BlogTitle = @BlogTitle,
                        BlogAuthor = @BlogAuthor,
                        BlogContent = @BlogContent
                    WHERE BlogId = @BlogId";

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new BlogDto() { BlogId = blogId });
                if (item == null)
                {
                    Console.WriteLine("Blog not found for Blog Id: " + blogId);
                    return;
                }
                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "Updating blog success!" : "Update Failed!");
            }
        }

        public void Delete()
        {
        FirstPage:
            Console.Write("Enter Blog Id to Delete: ");
            string input = Console.ReadLine()!;
            bool isInteger = int.TryParse(input, out int blogId);
            if (!isInteger)
            {
                Console.WriteLine("Invalid Id. Please enter a valid Id!");
                goto FirstPage;
            }
            string query = "DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new BlogDto() { BlogId = blogId });
                if (item == null)
                {
                    Console.WriteLine("Blog not found for Blog Id: " + blogId);
                    return;
                }
                int result = db.Execute(query, new BlogDto() { BlogId = blogId });
                Console.WriteLine(result > 0 ? "Deleting Blog Success! " : "Delete Blog Failed!");
            }
        }
    }
}
