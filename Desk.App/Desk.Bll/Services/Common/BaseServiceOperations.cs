using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Desk.DAL.Context;
using Desk.Domain.Common;
using Desk.Domain.Dto.Common;
using Microsoft.EntityFrameworkCore;

namespace Desk.Bll.Services.Common
{
    public abstract class BaseServiceOperations<TEntity, TDto> 
        where TEntity : class, IEntity
        where TDto : class, IDto
    {
        public DeskContext Context { get; set; }

        public IMapper Mapper { get; set; }

        protected BaseServiceOperations(DeskContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task AddAsync(TDto dto)
        {
            await this.Context.AddAsync(this.Mapper.Map<TEntity>(dto));
        }

        public virtual async Task<TDto> GetAsync(int id)
        {
            var result = await this.Context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return this.Mapper.Map<TDto>(result);
        }

        public virtual async Task<List<TDto>> ListAsync()
        {
            return await this.Context.Set<TEntity>()
                .AsNoTracking()
                .Select(x => this.Mapper.Map<TDto>(x))
                .ToListAsync();
        }

        public virtual void UpdateAsync(TDto dto)
        {
             this.Context.Update(this.Mapper.Map<TEntity>(dto));
        }
    }
}
