using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/users/{userId}/tracks")]
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
        public async Task<IEnumerable<TrackResource>> GetAllByUserId(int userId)
        {
            var tracks = await _trackService.ListByUserIdAsync(userId);

            var resources = _mapper.Map<IEnumerable<Track>, IEnumerable<TrackResource>>(tracks);

            return resources;

        }


    }
}