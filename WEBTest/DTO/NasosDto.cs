using WebTest.Data.Entityes;

namespace WEBTest.DTO
{
    public class NasosDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Максимальное давление
        /// </summary>
        public double MaxPressure { get; set; }

        /// <summary>
        /// Температура жидкости
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        ///  Изображение
        /// </summary>
        public string Picture { get; set; } = default!;

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Мотор
        /// </summary>
        public MotorEntity MotorEntity { get; set; } = default!;

        /// <summary>
        /// Материал корпуса
        /// </summary>
        public MaterialEntity MaterialHull { get; set; } = default!;

        /// <summary>
        /// Материал рабочего колеса
        /// </summary>
        public MaterialEntity ImpellerMaterial { get; set; } = default!;
    }
}
