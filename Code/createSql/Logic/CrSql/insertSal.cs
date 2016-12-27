using createSql.Model;
using createSql.Model.CrSql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic
{
    class insertSal : asqlCrete
    {
        

        public insertSal(List<WordModel> wordList)
        {
            this.wordList = wordList;
        }

        public override string GetHeadSql()
        {
         
            string SqlStr = @" dt = new DataTable();
            string ret = "" ;
             
";
            SqlStr += Prejuge(  );
            return SqlStr + " string dbcmd = \"insert into [WX_Activity].[dbo].[act_info](" + PublicInfo.TalbeModel.ParaStr + ")Values(";
        }

       

        public override void createSqlWithOutOuter(ref bool isfirst, ref string aimSql, string column)
        {
            aimSql += AddDou(ref isfirst) + "\"+" + column + "+\"";
        }
        public override void createSqlWithOuter(ref bool isfirst, ref string aimSql, string column)
        {
            aimSql += AddDou(ref isfirst) + "'\"+" + column + "+\"'";
        }
        public override string GetEndSql()
        {
            string updateEndStr = " )\";\n"+ @"     int num = 0;
            ret = sqldb.executeUpdate(dbcmd, out num);
   if (num != 1)
            {
              "+"  return \" 修改失败\";"+@"
            }
        ";
            return updateEndStr;
        }
    }
}
