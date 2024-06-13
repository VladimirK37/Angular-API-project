using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebTest.Data.Context;
using WebTest.Data.Entityes;
using WebTest.Data.Repositories;
using WEBTest.DTO;

namespace WEBTest.Services
{
    public class MotorService
    {
        private readonly MotorRepository _motorsRepositories;
        private readonly NasosDbContext _db;

        public MotorService(NasosDbContext db, MotorRepository motorsRepositories)
        {
            _motorsRepositories = motorsRepositories;
            _db = db;
        }

        /// <summary>
        /// Получение всех моторов
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MotorResultDto>> GetAllMotorAsync()
        {
            var query =  _motorsRepositories.GetAllMotors().Select(x => new MotorResultDto
            {
                Guid = x.Id,
                Name = x.Name,
                Description = x.Description,
                Current = x.Current,
                Motor = x.Motor,
                Power = x.Power,
                NominalSpeed = x.NominalSpeed,
                Price = x.Price,
            });
            var result = await query.ToListAsync();
            return result;
        }


        /// <summary>
        /// Создание мотора
        /// </summary>
        /// <param name="motorDto"></param>
        public async Task<MotorResultDto> CreateMotorAsync(MotorResultDto motorDto)
        {
            var motorEntity = new MotorEntity
            {
                Id = Guid.NewGuid(),
                Name = motorDto.Name,
                Power = motorDto.Power,
                Current = motorDto.Current,
                NominalSpeed = motorDto.NominalSpeed,
                Motor = motorDto.Motor,
                Description = motorDto.Description,
                Price = motorDto.Price,
            };
            _motorsRepositories.CreateMotor(motorEntity);
            await _db.SaveChangesAsync();

            return motorDto;
        }

        /// <summary>
        /// Обновление мотора
        /// </summary>
        /// <param name="motorDto"></param>
        /// <returns></returns>
        public async Task<MotorResultDto> UpdateMotorAsync(MotorResultDto motorDto)
        {
            var motorEntity = new MotorEntity
            {
                Id = motorDto.Guid,
                Name = motorDto.Name,
                Power = motorDto.Power,
                Current = motorDto.Current,
                NominalSpeed = motorDto.NominalSpeed,
                Motor = motorDto.Motor,
                Description = motorDto.Description,
                Price = motorDto.Price,
            };
            _motorsRepositories.UpdateMotor(motorEntity);
            await _db.SaveChangesAsync();

            return motorDto;
        }

        /// <summary>
        /// Удаление мотора
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataException"></exception>
        public async Task DeleteMotorAsync(Guid id)
        {
            var motor = _db.Motors.Find(id) ??
                throw new DataException($"Отсутвует мотор по этому идентификатору {id}");

            _motorsRepositories.DeleteMotor(motor);
            await _db.SaveChangesAsync();
        }
    }
}