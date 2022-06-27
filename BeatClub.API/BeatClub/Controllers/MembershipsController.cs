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
    [SwaggerTag("Create, read, update and delete Memberships")]
    public class MembershipsController : ControllerBase
    {
        private readonly IMembershipService _membershipService;
        private readonly IMapper _mapper;

        public MembershipsController(IMapper mapper, IMembershipService membershipService)
        {
            _mapper = mapper;
            _membershipService = membershipService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MembershipResource>),200)]
        public async Task<IEnumerable<MembershipResource>> GetAllSync()
        {
            var memberships = await _membershipService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Membership>, IEnumerable<MembershipResource>>(memberships);
            
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MembershipResource),201)]
        [ProducesResponseType(typeof(List<string>),400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMembershipResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var membership = _mapper.Map<SaveMembershipResource, Membership>(resource);

            var result = await _membershipService.SaveAsync(membership);

            if (!result.Success)
                return BadRequest(result.Message);

            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);

            return Created(nameof(PostAsync),membershipResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMembershipResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var membership = _mapper.Map<SaveMembershipResource, Membership>(resource);
            
            var result = await _membershipService.UpdateAsync(id,membership);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);

            return Ok(membershipResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _membershipService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);

            return Ok(membershipResource);
            
        }
    }
}