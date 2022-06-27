using System;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.Security.Resources
{
    public class UserResource
    {
        [SwaggerSchema("User Identifier")]
        public int Id { get; set; }
        [SwaggerSchema("User Nickname")]
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Usertype { get; set; }
        public string Location { get; set; }
        public string UrlToImage { get; set; }
        public string Description { get; set; }
        //public int MembershipId { get; set; }
        
    }
}