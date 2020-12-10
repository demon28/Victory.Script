using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Victory.Core.Extensions;
using Victory.Core.Models;
using Victory.Script.DataAccess;
using Victory.Script.Entity.CodeGenerator;
using Victory.Script.Entity.Enums;

namespace Victory.Script.DataAccess.CodeGenerator
{



    /// <summary>
    ///  系统日志表
    ///</summary>
   

    /// <summary>
    ///  系统日志表
    ///</summary>
    public class Tsys_Log_Da : FreeSql.BaseRepository<Tsys_Log>
    {
        public Tsys_Log_Da() : base(DbContext.Db, null, null)
        {


        }


        public List<Tsys_Log> ListByWhere(string keyword, SysLogType type, DateTime? keybegindate, DateTime? keyenddate, ref PageModel page)
        {

            var data = this.Select;

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(s => s.Content.Contains(keyword));
            }

            if (type != SysLogType.全部)
            {
                data = data.Where(s => s.Type == (int)type);
            }

            if (keybegindate.HasValue)
            {
                data = data.Where(s => s.Createtime >= keybegindate);
            }

            if (keyenddate.HasValue)
            {
                data = data.Where(s => s.Createtime <= keyenddate);
            }

            page.TotalCount = data.Count().ToInt();

            var list = data.Page(page.PageIndex, page.PageSize)
              .OrderByDescending(s => s.Createtime)
              .ToList();

            return list;
        }

    }

}

