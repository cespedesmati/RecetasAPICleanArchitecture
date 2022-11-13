using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Ingredient : AuditableBase
{
    [Key]
    public Guid idIngredient { get; set; } = Guid.NewGuid();
    public string name { get; set; }
}
