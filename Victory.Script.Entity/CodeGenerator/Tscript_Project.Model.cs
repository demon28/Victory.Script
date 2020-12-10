//----------------
//DA  v1.1
//2020-7-31
//Near
//---------------

using FreeSql.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Victory.Script.Entity.CodeGenerator
{
    /// <summary>
    ///  项目表
    ///</summary>
    public class   Tscript_Project
    {

       public Tscript_Project()
       {
      
       }

        ///<summary>
        ///描述：
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public DateTime Createtime { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public string Remark { get; set; }

    }
 }








