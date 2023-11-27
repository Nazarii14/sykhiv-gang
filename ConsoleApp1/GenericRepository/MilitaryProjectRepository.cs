using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.GenerickRepository
{
    public class MilitaryProjectRepository<T> : IGenericRepository<T> where T : class
    {
        private MilitaryProjectContext context;
        private DbSet<T> table;
        public MilitaryProjectRepository()
        {
            context = new MilitaryProjectContext();
            table = context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await this.table.AddAsync(entity);
        }

        public IQueryable<T> GetQuaryable()
        {
            return this.table.AsQueryable<T>();
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public Task<List<T>> GetAll()
        {
            return table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
