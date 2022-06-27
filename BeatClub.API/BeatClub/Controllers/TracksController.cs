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
    [SwaggerTag("Create, read, update and delete Tracks")]
    public class TracksController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITrackService _trackService;

        public TracksController(IMapper mapper, ITrackService trackService)
        {
            _mapper = mapper;
            _trackService = trackService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrackResource>),200)]
        public async Task<IEnumerable<TrackResource>> GetAllAsync()
        {
            var tracks = await _trackService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Track>, IEnumerable<TrackResource>>(tracks);

            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrackResource),201)]
        [ProducesResponseType(typeof(List<string>),400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTrackResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var track = _mapper.Map<SaveTrackResource, Track>(resource);

            var result = await _trackService.SaveAsync(track);

            if (!result.Success)
                return BadRequest(result.Message);

            var trackResource = _mapper.Map<Track, TrackResource>(result.Resource);

            return Created(nameof(PostAsync),trackResource);
            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTrackResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var track = _mapper.Map<SaveTrackResource, Track>(resource);

            var result = await _trackService.UpdateAsync(id, track);

            if (!result.Success)
                return BadRequest(result.Message);

            var trackResource = _mapper.Map<Track, TrackResource>(result.Resource);

            return Ok(trackResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _trackService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var trackResource = _mapper.Map<Track, TrackResource>(result.Resource);

            return Ok(trackResource);

        }
    }
}