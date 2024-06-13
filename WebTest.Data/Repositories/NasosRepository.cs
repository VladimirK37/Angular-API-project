using Microsoft.EntityFrameworkCore;
using WebTest.Data.Context;
using WebTest.Data.Entityes;

namespace WebTest.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class NasosRepository : BaseRepository<NasosEntity>
    {
        public NasosRepository(NasosDbContext context) : base(context) { }

        /// <summary>
        /// Получение всех насосов
        /// </summary>
        /// <returns></returns>
        public IQueryable<NasosEntity> GetAllNasos()
        {
            return DbContext.Nasoses.AsNoTracking().Include(p => p.MotorEntity)
                .Include(s => s.MaterialHull)
                .Include(m => m.ImpellerMaterial);
        }

        /// <summary>
        /// Добавить насос
        /// </summary>
        /// <param name="nasos"></param>
        /// <returns></returns>
        public NasosEntity CreateNasos(NasosEntity nasos)
        {
           return DbContext.Nasoses.Add(nasos).Entity;
        }

        /// <summary>
        /// Обновить насос
        /// </summary>
        /// <param name="nasos"></param>
        public void UpdateNasos(NasosEntity nasos)
        {
            DbContext.Nasoses.Update(nasos);
        }

        /// <summary>
        /// Удалить насос
        /// </summary>
        /// <param name="nasos"></param>
        public void DeleteNasos(NasosEntity nasos)
        {
            DbContext.Nasoses.Remove(nasos);
        }

        //public NasosEntity? GetNasosByGuid(Guid id)
        //{
        //    return DbContext.Nasoses.AsNoTracking().FirstOrDefault(n => n.Id == id);
        //}
    }
}
