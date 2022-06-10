using System;
using System.ComponentModel.DataAnnotations;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Resources
{
    public class SaveSongListResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}