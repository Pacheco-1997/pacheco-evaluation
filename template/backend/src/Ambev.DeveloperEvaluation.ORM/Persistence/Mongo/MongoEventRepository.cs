using Ambev.DeveloperEvaluation.Domain.Events;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Persistence.Mongo
{
    public class MongoEventRepository<TEvent> : IEventRepository<TEvent>
    {
        private readonly IMongoCollection<TEvent> _collection;

        public MongoEventRepository(IMongoDatabase db)
        {
            var name = typeof(TEvent).Name + "s";
            _collection = db.GetCollection<TEvent>(name);
        }

        public Task SaveAsync(TEvent @event)
            => _collection.InsertOneAsync(@event);
    }
}
