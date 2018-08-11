using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TextbookManage.Domain.Models;
using TextbookManage.Domain.Models.JiaoWu;

namespace TextbookManage.Applications.AdapterProfile
{
    /// <summary>
    /// 班级列表，转为班级名称
    /// 如：1班，2班
    /// </summary>
    public class ProfessionalClassesConvert : ITypeConverter<IEnumerable<ProfessionalClass>, string>
    {

        public string Convert(IEnumerable<ProfessionalClass> source, string destination, ResolutionContext context)
        {
            var classes = source.ToList();
            if (!classes.Any()) return "班级列表为空";
            //
            var name = new StringBuilder();
            foreach (var item in classes)
            {
                name.Append(item.Name);
                name.Append(",");
            }
            //移除末尾的逗号，
            name.Remove(name.Length - 1, 1);

            return name.ToString();
        }
    }
}
