using MongoDB.Driver;

namespace OntoWebStore.Infrastructure
{
    public class MongoDataContextProvider:IMongoDataContextProvider
    {
        private const string ConnectionString = "mongodb://appharbor_49f11610-043a-4d2d-8240-c58097c91b64:onj007uupd5dm5r1rl3mqs0snd@ds029828.mongolab.com:29828/appharbor_49f11610-043a-4d2d-8240-c58097c91b64";

        public MongoDataContextProvider()
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            DataContext = server.GetDatabase("appharbor_49f11610-043a-4d2d-8240-c58097c91b64");
        }

        public MongoDatabase DataContext { get; private set; }
    }
}