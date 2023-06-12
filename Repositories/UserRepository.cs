using Blog.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _conn;

        public UserRepository(SqlConnection conn) : base(conn)
        => _conn = conn;

        public List<User> GetWithRoles()
        {
            var query = @"select [User].*, [Role].* from 
                            [User] 
                        LEFT JOIN [UserRole] ON [UserRole].UserId = [User].[Id]
                        LEFT JOIN [Role] ON [UserRole].RoleId = [Role].[Id]";
            var users = new List<User>();

            var items = _conn.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr is null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                    {
                        usr.Roles.Add(role);
                    }

                    return user;
                }, splitOn: "Id");

            return users;
        }
    }
}