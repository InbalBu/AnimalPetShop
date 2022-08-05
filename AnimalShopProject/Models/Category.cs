namespace AnimalShopProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual IEnumerable<Animal>? Animals { get; set; }
    }
}
