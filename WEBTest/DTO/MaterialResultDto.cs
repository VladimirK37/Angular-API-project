namespace WEBTest.DTO
{
    public class MaterialResultDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Guid { get; set; } = default!;

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = default!;


        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = default!;
    }
}
