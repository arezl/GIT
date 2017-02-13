using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using createSql.Logic.CrWhere;
using createSql.Model;
using createSql.Model.CrSql;

namespace createSql.Logic.CrSql
{
    class CreatClass
    {
        internal void CreateClass(AbstrCodeByTable createClass,List<WordModel> modes)
        {
            foreach (WordModel item in PublicInfo.AllColumnModes)
            {
                if (item.WordType.IndexOf("Int")>-1)
                {
                    createClass.intDeal(item);
                }
                if (item.WordType.IndexOf("Decimal") > -1)
                {
                    createClass.DecimalDeal(item);
                }
                if (item.WordType.IndexOf("DateTime") > -1)
                {
                    string ret = createClass.DateTimeDeal(item);
                }
                if (item.WordType.IndexOf("TimeSpan") > -1)
                {
               string ret=     createClass.TimeSpanDeal(item);
                }
                if (item.WordType.IndexOf("String") > -1)
                {
                    string ret = createClass.StringSpanDeal(item);
                }
            }
            createClass.FinalDeal(null);
        }
    }
}
