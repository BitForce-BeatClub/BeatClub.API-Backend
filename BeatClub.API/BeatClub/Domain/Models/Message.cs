using System;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Message
    {
        public int id { get; set; }
        public string content { get; set; }
        public DateTime messageDate { get; set; }
        
        //Relationships
        public string userIdFrom { get; set; }
        public User UserFrom { get; set; }
        public string userIdTo { get; set; }
        public User UserTo { get; set; }
    }
}