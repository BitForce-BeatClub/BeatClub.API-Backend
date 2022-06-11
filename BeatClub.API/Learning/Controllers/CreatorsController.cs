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
    [Route("api/v1/[controller]")]
    
    public class CreatorsController : ControllerBase
    {
        private readonly ICreatorService _creatorService;
        private readonly IMapper _mapper;


        public CreatorsController(ICreatorService creatorService, IMapper mapper)
        {
            _creatorService = creatorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CreatorResource>> GetAllSync()
        {
            var creators = await _creatorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Creator>, IEnumerable<CreatorResource>>(creators);
            
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCreatorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var creator = _mapper.Map<SaveCreatorResource, Creator>(resource);

            var result = await _creatorService.SaveAsync(creator);

            if (!result.Success)
                return BadRequest(result.Message);

            var creatorResource = _mapper.Map<Creator, CreatorResource>(result.Resource);

            return Ok(creatorResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCreatorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var creator = _mapper.Map<SaveCreatorResource, Creator>(resource);
            
            var result = await _creatorService.UpdateAsync(id,creator);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var creatorResource = _mapper.Map<Creator, CreatorResource>(result.Resource);

            return Ok(creatorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _creatorService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var creatorResource = _mapper.Map<Creator, CreatorResource>(result.Resource);

            return Ok(creatorResource);
            
        }
    }
    
}

