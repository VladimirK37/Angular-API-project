using WebTest.Data.Context;

namespace WebTest.Data.Repositories
{
    public class BaseRepository<TEntityClass> where TEntityClass : class
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected NasosDbContext DbContext { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dbContext"></param>
        protected BaseRepository(NasosDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Получить все entity
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntityClass> GetAll()
        {
            return DbContext.Set<TEntityClass>();
        }
    }
}
