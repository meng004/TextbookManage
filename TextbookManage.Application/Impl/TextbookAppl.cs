using System;
using System.Collections.Generic;
using System.Linq;
using TextbookManage.IApplications;
using TextbookManage.ViewModels;
using TextbookManage.Domain.IRepositories;
using TextbookManage.Infrastructure;
using TextbookManage.Infrastructure.ServiceLocators;
using TextbookManage.Infrastructure.TypeAdapter;
using TextbookManage.Domain.Models;


namespace TextbookManage.Applications.Impl
{
    public class TextbookAppl : ITextbookAppl
    {

        #region 私有变量

        private readonly ITypeAdapter _adapter;//= ServiceLocator.Current.GetInstance<ITypeAdapter>();
        private readonly ITextbookRepository _bookRepo;// = ServiceLocator.Current.GetInstance<ITextbookRepository>();
        private readonly IPressRepository _pressRepo;

        #endregion

        #region 构造函数

        public TextbookAppl(
            ITypeAdapter adapter,
            ITextbookRepository bookRepo,
            IPressRepository pressRepo
            )
        {
            _adapter = adapter;
            _bookRepo = bookRepo;
            _pressRepo = pressRepo;
        }
        #endregion

        #region 实现接口

        public IEnumerable<PressView> GetPresses()
        {
            var presses = _pressRepo.GetAll();

            presses = presses.OrderBy(t => t.Name);

            return _adapter.Adapt<PressView>(presses);
        }

        public ResponseView Add(TextbookView textbook, string loginName)
        {
            if (string.IsNullOrWhiteSpace(loginName))
            {
                return new ResponseView { IsSuccess = false, Message = "用户名不能为空" };
            }

            //取用户
            var user = new TbmisUserAppl(loginName).GetUser();

            //类型转换
            var book = _adapter.Adapt<Textbook>(textbook);

            //创建教材
            var bookAdd = Domain.TextbookService.CreateTextbook(book, user);

            var repo = ServiceLocator.Current.GetInstance<ITextbookRepository>();
            var result = new ResponseView();

            try
            {
                repo.Add(bookAdd);
                repo.Context.Commit();
                return result;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "新增图书失败";
                return result;
            }
        }

        public ResponseView Modify(TextbookView textbook)
        {
            //取教材
            var id = textbook.TextbookId.ConvertToGuid();
            //CUD仓储
            var repo = ServiceLocator.Current.GetInstance<ITextbookRepository>();
            var bookModify = repo.First(t => t.TextbookId == id);
            //类型转换
            var book = _adapter.Adapt<Textbook>(textbook);
            //改教材
            bookModify.Author = book.Author;
            bookModify.Edition = book.Edition;
            bookModify.Isbn = book.Isbn;
            bookModify.IsSelfCompile = book.IsSelfCompile;
            bookModify.Name = book.Name;
            bookModify.PageCount = book.PageCount;
            bookModify.PressId = book.PressId;
            bookModify.Price = book.Price;
            bookModify.PrintCount = book.PrintCount;
            bookModify.PublishDate = book.PublishDate;
            bookModify.TextbookType = book.TextbookType;

            var result = new ResponseView();

            try
            {
                repo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "修改图书失败";
                return result;
            }
        }

        public ResponseView Remove(IEnumerable<TextbookForQueryView> textbooks)
        {

            var repo = ServiceLocator.Current.GetInstance<ITextbookRepository>();
            var result = new ResponseView();

            var books = _adapter.Adapt<Textbook>(textbooks);

            try
            {
                foreach (var item in books)
                {
                    repo.Remove(item);
                }

                repo.Context.Commit();
                return result;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.Message = "删除图书失败";
                return result;
            }
        }

        public TextbookView GetById(string textbookId)
        {
            var id = textbookId.ConvertToGuid();
            var book = _bookRepo.First(t => t.TextbookId == id);
            return _adapter.Adapt<TextbookView>(book);
        }

        public IEnumerable<TextbookForQueryView> GetByName(string textbookName, string isbn)
        {
            IEnumerable<Textbook> books = new List<Textbook>();

            if (string.IsNullOrWhiteSpace(textbookName))
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    //无数据返回   
                }
                else
                {
                    books = _bookRepo.Find(t => t.Isbn.Contains(isbn));
                }
            }
            else
            {
                books = _bookRepo.Find(t => t.Name.Contains(textbookName));
            }

            books = books.OrderBy(t => t.Name);

            return _adapter.Adapt<TextbookForQueryView>(books);
        }

        public IEnumerable<TextbookForQueryView> GetByLoginName(string loginName)
        {
            //取用户
            var userId = new TbmisUserAppl(loginName).GetUser().TbmisUserId;
            //取教材
            var books = _bookRepo.Find(t =>
                t.TeacherId == userId
                ).OrderBy(t =>
                    t.Num
                    );
            return _adapter.Adapt<TextbookForQueryView>(books);
        }

        #endregion



    }
}
