using System;
using System.Collections.Generic;
using System.Text;
using static Victory.Script.Entity.Enums.CodeEnum;

namespace Victory.Script.Entity
{
   public static class DateTimeHelper
    {

        public static DateTime CodeTypeDate(CodeType type)
        {

            DateTime date;
            switch (type)
            {
                case CodeType.天卡:
                    date= DateTime.Now.AddDays(1);
                        break;
                case CodeType.月卡:
                    date = DateTime.Now.AddMonths(1);
                    break;
                case CodeType.季卡:
                    date = DateTime.Now.AddMonths(3);
                    break;
                case CodeType.年卡:
                    date = DateTime.Now.AddYears(1);
                    break;
                case CodeType.终身:
                    date = DateTime.Now.AddYears(10);
                    break;
                default:
                    date = DateTime.Now;
                    break;
            }

            return date;


        }


    }
}
