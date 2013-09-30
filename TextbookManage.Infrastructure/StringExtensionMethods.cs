namespace TextbookManage.Infrastructure
{

    using System.Text.RegularExpressions;
    
    public static class StringExtensionMethods
    {
        /// <summary>
        /// 字符串转换为整型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ConvertToInt(this string str)
        {
            int result = 0;
            int.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为布尔
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ConvertToBool(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            bool rtnValue = false;

            rtnValue = bool.TryParse(str, out rtnValue) ? rtnValue : Regex.IsMatch(str, "^(?i:true|yes|y|1|ok|是|同意|通过|外借|已归还)$");

            return rtnValue;
        }

        /// <summary>
        /// 字符串转换为数值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(this string str)
        {
            decimal result = 0;
            decimal.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// 字符串转GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static System.Guid ConvertToGuid(this string str)
        {
            System.Guid result = System.Guid.Empty;
            System.Guid.TryParse(str, out result);
            return result;
        }

    }
}
