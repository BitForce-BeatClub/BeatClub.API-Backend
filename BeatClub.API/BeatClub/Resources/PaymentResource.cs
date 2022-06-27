using System;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Resources
{
    public class PaymentResource
    {
        public int Id { get; set; }
        public string plan { get; set; }
        public int price { get; set; }
        public DateTime date { get; set; }
        public string userId { get; set; }
       
    }
}