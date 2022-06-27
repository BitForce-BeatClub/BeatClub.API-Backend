using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Security.Domain.Services.Communication
{
    public class UpdateRequest
    {
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string UrlToImage { get; set; }
        
        public string Usertype { get; set; }
        
        public string Location { get; set; }
        
        public string Description { get; set; }
        
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        
        
        
    }
}