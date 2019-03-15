using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Entities
{
    public interface IHeroContext
    {
        IMongoCollection<Hero> Heroes { get; }
    }
}