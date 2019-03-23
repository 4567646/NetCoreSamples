using NetCoreDemo.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDemo.Core.Domain.Sys
{
    public class Sys_Role : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
        public DateTime AddTime { get; set; }
    }
}
