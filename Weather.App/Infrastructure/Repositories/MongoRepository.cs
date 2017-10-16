using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Weather.App.Infrastructure.Repositories
{
    public class MongoRepository : IRepository
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private string _connectionString;

        public MongoRepository()
        {
            RegisterMappings();
            SetupDb();
        }

        public async Task<TValue> CreateAsync<TValue>(TValue value)
        {
            string collectionName = typeof(TValue).Name;
            var collection = _db.GetCollection<TValue>(collectionName);
            await collection.InsertOneAsync(value);

            return value;
        }

        public Task<bool> DeleteAsync<TValue>(TValue value)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TValue>> ReadAsync<TValue>(Expression<Func<TValue, bool>> expression)
        {
            string collectionName = typeof(TValue).Name;
            IQueryable<TValue> result = null;
            await Task.Run(() =>
            {
                result = _db.GetCollection<TValue>(collectionName).AsQueryable<TValue>().Where(expression);
            });

            return result;
        }
        
        public Task<TValue> UpdateAsync<TValue>(TValue value)
        {
            throw new NotImplementedException();
        }

        private void RegisterMappings()
        {
            var conventionPack = new ConventionPack();
            conventionPack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
        }

        private void SetupDb()
        {
            // TODO: Move db details into config file
            _connectionString = "mongodb://localhost:27017";
            _client = new MongoClient(_connectionString);
            _db = _client.GetDatabase("weather");
        }
    }
}
