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
    ///  激活码
    ///</summary>
    public class   Tscript_Code
    {

       public Tscript_Code()
       {
      
       }

        ///<summary>
        ///描述：
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：激活码
        ///</summary>
        public string Code { get; set; }
        ///<summary>
        ///描述：状态{0:未使用，1，已使用}
        ///</summary>
        public string Status { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public int Project_Id { get; set; }
        ///<summary>
        ///描述：
        ///</summary>
        public DateTime Createtime { get; set; }
        ///<summary>
        ///描述：客户手机码
        ///</summary>
        public string Device { get; set; }
        ///<summary>
        ///描述：到期时间
        ///</summary>
        public DateTime Expiration { get; set; }
        ///<summary>
        ///描述：激活时间
        ///</summary>
        public DateTime Activation  { get; set; }
        ///<summary>
        ///描述：激活码类型{0:终生,1:月卡，2：季卡，3：年卡}
        ///</summary>
        public int Type { get; set; }
        ///<summary>
        ///描述：代理商，1为系统
        ///</summary>
        public int Agent { get; set; }

    }
 }








