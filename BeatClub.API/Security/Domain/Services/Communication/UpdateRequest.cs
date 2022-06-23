using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Security.Domain.Services.Communication
{
    public class UpdateRequest
    {
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string UrlToImage { get; set; }
        
        public string TypeUser { get; set; }
        
        public string Trend { get; set; }
        
        public string Result { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public int MembershipId { get; set; }
        
        public string Nickname { get; set; }
        
        public string Password { get; set; }
    }
}