using System;
using System.Text.Json.Serialization;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.Security.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname {get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Usertype { get; set; }
        public string UrlToImage { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        //Relationships
        /*public int MembershipId { get; set; }
        public Membership Membership { get; set; }*/
        
        [JsonIgnore]
        public string PasswordHash { get; set; }
        
        
    }
}