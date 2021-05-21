using CrudAPI.Domain;
using CrudAPI.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Services
{
    public class DetailService
    {
        // private readonly IMongoCollection<Suppliers> _collection;
        private readonly IMongoDatabase _uvgoDb;
        private const string Country = "Countries";
        private const string SupplyingRoles = "SupplyingRoles";
        private const string productClassification = "productClassification";

        public DetailService(IDatabaseSettings settings,
            MongoDbMultiton uvgoDb)
        {
            _uvgoDb = uvgoDb.GetDbClient(settings.ConnectionString);
        }

        public async Task<IList<Countries>> GetAllCountries() //Read
        {
            var collection = _uvgoDb.GetCollection<Countries>(Country);
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<IList<SupplyingRoles>> GetAllRoles() //Read
        {
            var collection = _uvgoDb.GetCollection<SupplyingRoles>(SupplyingRoles);
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<IList<productClassification>> GetAllSectors() //Read
        {
            var collection = _uvgoDb.GetCollection<productClassification>(SupplyingRoles);
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
    }
}
