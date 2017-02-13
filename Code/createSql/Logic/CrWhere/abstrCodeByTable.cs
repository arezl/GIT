using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using createSql.Model.CrSql;

namespace createSql.Logic.CrWhere
{
    abstract class AbstrCodeByTable
    {
        public string HeadStr = "";
        public string EndStr = "";
        public string resultStr = "";
        abstract public string intDeal(WordModel item);

        abstract public string DecimalDeal(WordModel item);

        abstract public string TimeSpanDeal(WordModel item);


        abstract public string DateTimeDeal(WordModel item);

        abstract public string StringSpanDeal(WordModel item);
         public string FinalDeal(WordModel item) {

            return resultStr = HeadStr + resultStr + EndStr;
        }
    }
}
