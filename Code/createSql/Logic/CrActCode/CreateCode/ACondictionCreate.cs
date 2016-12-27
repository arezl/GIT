using createSql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode.CreateCode
{
    abstract class ACondictionCreate
    {
        abstract public string PreReplace(string OringStr);
        protected CreateActCode createActCode;
        public int Rate;
        public DatasDal m_DatasDal = new DatasDal();
    }
}
