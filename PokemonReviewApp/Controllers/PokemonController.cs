using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonInterface _pokemonInterface;
        private readonly IReviewInterface _reviewInterface;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonInterface pokemonRepository, IReviewInterface reviewInterface, IMapper mapper)
        {
            _pokemonInterface = pokemonRepository;
            _reviewInterface = reviewInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonInterface.GetPokemons());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonInterface.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var pokemon = _mapper.Map<PokemonDto>(_pokemonInterface.GetPokemon(pokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonInterface.PokemonExists(pokeId))
                return NotFound();

            var rating = _pokemonInterface.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] PokemonDto pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            if (ownerId == 0 || categoryId == 0)
                return BadRequest(ModelState);

            var pokemons = _pokemonInterface.GetPokemons().Where(p => p.Name.Trim().ToUpper() == pokemonCreate.Name.Trim().ToUpper()).FirstOrDefault();

            if (pokemons != null)
            {
                ModelState.AddModelError("", $"Pokemon {pokemonCreate.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);

            if (!_pokemonInterface.CreatePokemon(ownerId, categoryId, pokemonMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the pokemon {pokemonCreate.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Pokemon Created Successfully");
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(int pokeId, [FromQuery] int ownerId, int categoryId, [FromBody] PokemonDto pokemonUpdate)
        {
            if (pokemonUpdate == null)
                return BadRequest(ModelState);

            if (pokeId != pokemonUpdate.Id)
                return BadRequest(ModelState);

            if (!_pokemonInterface.PokemonExists(pokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(pokemonUpdate);

            if (!_pokemonInterface.UpdatePokemon(ownerId, categoryId, pokemonMap))
            {
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonInterface.PokemonExists(pokeId))
                return NotFound();

            var reviews = _reviewInterface.GetReviewsByPokemon(pokeId);

            if (reviews.Count > 0)
            {
                if (!_reviewInterface.DeleteReviews(reviews))
                {
                    ModelState.AddModelError("", $"Something went wrong deleting the reviews for the pokemon {pokeId}");
                    return StatusCode(500, ModelState);
                }

            }

            var pokemon = _pokemonInterface.GetPokemon(pokeId);

            if (!_pokemonInterface.DeletePokemon(pokemon))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the pokemon {pokemon.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
