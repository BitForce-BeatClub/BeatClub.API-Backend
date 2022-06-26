using System;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Payment
    {
        public int id { get; set; }
        public int price { get; set; }
        public string plan { get; set; }
        public DateTime date { get; set; }
        public string userId { get; set; }
        public User User { get; set; }
    }
}