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
    public class PaymentsController: ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IMapper mapper, IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetAllAsync()
        {
            var payments = await _paymentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

            var result = await _paymentService.SaveAsync(payment);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);
            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePaymentResource, Payment>(resource);

            var result = await _paymentService.UpdateAsync(id, publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);

        }
        
    }
}