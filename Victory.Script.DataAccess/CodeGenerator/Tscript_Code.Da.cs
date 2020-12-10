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

/// <summary>
///   激活码
///</summary>
{
    public class Tscript_Code_Da : FreeSql.BaseRepository<Tscript_Code>
    {

        public Tscript_Code_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

    }

}

