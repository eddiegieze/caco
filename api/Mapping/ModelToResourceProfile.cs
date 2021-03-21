using AutoMapper;
using Caco.API.Models;
using Caco.API.Resources;

namespace Caco.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Board, BoardResource>();
        }
    }
}