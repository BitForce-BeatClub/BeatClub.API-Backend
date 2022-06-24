using System;

namespace BeatClub.API.Security.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        
        public string UrlToImage { get; set; }
        
        public string TypeUser { get; set; }

        public string Trend { get; set; }
        
        public string Result { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public string Token { get; set; }
        
    }
}