using AutoMapper;
using Caco.API.Models;
using Caco.API.Resources;

namespace Supermarket.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveBoardResource, Board>();
            CreateMap<SaveColumnResource, Column>();
            CreateMap<SaveCardResource, Card>();
        }
    }
}