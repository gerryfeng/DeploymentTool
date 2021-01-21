using ConfigBridge;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure
{
    public class SamplesContext
    {
        private readonly IMongoDatabase _database = null;

        public SamplesContext(IOptions<ConfigBridge.ConnectionString.configuration> settings)
        {
            var client = new MongoClient(settings.Value.mongo.Value);
            //if (client != null)
            //    _database = client.GetDatabase(settings.Value);
        }

        //public IMongoCollection<Locations> Locations
        //{
        //    get
        //    {
        //        return _database.GetCollection<Locations>("Locations");
        //    }
        //}
    }
}
