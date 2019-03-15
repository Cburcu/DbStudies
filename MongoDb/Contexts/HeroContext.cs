using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Entities;
using MongoDB.Models;

namespace MongoDB.Contexts
{
    public class HeroContext : IHeroContext
    {
        private readonly IMongoDatabase _db;
        public HeroContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Hero> Heroes => _db.GetCollection<Hero>("Heroes");
    }
}