using System.ComponentModel.DataAnnotations;

namespace AnimalShopProject.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string? Text { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}
