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
            Mapper.CreateMap<Bookseller, BooksellerView>();

            //学院
            Mapper.CreateMap<School, SchoolView>();

            //系教研室
            Mapper.CreateMap<Department, DepartmentView>();

            //课程
            Mapper.CreateMap<Course, CourseView>()
                .ForMember(v => v.NumAndName, m => m.MapFrom(s => string.Format("{0}-{1}", s.Num, s.Name)));

            //教学任务
            Mapper.CreateMap<TeachingTask, TeachingTaskView>()
                .ForMember(v => v.TeacherName, m => m.MapFrom(s => s.Teacher.Name))
                .ForMember(v => v.DataSignName, m => m.MapFrom(s => s.DataSign.Name));

            //出版社
            Mapper.CreateMap<Press, PressView>();

            //教材
            Mapper.CreateMap<Textbook, TextbookView>()
                //.ForMember(v => v.IsSelfCompile, m => m.MapFrom(s => s.IsSelfCompile ? "是" : "否"))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Press))
                //.ForMember(v => v.PressAddress, m => m.MapFrom(s => s.Press.Address))
                .ForMember(v => v.Edition, m => m.MapFrom(s => string.Format("第{0}版", s.Edition)))
                .ForMember(v => v.PrintCount, m => m.MapFrom(s => string.Format("第{0}次印刷", s.PrintCount)));

            Mapper.CreateMap<Textbook, TextbookForDeclarationView>();

            Mapper.CreateMap<Textbook, TextbookForQueryView>()
                //.ForMember(v => v.Declarant, m => m.MapFrom(s => s.Declarant.Name))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Press));
                //.ForMember(v => v.IsSelfCompile, m => m.MapFrom(s => s.IsSelfCompile ? "是" : "否"));

            Mapper.CreateMap<Textbook, TextbookForReleaseView>();

            Mapper.CreateMap<Textbook, InventoryView>()
                .ForMember(v => v.InventoryId, m => m.UseValue("0"))
                .ForMember(v => v.ShelfNumber, m => m.UseValue("无"))
                .ForMember(v => v.Press, m => m.MapFrom(s => s.Press))
                .ForMember(v => v.InventoryCount, m => m.UseValue("0"));

            Mapper.CreateMap<TextbookView, Textbook>()
                .ForMember(m => m.ID, v => v.MapFrom(s => string.IsNullOrWhiteSpace(s.TextbookId) ? System.Guid.Empty : s.TextbookId.ConvertToGuid()))
                .ForMember(m => m.Edition, v => v.MapFrom(s => s.Edition.Substring(1, s.Edition.Length - 2).ConvertToInt()))
                //.ForMember(m => m.IsSelfCompile, v => v.MapFrom(s => s.IsSelfCompile.ConvertToBool()))
                //.ForMember(m => m.PageCount, v => v.MapFrom(s => s.PageCount.ConvertToInt()))
                .ForMember(m => m.Price, v => v.MapFrom(s => s.Price))
                .ForMember(m => m.PrintCount, v => v.MapFrom(s => s.PrintCount.Substring(1, s.PrintCount.Length - 4).ConvertToInt()))
                //.ForMember(m => m.PressId, v => v.MapFrom(s => s.PressId.ConvertToInt()))
                .ForMember(m => m.Press, v => v.Ignore());

            //.ForMember(m => m.PublishDate, v => v.MapFrom(s => s.PublishDate));

            //专业班级
            Mapper.CreateMap<ProfessionalClass, ProfessionalClassBaseView>();
            Mapper.CreateMap<ProfessionalClass, ProfessionalClassView>();


            //学生
            Mapper.CreateMap<Student, StudentView>()
                .ForMember(v => v.Gender, m => m.MapFrom(s => s.Gender));

            //申报
            Mapper.CreateMap<IEnumerable<ProfessionalClass>, string>().ConvertUsing<ProfessionalClassesConvert>();


            //Mapper.CreateMap<Declaration, DeclarationBaseView>()
            //    .ForMember(v => v.TeachingTaskNum, m => m.MapFrom(s => s.TeachingTask_Num))
            //    .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
            //    .ForMember(v => v.TextbookNum, m => m.MapFrom(s => s.Textbook.Num))
            //    .ForMember(v => v.TextbookName, m => m.MapFrom(s => s.NotNeedTextbook ? "不需要教材" : s.Textbook.Name))
            //    .ForMember(v => v.Declarant, m => m.MapFrom(s => s.Declarant.Name))
            //    .ForMember(v => v.ProfessionalClassName, m => m.MapFrom(s => s.TeachingTask.ProfessionalClasses));

            //Mapper.CreateMap<Declaration, DeclarationForTeachingTaskView>()
            //    .ForMember(v => v.TeachingTaskNum, m => m.MapFrom(s => s.TeachingTask_Num))
            //    .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
            //    .ForMember(v => v.TextbookNum, m => m.MapFrom(s => s.Textbook.Num))
            //    .ForMember(v => v.TextbookName, m => m.MapFrom(s => s.NotNeedTextbook ? "不需要教材" : s.Textbook.Name))
            //    .ForMember(v => v.Declarant, m => m.MapFrom(s => s.Declarant.Name))
            //    .ForMember(v => v.ProfessionalClassName, m => m.MapFrom(s => s.TeachingTask.ProfessionalClasses))
            //    .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Textbook.Isbn))
            //    .ForMember(v => v.Press, m => m.MapFrom(s => s.Textbook.Press.Name))
            //    .ForMember(v => v.Author, m => m.MapFrom(s => s.Textbook.Author))
            //    .ForMember(v => v.Price, m => m.MapFrom(s => s.Textbook.Price))
            //    .ForMember(v => v.Edition, m => m.MapFrom(s => s.Textbook.Edition))
            //    .ForMember(v => v.PrintCount, m => m.MapFrom(s => s.Textbook.PrintCount));


            //Mapper.CreateMap<Declaration, DeclarationForApprovalView>()
            //    //.ForMember(v => v.TeachingTaskNum, m => m.MapFrom(s => s.TeachingTask_Num))
            //    .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
            //    .ForMember(v => v.TextbookNum, m => m.MapFrom(s => s.Textbook.Num))
            //    .ForMember(v => v.TextbookName, m => m.MapFrom(s => s.NotNeedTextbook ? "不需要教材" : s.Textbook.Name))
            //    .ForMember(v => v.Declarant, m => m.MapFrom(s => s.Declarant.Name))
            //    .ForMember(v => v.ProfessionalClassName, m => m.MapFrom(s => s.TeachingTask.ProfessionalClasses))
            //    .ForMember(v => v.DataSignName, m => m.MapFrom(s => s.TeachingTask.DataSign.Name))
            //    .ForMember(v => v.CourseNum, m => m.MapFrom(s => s.TeachingTask.Course.Num))
            //    .ForMember(v => v.CourseName, m => m.MapFrom(s => s.TeachingTask.Course.Name));


            //Mapper.CreateMap<Declaration, DeclarationForQueryView>()
            //    //.ForMember(v => v.TeachingTaskNum, m => m.MapFrom(s => s.TeachingTask_Num))
            //    .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
            //    //.ForMember(v => v.TextbookNum, m => m.MapFrom(s => s.Textbook.Num))
            //    .ForMember(v => v.TextbookName, m => m.MapFrom(s => s.Textbook.Name));
            //    //.ForMember(v => v.Declarant, m => m.MapFrom(s => s.Declarant.Name))
            //    //.ForMember(v => v.ProfessionalClassName, m => m.MapFrom(s => s.TeachingTask.ProfessionalClasses));

            //Mapper.CreateMap<Declaration, DeclarationView>()
            //    //.ForMember(v => v.Declarant, m => m.MapFrom(s => s.Declarant.Name))
            //    .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id));

            //Mapper.CreateMap<DeclarationView, Declaration>()
            //    .ForMember(m => m.ID, v => v.MapFrom(s => s.DeclarationId.ConvertToGuid()));
            //.ForMember(m => m.Textbook_Id, v => v.MapFrom(s => s.TextbookId.ConvertToGuid()))
            //.ForMember(m => m.TeachingTask_Num, v => v.MapFrom(s => s.TeachingTaskNum))
            //.ForMember(m => m.ProfessionalClass_Id, v => v.MapFrom(s => s.ProfessionalClassId.ConvertToGuid()))
            //.ForMember(m => m.Teacher_Id, v => v.MapFrom(s => s.TeacherId.ConvertToGuid()))
            //.ForMember(m => m.RecipientType, v => v.MapFrom(s => System.Enum.Parse(typeof(RecipientType), s.RecipientType)))
            //.ForMember(m => m.DeclarationCount, v => v.MapFrom(s => s.DeclarationCount.ConvertToInt()))
            //.ForMember(m => m.DeclarationDate, v => v.MapFrom(s => System.DateTime.Parse(s.DeclarationDate)))
            //.ForMember(m => m.ApprovalState, v => v.MapFrom(s => System.Enum.Parse(typeof(ApprovalState), s.ApprovalState)))
            //.ForMember(m => m.HadViewFeedback, v => v.MapFrom(s => s.HadViewFeedback.ConvertToBool()));



            //学院申报进度
            Mapper.CreateMap<SchoolProgress, SchoolProgressView>()
                .ForMember(v => v.SchoolId, m => m.MapFrom(s => s.School.ID))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.School.Name));

            //系教研室申报进度
            Mapper.CreateMap<DepartmentProgress, DepartmentProgressView>()
                .ForMember(v => v.SchoolId, m => m.MapFrom(s => s.School.ID))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.School.Name))
                .ForMember(v => v.DepartmentId, m => m.MapFrom(s => s.Department.ID))
                .ForMember(v => v.DepartmentName, m => m.MapFrom(s => s.Department.Name))
                .ForMember(v => v.DataSignName, m => m.MapFrom(s => s.DataSign.Name))
                .ForMember(v => v.CourseNum, m => m.MapFrom(s => s.Course.Num))
                .ForMember(v => v.CourseName, m => m.MapFrom(s => s.Course.Name));

            //审核记录
            //Mapper.CreateMap<DeclarationApproval, ApprovalView>()
            //    .ForMember(v => v.Suggestion, m => m.MapFrom(s => s.Suggestion ? "同意" : "不同意"));
            //Mapper.CreateMap<TextbookApproval, ApprovalView>()
            //    .ForMember(v => v.Suggestion, m => m.MapFrom(s => s.Suggestion ? "同意" : "不同意"));
            Mapper.CreateMap<FeedbackApproval, ApprovalView>()
                .ForMember(v => v.Suggestion, m => m.MapFrom(s => s.Suggestion ? "同意" : "不同意"));

            //回告
            Mapper.CreateMap<Feedback, FeedbackView>()
                .ForMember(v => v.BooksellerName, m => m.MapFrom(s => s.Subscriptions.First().Bookseller.Name));

            Mapper.CreateMap<Feedback, FeedbackForApprovalView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook_Id))
                //.ForMember(v => v.TextbookNum, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook.Num))
                .ForMember(v => v.TextbookName, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook.Name))
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Subscriptions.FirstOrDefault().Textbook.Isbn))
                .ForMember(v => v.SubscriptionCount, m => m.MapFrom(s => s.Subscriptions.Sum(t => t.PlanCount + t.SpareCount)));

            //订单
            Mapper.CreateMap<Subscription, SubscriptionForSubmitView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
                //.ForMember(v => v.Num, m => m.MapFrom(s => s.Textbook.Num))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Textbook.Name))
                .ForMember(v => v.Isbn, m => m.MapFrom(s => s.Textbook.Isbn))
                .ForMember(v => v.DeclarationCount, m => m.MapFrom(s => s.PlanCount));

            Mapper.CreateMap<Subscription, SubscriptionForFeedbackView>()
                .ForMember(v => v.TextbookId, m => m.MapFrom(s => s.Textbook_Id))
                //.ForMember(v => v.Num, m => m.MapFrom(s => s.Textbook.Num))
                .ForMember(v => v.Name, m => m.MapFrom(s => s.Textbook.Name))
                .ForMember(v => v.DeclarationCount, m => m.MapFrom(s => s.PlanCount))
                .ForMember(v => v.TotalCount, m => m.MapFrom(s => s.PlanCount + s.SpareCount));

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
                .ForMember(m => m.Storage_Id, v => v.MapFrom(s => s.StorageId.ConvertToInt()));


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
        }
        #endregion

    }
}