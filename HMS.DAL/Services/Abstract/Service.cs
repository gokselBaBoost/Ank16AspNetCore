using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Execution;
using AutoMapper.Extensions.ExpressionMapping;
using HMS.DAL.Repositories.Abstract;
using HMS.DAL.Repositories.Concrete;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Services.Abstract
{
    public abstract class Service<TEntity, TDto> : IService<TDto> 
        where TEntity : BaseEntity
        where TDto : BaseDto

    {
        protected IMapper _mapper;
        public Repo<TEntity> _repo;

        public Service(Repo<TEntity> repo)
        {

            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.CreateMap<TDto, TEntity>().ReverseMap();
            });

            _mapper = _config.CreateMapper();
            
            _repo = repo;
        }

        public IMapper Mapper 
        { 
            set { _mapper = value; } 
        }

        public int Add(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            return _repo.Add(entity);
        }

        public int Delete(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            return _repo.Delete(entity);
        }

        public TDto? Get(int id)
        {
            TEntity? entity = _repo.Get(id);

            TDto? dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            IEnumerable<TEntity> entities = _repo.GetAll();

            IEnumerable<TDto> dtos = _mapper.Map<IEnumerable<TDto>>(entities.ToList());

            return dtos;
        }

        public int Update(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            return _repo.Update(entity);
        }
    }
}
