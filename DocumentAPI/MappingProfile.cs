using AutoMapper;
using DocumentAPI.Dto;
using DocumentAPI.Models;

namespace DocumentAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentForEditDto, Document>();
        }
    }
}
