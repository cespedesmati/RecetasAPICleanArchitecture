using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Review : AuditableBase
    {
        [Key]
        public Guid idReview { get; set; } = Guid.NewGuid();
        public string title { get; set; }
        public string description { get; set; }
        public int score { get; set; }

        public Guid? idUser { get; set; }

        [ForeignKey("idUser")]
        public User user { get; set; }

        public Guid idRecipe { get; set; }

        [ForeignKey("idRecipe")]
        public Recipe recipe { get; set; }
    }
}