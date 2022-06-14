using System;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Resources
{
    public class SongResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlToImage { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}