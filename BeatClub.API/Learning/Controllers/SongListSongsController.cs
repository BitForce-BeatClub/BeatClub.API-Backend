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
    [Route("/api/v1/songLists/{songListId}/songs")]
    public class SongListSongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;


        public SongListSongsController(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<SongResource>> GetAllByPlayListId(int songListId)
        {
            var songs = await _songService.ListBySongListIdAsync(songListId);

            var resources = _mapper.Map<IEnumerable<Song>, IEnumerable<SongResource>>(songs);

            return resources;
        }
    }
}