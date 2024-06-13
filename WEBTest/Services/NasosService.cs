using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using WebTest.Data.Context;
using WebTest.Data.Entityes;
using WebTest.Data.Repositories;
using WEBTest.DTO;

namespace WEBTest.Services
{
    public class NasosService
    {
        private readonly NasosRepository _nasosRepositories;
        private readonly MotorRepository _motorRepositories;
        private readonly MaterialRepository _materialRepositories;

        private readonly NasosDbContext _db;
        public NasosService(NasosDbContext db,NasosRepository nasosRepositories, MotorRepository motorRepositories, MaterialRepository materialRepositories)
        {
            _nasosRepositories = nasosRepositories;
            _motorRepositories = motorRepositories;
            _materialRepositories = materialRepositories;
            _db = db;
        }
        
        /// <summary>
        /// Получение всех насосов
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<NasosDto>> GetAllNasosAsync()
        {
            var query =  _nasosRepositories.GetAllNasos().Select(x => new NasosDto
            {
                Id = x.Id,
                Name = x.Name,
                MaxPressure = x.MaxPressure,
                Temperature = x.Temperature,
                Weight = x.Weight,
                Description = x.Description,
                Picture = x.Picture,
                Price = x.Price,
                MotorEntity = x.MotorEntity,
                MaterialHull = x.MaterialHull,
                ImpellerMaterial = x.ImpellerMaterial
            });
            var result = await query.ToListAsync();

            return result;
        }

        /// <summary>
        /// Создание насоса
        /// </summary>
        /// <param name="nasosDto"></param>
        /// <exception cref="DataException"></exception>
        public async Task CreateNasosAsync(NasosRequestDto nasosDto)
        {
            var motorEntity = _motorRepositories.GetMotorByGuid(nasosDto.MotorId) ??
                throw new DataException("Отсутвует мотор");
            var impellerMaterilEntity = new MaterialEntity();
            var materialEntitylHull = new MaterialEntity();

            if (nasosDto.ImpellerMaterialId is null)
                impellerMaterilEntity = null;
            else
                impellerMaterilEntity = _materialRepositories.GetMaterialByGuid(nasosDto.ImpellerMaterialId) ??
                    throw new DataException("Отсутвует материал");
            if (nasosDto.ImpellerMaterialId is null)
                materialEntitylHull = null;
            else
                materialEntitylHull = _materialRepositories.GetMaterialByGuid(nasosDto.MaterialHullId) ??
                    throw new DataException("Отсутвует материал");

            var nasosEntity = new NasosEntity
            {
                Id = Guid.NewGuid(),
                Name = nasosDto.Name,
                MaxPressure = nasosDto.MaxPressure,
                Temperature = nasosDto.Temperature,
                Weight = nasosDto.Weight,
                Description = nasosDto.Description,
                Picture = nasosDto.Picture,
                Price = nasosDto.Price,
                MotorEntity = motorEntity,
                MaterialHull = materialEntitylHull,
                ImpellerMaterial = impellerMaterilEntity
            };
            motorEntity.Nasoses.Add( nasosEntity);
            if(!(impellerMaterilEntity is null))
                impellerMaterilEntity.BodyMaterialNasoses.Add(nasosEntity);
            if (!(materialEntitylHull is null))
                materialEntitylHull.ImpellerMaterialNasoses.Add(nasosEntity);
           _nasosRepositories.CreateNasos(nasosEntity);
            await _db.SaveChangesAsync();
        }

       /// <summary>
       /// Обновление значений насоса
       /// </summary>
       /// <param name="nasos"></param>
       /// <returns></returns>
        public async Task<NasosDto> UpdateNasosAsync(NasosDto nasos)
        {

            var nasosEntity = new NasosEntity
            {
                Id = nasos.Id,
                Name = nasos.Name,
                MaxPressure = nasos.MaxPressure,
                Temperature = nasos.Temperature,
                Weight = nasos.Weight,
                Description = nasos.Description,
                Price = nasos.Price,
                Picture = nasos.Picture,
                ImpellerMaterial = nasos.ImpellerMaterial,
                MaterialHull = nasos.MaterialHull,
                MotorEntity = nasos.MotorEntity,
            };

            _nasosRepositories.UpdateNasos(nasosEntity);
            await _db.SaveChangesAsync();
             
            return nasos;
        }

        /// <summary>
        /// Удаление насоса
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataException"></exception>
        public async Task DeleteNasosAsync(Guid id)
        {
            var nasosEntity = _db.Nasoses.Find(id) ??
                throw new DataException($"Отсутвует насос по этому идентификатору {id}");

            _nasosRepositories.DeleteNasos(nasosEntity);
            await _db.SaveChangesAsync();
        }
    }
}
