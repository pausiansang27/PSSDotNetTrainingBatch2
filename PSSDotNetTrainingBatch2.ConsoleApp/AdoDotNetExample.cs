using Microsoft.Data.SqlClient;
using System.Data;

namespace PSSDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTraining",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Opening a new connection...");
            connection.Open();
            Console.WriteLine("Connection successfully opened!");

            string query = "SELECT * FROM Tbl_Blog";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Console.WriteLine("Closing the connection...");
            connection.Close();
            Console.WriteLine("Connection successfully closed!");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Console.WriteLine("Blog Id => " + row["BlogId"]);
                Console.WriteLine("Blog Title => " + row["BlogTitle"]);
                Console.WriteLine("Blog Author => " + row["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + row["BlogContent"] + "\n");
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

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(rowsAffected > 0 ? "Insert Success!" : "Insert Failed!");
        }

        public void Edit()
        {
            Console.Write("Enter Blog Id to Edit: ");
            string blogId = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $"SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", blogId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                Console.WriteLine("Blog Id => " + row["BlogId"]);
                Console.WriteLine("Blog Title => " + row["BlogTitle"]);
                Console.WriteLine("Blog Author => " + row["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + row["BlogContent"]);
            }
        }

        public void Update()
        {
            Console.Write("Enter Blog Id to update: ");
            string blogId = Console.ReadLine()!;

            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            string query = $@"UPDATE Tbl_Blog
                    SET BlogTitle = @BlogTitle,
                        BlogAuthor = @BlogAuthor,
                        BlogContent = @BlogContent
                    WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", blogId);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(rowsAffected > 0 ? "Update Success!" : "Update Failed!");
        }

        public void Delete()
        {
            Console.Write("Enter Blog Id to update: ");
            string blogId = Console.ReadLine()!;

            string query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", blogId);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(rowsAffected > 0 ? "Delete Success!" : "Delete Failed!");
        }
    }
}