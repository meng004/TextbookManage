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

        #region Configure

        protected override void Configure()
        {
            //cas映射
            Mapper.CreateMap<CasMapper, CasMapperView>();
            Mapper.CreateMap<CasMapperView, CasMapper>()
                .ForMember(m => m.UserId, v => v.MapFrom(s => s.UserId.ConvertToGuid()));

            //数据标识
            Mapper.CreateMap<DataSign, DataSignView>();

            //学年学期 
            Mapper.CreateMap<Term, TermView>()
                .ForMember(v => v.IsCurrent, m => m.MapFrom(s => s.DqXnXqBz));

            //书商
            Mapper.CreateMap<Bookseller, BooksellerView>()
                .ForMember(v => v.BooksellerId, m => m.MapFrom(s => s.ID));

            //学院
            Mapper.CreateMap<School, SchoolView>()
                .ForMember(v => v.SchoolId, m => m.MapFrom(s => s.ID));

            //系教研室
            Mapper.CreateMap<Department, DepartmentView>()
                .ForMember(v => v.DepartmentId, m => m.MapFrom(s => s.ID));

            //课程
            Mapper.CreateMap<Course, CourseView>()
                .ForMember(v => v.CourseId, m => m.MapFrom(s => s.ID))
                .ForMember(v => v.NumAndName, m => m.MapFrom(s => string.Format("{0}-{1}", s.Num, s.Name)));

            //教学任务
            Mapper.CreateMap<TeachingTask, TeachingTaskView>()
                .ForMember(v => v.TeacherName, m => m.MapFrom(s => s.Teacher.Name))
                .ForMember(v => v.DataSignName, m => m.MapFrom(s => s.DataSign.Name));

            //出版社
            Mapper.CreateMap<Press, PressView>();

            //教材
            Mapper.CreateMap<Textbook, TextbookView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.ID));

            Mapper.CreateMap<Textbook, TextbookForDeclarationView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.ID));

            Mapper.CreateMap<Textbook, TextbookForQueryView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.ID));

            Mapper.CreateMap<Textbook, TextbookForReleaseView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.ID));

            Mapper.CreateMap<Textbook, InventoryView>()
                .ForMember(v => v.InventoryId, m => m.UseValue("0"))
                .ForMember(v => v.ShelfNumber, m => m.UseValue("无"))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Press))
                .ForMember(v => v.InventoryCount, m => m.UseValue("0"));

            Mapper.CreateMap<TextbookView, Textbook>()
                .ForMember(m => m.ID, v => v.MapFrom(s => string.IsNullOrWhiteSpace(s.TextbookId) ? System.Guid.Empty : s.TextbookId.ConvertToGuid()))
                .ForMember(m => m.Price, v => v.MapFrom(s => s.Price))
                .ForMember(m => m.Press, v => v.MapFrom(s => s.Press))
                .ForMember(m => m.PublishDate, v => v.MapFrom(s => s.PublishDate));

            //专业班级
            Mapper.CreateMap<ProfessionalClass, ProfessionalClassBaseView>()
                .ForMember(v => v.ProfessionalClassId, m => m.MapFrom(s => s.ID));
            Mapper.CreateMap<ProfessionalClass, ProfessionalClassView>()
                .ForMember(v => v.ProfessionalClassId, m => m.MapFrom(s => s.ID));

            //学生
            Mapper.CreateMap<Student, StudentView>()
                .ForMember(v => v.StudentId, m => m.MapFrom(s => s.ID));

            //申报
            Mapper.CreateMap<IEnumerable<ProfessionalClass>, string>()
                .ConvertUsing<ProfessionalClassesConvert>();

            //订单
            Mapper.CreateMap<Subscription, SubscriptionForSubmitView>()
                .ForMember(v => v.SubscriptionId, m => m.MapFrom(s => s.ID))
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Textbook.Name))
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Textbook.Isbn))
                .ForMember(v => v.DeclarationCount, m => m.MapFrom(s => s.PlanCount));

            Mapper.CreateMap<Subscription, SubscriptionForFeedbackView>()
                .ForMember(v => v.SubscriptionId, m => m.MapFrom(s => s.ID))
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Textbook.Name))
                .ForMember(v => v.DeclarationCount, m => m.MapFrom(s => s.PlanCount))
                .ForMember(v => v.TotalCount, m => m.MapFrom(s => s.PlanCount + s.SpareCount));

            //回告
            Mapper.CreateMap<BaseModel, FeedbackStateView>();

            Mapper.CreateMap<Feedback, FeedbackView>()
                .ForMember(v => v.FeedbackId, m => m.MapFrom(s => s.ID))
                .ForMember(v => v.BooksellerName, m => m.MapFrom(s => s.Subscriptions.First().Bookseller.Name));

            Mapper.CreateMap<Feedback, FeedbackForApprovalView>()
                .ForMember(v => v.FeedbackId, m => m.MapFrom(s => s.ID))
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook_Id))
                .ForMember(v => v.TextbookName, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook.Name))
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook.Isbn))
                .ForMember(v => v.SubscriptionCount, m => m.MapFrom(s => s.Subscriptions.Sum(t => t.PlanCount + t.SpareCount)));

            Mapper.CreateMap<FeedbackApproval, ApprovalView>()
                .ForMember(v => v.Suggestion, m => m.MapFrom(s => s.Suggestion ? "同意" : "不同意"));


            //仓库
            Mapper.CreateMap<Storage, StorageView>()
                .ForMember(v => v.BooksellerId, m => m.MapFrom(s => s.Bookseller_Id));

            Mapper.CreateMap<StorageView, Storage>()
                .ForMember(m => m.ID, v => v.MapFrom(s => s.StorageId.ConvertToGuid()))
                .ForMember(m => m.Bookseller_Id, v => v.MapFrom(s => s.BooksellerId.ConvertToGuid()));

            //库存
            Mapper.CreateMap<Inventory, InventoryView>()
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Textbook.Isbn))
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Textbook.Name))
                //.ForMember(v => v.Num, m => m.MapFrom(s => s.Textbook.Num))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Textbook.Press))
                .ForMember(v => v.Author, m => m.MapFrom(s => s.Textbook.Author))
                .ForMember(v => v.Price, m => m.MapFrom(s => s.Textbook.Price))
                .ForMember(v => v.Edition, m => m.MapFrom(s => s.Textbook.Edition))
                .ForMember(v => v.PrintCount, m => m.MapFrom(s => s.Textbook.PrintCount))
                .ForMember(v => v.StorageId, m => m.MapFrom(s => s.Storage_Id));


            Mapper.CreateMap<InventoryView, Inventory>()
                .ForMember(m => m.ID, v => v.MapFrom(s => s.InventoryId.ConvertToGuid()))
                .ForMember(m => m.Textbook_Id, v => v.MapFrom(s => s.TextbookId.ConvertToGuid()))
                .ForMember(m => m.Storage_Id, v => v.MapFrom(s => s.StorageId.ConvertToGuid()));


            Mapper.CreateMap<Inventory, InventoryForReleaseClassView>()
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Textbook.Isbn))
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Textbook.Name))
                //.ForMember(v => v.Num, m => m.MapFrom(s => s.Textbook.Num))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Textbook.Press))
                .ForMember(v => v.Author, m => m.MapFrom(s => s.Textbook.Author))
                .ForMember(v => v.Price, m => m.MapFrom(s => s.Textbook.Price))
                .ForMember(v => v.Discount, m => m.MapFrom(s => s.Textbook.Discount))
                .ForMember(v => v.DiscountPrice, m => m.MapFrom(s => s.Textbook.DiscountPrice))
                .ForMember(v => v.Edition, m => m.MapFrom(s => s.Textbook.Edition))
                .ForMember(v => v.PrintCount, m => m.MapFrom(s => s.Textbook.PrintCount))
                //.ForMember(v => v.PressAddress, m => m.MapFrom(s => s.Textbook.Press.Address))
                //.ForMember(v => v.PageCount, m => m.MapFrom(s => s.Textbook.PageCount))
                .ForMember(v => v.PublishDate, m => m.MapFrom(s => s.Textbook.PublishDate))
                .ForMember(v => v.TextbookType, m => m.MapFrom(s => s.Textbook.TextbookType))
                .ForMember(v => v.StorageId, m => m.MapFrom(s => s.Storage_Id));

            //入库记录
            Mapper.CreateMap<StockRecord, StockRecordView>()
                .ForMember(v => v.Author, m => m.MapFrom(s => s.Inventory.Textbook.Author))
                .ForMember(v => v.Edition, m => m.MapFrom(s => s.Inventory.Textbook.Edition))
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Inventory.Textbook.Isbn))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Inventory.Textbook.Press))
                .ForMember(v => v.Price, m => m.MapFrom(s => s.Inventory.Textbook.Price))
                .ForMember(v => v.PrintCount, m => m.MapFrom(s => s.Inventory.Textbook.PrintCount))
                .ForMember(v => v.ShelfNumber, m => m.MapFrom(s => s.Inventory.ShelfNumber))
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Inventory.Textbook_Id))
                //.ForMember(v => v.Num, m => m.MapFrom(s => s.Inventory.Textbook.Num))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Inventory.Textbook.Name))
                .ForMember(v => v.TextbookType, m => m.MapFrom(s => s.Inventory.Textbook.TextbookType));

            //班级教材退还查询

        }
        #endregion

    }
}