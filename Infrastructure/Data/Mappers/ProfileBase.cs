using AutoMapper;
using Infrastructure.Data.Entities.Abstractions;

namespace Infrastructure.Data.Mappers
{
    public abstract class ProfileBase<TModel, TEntity> : Profile
        where TEntity : EntityBase
    {
        protected ProfileBase()
        {
            CreateMap<TModel, TEntity>().ReverseMap();
        }
    }
}
