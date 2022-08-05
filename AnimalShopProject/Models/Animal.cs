namespace AnimalShopProject.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? PictureName { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
