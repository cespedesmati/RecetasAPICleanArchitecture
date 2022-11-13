using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Recipe : AuditableBase
{
    [Key]
    public Guid idRecipe { get; set; } = Guid.NewGuid();
    public string nameRecipe { get; set; }
    public int score { get; set; }
    public Guid idUser { get; set; }

    [ForeignKey("idUser")]
    public User user { get; set; }
    public IList<Review>? reviews { get; set; } = new List<Review>();

    public IList<IngredientUsed>? ingredients { get; set; } = new List<IngredientUsed>();
    public IList<Step>? Steps { get; set; } = new List<Step>();

    public IList<Category>? categories { get; set; } = new List<Category>();
    public IList<Bookmark>? bookmarks { get; set; } = new List<Bookmark>();

}