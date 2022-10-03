using SEDC.Lamazon.DataAccess.DataContext;

namespace SEDC.Lamazon.DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
