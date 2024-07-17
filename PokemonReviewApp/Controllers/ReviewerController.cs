using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerInterface _reviewerInterface;
        private readonly IReviewInterface _reviewInterface;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerInterface reviewerInterface, IReviewInterface reviewInterface, IMapper mapper)
        {
            _reviewerInterface = reviewerInterface;
            _reviewInterface = reviewInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerInterface.GetReviewers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!_reviewerInterface.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerInterface.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            if (!_reviewerInterface.ReviewerExists(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerInterface.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            if (reviewerCreate == null)
                return BadRequest(ModelState);

            var existingReviewer = _reviewerInterface.GetReviewers().FirstOrDefault(c => c.FirstName.Trim().ToUpper() == reviewerCreate.FirstName.Trim().ToUpper() || c.LastName.Trim().ToUpper() == reviewerCreate.LastName.Trim().ToUpper());

            if (existingReviewer != null)
            {
                ModelState.AddModelError("", $"Reviewer '{existingReviewer.FirstName} {existingReviewer.LastName}' already exists");
                return Conflict(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<Reviewer>(reviewerCreate);

            if (!_reviewerInterface.CreateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{reviewerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerDto reviewerUpdate)
        {
            if (reviewerUpdate == null)
                return BadRequest(ModelState);

            if (reviewerId != reviewerUpdate.Id)
                return BadRequest(ModelState);

            if (!_reviewerInterface.ReviewerExists(reviewerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<Reviewer>(reviewerUpdate);

            if (!_reviewerInterface.UpdateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", "An error occurred while saving the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{reviewerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteReviewer(int reviewerId)
        {
            if (!_reviewerInterface.ReviewerExists(reviewerId))
                return NotFound();

            var reviews = _reviewerInterface.GetReviewsByReviewer(reviewerId);

            if (reviews.Count > 0)
            {
                if (!_reviewInterface.DeleteReviews(reviews))
                {
                    ModelState.AddModelError("", "An error occurred while deleting the data.");
                    return StatusCode(500, ModelState);
                }
            }

            var reviewer = _reviewerInterface.GetReviewer(reviewerId);

            if (!_reviewerInterface.DeleteReviewer(reviewer))
            {
                ModelState.AddModelError("", "An error occurred while deleting the data.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
