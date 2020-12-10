
using System;
using System.Collections.Generic;
using System.Linq;
using Victory.Script.Entity.CodeGenerator;
using FreeSql;
using Victory.Script.Entity.Model;

namespace Victory.Script.DataAccess.CodeGenerator
{

    /// <summary>
    ///  权限表
    ///</summary>
    public class Tright_Power_Da : FreeSql.BaseRepository<Tright_Power>
    {
        public Tright_Power_Da() : base(DataAccess.DbContext.Db, null, null)
        {


        }


        public List<Tright_Power> ListByOder()
        {

            return Select.ToTreeList();
        }
    }

}

