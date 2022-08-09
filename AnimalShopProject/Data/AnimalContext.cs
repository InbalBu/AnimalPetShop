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
                "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Cyanocitta_cristata_blue_jay.jpg/330px-Cyanocitta_cristata_blue_jay.jpg",
                "https://youriste.com/wp-content/uploads/2021/03/golden-retriever.jpeg",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/6/64/Ragdoll_from_Gatil_Ragbelas.jpg/330px-Ragdoll_from_Gatil_Ragbelas.jpg",
                "https://www.animalfunfacts.net/images/stories/pets/birds/pacific_parrotlet_l.jpg",
                "https://www.animalfunfacts.net/images/stories/pets/birds/canary_bird_l.jpg",
                "https://dogtime.com/assets/uploads/gallery/australian-retriever-mixed-dog-breed-pictures/australian-retriever-mixed-dog-breed-pictures-2.jpg",
                "https://assets.orvis.com/is/image/orvisprd/AdobeStock_25245434",
                "https://cdn.wamiz.fr/cdn-cgi/image/format=auto,quality=80,width=460,height=600,fit=cover/animal/breed/pictures/61658afd3b5cb624077024.jpg",
                "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F47%2F2022%2F03%2F08%2Famerican-curl-lying-down-indoors-333618000-2000.jpeg",
                "https://animalmedia.org/wp-content/uploads/2022/06/Cream-Color.jpg"

            };

            modelBuilder.Entity<Animal>().HasData(
                new { Id = 1, Name = "Blue Jay", Age = 5, PictureName = sources[0] , Description = "The blue jay (Cyanocitta cristata) is a passerine bird in the family Corvidae, native to eastern North America \n. It lives in most of the eastern and central United States; some eastern populations may be migratory. ", CategoryID = 1 },
                new { Id = 2, Name = "Golden Retriever", Age = 8, PictureName = sources[1], Description = "The Golden Retriever, an exuberant Scottish gundog of great beauty, stands among America's most popular dog breeds. \n They are serious workers at hunting and field work, as guides for the blind, and in search-and-rescue, \n enjoy obedience and other competitive events, and have an endearing love of life when not at work. ", CategoryID = 2 },
                new { Id = 3, Name = "Ragdoll Cat", Age = 3, PictureName = sources[2], Description = "The Ragdoll is a cat breed with a colorpoint coat and blue eyes. Its morphology is large and weighty, and it has a semi-long and silky soft coat. \n Ragdolls were bred by American breeder Ann Baker in the 1960s.", CategoryID = 3 },
                new { Id = 4, Name = "Pacific Parrotlet ", Age = 12, PictureName = sources[3], Description = "Pacific parrotlets are very cheerful, funny, intelligent, feisty, curious and cheeky little chaps. \n They’re becoming more and more popular as pets as their plumage is so colorful and you can even teach them tricks with enough patience. ", CategoryID = 1 },
                new { Id = 5, Name = "Canary", Age = 2, PictureName = sources[4], Description = "Canaries are known and loved for their lovely singing. Their yellow plumage is their trademark. \n But they can actually come in many different colors (see below)! It’s possible that two very famous characters \n have caused most people to think of canaries as yellow: cartoon bird Tweety Pie (that tomcat Silvester hunts) and Woodstock, Snoopy’s bird in Peanuts. ", CategoryID = 1 },
                new { Id = 6, Name = "Australian Retriever", Age = 10, PictureName = sources[5], Description = "The Australian Retriever is a mixed breed dog–a cross between the Australian Shepherd and Golden Retriever dog breeds. \n Loyal, intelligent, and friendly, these pups inherited some of the best traits from both of their parents. ", CategoryID = 2 },
                new { Id = 7, Name = "Beagle", Age = 3, PictureName = sources[6], Description = "Small, compact, and hardy, Beagles are active companions for kids and adults alike. \n Canines of this dog breed are merry and fun loving, but being hounds,  \n they can also be stubborn and require patient, creative training techniques. ", CategoryID = 2 },
                new { Id = 8, Name = "Collie", Age = 3, PictureName = sources[7], Description = "The Collie dog breed is a native of Scotland, mostly of the Highland regions but also bred in the Scottish Lowlands and northern England, \n where they were used primarily as a herding dog. They’re great family companions and are still capable herding dogs. ", CategoryID = 2 },
                new { Id = 9, Name = "American Curl", Age = 3, PictureName = sources[8], Description = "The distinctive feature of the American Curl is their attractive, uniquely curled-back ears. \n Elegant, well balanced, moderately muscled, slender rather than massive in build. \n  They often appear well proportioned and balanced and can vary in size. ", CategoryID = 3 },
                new { Id = 10, Name = "British Shorthair", Age = 6, PictureName = sources[9], Description = "The British Shorthair is a compact, well-balanced, and powerful cat, with a short, very dense coat. \n They often convey an overall impression of balance and proportion in which no feature is exaggerated. ", CategoryID = 3 }

            );

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Birds" },
                new { Id = 2, Name = "Dogs" },
                new { Id = 3, Name = "Cats" }
            );
            modelBuilder.Entity<Comment>().HasData(
               new { Id = 1, AnimalId = 1, Text = "Amazing, beautiful colors" },
               new { Id = 2, AnimalId = 1, Text = "The blue jay is between 9 and 12 inches in length. " },
               new { Id = 3, AnimalId = 1, Text = "The blue jay is very aggressive and territorial." },

               new { Id = 4, AnimalId = 2, Text = "Golden retrievers are playful" },
               new { Id = 5, AnimalId = 2, Text = "gentle with children" },
               new { Id = 6, AnimalId = 2, Text = "This breed likes to be active. " },
               new { Id = 7, AnimalId = 2, Text = "The dog's head is strong and broad." },

               new { Id = 8, AnimalId = 3, Text = "They have dog-like personalities." },
               new { Id = 9, AnimalId = 3, Text = "Ragdolls are quiet by nature." },

               new { Id = 10, AnimalId = 4, Text = "They live for about 20 years." },

               new { Id = 11, AnimalId = 5, Text = "The canaries are excellent at remembering." },
               new { Id = 12, AnimalId = 5, Text = "The canaries live to be 15 years old." },

               new { Id = 13, AnimalId = 6, Text = "Easy to train." },
               new { Id = 14, AnimalId = 6, Text = "Australian Retrievers are mixed breed dogs." },
               new { Id = 15, AnimalId = 6, Text = "The Australian Retriever is a large dog. " },

               new { Id = 16, AnimalId = 7, Text = "Beagles are excellent dogs for hunting rabbits and hares." },

               new { Id = 17, AnimalId = 8, Text = "They Are Extremely Smart Dogs." },
               new { Id = 18, AnimalId = 8, Text = "They Are Champion Herders." },

               new { Id = 19, AnimalId = 9, Text = "The American Curl is a lively cat." },

               new { Id = 20, AnimalId = 10, Text = "British Shorthairs can weigh more than the average cat. " },
               new { Id = 21, AnimalId = 10, Text = "British Shorthairs are known as one of the oldest cat breeds in the world." },
               new { Id = 22, AnimalId = 10, Text = "many people have noted that these cats do not feel fluffy, but instead feel plush." }
                );
        }
    }
}
