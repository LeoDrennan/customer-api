namespace Infrastructure.Data.Entities.Abstractions;

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
