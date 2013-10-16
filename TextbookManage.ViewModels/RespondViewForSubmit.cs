using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TextbookManage.ViewModels
{
    [DataContract]
    public class RespondViewForSubmit:ResponseView
    {
        [DataMember]
        public int successCount { get; set; }
    }
}
