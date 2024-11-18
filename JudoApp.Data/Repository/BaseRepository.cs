namespace JudoApp.Data.Repository
{
    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using JudoApp.Web.Data;

    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly JudoDbContext dbContext;
        private readonly DbSet<TType> dbSet;

        public BaseRepository(JudoDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TType>();
        }

        public TType GetById(TId id)
        {
            TType entity = dbSet
                .Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await dbSet
                .FindAsync(id);

            return entity;
        }

        public TType FirstOrDefault(Func<TType, bool> predicate)
        {
            TType entity = dbSet
                .FirstOrDefault(predicate);

            return entity;
        }

        public async Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
        {
            TType entity = await dbSet
                .FirstOrDefaultAsync(predicate);

            return entity;
        }

        public IEnumerable<TType> GetAll()
        {
            return dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await dbSet.ToArrayAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return dbSet.AsQueryable();
        }

        public void Add(TType item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public void AddRange(TType[] items)
        {
            dbSet.AddRange(items);
            dbContext.SaveChanges();
        }

        public async Task AddRangeAsync(TType[] items)
        {
            await dbSet.AddRangeAsync(items);
            await dbContext.SaveChangesAsync();
        }

        public bool Delete(TType entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TType entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public bool Update(TType item)
        {
            try
            {
                dbSet.Attach(item);
                dbContext.Entry(item).State = EntityState.Modified;
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                dbSet.Attach(item);
                dbContext.Entry(item).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
