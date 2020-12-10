
using System;
using System.Collections.Generic;
using System.Linq;
using Victory.Script.Entity.CodeGenerator;
using FreeSql;
using Victory.Script.Entity.Model;
using Victory.Script.Entity.Enums;

namespace Victory.Script.DataAccess.CodeGenerator
{

    /// <summary>
    ///   
    ///</summary>
    public class Tright_Menu_Da : FreeSql.BaseRepository<Tright_Menu>
    {

        public Tright_Menu_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }

        /// <summary>
        /// ��ȡ���в˵�
        /// </summary>
        /// <returns></returns>
        public List<Tright_Menu> ListByTree()
        {
            return Select.OrderBy(s => s.Sortid).ToTreeList();
        }

        /// <summary>
        /// �����û� ��ӦȨ�� ȥ��ȡ�˵�
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Tright_Menu> ListByLogin(int userid)
        {

            string sql = @"  SELECT
   DISTINCT tm.Id ,
    tm.Menu_Name,
    tm.Menu_Url,
    tm.Parent_Id,
    tm.Status,
    tm.Icon,
    tm.SortId
   
    FROM  Vright_UserRole vur
    
    LEFT JOIN Tright_Role_Power trp ON vur.Roleid=trp.Role_Id
    LEFT JOIN Tright_Power tp ON tp.Id=trp.Power_Id
    LEFT JOIN Tright_Power_Menu tpm ON tpm.Power_Id=tp.Id
    LEFT JOIN Tright_Menu tm ON tm.Id=tpm.Menu_Id
    WHERE   tm.Status=0  and  vur.userid=@userid 
   
";
            return this.Select.WithSql(sql, new { userid = userid }).OrderBy(s => s.Sortid).ToTreeList();


        }

    }

}

