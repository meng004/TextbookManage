using System;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Domain
{
    public class TextbookService
    {

        /// <summary>
        /// 创建教材
        /// </summary>
        /// <returns></returns>
        //public static Textbook CreateTextbook(Textbook book, TbmisUser user)
        //{
        //    var b = new Textbook
        //    {
        //        //初始值
        //        ApprovalState = ApprovalState.学院审核中,
        //        Author = book.Author,
        //        DeclarationDate = DateTime.Now,
        //        Edition = book.Edition,
        //        Isbn = book.Isbn,
        //        IsSelfCompile = book.IsSelfCompile,
        //        Name = book.Name,
        //        PageCount = book.PageCount,
        //        PressId = book.PressId,
        //        Price = book.Price,
        //        PrintCount = book.PrintCount,
        //        PublishDate = book.PublishDate,
        //        TeacherId = user.TbmisUserId,
        //        TextbookId = System.Guid.NewGuid(),
        //        TextbookType = book.TextbookType
        //    };
        //    //修改审核状态
        //    if (user.IsInRole("学院院长"))
        //    {
        //        b.ApprovalState = ApprovalState.教材科审核中;
        //    }
        //    else if (user.IsInRole("教材科")||user.IsInRole("教务处"))
        //    {
        //        b.ApprovalState = ApprovalState.终审通过;
        //    }

        //    return b;
        //}
    }
}
