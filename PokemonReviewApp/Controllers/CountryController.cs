using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryInterface _countryInterface;
        private readonly IOwnerInterface _ownerInterface;
        private readonly IMapper _mapper;

        public CountryController(ICountryInterface countryInterface, IOwnerInterface ownerInterface, IMapper mapper)
        {
            _countryInterface = countryInterface;
            _ownerInterface = ownerInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryInterface.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetCountry(int countryId)
        {
            if (!_countryInterface.CountryExists(countryId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countryInterface.GetCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("owner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult GetCountryByOwner(int ownerId)
        {
            if (!_ownerInterface.OwnerExists(ownerId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countryInterface.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("{countryId}/owners")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromCountry(int countryId)
        {
            if (!_countryInterface.CountryExists(countryId))
                return NotFound();

            var owners = _mapper.Map<List<OwnerDto>>(_countryInterface.GetOwnersFromCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);

            var existingCountry = _countryInterface.GetCountries().FirstOrDefault(c => c.Name.Trim().ToUpper() == countryCreate.Name.Trim().ToUpper());


            if (existingCountry != null)
            {
                ModelState.AddModelError("", $"Country '{existingCountry.Name}' already exists");
                return Conflict(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(countryCreate);

            if (!_countryInterface.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto countryUpdate)
        {
            if (countryUpdate == null)
                return BadRequest(ModelState);

            if (countryId != countryUpdate.Id)
                return BadRequest(ModelState);

            if (!_countryInterface.CountryExists(countryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(countryUpdate);

            if (!_countryInterface.UpdateCountry(countryMap))
            {
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryInterface.CountryExists(countryId))
                return NotFound();

            var country = _countryInterface.GetCountry(countryId);

            if (_countryInterface.GetOwnersFromCountry(countryId).Count > 0)
            {
                ModelState.AddModelError("", $"Country '{country.Name}' cannot be deleted because it is associated with at least one Owner");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryInterface.DeleteCountry(country))
            {
                ModelState.AddModelError("", "An error occurred while deleting the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
