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
    [SwaggerTag("Create, read, update and delete Messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResource>),200)]
        public async Task<IEnumerable<MessageResource>> GetAllAsync()
        {
            var messages = await _messageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);

            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MessageResource),201)]
        [ProducesResponseType(typeof(List<string>),400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = _mapper.Map<SaveMessageResource, Message>(resource);

            var result = await _messageService.SaveAsync(message);

            if (!result.Success)
                return BadRequest(result.Message);

            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);

            return Created(nameof(PostAsync),messageResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var message = _mapper.Map<SaveMessageResource, Message>(resource);

            var result = await _messageService.UpdateAsync(id, message);

            if (!result.Success)
                return BadRequest(result.Message);

            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);

            return Ok(messageResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _messageService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);

            return Ok(messageResource);
            
        }
        
        // /api/v1/users/1/messages
        
        

    }
}