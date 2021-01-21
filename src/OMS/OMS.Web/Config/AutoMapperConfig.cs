using AutoMapper;
using OMS.ApplicationCore;
using OMS.Infrastructure;

namespace OMS.Web
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            ////GoodsEntity转GoodsDto.
            //CreateMap<GoodsEntity, GoodsDto>()
            //    //映射发生之前
            //    .BeforeMap((source, dto) => {
            //        //可以较为精确的控制输出数据格式
            //        dto.CreateTime = Convert.ToDateTime(source.CreateTime).ToString("yyyy-MM-dd");
            //    })
            //    //映射发生之后
            //    .AfterMap((source, dto) => {
            //        //code ...
            //    });

            ////GoodsDto转GoodsEntity.
            //CreateMap<GoodsDto, GoodsEntity>();


            //!string.IsNullOrEmpty(dt.Rows[i]["主管人"].ToString()) && item.userID == dt.Rows[i]["主管人"].ToString()
            //控制器中使用：_mapper.Map<GoodsDto>(goods);

            CreateMap<Flow_Users, UserItem>()
                .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.名称))
                .ForMember(dest => dest.userID, opt => opt.MapFrom(src => src.用户id))
                .ForMember(dest => dest.loginName, opt => opt.MapFrom(src => src.工号))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.coordinate, opt => opt.MapFrom(src => src.Coordinate))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src.Phone));
        }
    }
}
