using Domain;
using Domain.Interfaces;
using Infraestructure.Data;

namespace Infraestructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
