﻿using System;
using System.Collections.Generic;
using System.Linq;

//添加引用
using TextbookManage.WebUI.SubscriptionService;

using Telerik.Web.UI;
using TextbookManage.WebUI.BooksellerService;

namespace TextbookManage.WebUI.SubscriptionPlan
{
    public partial class OrderByPress : USCTAMis.Web.WebControls.Page
    {

        #region 属性

        //获取用户信息
        //ProfileManger profile = new ProfileManger(HttpContext.Current.User.Identity.Name);
        //获取登录名
        //readonly string _loginName = HttpContext.Current.User.Identity.Name;

        //外国语学院院长，42018
        //教材科,hynhpgj
        //教务处，jwclsl

        #endregion

        #region 页面加载

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ccmbTerm.DoDataBind();
                //获取书商列表
                ccmbBookseller.DoDataBind();
            }
        }

        #endregion

        #region 学期

        protected void ccmbTerm_DataBinding(object sender, EventArgs e)
        {
            using (TermService.TermApplClient app = new TermService.TermApplClient())
            {
                var result = app.GetAllTerms();
                ccmbTerm.DataSource = result;
            }
        }

        protected void ccmbTerm_DataBound(object sender, EventArgs e)
        {
            ccmbPress.DoDataBind();
        }

        protected void ccmbTerm_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ccmbPress.DoDataBind();
        }
        #endregion

        #region 出版社

        protected void ccmbPress_BeforeDataBind(object sender, EventArgs e)
        {
            using (SubscriptionApplClient app = new SubscriptionApplClient())
            {
                var term = ccmbTerm.SelectedValue;
                ccmbPress.DataSource = app.GetPressWithNotSub(term);
            }
        }

        protected void ccmbPress_AfterDataBind(object sender, EventArgs e)
        {
            cgrdPlanSet.DoDataBind();
        }

        protected void ccmbPress_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cgrdPlanSet.DoDataBind();
        }

        #endregion

        #region 书商

        protected void ccmbBookseller_BeforeDataBind(object sender, EventArgs e)
        {
            using (BooksellerApplClient app = new BooksellerApplClient())
            {
                ccmbBookseller.DataSource = app.GetBooksellers();
            }
        }
        #endregion

        #region 订单

        /// <summary>
        /// 申报列表绑定前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdPlanSet_BeforeDataBind(object sender, EventArgs e)
        {
            //获取出版社
            string press = ccmbPress.SelectedValue;
            //取学期
            var term = ccmbTerm.SelectedValue;
            using (SubscriptionApplClient app = new SubscriptionApplClient())
            {
                //根据学院ID获取当前学年学期的未生成订单的申报列表
                cgrdPlanSet.DataSource = app.CreateSubscriptionsByPress(term, press);
            }

        }

        /// <summary>
        /// 全选或全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cchkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //处理复选框全选或不选
            USCTAMis.Web.WebControls.UTMisCheckBox chk = sender as USCTAMis.Web.WebControls.UTMisCheckBox;
            cgrdPlanSet.SetAllCheckControlState(chk.Checked);
        }

        /// <summary>
        /// 分页前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cgrdPlanSet_BeforePageIndexChanged(object sender, EventArgs e)
        {
            cgrdPlanSet.PersistCheckState<SubscriptionForSubmitView>();
        }

        #endregion

        #region 提交按钮

        /// <summary>
        /// 提交订单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbtnOrder_Click(object sender, EventArgs e)
        {
            //获取选中的征订计划ID列表
            cgrdPlanSet.PersistCheckState<SubscriptionForSubmitView>();

            IList<SubscriptionForSubmitView> views = cgrdPlanSet.GetAllCheckedDataList<SubscriptionForSubmitView>();

            if (views.Count() > 0)
            {
                //获取书商ID
                string booksellerId = ccmbBookseller.SelectedValue;

                //生成订单
                using (SubscriptionApplClient app = new SubscriptionApplClient())
                {
                    var result = app.SubmitSubscriptions(booksellerId, ctxtSpareCount.Text.Trim(), views.ToArray());

                    USCTAMis.Web.WebClient.ScriptManager.Alert(result.Message);
                }

            }
            else
            {
                USCTAMis.Web.WebClient.ScriptManager.Alert("请选择订单");
            }
        }

        protected void cbtnOrder_AfterClick(object sender, EventArgs e)
        {
            cgrdPlanSet.DoDataBind();
        }

        #endregion

    }
}