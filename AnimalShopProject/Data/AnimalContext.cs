using Microsoft.EntityFrameworkCore;
using AnimalShopProject.Models;

namespace AnimalShopProject.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
        }
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sources = new string[]
            {
                "https://www.aejames.com/wp-content/uploads/2019/01/Pigeon-care-Albert-E-James-and-Son-900x600.jpg",
                "https://youriste.com/wp-content/uploads/2021/03/golden-retriever.jpeg",
                "https://www.everypaw.com/.imaging/mte/everypaw/590x330/dam/cat-breed-guides/persian/persian-kitten.jpg/jcr:content/persian-kitten.jpg"

            };

            modelBuilder.Entity<Animal>().HasData(
                new { Id = 1, Name = "Pingeon", Age = 5, PictureName = sources[0] , Description = "The domestic pigeon (Columba livia domestica) is a pigeon subspecies that was derived from the rock dove (also called the rock pigeon).\nThe rock pigeon is the world's oldest domesticated bird. Mesopotamian cuneiform tablets mention the domestication of pigeons more than 5,000 years ago, as do Egyptian hieroglyphics.", CategoryID = 1 },
                new { Id = 2, Name = "Doberman", Age = 8, PictureName = sources[1], Description = "Doberman Pinscher in the United States and Canada, is a medium-large breed of domestic dog that was originally developed around 1890 by Louis Dobermann, a tax collector from Germany.\nThe Dobermann has a long muzzle. It stands on its pads and is not usually heavy-footed. Ideally, they have an even and graceful gait.", CategoryID = 2 },
                new { Id = 3, Name = "Persian Cat", Age = 3, PictureName = sources[2], Description = "The Persian cat is a long-haired breed of cat characterized by its round face and short muzzle.", CategoryID = 3 }
            );

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Birds" },
                new { Id = 2, Name = "Dogs" },
                new { Id = 3, Name = "Cats" }
            );
            modelBuilder.Entity<Comment>().HasData(
               new { Id = 1, AnimalId = 1, Text = "Amazing, beautiful colors" },
               new { Id = 2, AnimalId = 1, Text = "Amazing, beautiful colors" },
               new { Id = 3, AnimalId = 1, Text = "Amazing, beautiful colors" },
               new { Id = 4, AnimalId = 2, Text = "Looks like such a nice and good dog" },
               new { Id = 5, AnimalId = 2, Text = "Looks like such a nice and good dog" },
               new { Id = 6, AnimalId = 2, Text = "They’re an active and playful breed" },
               new { Id = 7, AnimalId = 2, Text = "They’re an active and playful breed" },
               new { Id = 8, AnimalId = 3, Text = "They’re an active and playful breed" },
               new { Id = 9, AnimalId = 3, Text = "They’re an active and playful breed" },
               new { Id = 10, AnimalId = 3, Text = "They’re an active and playful breed" },
               new { Id = 11, AnimalId = 3, Text = "They’re an active and playful breed" },
               new { Id = 12, AnimalId = 3, Text = "They’re an active and playful breed" }
                );

        }
    }
}
