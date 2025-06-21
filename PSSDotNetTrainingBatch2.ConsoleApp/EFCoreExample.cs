using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PSSDotNetTrainingBatch2.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            db.Blogs.Where(b => !b.DeleteFlag).ToList().ForEach(DisplayBlogItem);
        }

        public void Edit()
        {
            int blogId = GetBlogIdFromUser();
            AppDbContext db = new AppDbContext();
            BlogModel? blog = db.Blogs.FirstOrDefault(b => b.BlogId == blogId && !b.DeleteFlag);
            if (blog is null)
            {
                Console.WriteLine("Blog not found for Blog Id: " + blogId);
                return;
            }
            DisplayBlogItem(blog);

        }

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            BlogModel blog = new BlogModel()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content,
                DeleteFlag = false
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving blog success!" : "Saving Failed!");
        }

        public void Update()
        {
            int blogId = GetBlogIdFromUser();
            bool isExistBlog = IsExistBlog(blogId);
            if (!isExistBlog)
            {
                Console.WriteLine("Blog not found for Blog Id: " + blogId);
                return;
            }

            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            AppDbContext db = new AppDbContext();
            BlogModel? blog = db.Blogs.FirstOrDefault(b => b.BlogId == blogId && !b.DeleteFlag);
            blog.BlogTitle = title;
            blog.BlogAuthor = author;
            blog.BlogContent = content;
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating blog success!" : "Update Failed!");
        }

        public void Delete()
        {
            int blogId = GetBlogIdFromUser();
            bool isExistBlog = IsExistBlog(blogId);
            if (!isExistBlog)
            {
                Console.WriteLine("Blog not found for Blog Id: " + blogId);
                return;
            }
            AppDbContext db = new AppDbContext();
            BlogModel? blog = db.Blogs.FirstOrDefault(b => b.BlogId == blogId && !b.DeleteFlag);
            blog.DeleteFlag = true;
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting Blog Success! " : "Delete Blog Failed!");
        }

        public int GetBlogIdFromUser()
        {
            while (true)
            {
                Console.Write("Enter Blog Id: ");
                string input = Console.ReadLine()!;
                bool isInteger = int.TryParse(input, out int blogId);
                if (!isInteger)
                {
                    Console.WriteLine("Invalid Id. Please enter a valid Id!");
                }
                return blogId;
            }
        }

        public void DisplayBlogItem(BlogModel blog)
        {
            Console.WriteLine("Blog Id => " + blog.BlogId);
            Console.WriteLine("Blog Title => " + blog.BlogTitle);
            Console.WriteLine("Blog Author => " + blog.BlogAuthor);
            Console.WriteLine("Blog Content => " + blog.BlogContent + "\n");
        }

        public bool IsExistBlog(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel? blog = db.Blogs.FirstOrDefault(b => b.BlogId == id && !b.DeleteFlag);
            return blog != null ? true : false;
        }
    }
}
