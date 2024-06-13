namespace WebTest.Data.Entityes;
/// <summary>
/// Материал
/// </summary>
public class MaterialEntity
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
    /// Описание
    /// </summary>
    public string Description { get; set; } = default!;

    public virtual List<NasosEntity> BodyMaterialNasoses { get; set; } = new List<NasosEntity>();
    public virtual List<NasosEntity> ImpellerMaterialNasoses { get; set; } = new List<NasosEntity>();
}