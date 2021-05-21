using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Settings
{
    public class MongoDbMultiton
    {
        //public IMongoDatabase GetDbClient(string conString);
        static readonly ConcurrentDictionary<string, IMongoDatabase> _mongoDbs
                       = new ConcurrentDictionary<string, IMongoDatabase>();
        public IMongoDatabase GetDbClient(string conString)
        {
            if (string.IsNullOrWhiteSpace(conString))
                throw new ArgumentNullException($"{nameof(conString)} is required.");

            // it will add or get the mongo connection based on 'connection string' which is used as key in the concurrent dictionary. 
            // if the key does not already exist. Returns the new value, or the existing value if the key exists.
            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.Database);
            return _mongoDbs.GetOrAdd(
            conString, (key) =>
            {
                var url = new MongoUrl(conString);
                var mongoSettings = MongoClientSettings.FromUrl(url);
                mongoSettings.ClusterConfigurator = cb =>
                {
                    cb.Subscribe<CommandStartedEvent>(e =>
                    {
                        Trace.WriteLine($"MongoDb Command: {e.CommandName}");
                        Trace.WriteLine($"MQL: {e.Command.ToString()}");
                    });
                };
                var mongoClient = new MongoClient(mongoSettings);
                return mongoClient.GetDatabase(url.DatabaseName);
            });
        }
    }
}
