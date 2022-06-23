using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Resources;
using BeatClub.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Create, read, update and delete Users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResource>),200)]
        public async Task<IEnumerable<UserResource>> GetAllSync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResource),201)]
        [ProducesResponseType(typeof(List<string>),400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);

            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);

            return Created(nameof(PostAsync),userResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            
            var result = await _userService.UpdateAsync(id,user);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);

            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);

            return Ok(userResource);
            
        }
    }
}