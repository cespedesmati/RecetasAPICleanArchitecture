using Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Bookmark : AuditableBase
{
    public Guid idUser { get; set; }
    public Guid idRecipe { get; set; }

    [ForeignKey("idUser")]
    public User? user { get; set; }

    [ForeignKey("idRecipe")]
    public Recipe? recipe { get; set; }
}