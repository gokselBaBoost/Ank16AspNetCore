using AutoMapper;
using HMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Services.Abstract
{
    public interface IService<TDto> where TDto : BaseDto
    {
        IMapper Mapper { set; }
        int Add(TDto dto);
        int Update(TDto dto);
        int Delete(TDto dto);
        IEnumerable<TDto> GetAll();
        TDto? Get(int id);
    }
}
