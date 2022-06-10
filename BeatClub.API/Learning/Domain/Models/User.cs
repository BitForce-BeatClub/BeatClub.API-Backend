using System.Collections.Generic;

namespace BeatClub.API.Learning.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Nickname {get; set; }
        
        public string Password { get; set; }
        
        public string TypeUser { get; set; }

        public IList<Message> Messages { get; set; } = new List<Message>();

    }
}