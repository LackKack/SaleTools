namespace SaleTools.Abstracts.Entities.Shared;

public interface IBaseEntity<T>
{
    public T Id { get; set; }
}