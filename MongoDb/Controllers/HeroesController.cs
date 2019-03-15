using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using MongoDB.Models;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : Controller
    {
        private readonly IHeroRepository _heroRepository;
        public HeroesController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        // GET: api/Game
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _heroRepository.GetAllHeroes());
        }
        // GET: api/Game/name
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var hero = await _heroRepository.GetHero(name);
            if (hero == null)
                return new NotFoundResult();
            return new ObjectResult(hero);
        }
        // POST: api/Game
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hero hero)
        {
            await _heroRepository.Create(hero);
            return new OkObjectResult(hero);
        }
        // PUT: api/Game/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Hero hero)
        {
            var heroFromDb = await _heroRepository.GetHero(name);
            if (heroFromDb == null)
                return new NotFoundResult();
            hero.Id = heroFromDb.Id;
            await _heroRepository.Update(hero);
            return new OkObjectResult(hero);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var heroFromDb = await _heroRepository.GetHero(name);
            if (heroFromDb == null)
                return new NotFoundResult();
            await _heroRepository.Delete(name);
            return new OkResult();
        }
    }
}
