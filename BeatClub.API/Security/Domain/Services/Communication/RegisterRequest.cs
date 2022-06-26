using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Security.Domain.Services.Communication
{
    public class RegisterRequest
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string UrlToImage { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Usertype { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
    }
}