using createSql.Model.CrSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrWhere
{
    class ClassCreate : AbstrCodeByTable
    {
        public override string intDeal(WordModel item)
        {
            string aimStr = " public int name { get; set; }\n";
            resultStr += aimStr.Replace("name", item.WordName);
            return "";
        }
        
        public override string DecimalDeal(WordModel item)
        {
            string aimStr = " public decimal name { get; set; }\n";
            resultStr += aimStr.Replace("name", item.WordName);
            return "";
        }

        public override string TimeSpanDeal(WordModel item)
        {
            string aimStr = " public TimeSpan name { get; set; }\n";
            resultStr += aimStr.Replace("name", item.WordName);
            return "";
        }

        public override string DateTimeDeal(WordModel item)
        {
            string aimStr = " public DateTime name { get; set; }\n";
            resultStr += aimStr.Replace("name", item.WordName);
            return "";
        }
        public override string StringSpanDeal(WordModel item) {

            string aimStr = " public  string name { get; set; }\n";
            resultStr += aimStr.Replace("name", item.WordName);
            return "";
        }
    }
}
