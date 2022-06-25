using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.Security.Authorization.Attributes;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Domain.Services;
using BeatClub.API.Security.Domain.Services.Communication;
using BeatClub.API.Security.Persistence.Repositories;
using BeatClub.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.Security.Controllers
{
    [Authorize]
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
        
        [AllowAnonymous]
        [HttpPost("sign-in")] //sign-in 
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            await _userService.RegisterAsync(request);
            return Ok(new {message = "Registration successful"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserRepository>>(users);
            return Ok(resources);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateRequest request)
        {
            await _userService.UpdateAsync(id, request);
            return Ok(new {message = "User updated successfully"});
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok(new {message = "User deleted successfully"});
        }

    }
}