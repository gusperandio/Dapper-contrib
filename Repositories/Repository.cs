using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _conn;
        public Repository(SqlConnection conn)
            => _conn = conn;

        public IEnumerable<T> Get()
            => _conn.GetAll<T>();

        public T Get(int id)
                => _conn.Get<T>(id);

        public void Create(T model)
         => _conn.Insert<T>(model);

        public void Update(T model)
        => _conn.Insert<T>(model);


        public void Delete(T model)
        => _conn.Delete<T>(model);


        public void Delete(int id)
        {
            var model = _conn.Get<T>(id);
            _conn.Delete<T>(model);
        }
    }
}