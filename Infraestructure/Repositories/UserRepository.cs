using Domain;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DataContext dataContext;
    public UserRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<User> GetAllBookmarks(Guid idUser)
    {
        var entity = await dataContext.User
            .Where(x => x.idUser == idUser)
            .Include(x1 => x1.bookmarks)!
                .ThenInclude(y1 => y1.recipe)
            .FirstOrDefaultAsync();
        if (entity == null)
            throw new KeyNotFoundException();

        return entity;
    }

    public async Task<User> GetAllReviews(Guid idUser)
    {
        var entity = await dataContext.User
            .Where(x => x.idUser == idUser)
                .Include(x1 => x1.reviews)!
            .FirstOrDefaultAsync();

        if (entity == null)
            throw new KeyNotFoundException();

        return entity;
    }

    public async Task<User> GetByMail(string email)
    {
        var entity = await dataContext.User
            .Where(x => x.email == email.ToLower())
            .FirstOrDefaultAsync();
        return entity;
    }
}
