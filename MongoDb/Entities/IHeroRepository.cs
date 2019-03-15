using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Models;

namespace MongoDB.Entities
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAllHeroes();
        Task<Hero> GetHero(string name);
        Task Create(Hero hero);
        Task<bool> Update(Hero hero);
        Task<bool> Delete(string name);
    }
}