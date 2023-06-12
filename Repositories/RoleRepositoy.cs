using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Models;

namespace Blog.Repositories
{
    public class RoleRepository
    {

        private readonly SqlConnection _conn; 

        public RoleRepository(SqlConnection conn)
            => _conn = conn;

        public IEnumerable<Role> Get()
           => _conn.GetAll<Role>();

        public Role GetOne(int id)
            => _conn.Get<Role>(id);

        public void Create(Role role)
         => _conn.Insert<Role>(role);

    }
}