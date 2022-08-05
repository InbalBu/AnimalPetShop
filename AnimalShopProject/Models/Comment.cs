namespace AnimalShopProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}
