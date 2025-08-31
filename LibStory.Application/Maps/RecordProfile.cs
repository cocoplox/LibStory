using AutoMapper;
using LibStory.Application.DTOs;
using LibStory.Domain.Models;
using System.Reflection.Metadata.Ecma335;

namespace LibStory.Application.Maps
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            CreateMap<Record, RecordDTO>()
                .ForMember(source => source.PageFrom, options => options.MapFrom(dest => dest.PageFrom));
        }
    }
}
