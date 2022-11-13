using Domain;
using Domain.Interfaces;
using Infraestructure.Data;

namespace Infraestructure.Repositories;

public class BookMarkRepository : GenericRepository<Bookmark>, IBookMarkRepository { 
    public BookMarkRepository(DataContext dataContext) : base(dataContext)
    {
    }

}
