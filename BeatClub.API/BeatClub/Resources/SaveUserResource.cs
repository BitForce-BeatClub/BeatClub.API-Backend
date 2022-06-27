using System;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Resources
{
    [SwaggerSchema(Required = new[]{"Nickname"})]
    public class SaveUserResource
    {
        [SwaggerSchema("User Id")]
        [Required]
        public string id { get; set; }
        [SwaggerSchema("User Nickname")]
        [Required]
        [MaxLength(50)]
        public string nickName {get; set; }
        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string email { get; set; }
        [Required]
        [MaxLength(150)]
        public string location { get; set; }
        [Required]
        [MaxLength(200)]
        public string description { get; set; }
        [Required]
        [MaxLength(200)]
        public string urlToImage { get; set; }

    }
}