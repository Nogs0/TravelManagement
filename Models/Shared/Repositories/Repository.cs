
using Microsoft.EntityFrameworkCore;
using TravelManagement.Database;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Models.Shared.Repository
{
    public class Repository<Model, PKType> : IRepository<Model, PKType>
        where Model : AuditedEntity<PKType>
        where PKType : struct
    {

        private readonly TravelManagementDbContext _context;
        private readonly DbSet<Model> _dbSet;

        public Repository(TravelManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Model>();
        }

        public async Task<Model> CreateAsync(Model entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            var saved = _dbSet.OrderBy(x => x.Id).Last();
            if (saved == null)
                throw new Exception("Entity is null!");

            return saved;
        }
        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }

        public IQueryable<Model> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted);
        }

        public async Task<Model> GetAsync(PKType id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("Entity not found!");
        }

        public async Task<PKType> CreateAndGetIdAsync(Model entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            var saved = _dbSet.OrderBy(x => x.Id).Last();
            if (saved == null)
                throw new Exception("Entity is null!");

            return saved.Id;
        }

        public async Task<Model> UpdateAsync(Model entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return await GetAsync(entity.Id);
        }

        public async Task<PKType> UpdateAndGetIdAsync(Model entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            var saved = await GetAsync(entity.Id);
            if (saved == null)
                throw new Exception("Entity is null!");

            return  saved.Id;
        }
        public async Task DeleteAsync(PKType id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
