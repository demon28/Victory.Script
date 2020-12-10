using System;
using System.Collections.Generic;
using System.Text;

namespace Victory.Script.Entity
{
    public static class CreateCode
    {
        public static string Create()
        {

            return Guid.NewGuid().ToString("N");

        }

    }
}
