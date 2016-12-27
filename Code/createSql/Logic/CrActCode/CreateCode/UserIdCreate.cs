using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode.CreateCode
{
    class UserIdCreate : ACondictionCreate
    {


        public UserIdCreate(CreateActCode createActCode)
        {
            this.createActCode = createActCode;
            Rate = 0;
        }

        override public string PreReplace(string OringStr)
        {
            OringStr = OringStr.Replace(CreateActCode.UserIdStr, " ");
            return OringStr;
        }
    }
}
