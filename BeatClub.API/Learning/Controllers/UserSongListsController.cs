using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BeatClub.API.Learning.Controllers
{
    [ApiController]
    [Route("/api/v1/users/{userId}/songLists")]
    public class UserSongListsController: ControllerBase
    {
        private readonly ISongListService _songListService;
        private readonly IMapper _mapper;

        public UserSongListsController(ISongListService songListService, IMapper mapper)
        {
            _songListService = songListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SongListResource>> GetAllByUserId(int userId)
        {
            var songLists = await _songListService.ListByUserIdAsync(userId);

            var resources = _mapper.Map<IEnumerable<SongList>, IEnumerable<SongListResource>>(songLists);

            return resources;
        }
    }
}