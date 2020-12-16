using System;
using System.Collections.Generic;
using System.Text;
using Victory.Script.Entity.Enums;

namespace Victory.Script.Entity
{
   public static class DateTimeHelper
    {

        public static DateTime CodeTypeDate(CodeType type)
        {
            return type switch
            {
                CodeType.天卡 => DateTime.Now.AddDays(1),
                CodeType.月卡 => DateTime.Now.AddMonths(1),
                CodeType.季卡 => DateTime.Now.AddMonths(3),
                CodeType.年卡 => DateTime.Now.AddYears(1),
                CodeType.终身 => DateTime.Now.AddYears(10),
                _ => DateTime.Now,
            };

        }


    }
}
