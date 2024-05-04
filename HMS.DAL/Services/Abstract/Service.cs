using AutoMapper;
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
        protected readonly IMapper _mapper;
        public Repo<TEntity> _repo;
        protected Profile _profile = null;

        public Service(Repo<TEntity> repo)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping()
                   .CreateMap<TDto, TEntity>()
                   .ReverseMap();

                if (_profile != null)
                    cfg.AddProfile(_profile);
            });

            _mapper = config.CreateMapper();
            
            _repo = repo;
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

            IEnumerable<TDto> dtos = _mapper.Map<IEnumerable<TDto>>(entities);

            return dtos;
        }

        public int Update(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            return _repo.Update(entity);
        }
    }
}
