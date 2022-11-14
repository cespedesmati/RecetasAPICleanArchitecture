using Domain.SeedWork;

namespace Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByMail(string email);
    Task<User> GetAllBookmarks(Guid idUser);
    Task<User> GetAllReviews(Guid idUser);
}
