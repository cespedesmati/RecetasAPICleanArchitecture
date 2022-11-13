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

    public async Task<User> GetByMail(string email)
    {
        var entity = await dataContext.Set<User>().Where(x => x.email == email.ToLower()).FirstOrDefaultAsync();
        return entity;
    }
}
