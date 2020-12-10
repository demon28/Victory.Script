//DA  v1.1
//2020-7-31
//Near


using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Victory.Core.Extensions;
using Victory.Core.Models;
using Victory.Script.Entity.CodeGenerator;

namespace Victory.Script.DataAccess.CodeGenerator
{

    /// <summary>
    ///   项目表
    ///</summary>
    public class Tscript_Project_Da : FreeSql.BaseRepository<Tscript_Project>
    {

        public Tscript_Project_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

    }

}

