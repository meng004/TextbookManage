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
using TextbookManage.Domain.IRepositories.JiaoWu;
using TextbookManage.Domain.Models.JiaoWu;


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

        public ResponseView Add(TextbookView textbook)
        {
            //类型转换
            var book = _adapter.Adapt<Textbook>(textbook);
            //创建教材ID
            book.TextbookId = Guid.NewGuid().ToString();
            var result = new ResponseView();

            try
            {
                _bookRepo.Add(book);
                _bookRepo.Context.Commit();
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
            //return new ResponseView();
            //取教材
            //var id = textbook.TextbookId.ConvertToGuid();
            //CUD仓储
            //var repo = ServiceLocator.Current.GetInstance<ITextbookRepository>();
            var bookModify = _bookRepo.First(t => t.TextbookId == textbook.TextbookId);
            //类型转换
            var book = _adapter.Adapt<Textbook>(textbook);
            //改教材
            bookModify.Author = book.Author;
            bookModify.Edition = book.Edition;
            bookModify.Isbn = book.Isbn;
            bookModify.IsSelfCompile = book.IsSelfCompile;
            bookModify.Name = book.Name;
           // bookModify.PageCount = book.PageCount;
           // bookModify.PressId = book.PressId;
            bookModify.Price = book.Price;
            bookModify.PrintCount = book.PrintCount;
            //bookModify.PublishDate = book.PublishDate;
            bookModify.TextbookType = book.TextbookType;


            var result = new ResponseView();

            try
            {
                _bookRepo.Modify(bookModify);
                _bookRepo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "修改图书失败";
                return result;
            }
        }

        public ResponseView Remove(IEnumerable<TextbookView> textbooks)
        {
            var result = new ResponseView();

            try
            {
                foreach (var item in textbooks)
                {
                    var book = _bookRepo.First(t => t.TextbookId == item.TextbookId);
                    
                   _bookRepo.Remove(book);
                }

                _bookRepo.Context.Commit();
                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "删除图书失败";
                return result;
            }
        }

        public TextbookView GetById(string textbookId)
        {
            //var id = textbookId.ConvertToGuid();
            var book = _bookRepo.First(t => t.TextbookId == textbookId);
            return _adapter.Adapt<TextbookView>(book);
        }

        public IEnumerable<TextbookView> GetByName(string textbookName, string isbn)
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

            return _adapter.Adapt<TextbookView>(books);
        }

        #endregion



    }
}
