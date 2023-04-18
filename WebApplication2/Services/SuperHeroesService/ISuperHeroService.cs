namespace WebApplication2.Services.SuperHeroeService
{
	public interface ISuperHeroService
	{
		Task<List<superhero>> GetAllHeroes();
		Task<superhero?> GetSingleHero(int id);
		Task<List<superhero>> AddHeroes(superhero hero);
		Task<List<superhero>?> UpdateHeroes(int id, superhero request);
		Task<List<superhero>?> DeleteHeroes(int id);
	}
}
