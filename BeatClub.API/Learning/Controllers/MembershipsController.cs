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
    [Route("/api/v1/[controller]")]
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
        public async Task<IEnumerable<MembershipResource>> GetAllSync()
        {
            var memberships = await _membershipService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Membership>, IEnumerable<MembershipResource>>(memberships);
            
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMembershipResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var membership = _mapper.Map<SaveMembershipResource, Membership>(resource);

            var result = await _membershipService.SaveAsync(membership);

            if (!result.Success)
                return BadRequest(result.Message);

            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);

            return Ok(membershipResource);
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