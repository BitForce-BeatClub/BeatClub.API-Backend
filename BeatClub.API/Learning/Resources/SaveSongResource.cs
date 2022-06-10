using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Learning.Resources
{
    public class SaveSongResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        /*[Required]
        public DateTime CreateAt { get; set; }*/
        [Required]
        public int SongListId { get; set; }
    }
}