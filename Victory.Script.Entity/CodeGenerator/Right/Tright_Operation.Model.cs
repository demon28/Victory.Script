//----------------
//DA  v1.1
//2020-7-31
//Near
//---------------

using FreeSql.DataAnnotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Victory.Script.Entity.CodeGenerator
{
    /// <summary>
    ///  
    ///</summary>
    public class Tright_Operation
    {

        public Tright_Operation()
        {

        }

        ///<summary>
        ///描述：主键
        ///</summary>
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        ///<summary>
        ///描述：编号
        ///</summary>
        public string Code { get; set; }
        ///<summary>
        ///描述：域
        ///</summary>
        public string Area { get; set; }
        ///<summary>
        ///描述：控制器
        ///</summary>
        public string Controller { get; set; }
        ///<summary>
        ///描述：行为
        ///</summary>
        public string Action { get; set; }
        ///<summary>
        ///描述：地址
        ///</summary>
        public string Url { get; set; }
        ///<summary>
        ///描述：排序id
        ///</summary>
        public int Sortid { get; set; }
        ///<summary>
        ///描述：状态{0：正常，1：禁用}
        ///</summary>
        public int Status { get; set; }
        ///<summary>
        ///描述：父id
        ///</summary>
        public int Parent_Id { get; set; }

        /// <summary>
        /// 操作类型{0：按钮类请求，1，页面跳转}
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }


        [Navigate(nameof(Parent_Id))]
        [JsonIgnore]
        public Tright_Operation Parent { get; set; }

        [Navigate(nameof(Parent_Id))]
        public List<Tright_Operation> Childs { get; set; }

    }
}








