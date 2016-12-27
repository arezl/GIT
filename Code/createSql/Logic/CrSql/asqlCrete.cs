using createSql.Model.CrSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic
{
    abstract class asqlCrete
    {
        //   void GetHeadSql();
        protected List<WordModel> wordList;
        abstract public string GetHeadSql();
        abstract public void createSqlWithOutOuter(ref bool isfirst, ref string aimSql, string column);
        abstract public void createSqlWithOuter(ref bool isfirst, ref string aimSql, string column);
        abstract public string GetEndSql();
        public static string AddDou(ref bool isfirst)
        {
            if (isfirst)
            {
                isfirst = false;
                return "";
            }
            return ",";
        }
        protected string Prejuge()
        {
            string SqlStr = "";
            List<WordModel> wordModels = wordList;
            foreach (var oneModel in wordModels)
            {
                if (CreSqlModel.AllDataType.Contains(oneModel.WordType))
                {
                    if (oneModel.WordType == "DateTime")
                    {
                        SqlStr += "if (string.IsNullOrWhiteSpace(" + oneModel.WordName + "))\n{ " + oneModel.WordName + "= \"NULL\";}else\n{\n"+
                          oneModel.WordName+ "=\"'\"+" + oneModel.WordName + "+\"'\"; \n}";


                        continue;
                    }

                    SqlStr += "if (string.IsNullOrWhiteSpace(" + oneModel.WordName + "))\n " + oneModel.WordName + "= \"0\";\n";

                }

            }

            return SqlStr;
        }

    }
}
