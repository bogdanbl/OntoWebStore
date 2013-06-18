using MongoDB.Driver;

namespace OntoWebStore.Infrastructure
{
    public interface IMongoDataContextProvider
    {
        MongoDatabase DataContext { get; }
    }
}
