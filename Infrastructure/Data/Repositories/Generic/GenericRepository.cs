using AutoMapper;
using Infrastructure.Data.Abstractions;
using Infrastructure.Data.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Generic;

internal class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity, TModel> where TEntity : EntityBase
{
    protected readonly CustomerDbContext _context;

    protected readonly IMapper _mapper;

    public GenericRepository(CustomerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TModel>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();

        return _mapper.Map<List<TModel>>(entities);
    }

    public async Task<TModel?> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);

        return _mapper.Map<TModel>(entity);
    }

    public async Task<TModel> AddAsync(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);

        _context.Set<TEntity>().Add(entity);

        await _context.SaveChangesAsync();

        return _mapper.Map<TModel>(entity);
    }

    public async Task<TModel> UpdateAsync(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);

        _context.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return model;
    }

    public async Task DeleteByIdAsync(int id)
    {
        TEntity? entity = await _context.Set<TEntity>().FindAsync(id);

        if (entity is not null)
        {
            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
