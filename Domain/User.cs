using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User : AuditableBase
{
    [Key]
    public Guid idUser { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public IList<Recipe>? recipes { get; set; }
    public IList<Review>? reviews { get; set; } = new List<Review>();
    public IList<Bookmark>? bookmarks { get; set; } = new List<Bookmark>();
}