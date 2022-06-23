using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/users/{userId}/payments")]
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
        public async Task<IEnumerable<PaymentResource>> GetAllByUserId(int userId)
        {
            var payments = await _paymentService.ListByUserIdAsync(userId);

            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

            return resources;
        }
        
    }
}