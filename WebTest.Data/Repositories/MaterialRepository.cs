using WebTest.Data.Context;
using WebTest.Data.Entityes;

namespace WebTest.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MaterialRepository : BaseRepository<MaterialEntity>
    {
        public MaterialRepository( NasosDbContext context) : base( context)
        {
            
        }

        /// <summary>
        /// Получение всех материалов
        /// </summary>
        /// <returns></returns>
        public IQueryable<MaterialEntity> GetAllMaterials()
        {
            return DbContext.Materials;
        }

        /// <summary>
        /// Получение материала по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MaterialEntity? GetMaterialByGuid(Guid? id)
        {
            return DbContext.Materials.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Добавить материал
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public MaterialEntity CreateMaterial(MaterialEntity material)
        {
            return DbContext.Materials.Add(material).Entity;
        }

        /// <summary>
        /// Обновление материала
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public MaterialEntity UpdateMaterial(MaterialEntity material)
        {
            return DbContext.Materials.Update(material).Entity;
        }

        /// <summary>
        /// Удаление материала
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public MaterialEntity DeleteMaterial(MaterialEntity material)
        {
            return DbContext.Materials.Remove(material).Entity;
        }
    }
}
