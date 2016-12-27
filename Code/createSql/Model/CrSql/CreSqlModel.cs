using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Model.CrSql
{
    class CreSqlModel
    {
        static public List<string> AllDataType = new List<string>();
        static   CreSqlModel() {

            AllDataType.Add("Int");
            AllDataType.Add("Decimal");
            }

    }
}
