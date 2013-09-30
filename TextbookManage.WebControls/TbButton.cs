using System;


namespace TextbookManage.WebControls
{
    public class TbButton : Telerik.Web.UI.RadButton
    {

        #region 单击

        protected override void OnClick(Telerik.Web.UI.ButtonClickEventArgs e)
        {
            if (BeforeClick != null)
            {
                BeforeClick(this, e);
            }
            base.OnClick(e);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 单击前事件
        /// </summary>
        public event EventHandler BeforeClick;

        #endregion

    }
}
