using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Security.Domain.Services.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}