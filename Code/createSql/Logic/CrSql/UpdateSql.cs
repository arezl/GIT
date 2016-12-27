using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using createSql.Model.CrSql;

namespace createSql.Logic
{
    class UpdateSql : asqlCrete
    {
        private Form1 form1;

        public UpdateSql(List<WordModel> wordList)
        {
            this.wordList = wordList;
        }

        public override string GetEndSql()
        {
            string updateEndStr = File.ReadAllText(@"Resource\Update\updateEnd.txt");
            return updateEndStr;
        }

        public override string GetHeadSql()
        {
            //  string sqlcmd = "update [WX_Activity].[dbo].[act_info] set  ";
            string SqlStr = "";
            SqlStr += Prejuge();
            return SqlStr+= "\nstring sqlcmd=\"update [WX_Activity].[dbo].[act_info] set \";\n string set=\"\";\n ";
        }

        public override void createSqlWithOutOuter(ref bool isfirst, ref string aimSql, string column)
        {
            //  string value = "      if (actname != \"\") set += \" actname= \" + actname + \",\";\n";
            string value = "       set += \" actname= \" + actname + \",\";\n";
            string temp = Regex.Replace(value, @"\bactname\b", column);
            aimSql += temp;
            // aimSql += AddDou(ref isfirst) + "\"+" + column + "+\"";
        }
        public override void createSqlWithOuter(ref bool isfirst, ref string aimSql, string column)
        {
            //    string value = "      if (actname != \"\") set += \" actname= '\" + actname + \"',\";\n";
            string value = "       set += \" actname= '\" + actname + \"',\";\n";
            string temp = Regex.Replace(value, @"\bactname\b", column);
            aimSql += temp;
        }
    }
}
