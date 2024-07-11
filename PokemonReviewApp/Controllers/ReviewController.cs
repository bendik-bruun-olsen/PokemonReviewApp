using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewInterface _reviewInterface;
        private readonly IPokemonInterface _pokemonInterface;
        private readonly IReviewerInterface _reviewerInterface;
        private readonly IMapper _mapper;

        public ReviewController(IReviewInterface reviewInterface, IPokemonInterface pokemonInterface, IReviewerInterface reviewerInterface, IMapper mapper)
        {
            _reviewInterface = reviewInterface;
            _pokemonInterface = pokemonInterface;
            _reviewerInterface = reviewerInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewInterface.GetReviews());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewInterface.ReviewExists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewInterface.GetReview(reviewId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet("pokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByPokemon(int pokeId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewInterface.GetReviewsByPokemon(pokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromBody] ReviewDto reviewCreate, [FromQuery] int pokeId, int reviewerId)
        {
            if (pokeId == 0 || reviewerId == 0)
                return BadRequest(ModelState);

            var pokemon = _pokemonInterface.GetPokemon(pokeId);
            var reviewer = _reviewerInterface.GetReviewer(reviewerId);

            if (pokemon == null || reviewer == null)
                return NotFound();

            if (reviewCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(reviewCreate);
            reviewMap.Pokemon = pokemon;
            reviewMap.Reviewer = reviewer;

            if (!_reviewInterface.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", $"An error occurred while saving");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
