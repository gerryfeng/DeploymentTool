using AutoMapper;
using System;
using System.Runtime.Serialization;
using Web.Models;

namespace Web.Profiles
{
    public class DayProfile : Profile
    {
        public DayProfile()
        {
            CreateMap<节假日信息表, DayItemDto>()
                .ForMember(
                    dest => dest.DateInfo, 
                    opt => opt.MapFrom(src => src.日期))
                .ForMember(
                    dest => dest.DateType, 
                    opt => opt.MapFrom(src => src.节假日类型))
                .ForMember(
                    dest => dest.IsHoliday, 
                    opt => opt.MapFrom(src => src.是否节假日))
                .ForMember(
                    dest => dest.Weekday, 
                    opt => opt.MapFrom(src => DayItemDto.GetWeekDay(src.日期)));

            CreateMap<DayItemDto, 节假日信息表>()
                .ForMember(
                    dest => dest.日期, 
                    opt => opt.MapFrom(src => src.DateInfo))
                .ForMember(
                    dest => dest.节假日类型, 
                    opt => opt.MapFrom(src => src.DateType.ToDescription()))
                .ForMember(
                    dest => dest.是否节假日, 
                    opt => opt.MapFrom(src => src.IsHoliday));
        }

        
    }
}
