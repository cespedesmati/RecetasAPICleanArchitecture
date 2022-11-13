using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class IngredientUsed : AuditableBase
{
    [Key]
    public Guid idIngredientUsed { get; set; } = Guid.NewGuid();
    public string amount { get; set; }
    public Guid idUnit { get; set; }
    public Guid idIngredient { get; set; }
    public string comment { get; set; } = string.Empty;
    public Guid idRecipe { get; set; }

    [ForeignKey("idUnit")]
    public Unit unit { get; set; }

    [ForeignKey("idIngrediente")]
    public Ingredient ingredient { get; set; }

    [ForeignKey("idRecipe")]
    public Recipe recipe { get; set; }
}