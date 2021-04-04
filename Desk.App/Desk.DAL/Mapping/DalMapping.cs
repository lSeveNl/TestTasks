using AutoMapper;
using Desk.DAL.Extensions;
using Desk.Domain.Auth;
using Desk.Domain.Dictionary.RequestModels;
using Desk.Domain.Dto;
using Desk.Domain.Dto.Request;
using Desk.Domain.Dto.User;
using Desk.Domain.Registration;

namespace Desk.DAL.Mapping
{
    public class DalMapping : Profile
    {
        public DalMapping()
        {
            this.MapDto();
            this.MapSummaryDto();
        }

        private void MapDto()
        {
            this.CreateMap<RequestDto, Request>();
            this.CreateMap<Request, RequestDto>();

            this.CreateMap<LogTableDto, LogTable>();
            this.CreateMap<LogTable, LogTableDto>();

            this.CreateMap<RequestTypeDto, RequestType>();
            this.CreateMap<RequestType, RequestTypeDto>();

            this.CreateMap<UserDto, User>();
            this.CreateMap<User, UserDto>()
                .ForMember(x => x.AuthRoleName,
                    o => o.MapFrom(z => z.AuthRole.GetDescription())); ;
        }

        private void MapSummaryDto()
        {

        }
    }
}
