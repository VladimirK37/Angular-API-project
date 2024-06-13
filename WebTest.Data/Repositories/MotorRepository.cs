using WebTest.Data.Context;
using WebTest.Data.Entityes;

namespace WebTest.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MotorRepository : BaseRepository<MotorEntity>
    {
        public MotorRepository(NasosDbContext context) : base(context) { }

        /// <summary>
        /// Получение всех моторов
        /// </summary>
        /// <returns></returns>
        public IQueryable<MotorEntity> GetAllMotors()
        {
            return DbContext.Motors;
        }

        /// <summary>
        /// Получение мотора по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MotorEntity? GetMotorByGuid(Guid id)
        {
            return DbContext.Motors.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Добавить мотор
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        public MotorEntity CreateMotor(MotorEntity motor)
        {
            return DbContext.Motors.Add(motor).Entity;
        }

        /// <summary>
        /// Обновление мотора
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        public MotorEntity UpdateMotor(MotorEntity motor)
        {
            return DbContext.Motors.Update(motor).Entity;
        }

        /// <summary>
        /// Удаление мотора
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        public MotorEntity DeleteMotor(MotorEntity motor)
        {
            return DbContext.Motors.Remove(motor).Entity;
        }
    }
}
