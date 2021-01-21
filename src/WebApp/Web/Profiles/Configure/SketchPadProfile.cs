using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure;

namespace Web.Profiles.Configure
{

    /// <summary>
    /// 画板bolb 转字符串
    /// </summary>
    public class SketchPadProfile : Profile
    {
        public SketchPadProfile()
        {
            //Entity 转dto
            CreateMap<Sketchpad, SketchPadDTO>()
            //.ForMember(dest => dest.Json, opt => opt.MapFrom(s => Encoding.UTF8.GetString(s.Json)))
            .ReverseMap();
        }

    }
}
