using System.Collections.Generic;
using System.Threading.Tasks;
using CrudAPI.Domain;
using CrudAPI.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudAPI.Services
{
    public class SuppliersService
    {
        private readonly IMongoCollection<Suppliers> _collection;

        public SuppliersService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _collection = database.GetCollection<Suppliers>("Suppliers");
        }


        public async Task<Suppliers> Insert(Suppliers todoList) //Create
        {
            await _collection.InsertOneAsync(todoList);
            return todoList;
        }

        public async Task<Suppliers> Update(Suppliers todoList) //Update
        {
            await _collection.ReplaceOneAsync(t => t.Id
                                                   == todoList.Id, todoList);
            return todoList;
        }

        public async Task<IList<Suppliers>> GetAll() //Read
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }


        public async Task<Suppliers> GetById(int todoListId) //Read
        {
            return await _collection.FindAsync(t => t.Id == todoListId).Result.FirstOrDefaultAsync();
        }

        public async Task Remove(int todoListId) //Delete
        {
            await _collection.DeleteOneAsync(t => t.Id
                                                  == todoListId);
        }
    }
}