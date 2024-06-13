namespace WEBTest.DTO
{
    public class MotorResultDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Мощность
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Ток
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// Номинальная скорость
        /// </summary>
        public int NominalSpeed { get; set; }

        /// <summary>
        /// Мотор
        /// </summary>
        public string Motor { get; set; } = default!;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }
}



