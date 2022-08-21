using System.ComponentModel.DataAnnotations;

namespace AnimalShopProject.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Animal name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter Animal age")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Please enter A Picture")]
        public string? PictureName { get; set; }
        [Required(ErrorMessage = "Please enter A Description")]
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
