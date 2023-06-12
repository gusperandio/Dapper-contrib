using Microsoft.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Blog.Repositories;

namespace Blog
{
    class Program
    {

        static void Main()
        {
            Console.Clear();
            var conn = new SqlConnection("Server=NTBGFINF13\\SQLEXPRESS;Database=blog;Trusted_Connection=True;TrustServerCertificate=true;");
            conn.Open();

            ReadUsers(conn);
            ReadRoles(conn);
            
            conn.Close();
        }


        public static void ReadUsers(SqlConnection conn)
        {

            var repo = new UserRepository(conn);
            var users = repo.Get();

            foreach (var item in users)
                Console.WriteLine(item.Name);
        }

        public static void ReadRoles(SqlConnection conn)
        {

            var repo = new RoleRepository(conn);
            var roles = repo.Get();

            foreach (var item in roles)
                Console.WriteLine(item.Slug);
        }

    }
}