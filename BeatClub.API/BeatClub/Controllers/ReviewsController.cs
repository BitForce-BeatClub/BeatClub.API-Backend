using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using BeatClub.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Create, read, update and delete Reviews")]
    public class ReviewsController:ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;


        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReviewResource>),200)]
        public async Task<IEnumerable<ReviewResource>> GetAllAsync()
        {
            var reviews = await _reviewService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);

            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReviewResource),201)]
        [ProducesResponseType(typeof(List<string>),400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var review = _mapper.Map<SaveReviewResource, Review>(resource);

            var result = await _reviewService.SaveAsync(review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

            return Created(nameof(PostAsync),reviewResource);
            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var review = _mapper.Map<SaveReviewResource, Review>(resource);

            var result = await _reviewService.UpdateAsync(id, review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

            return Ok(reviewResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _reviewService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);

            return Ok(reviewResource);

        }
    }
}