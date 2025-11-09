using AutoMapper;
using GameLibrary.Domain.DTOs;
using GameLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Business.Mapping
{
    public class GameMappingProfile : Profile
    {
        public GameMappingProfile()
        {
            CreateMap<Game, GameResponseDTO>().ForMember(dest => dest.Platform, opt => opt.MapFrom(src => src.Platform.ToString()));
            CreateMap<Game, GameResponseDTO>().ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.ToString()));
            CreateMap<Game, GameResponseDTO>().ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.Format.ToString()));
        }
    }
}
