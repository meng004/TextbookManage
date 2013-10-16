using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;

namespace USCTAMis.WebPage.CommonControl
{
    public partial class Calendar : System.Web.UI.UserControl
    {
        private IBLL.Educational.ParameterSet.IEducationCalendar _calendarBLL =
            new BLL.Educational.ParameterSet.EducationCalendar();
        private IBLL.BaseInfo.ITerm _termBLL = new BLL.BaseInfo.Term();
        private DateTime _now = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wg_Calendar.DoDataBind();
                wg_Calendar.BackImageUrl = "../Images/Months/" + _now.Month + ".gif";
            }
        }

        /// <summary>
        /// 当前学年学期
        /// </summary>
        private string CurrentYearTerm
        {
            get
            {
                IList<Model.BaseInfo.TermModel>termList = _termBLL.Retrieve();
                foreach (Model.BaseInfo.TermModel term in termList)
                {
                    if (term.IsCurrentTerm)
                    {
                        return term.YearTerm;
                    }
                }
                return "2010-2011-1";
            }
        }
        protected void wg_Calendar_BeforeDataBind(object sender, EventArgs e)
        {
            wg_Calendar.DataSource = _calendarBLL.RetrieveWeekInfo(CurrentYearTerm, _now.Year.ToString(), _now.Month.ToString());
            //IList<string> tempList = new List<string>();
            //tempList.Add("test");
            //wg_Calendar.DataSource = tempList;
        }

        protected void wg_Calendar_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                string temUniqueName = string.Empty;
                switch (DateTime.Now.DayOfWeek.ToString("d"))
                {
                    case "0":
                        temUniqueName = "Sunday";
                        break;//星期日
                    case "1":
                        temUniqueName = "Monday";
                        break;//星期一
                    case "2":
                        temUniqueName = "Tuesday";
                        break;//星期二
                    case "3":
                        temUniqueName = "Wednesday";
                        break;//星期三
                    case "4":
                        temUniqueName = "Thursday";
                        break;//星期四
                    case "5":
                        temUniqueName = "Friday";
                        break;//星期五
                    case "6":
                        temUniqueName = "Saturday";
                        break;//星期六
                }
                string today = _now.Day.ToString();
                GridDataItem dataItem = e.Item as GridDataItem;
                if (dataItem[temUniqueName].Text.Trim() == today)
                {
                    dataItem[temUniqueName].ForeColor = System.Drawing.Color.Blue;
                }
            }
            //if (e.Item is GridDataItem)    //当前是不是GridDataItem
            //{
            //    GridDataItem dataItem = e.Item as GridDataItem;
            //    //查找控件
            //    USCTAMis.Web.WebControls.UTMisGrid wg_Week = 
            //        (USCTAMis.Web.WebControls.UTMisGrid)dataItem.FindControl("wg_WeekInfo");
            //    wg_Week.BackImageUrl = "../Img/Months/" + _now.Month + ".gif";
            //    wg_Week.ItemDataBound += new GridItemEventHandler(wg_Week_ItemDataBound);
            //    wg_Week.DataSource = _calendarBLL.RetrieveWeekInfo(CurrentYearTerm, _now.Year.ToString(), _now.Month.ToString());
            //    wg_Week.DataBind();
            //}
        }

        void wg_Week_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                string temUniqueName = string.Empty;
                switch (DateTime.Now.DayOfWeek.ToString("d"))
                {
                    case "0":
                        temUniqueName = "Sunday";
                        break;//星期日
                    case "1":
                        temUniqueName = "Monday";
                        break;//星期一
                    case "2":
                        temUniqueName = "Tuesday";
                        break;//星期二
                    case "3":
                        temUniqueName = "Wednesday";
                        break;//星期三
                    case "4":
                        temUniqueName = "Thursday";
                        break;//星期四
                    case "5":
                        temUniqueName = "Friday";
                        break;//星期五
                    case "6":
                        temUniqueName = "Saturday";
                        break;//星期六
                }
                string today = _now.Day.ToString();
                GridDataItem dataItem = e.Item as GridDataItem;
                if (dataItem[temUniqueName].Text.Trim() == today)
                {
                    dataItem[temUniqueName].ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
    }
}