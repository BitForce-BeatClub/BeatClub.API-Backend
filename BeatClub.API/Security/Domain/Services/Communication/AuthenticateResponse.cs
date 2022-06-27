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
        public string Usertype { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        
    }
}