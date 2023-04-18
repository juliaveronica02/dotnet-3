using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.SuperHeroeService;
using WebApplication2.Services.SuperHeroesService;
// using WebApplication2.Models; // get models call superhero, move to global on program.cs file.

// controller file just for sending request not function. function on SuperHeroService. ISuperHeroSevice same with route.
namespace WebApplication2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		// below comment move to SuperHeroService.cs.
		/*// below is heroes data.
		private static List<superhero> superheroes = new List<superhero>
		{
				new superhero {Id = 1, name ="Iron man", firstname = "iron", lastname="man", place="avengers"},
				new superhero {Id = 2, name ="Doctor Strange", firstname = "doctor", lastname="strange", place="avengers"},
		};*/

		private readonly ISuperHeroService _superHeroService;
		public SuperHeroController(ISuperHeroService superHeroService) => _superHeroService = superHeroService;

		// get all heroes.
		[HttpGet]
		public async Task<ActionResult<List<superhero>>> GetAllHeroes()
		{
			// show response 200 (available).
			return await _superHeroService.GetAllHeroes();
		}

		// get heroes by id.
		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<List<superhero>>> GetSingleHero(int id)
		{
			var result = await _superHeroService.GetSingleHero(id);
			if (result is null)
			{
				return NotFound("Hero not found");
			}
			else
			{
				return Ok(result);
			}
		}

		// add hero.
		[HttpPost]
		// "hero" just a variabel to add heroes data.
		public async Task<ActionResult<List<superhero>>> AddHeroes(superhero hero)
		{
			var result = await _superHeroService.AddHeroes(hero);
			return Ok(result);
		}

		// edit hero data.
		[HttpPut]
		[Route("{id}")]
		public async Task<ActionResult<List<superhero>>> UpdateHeroes(int id, superhero request)
		{
			var result = await _superHeroService.UpdateHeroes(id, request);
			if (result is null)
			{
				return NotFound("Hero not found");
			}
			else
			{
				return Ok(result);
			}
		}

		// delete hero data.
		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult<List<superhero>>> DeleteHeroes(int id)
		{
			var result = await _superHeroService.DeleteHeroes(id);
			if(result is null)
			{
				return NotFound("Hero not found");
			} else
			{
				return Ok(result);
			}
		}
	}
}