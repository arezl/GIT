using createSql.Logic.CrActCode.CreateCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode
{
    class OneCreate: CreateActCode
    {
        protected override string GetAimResutStr(string OringStr)
        {
            foreach (ACondictionCreate itemCrete in AllCondiction)
            {
                OringStr = itemCrete.PreReplace(OringStr);
            }

            return OringStr;
        }
    }
}
