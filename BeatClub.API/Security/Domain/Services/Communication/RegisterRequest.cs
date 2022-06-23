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
        public string TypeUser { get; set; }
        [Required]
        public string Trend { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public int MembershipId { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}