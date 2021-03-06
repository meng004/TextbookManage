﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextbookManage.WebUI.DeclarationProgressService;

namespace TextbookManage.WebUI.Declaration
{
    public partial class SchoolProgress : USCTAMis.Web.WebControls.Page
    {

        #region 属性与构造函数

        //获取登陆用户
        readonly string _loginName = HttpContext.Current.User.Identity.Name;
        //readonly string _loginName = "46010";
        //新华书店，dongxb
        //外国语教师，46010
        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl
        

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //首次加载
            if (!IsPostBack)
            {
                //根据用户的角色列表初始化页面显示                                
                ccmbDataSign.DoDataBind();
            }
        }

        #endregion

        #region 对外参数

        public string DataSignId
        {
            get
            {
                return ccmbDataSign.SelectedValue;
            }
        }

        public string SchoolId { set; get; }
        #endregion

        #region 数据标识

        protected void ccmbDataSign_BeforeDataBind(object sender, EventArgs e)
        {
            using (DeclarationProgressApplClient client = new DeclarationProgressApplClient())
            {
                ccmbDataSign.DataSource = client.GetDataSign();
            }
        }

        protected void ccmbDataSign_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }
        #endregion

        #region Ajax

        /// <summary>
        /// Ajax回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            string argument = e.Argument;
            switch (argument)
            {
                default:
                    cgrdDeclarationList.DoDataBind();
                    break;
            }
        }
        #endregion

        #region 查询按钮

        protected void cbtnQuery_Click(object sender, EventArgs e)
        {
            cgrdDeclarationList.DoDataBind();
        }
        #endregion

        #region 进度Grid

        protected void cgrdDeclarationList_BeforeDataBind(object sender, EventArgs e)
        {

            string dataSignId = ccmbDataSign.SelectedValue;
            using (DeclarationProgressApplClient client = new DeclarationProgressApplClient())
            {
                cgrdDeclarationList.DataSource = client.GetSchoolProgress(dataSignId);
            }
        }
        #endregion

        #region 进度颜色处理

        /// <summary>
        /// 完成绿色
        /// 进行中黄色
        /// 没开始红色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDeclarationList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is Telerik.Web.UI.GridDataItem)
            {
                Telerik.Web.UI.GridDataItem dataItem = e.Item as Telerik.Web.UI.GridDataItem;
                switch (dataItem["Proportion"].Text)
                {
                    case "100":
                        dataItem["Proportion"].BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "0":
                        dataItem["Proportion"].BackColor = System.Drawing.Color.Red;
                        break;
                    default:
                        dataItem["Proportion"].BackColor = System.Drawing.Color.Orange;
                        break;
                }
            }
        }
        #endregion

        #region 查看教研室进度

        /// <summary>
        /// grid按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdDeclarationList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.Item is Telerik.Web.UI.GridDataItem)
            {
                //对属性SchoolId赋值，用于跨页面传值
                Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
                SchoolId = item["SchoolId"].Text;                
            }
        }
        #endregion

    }
}