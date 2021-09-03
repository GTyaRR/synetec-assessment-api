using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories
{
    public class BaseRepository<TEntity> where TEntity : Entities.Base.Base
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> FindById(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }
    }
}
