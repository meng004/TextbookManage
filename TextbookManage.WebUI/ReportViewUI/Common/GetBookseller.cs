using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPMis.WebPage.ReportViewsUI.Common
{
    public class GetBooksellers
    {
        CPMis.IBLL.Tb_Maintain.Tb_Maintain_3.IBooksellerBLL _booksellerBLL=new BLL.Tb_Maintain.Tb_Maintain_3.BooksellerBLL();
        IBLL.ReportViews.IBooksellerInfoBLL _booksellerInfoBLL = new BLL.ReportViews.BooksellerInfoBLL();
        public  IList<Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel> getBooksellerSource(CPMis.Web.WebClient.ProfileManger profileManager)
        {
            IList<Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel> list = new List<Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel>();
            //如果登录的是教务处角色用户
            if (profileManager.RoleName == CPMis.Common.ParameterList.ReportViews.Roles.ACADEMIC)
            {
                return _booksellerBLL.Fn_CheckBooksellerName();
            }
             //如果登录的书商角色用户
            else if(profileManager.RoleName==CPMis.Common.ParameterList.ReportViews.Roles.BOOKSELLER){
                Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel bookseller = new Model.Tb_Maintain.Tb_Maintain_3.BooksellerModel();
                bookseller.BooksellerID = profileManager.UserInGroupID;
                bookseller.BooksellerName = _booksellerInfoBLL.Fn_GetBooksellerInfo(bookseller.BooksellerID).BooksellerName;
                list.Add(bookseller);
            }
            return list;
        }
    }
}