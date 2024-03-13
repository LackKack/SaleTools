namespace SaleTools.Abstracts.Interfaces;

public interface IPostIntegrateServices
{
    Task<T> InitService<T>();
    
}