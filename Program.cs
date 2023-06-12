using Microsoft.Data.SqlClient;
using Blog.Models;
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
            //CreateUser(conn);
            ReadWithRoles(conn);
            //ReadRoles(conn);

            conn.Close();
        }


        public static void ReadUsers(SqlConnection conn)
        {

            var repo = new Repository<User>(conn);
            var items = repo.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateUser(SqlConnection conn)
        {
            var user = new User()
            {
                Name = "Marcelo",
                Email = "marcelo@teste.com",
                PasswordHash = "HASH",
                Image = "imagem",
                Bio = "bio",
                Slug = "Slug"
            };

            var repo = new Repository<User>(conn);
            repo.Create(user);
        }

        public static void ReadRoles(SqlConnection conn)
        {

            var repo = new Repository<Role>(conn);
            var items = repo.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var user in items)
            {
                Console.WriteLine($"{user.Email} \n|");
                
                foreach (var role in user.Roles)
                    Console.WriteLine($"+----{role.Slug}");

                Console.WriteLine($"|");
                Console.WriteLine($"|");
            }
        }

        public static void ReadTags(SqlConnection conn)
        {

            var repo = new Repository<Tag>(conn);
            var items = repo.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

    }
}