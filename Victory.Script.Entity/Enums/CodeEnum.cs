using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.Script.Entity.Enums
{
   public class CodeEnum
    {

       public enum CodeType
        {
                天卡=0,
                月卡=1,
                季卡=2,
                年卡=3,
                终身=4,
        }

        public enum CodeStatus
        {
            未激活 = 0,
            已激活=1
        }
    }
}
