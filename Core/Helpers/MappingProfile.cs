using AutoMapper;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries;
using SelectorExtensionForChrome.PopupModule.Infrastructure.ApiDto;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome.Core.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            /*CreateMap<GetAllControlTasks, TaskControlRequest>()
                .ForMember(to => to.to, from => from.MapFrom(m => $"{m.To.ToString("yyyy")}-{m.To.ToString("MM")}-{m.To.ToString("dd")}T00:00:00.000+03:00"))
                .ForMember(to => to.from, from => from.MapFrom(m => $"{m.From.ToString("yyyy")}-{m.From.ToString("MM")}-{m.From.ToString("dd")}T00:00:00.000+03:00"))
                .ForMember(to => to.createFrom, from => from.MapFrom(m => $"{m.CreateFrom.ToString("yyyy")}-{m.CreateFrom.ToString("MM")}-{m.CreateFrom.ToString("dd")}T00:00:00.000Z"))
                .ForMember(to => to.createTo, from => from.MapFrom(m => $"{m.CreateTo.ToString("yyyy")}-{m.CreateTo.ToString("MM")}-{m.CreateTo.ToString("dd")}T00:00:00.000Z"))
                .ForMember(to => to.token, from => from.MapFrom(m => m.Token))
                .ReverseMap();*/
            CreateMap<ControlTaskEntityResponse, SedTaskDTO>()
                .ForMember(to => to.Name, from => from.MapFrom(m => m.internalNumber))
                .ForMember(to => to.ExecutionDate, from => from.MapFrom(m => m.dateForExecution))
                .ForMember(to => to.Description, from => from.MapFrom(m => m.summaryOfDocument))
                .ForMember(to => to.Subject, from => from.MapFrom(m => m.commissionSubject))
                .ForMember(to => to.DocumentID, from => from.MapFrom(m => m.documentId))
                .ReverseMap();

        }
    }
}