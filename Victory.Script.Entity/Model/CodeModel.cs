using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.ExporterAndImporter.Core;

namespace Victory.Script.Entity.Model
{
    public class CodeModel
    {
        [ExporterHeader(DisplayName = "ID")]
        public int Id { get; set; }
        [ExporterHeader(DisplayName = "激活码")]
        public string Code { get; set; }

        [ExporterHeader(DisplayName = "项目名称")]
        public string ProjectName { get; set; }
        [ExporterHeader(DisplayName = "激活时间")]
        public DateTime Activation { get; set; }
        [ExporterHeader(DisplayName = "项目id")]
        public int Project_Id { get; set; }

        [ExporterHeader(DisplayName = "到期时间")]
        public DateTime Expiration { get; set; }
        [ExporterHeader(DisplayName = "状态")]
        public int Status { get; set; }
        [ExporterHeader(DisplayName = "类型")]
        public int Type { get; set; }
        [ExporterHeader(DisplayName = "创建时间")]
        public DateTime Createtime { get ; set; }


    }
}
