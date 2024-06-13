namespace WEBTest.DTO
{
    public class MaterialDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Guid { get; set; } = default!;

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = default!;
    }
}
