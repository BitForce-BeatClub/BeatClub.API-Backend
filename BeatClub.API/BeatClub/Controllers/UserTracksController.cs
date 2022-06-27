using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/users/{userId}/tracks")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserTracksController : ControllerBase
    {
        private readonly ITrackService _trackService;
        private readonly IMapper _mapper;

        public UserTracksController(ITrackService trackService, IMapper mapper)
        {
            _trackService = trackService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all Tracks for given User",
            Description = "Get existing Tracks associated with the specified User",
            OperationId = "GetUserTracks",
            Tags = new []{"Users"}
        )]
        public async Task<IEnumerable<TrackResource>> GetAllByUserId(int userId)
        {
            var tracks = await _trackService.ListByUserIdAsync(userId);

            var resources = _mapper.Map<IEnumerable<Track>, IEnumerable<TrackResource>>(tracks);

            return resources;

        }


    }
}