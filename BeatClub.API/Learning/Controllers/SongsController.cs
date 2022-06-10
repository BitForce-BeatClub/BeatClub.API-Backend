using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Resources;
using BeatClub.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BeatClub.API.Learning.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SongsController:ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SongResource>> GetAllAsync()
        {
            var songs = await _songService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Song>, IEnumerable<SongResource>>(songs);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSongResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var song = _mapper.Map<SaveSongResource, Song>(resource);

            var result = await _songService.SaveAsync(song);

            if (!result.Success)
                return BadRequest(result.Message);

            var songResource = _mapper.Map<Song, SongResource>(result.Resource);

            return Ok(songResource);
            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSongResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var song = _mapper.Map<SaveSongResource, Song>(resource);

            var result = await _songService.UpdateAsync(id, song);

            if (!result.Success)
                return BadRequest(result.Message);

            var songResource = _mapper.Map<Song, SongResource>(result.Resource);

            return Ok(songResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _songService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var songResource = _mapper.Map<Song, SongResource>(result.Resource);

            return Ok(songResource);

        }
        
    }
}