namespace Infrastructure.Data.Repositories.Generic;

public interface IGenericRepository<TEntity, TModel>
{
    Task<List<TModel>> GetAllAsync();

    Task<TModel?> GetByIdAsync(int id);

    Task<TModel> AddAsync(TModel modelType);

    Task<TModel> UpdateAsync(TModel modelType);

    Task DeleteByIdAsync(int id);
}
