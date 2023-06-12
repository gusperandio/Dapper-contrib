using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Models;

namespace Blog.Repositories
{
    public class UserRepository
    {

        private readonly SqlConnection _conn; 

        public UserRepository(SqlConnection conn)
            => _conn = conn;

        public IEnumerable<User> Get()
           => _conn.GetAll<User>();

        public User GetOne(int id)
            => _conn.Get<User>(id);

        public void Create(User user)
         => _conn.Insert<User>(user);

    }
}