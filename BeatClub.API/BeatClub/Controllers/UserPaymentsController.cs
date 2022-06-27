using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/users/{userId}/payments")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserPaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public UserPaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all Payments for given User",
            Description = "Get existing Payments associated with the specified User",
            OperationId = "GetUserPayments",
            Tags = new []{"Users"}
        )]
        public async Task<IEnumerable<PaymentResource>> GetAllByUserId(int userId)
        {
            var payments = await _paymentService.ListByUserIdAsync(userId);

            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

            return resources;
        }
        
    }
}