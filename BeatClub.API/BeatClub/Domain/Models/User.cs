using System;
using System.Collections.Generic;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class User
    {
        public string id { get; set; }
        public string nickName {get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string urlToImage { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public string description { get; set; }

    }
}