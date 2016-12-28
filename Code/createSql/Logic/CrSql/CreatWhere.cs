using createSql.Model;
using createSql.Model.CrSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace createSql.Logic.CrSql
{
    class CreatWhere
    {
        internal string CreateSql(DataTable dt,out string paraStr,out string PureStr)
        {
            string modelStr = "";
            PureStr = "";
            paraStr = "";
            int colIndex = 0;
            string Equalcode = " if (!string.IsNullOrWhiteSpace(SignUpTime)) \n ";
            Equalcode += "   {";
            Equalcode += "   whereStr += \" and SignUpTime ='\" + SignUpTime.Trim() + \"'\";\n";
            Equalcode += "    } \n  ";
            string Likecode = " if (!string.IsNullOrWhiteSpace(SignUpTime)) \n ";
            Likecode += "   {";
            Likecode += "   whereStr += \" and SignUpTime like '%\" + SignUpTime + \"%'\";\n";
            Likecode += "    } \n  ";
            string Roundcode = " if (!string.IsNullOrWhiteSpace(min_SignUpTime)) \n ";
            Roundcode += "   {";
            Roundcode += "   whereStr += \" and SignUpTime >= '\" + min_SignUpTime + \"'\";\n";
            Roundcode += "    } \n  ";

            Roundcode += " if (!string.IsNullOrWhiteSpace(max_SignUpTime)) \n ";
            Roundcode += "   {";
            Roundcode += "   whereStr += \" and SignUpTime <= '\" + max_SignUpTime + \"'\";\n";
            Roundcode += "    }  \n ";
            String wherStr = "";
          
            List<WordModel> listModel = new List<WordModel>();


            foreach (DataColumn col in dt.Columns)
            {
                WordModel oneModel = new WordModel();
             
                string Name = col.ColumnName;
                oneModel.WordName = Name;
                string typeS = col.DataType.ToString();
                oneModel.WordType = col.DataType.ToString().Substring(typeS.IndexOf(".")+1);
                colIndex++;
                PureStr += "," + Name;
                if (col.ColumnName.ToLower()=="id")
                {
                    string tempStr = "";
                    tempStr = ReplaceToAimWord(Equalcode, Name);
                    paraStr += "," + Name;
                    if (IsNumType(col.DataType.Name))
                    {
                        tempStr = tempStr.Replace("'", "");
                    }
                    wherStr += tempStr;
                    //todo 实现主键的判断
                    listModel.Add(oneModel);
                    continue;
                }
                //System.TimeSpan
                if (col.DataType == System.Type.GetType("System.DateTime")|| col.DataType == System.Type.GetType("System.TimeSpan"))
                {
                    ////string strContent = dt.Rows[0][0].ToString();
                    ////int iMaxLength = strContent.Length;
                    int text = col.MaxLength;
                    
                    // string Name=    col.ColumnName; 
                    wherStr += ReplaceToAimWord(Roundcode, Name);
                    paraStr += CreteParaStrForRound(Name);
                }
                if (IsNumType( col.DataType.Name  ))
                {
                   
               string temp = ReplaceToAimWord(Roundcode, Name)  ;
                    temp = temp.Replace("'","");
                    wherStr += temp;
                   paraStr += CreteParaStrForRound(Name);
                }
                if (col.DataType.Name.ToLower().IndexOf("string") > -1)
                {
                    wherStr += ReplaceToAimWord(Likecode, Name)  ;
                    paraStr += "," + Name;
                }
                listModel.Add(oneModel);
            }
            PublicInfo.AllColumnModes = listModel;
            return wherStr;
        }

        private static string CreteParaStrForRound(string Name)
        {
            return ",min_" + Name + ",max_" + Name;
        }

        private static string ReplaceToAimWord(string Equalcode, string Name)
        {
            return Regex.Replace(Equalcode, "SignUpTime", Name);
        }

        private bool IsNumType(string name)
        {
            bool result = false;
            foreach (var item in CreSqlModel.AllDataType)
            {
                if (name.ToLower().IndexOf(item) > -1)
                {
                    result = true;
                    return true;
                }
            }
           
            return result;
        }
    }
}
