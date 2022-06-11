namespace BeatClub.API.Learning.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public DateTime CreateAt { get; set; }
        public UserResource User { get; set; }
    }
}