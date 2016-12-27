using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode.CreateCode
{
    class PageCreate : ACondictionCreate
    {


        public PageCreate(CreateActCode createActCode)
        {
            this.createActCode = createActCode;
            Rate = 2;

        }

        override public string PreReplace(string OringStr)
        {
            createActCode.Para = createActCode.ParaOrig + ",viewRows, pageNums";


            //  OringStr = OringStr.Replace(CreateActCode.UserIdStr, "");
            return OringStr;
        }
    }
}

