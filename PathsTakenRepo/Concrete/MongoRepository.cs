using System;
using System.Linq;
using System.Linq.Expressions;
using PathsTakenRepo.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace PathsTakenRepo.Concrete
{
    public class MongoRepository : IRepository
    {
        #region Variables

        private readonly string _connectionString;

        #endregion

        #region Properties

        private string DatabaseName
        {
            get
            {
                var index = _connectionString.LastIndexOf("/", StringComparison.Ordinal);

                return _connectionString.Substring(index + 1, _connectionString.Length - (index + 1));
            }
        }

        #endregion

        #region Constructors

        public MongoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Public Methods

        public IQueryable<T> All<T>() where T : class
        {
            return Read<T>(collection => collection).AsQueryable();
        }

        public IQueryable<T> Where<T>(Func<T, bool> predicate) where T : class
        {
            return All<T>().Where(predicate).AsQueryable();
        }

        public T SingleOrDefault<T>(Func<T, bool> predicate) where T : class
        {
            return All<T>().SingleOrDefault(predicate);
        }

        public T Add<T>(T entity) where T : class
        {
            Write<T>(collection => collection.Save(entity));
            return entity;
        }

        public void Update<T>(T entity) where T : class
        {
            Add(entity);
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var query = Query<T>.Where(predicate);
            Write<T>(collection => collection.Remove(query));
        }

        #endregion

        #region Private Methods

        private MongoServer GetConnection()
        {
            var client = new MongoClient(_connectionString);
            return client.GetServer();
        }

        private MongoCollection<T> Read<T>(Func<MongoCollection<T>, MongoCollection<T>> action)
        {
            var server = GetConnection();
            var database = server.GetDatabase(DatabaseName);
            var collection = database.GetCollection<T>(GetCollectionName<T>());

            using (server.RequestStart(database))
            {
                return action(collection);
            }
        }

        private void Write<T>(Action<MongoCollection> action)
        {
            var server = GetConnection();
            var database = server.GetDatabase(DatabaseName);
            var collection = database.GetCollection<T>(GetCollectionName<T>());

            using (server.RequestStart(database))
            {
                action(collection);
            }
        }

        private static string GetCollectionName<T>()
        {
            var col = typeof(T).ToString();
            var index = col.LastIndexOf(".", StringComparison.Ordinal);

            return col.Substring(index + 1, col.Length - (index + 1));
        }

        #endregion
    }
}
