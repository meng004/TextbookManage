namespace TextbookManage.Applications.AdapterProfile
{

    using AutoMapper;
    using TextbookManage.Domain.Models;
    using TextbookManage.Infrastructure;   


    /// <summary>
    /// AutoMapper配置文件
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<Book, BookView>()
            //    .ForMember(dto => dto.IsLent, m => m.MapFrom(s => s.IsLent ? "外借" : "在馆"));

            //教学任务 转 课程

  
        }
    }
}