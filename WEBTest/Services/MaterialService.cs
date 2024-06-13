using Microsoft.EntityFrameworkCore;
using System.Data;
using WebTest.Data.Context;
using WebTest.Data.Entityes;
using WebTest.Data.Repositories;
using WEBTest.DTO;

namespace WEBTest.Services
{
    public class MaterialService
    {
        private readonly MaterialRepository _materilRepositories;
        private readonly NasosDbContext _db;

        public MaterialService(NasosDbContext db,MaterialRepository materialRepositories)
        {
            _materilRepositories = materialRepositories;
            _db = db;
        }

        /// <summary>
        /// Получение всех материалов
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MaterialResultDto>> GetAllMaterialsAsync()
        {
            var query = _materilRepositories.GetAllMaterials().Select(x => new MaterialResultDto
            {
                Guid = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
            var result = await query.ToListAsync();

            return result;
        }

        /// <summary>
        /// Создание мотора
        /// </summary>
        /// <param name="materialDto"></param>
        public async Task CreateMaterialAsync(MaterialResultDto materialDto)
        {
            var materialEntity = new MaterialEntity
            {
                Id = Guid.NewGuid(),
                Name = materialDto.Name,
                Description = materialDto.Description,
            };
            _materilRepositories.CreateMaterial(materialEntity);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Обновление материала
        /// </summary>
        /// <param name="materialDto"></param>
        /// <returns></returns>
        public async Task<MaterialResultDto> UpdateMaterialAsync(MaterialResultDto materialDto)
        {
            var materialEntity = new MaterialEntity
            {
                Id = materialDto.Guid,
                Name = materialDto.Name,
                Description = materialDto.Description,
            };
            _materilRepositories.UpdateMaterial(materialEntity);
            await _db.SaveChangesAsync();

            return materialDto;
        }

        /// <summary>
        /// Удаление материала
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataException"></exception>
        public async Task DeleteMaterialAsync(Guid id)
        {
            var motor = _db.Materials.Find(id) ??
                throw new DataException($"Отсутвует материал по этому идентификатору {id}");

            _materilRepositories.DeleteMaterial(motor);
            await _db.SaveChangesAsync();
        }
    }
}
