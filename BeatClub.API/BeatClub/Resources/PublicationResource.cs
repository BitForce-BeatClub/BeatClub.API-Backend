namespace BeatClub.API.BeatClub.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
    }
}