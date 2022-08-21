using System.ComponentModel.DataAnnotations;

namespace AnimalShopProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public virtual IEnumerable<Animal>? Animals { get; set; }

    }
}
