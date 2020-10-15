namespace WebStore.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
