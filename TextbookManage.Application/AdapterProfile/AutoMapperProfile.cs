namespace TextbookManage.Applications.AdapterProfile
{

    using AutoMapper;
    using System.Linq;
    using TextbookManage.Domain.Models;
    using TextbookManage.ViewModels;
    using TextbookManage.Infrastructure;
    using System.Collections.Generic;
    using TextbookManage.Domain.Models.JiaoWu;


    /// <summary>
    /// AutoMapper配置文件
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CasMapper, CasMapperView>();
            CreateMap<CasMapperView, CasMapper>()
                .ForMember(m => m.UserId, v => v.MapFrom(s => s.UserId.ConvertToGuid()));

            
            //学年学期 
            CreateMap<Term, TermView>()
                .ForMember(v => v.IsCurrent, m => m.MapFrom(s => s.DqXnXqBz));

            //书商
            CreateMap<Bookseller, BooksellerView>()
                .ForMember(v => v.BooksellerId, m => m.MapFrom(s => s.ID));

            //学院
            CreateMap<School, SchoolView>()
                .ForMember(v => v.SchoolId, m => m.MapFrom(s => s.ID));

            //系教研室
            CreateMap<Department, DepartmentView>()
                .ForMember(v => v.DepartmentId, m => m.MapFrom(s => s.ID));
            

            //教材
            CreateMap<Textbook, TextbookView>()
                .ForMember(v => v.IsSelfCompile, m => m.MapFrom(s => s.IsSelfCompile == "1" ? true : false));
            //.ForMember(v => v.TextbookId, m => m.MapFrom(s => s.TextbookId))
            //.ForMember(v => v.Price, m => m.MapFrom(s => s.Price.ConvertToDecimal()))
            //.ForMember(v => v.PublishDate, m => m.MapFrom(s => s.PublishDate.ConvertToDateTime()));

           CreateMap<TextbookView, Textbook>()
                //.ForMember(m => m.ID, v => v.MapFrom(s => string.IsNullOrWhiteSpace(s.TextbookId) ? System.Guid.Empty : s.TextbookId.ConvertToGuid()))
                .ForMember(m => m.Price, v => v.MapFrom(s => s.Price.ConvertToDecimal()))
                .ForMember(m => m.IsSelfCompile, v => v.MapFrom(s => s.IsSelfCompile ? "1" : "0"));
            //.ForMember(m => m.Press, v => v.MapFrom(s => s.Press))
            //.ForMember(m => m.PublishDate, v => v.MapFrom(s => s.PublishDate));

            //专业班级
            CreateMap<ProfessionalClass, ProfessionalClassBaseView>()
                .ForMember(v => v.ProfessionalClassId, m => m.MapFrom(s => s.ID));
            CreateMap<ProfessionalClass, ProfessionalClassView>()
                .ForMember(v => v.ProfessionalClassId, m => m.MapFrom(s => s.ID));

            //学生
            CreateMap<Student, StudentView>()
                .ForMember(v => v.StudentId, m => m.MapFrom(s => s.ID));

           
        }




    }
}