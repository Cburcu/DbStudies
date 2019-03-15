using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Entities;

namespace MongoDB.Models
{
    public class HeroRepository : IHeroRepository
    {
        private readonly IHeroContext _context;
        public HeroRepository(IHeroContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            return await _context.Heroes.Find(_ => true).ToListAsync();
        }
        public Task<Hero> GetHero(string name)
        {
            FilterDefinition<Hero> filter = Builders<Hero>.Filter.Eq(m => m.Name, name);
            return _context.Heroes.Find(filter).FirstOrDefaultAsync();
        }
        public async Task Create(Hero Hero)
        {
            await _context.Heroes.InsertOneAsync(Hero);
        }
        public async Task<bool> Update(Hero Hero)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Heroes
                        .ReplaceOneAsync(
                            filter: g => g.Id == Hero.Id,
                            replacement: Hero);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Hero> filter = Builders<Hero>.Filter.Eq(m => m.Name, name);
            DeleteResult deleteResult = await _context.Heroes.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}