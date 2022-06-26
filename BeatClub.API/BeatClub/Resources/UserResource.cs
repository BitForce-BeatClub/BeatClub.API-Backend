using System;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class UserResource
    {
        [SwaggerSchema("User Identifier")]
        public string id { get; set; }
        [SwaggerSchema("User Nickname")]
        public string nickName {get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string urlToImage { get; set; }
        public string userType { get; set; }
        public string membership { get; set; }

    }
}