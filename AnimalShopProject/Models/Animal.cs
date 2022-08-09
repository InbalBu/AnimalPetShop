using System.ComponentModel.DataAnnotations;

namespace AnimalShopProject.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string? Name { get; set; }

        [Required, Range(0, 100)]
        public int Age { get; set; }
        public string? PictureName { get; set; }

        [Required, DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
