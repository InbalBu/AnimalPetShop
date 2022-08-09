using System.ComponentModel.DataAnnotations;

namespace AnimalShopProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string? Name { get; set; }
        public virtual IEnumerable<Animal>? Animals { get; set; }
    }
}
