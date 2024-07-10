using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface _categoryInterface;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryInterface categoryRepository, IMapper mapper)
        {
            _categoryInterface = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        { 
            var categories = _mapper.Map<List<CategoryDto>>(_categoryInterface.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryInterface.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(_categoryInterface.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type= typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int categoryId)
        {
            if (!_categoryInterface.CategoryExists(categoryId))
                return NotFound();

            var pokemons = _mapper.Map<List<PokemonDto>>(_categoryInterface.GetPokemonByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var existingCategory = _categoryInterface.GetCategories().FirstOrDefault(c => c.Name.Trim().ToUpper() == categoryCreate.Name.Trim().ToUpper());


            if (existingCategory != null)
            {
                ModelState.AddModelError("", $"Category '{existingCategory.Name}' already exists");
                return Conflict(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if (!_categoryInterface.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
