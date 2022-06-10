using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Domain.Services;
using BeatClub.API.Learning.Resources;
using BeatClub.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BeatClub.API.Learning.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SongListsController : ControllerBase
    {
        private readonly ISongListService _songListService;
        private readonly IMapper _mapper;

        public SongListsController(ISongListService songListService, IMapper mapper)
        {
            _songListService = songListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SongListResource>> GetAllAsync()
        {
            var songlists = await _songListService.ListAsync();
            var resources = _mapper.Map<IEnumerable<SongList>, IEnumerable<SongListResource>>(songlists);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSongListResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var songList = _mapper.Map<SaveSongListResource, SongList>(resource);

            var result = await _songListService.SaveAsync(songList);

            if (!result.Success)
                return BadRequest(result.Message);

            var songListResource = _mapper.Map<SongList, SongListResource>(result.Resource);

            return Ok(songListResource);
            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSongListResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var songList = _mapper.Map<SaveSongListResource, SongList>(resource);

            var result = await _songListService.UpdateAsync(id, songList);

            if (!result.Success)
                return BadRequest(result.Message);

            var songListResource = _mapper.Map<SongList, SongListResource>(result.Resource);

            return Ok(songListResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _songListService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var songListResource = _mapper.Map<SongList, SongListResource>(result.Resource);

            return Ok(songListResource);

        }

    }
}