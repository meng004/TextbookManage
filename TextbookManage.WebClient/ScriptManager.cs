using System;
using System.Text;
using System.Web;
using System.Web.UI;

namespace TextbookManage.WebClient
{
    /// <summary>
    /// Javascript��ش���
    /// </summary>
    public static class ScriptManager
    {

        #region ����

        /// <summary>
        /// Script��Key��
        /// </summary>
        private static string ScriptKeyName
        {
            get
            {
                unchecked
                {
                    registerScriptKeyIndex = ++registerScriptKeyIndex;
                }
                return string.Format("WebUtilityScriptManager{0}",
                    registerScriptKeyIndex);
            }
        }

        /// <summary>
        /// RegisterStartupScript
        /// </summary>
        private static double registerScriptKeyIndex = int.MinValue;
        #endregion

        #region ִ��

        /// <summary>
        /// ִ��js�ű�
        /// </summary>
        /// <param name="scriptKey">RegisterStartupScript��Key</param>
        /// <param name="jsScript">Javascript�ű�</param>
        public static void ExecuteJs(string scriptKey, string jsScript)
        {
            string js = String.Format("<script language=\"javascript\">{0}</script>", jsScript);

            if (scriptKey == null)
            {
                //ע��ű�key
                scriptKey = ScriptKeyName;
            }
            Page page = (HttpContext.Current.Handler as Page);
            Telerik.Web.UI.RadScriptManager.RegisterStartupScript(page, page.GetType(), scriptKey, js, false);
        }

        /// <summary>
        /// ִ��js�ű�
        /// </summary>
        /// <param name="jsScript">Javascript�ű�</param>
        public static void ExecuteJs(string jsScript)
        {
            ExecuteJs(null, jsScript);
        }
        #endregion

        #region Alert

        /// <summary>
        /// ִ��js Alert��֧�ֱ�׼������
        /// </summary>
        /// <param name="msg"></param>
        public static void TopAlert(string msg)
        {
            string js = string.Format("top.FloatingFrame.alert(\"{0}\");",
                CleanJsString(ref msg));
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��Alert,��ˢ��ҳ�棬֧�ֱ�׼������
        /// </summary>
        /// <param name="msg"></param>
        public static void TopAlertAndRefresh(string msg)
        {
            string js = string.Format("top.FloatingFrame.alert(\"{0}\");window.location.href=window.location.href;",
                CleanJsString(ref msg));
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��js Alert����ת��ָ��ҳ��[֧�ֱ�׼������]
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url">ת���ַ</param>
        public static void TopAlert(string msg, string url)
        {
            string js = string.Format("top.FloatingFrame.alert(\"{0}\");window.location='{1}';",
                CleanJsString(ref msg), url);
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��js�AAlert
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        public static void Alert(string msg)
        {
            string js = string.Format("alert(\"{0}\");",
                CleanJsString(ref msg));
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��js Alert����ת��ָ��ҳ��[֧�ֱ�׼������]
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url">ת���ַ</param>
        public static void TopAlertAndJump(string msg, string url)
        {
            string js = string.Format("top.FloatingFrame.alert(\"{0}\");window.top.location.href='{1}';",
                CleanJsString(ref msg), url);
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��js�AAlert��ת��ָ��ҳ��
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        /// <param name="url">ת���ַ[��"~"��ͷ]</param>
        public static void AlertAndRedirect(string msg, string url)
        {
            string js = string.Format("alert(\"{0}\");window.location='{1}';",
                CleanJsString(ref msg),
                (HttpContext.Current.Handler as Page).ResolveUrl(url));
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��js�AAlert���رյ�ǰҳ��
        /// </summary>
        /// <param name="msg">Alert��Ϣ</param>
        public static void AlertAndClose(string msg)
        {
            string js = string.Format("alert(\"{0}\");window.close();",
                CleanJsString(ref msg));
            ExecuteJs(js);
        }

        /// <summary>
        /// ִ��js�AConfirm��ת��ָ��ҳ�歱
        /// </summary>
        /// <param name="msg">��Ϣ</param>
        /// <param name="url">ת���ַ[��"~"��ͷ]</param>
        public static void ConfirmAndRedirect(string msg, string url)
        {
            string js = string.Format("if (confirm(\"{0}\")){window.location='{1}';}",
                CleanJsString(ref msg),
                (HttpContext.Current.Handler as Page).ResolveUrl(url));
            ExecuteJs(js);
        }

        /// <summary>
        /// ���js�в��Ϸ��Ĵ���
        /// </summary>
        /// <param name="str"></param>
        public static string CleanJsString(ref string str)
        {
            str = str.Replace("'", "\'").Replace("\"", "\\\"");
            return str;
        }
        #endregion

        #region OpenWindow

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="_pathBuilder"></param>
        /// <param name="_webPageHeight"></param>
        /// <param name="_webPageWidth"></param>
        public static void OpenWindow(string _pathBuilder, int _webPageHeight, int _webPageWidth)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("window.open('");
            sBuilder.Append(_pathBuilder);
            sBuilder.Append("','' , '");
            sBuilder.Append("height=");
            sBuilder.Append(_webPageHeight);
            sBuilder.Append(",width=");
            sBuilder.Append(_webPageWidth);
            sBuilder.Append(",top='+(window.screen.availHeight-30-");
            sBuilder.Append(_webPageHeight);
            sBuilder.Append(")/2 +'");
            sBuilder.Append(",left='+(window.screen.availWidth-20-");
            sBuilder.Append(_webPageWidth);
            sBuilder.Append(")/2+',scrollbars=yes,toolbar=no,location=no,status=no,resizable=yes,directories=no,titlebar=no");
            sBuilder.Append("')");
            ExecuteJs(sBuilder.ToString());
        }

        /// <summary>
        /// Rad����
        /// </summary>
        /// <param name="pathBuilder"></param>
        /// <param name="radWindowName"></param>
        public static void OpenRadWindow(string pathBuilder, string radWindowName)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("window.radopen('");
            sBuilder.Append(pathBuilder);
            sBuilder.Append("', '");
            sBuilder.Append(radWindowName);
            sBuilder.Append("')");
            ExecuteJs(sBuilder.ToString());
        }

        #endregion
       
    }
}