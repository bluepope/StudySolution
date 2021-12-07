
using Microsoft.Data.SqlClient;

using Study.DatabaseTest.DbClass;

using System.Data;
using Dapper;
using Study.DatabaseTest.Models;
using Study.DatabaseTest.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Study.DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=nas.hyunmo.net;Database=Test;User Id=test;Password=test1234;TrustServerCertificate=True";
            string searchText = "test";

            //1. ADO.NET
            //new AdoNetTest().Test(connectionString, searchText);

            //2.Dapper -- Micro ORM
            //Connection 객체만
            //Parameter / Select 를 class 가지고 일부만 ORM 기능을 활용하겠다 라는 목적
            //Query 익숙한 세대에게 편함
            //new DapperTest().Test(connectionString, searchText);

            //3.EF - EF Core -- ORM  Code / DB First
            //DB 명령없이 C# 객체만 가지고 DB 를 활용할수 있도록
            //Query 사용하지 않음 --> 하지만 불필요한 쿼리가 생성될 수 있음

            using (var db = new BlogDbContext())
            {
                //트랜잭션 이용
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        tran.Rollback();
                    }
                }
                /*
SELECT TOP(1) [t].[Col1], [t].[Col2]
FROM [tblSample] AS [t]
WHERE ([t].[Col1] = 1) OR ([t].[Col2] LIKE N'Test%')
                 */

                var query = db.Samples.Where(s => s.Col1 > 1);
                query = query.Where(s => s.Col1 < 3);

                //query = query.Where(s => s.Col2.Contains("테슽")); //%테슽%
                query = query.Where(s => EF.Functions.Like(s.Col2, "테슽%"));

                if (1 == 2)
                {
                    query = query.OrderBy(s => s.Col1);
                }

                var sample = query.ToList();

                //sample.Col2 = "ㅁㄴ야ㅏ렁니ㅓㄹ";
                db.SaveChanges();

                // Create
                /*
exec sp_executesql N'SET NOCOUNT ON;
INSERT INTO [Blogs] ([Url])
VALUES (@p0);
SELECT [BlogId]
FROM [Blogs]
WHERE @@ROWCOUNT = 1 AND [BlogId] = scope_identity();

',N'@p0 nvarchar(2000)',@p0=N'http://blogs.msdn.com/adonet'
                 */
                Console.WriteLine("Inserting a new blog");
                db.Blogs.Add(new BlogModel { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .Where(b => b.BlogId == 2)
                    //.Include(b => b.Posts)
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");

                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new PostModel { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}