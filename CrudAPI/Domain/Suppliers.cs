using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudAPI.Domain
{
    public class Suppliers
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Roles { get; set; }
        public string productClassification { get; set; }
        public string vatNumber { get; set; }

       // public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}