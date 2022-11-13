using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Category : AuditableBase
{
	[Key]
	public Guid idCategory { get; set; } = Guid.NewGuid();
	public string name { get; set; }
	public IList<Recipe>? recipesCategory { get; set; } = new List<Recipe>();
}

