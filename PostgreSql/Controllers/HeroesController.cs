using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroContext _heroContext;
        public HeroesController(HeroContext heroContext)
        {
            _heroContext = heroContext;
            if (_heroContext.Heroes.Count() == 0)
            {
                _heroContext.Heroes.Add(new Hero { Name = "Batman", Character = "Bruce Wayne", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Superman", Character = "Kal-El", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Flash", Character = "Barry Allen", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Green Lantern", Character = "Alan Scott", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Green Arrow", Character = "Oliver Queen", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Wonder Woman", Character = "Princess Diana", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Martian Manhunter", Character = "Martian Manhunter", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Robin/Nightwing", Character = "Dick Grayson", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Spider Man", Character = "Peter Parker", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Captain America", Character = "Steve Rogers", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Blue Beetle", Character = "Dan Garret", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Black Canary", Character = "Dinah Drake", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Iron Man", Character = "Tony Stark", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Thor", Character = "Thor Odinson", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Hulk", Character = "Bruce Banner", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Wolverine", Character = "James Howlett", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Daredevil", Character = "Matthew Michael Murdock", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Hawkeye", Character = "Clinton Francis Barton", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Cyclops", Character = "Scott Summers", Power = 1000 });
                _heroContext.Heroes.Add(new Hero { Name = "Silver Surfer", Character = "Norrin Radd", Power = 1000 });
                _heroContext.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Hero>> GetAll()
        {
            return _heroContext.Heroes.ToList();
        }

        [HttpGet("{id}", Name = "GetHero")]
        public ActionResult<Hero> GetById(int id)
        {
            var item = _heroContext.Heroes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        // POST api/values
        [HttpPost("{name}+{character}+{power}")]
        public IActionResult POST(string name, string character, int power)
        {
            var item = new Hero { Name = name, Character = character, Power = power };
            _heroContext.Heroes.Add(item);
            _heroContext.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}/{name}+{character}+{power}")]
        public void Put(int id, string name, string character, int power)
        {
            var item = _heroContext.Heroes.Find(id);
            item.Name = name;
            item.Character = character;
            item.Power = power;
            _heroContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _heroContext.Heroes.Find(id);
            _heroContext.Heroes.Remove(item);
            _heroContext.SaveChanges();
            GetAll();
        }
    }
}