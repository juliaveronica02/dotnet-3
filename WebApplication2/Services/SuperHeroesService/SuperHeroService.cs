using WebApplication2.Models;
using WebApplication2.Services.SuperHeroeService;

namespace WebApplication2.Services.SuperHeroesService
{
	public class SuperHeroService : ISuperHeroService
	{
		/*// below is heroes data.
		private static List<superhero> superheroes = new List<superhero>
		{
				new superhero {Id = 1, name ="Iron man", firstname = "iron", lastname="man", place="avengers"},
				new superhero {Id = 2, name ="Doctor Strange", firstname = "doctor", lastname="strange", place="avengers"},
		};*/
		private readonly DataContext _context;
		public SuperHeroService(DataContext context)
		{
			_context = context;
		}
		public async Task<List<superhero>> AddHeroes(superhero hero)
		{
			_context.superheroes.Add(hero);
			await _context.SaveChangesAsync();
			return await _context.superheroes.ToListAsync();
		}

		public async Task<List<superhero>?> DeleteHeroes(int id)
		{

			// superheroes are the name from heroes table -> simply database name.
			var hero = await _context.superheroes.FindAsync(id);

			// in swagger json data or form, remember delete the id. because we already put id on swagger just need fill below data.
			_context.superheroes.Remove(hero);
			await _context.SaveChangesAsync();
			if (hero is null)
			{
				// if hero not found will show below message.
				return null;
			}
			else
			{
				return await _context.superheroes.ToListAsync();
			}
		}

		public async Task<List<superhero>> GetAllHeroes()
		{
			var heroes = await _context.superheroes.ToListAsync();
			return heroes;
		}

		public async Task<superhero?> GetSingleHero(int id)
		{
			// superheroes are the name from heroes table -> simply database name.
			var hero = await _context.superheroes.FindAsync(id);
			if (hero is null)
			{
				// if hero not found will show below message.
				return null;
			}
			else
			{
				return hero;
			}
		}

		public async Task<List<superhero>?> UpdateHeroes(int id, superhero request)
		{
			// throw new NotImplementedException();

			// superheroes are the name from heroes table -> simply database name.
			var hero = await _context.superheroes.FindAsync(id);

			// in swagger json data or form, remember delete the id. because we already put id on swagger just need fill below data.
			hero.name = request.name;
			hero.firstname = request.firstname;
			hero.lastname = request.lastname;
			hero.place = request.place;

			await _context.SaveChangesAsync();

			if (hero is null)
			{
				// if hero not found will show below message.
				return null;
			}
			else
			{
				return await _context.superheroes.ToListAsync();
			}
		}
	}
}
