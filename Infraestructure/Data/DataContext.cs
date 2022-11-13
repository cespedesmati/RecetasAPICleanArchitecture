using Application.Services.Interfaces;
using Domain;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Shared.Helpers;

namespace Infraestructure.Data;

public class DataContext : DbContext
{
    private readonly ICurrentUserService currentUserService;
    private readonly IConfiguration configuration;
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options, ICurrentUserService currentUserService) : base(options)
    {
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        this.currentUserService = currentUserService;
    }

    public DbSet<Review> Reviews { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientUsed> ingredientsUsed { get; set; }
    public DbSet<Unit> Unit { get; set; }

    public ICurrentUserService CurrentUserService { get; }
  

    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(ConnectionString.GetConnectionString());
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookmark>()
            .HasKey(bc => new { bc.idUser, bc.idRecipe });
        modelBuilder.Entity<Bookmark>()
            .HasOne(bc => bc.user)
            .WithMany(b => b.bookmarks)
            .HasForeignKey(bc => bc.idUser)
            .OnDelete(DeleteBehavior.ClientSetNull);
        modelBuilder.Entity<Bookmark>()
            .HasOne(bc => bc.recipe)
            .WithMany(c => c.bookmarks)
            .HasForeignKey(bc => bc.idRecipe)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableBase();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableBase()
    {
        var currentTime = DateTimeOffset.UtcNow;
        foreach (var item in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added && e.Entity is AuditableBase))
        {
            var auditableEntity = item.Entity as AuditableBase;
            auditableEntity!.CreatedAt = currentTime;
            auditableEntity.CreatedBy = currentUserService.getNameCurrentUser();
            auditableEntity.ModifiedAt = currentTime;
            auditableEntity.ModifiedBy = currentUserService.getNameCurrentUser();
        }

        foreach (var item in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified && e.Entity is AuditableBase))
        {
            var auditableEntity = item.Entity as AuditableBase;
            auditableEntity!.ModifiedAt = currentTime;
            auditableEntity.ModifiedBy = currentUserService.getNameCurrentUser();
            item.Property(nameof(auditableEntity.CreatedAt)).IsModified = false;
            item.Property(nameof(auditableEntity.CreatedBy)).IsModified = false;
        }
    }

}

