using createSql.Model.CrSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrWhere
{
    class ValueBindCreate : AbstrCodeByTable
    {
        public ValueBindCreate() {
            HeadStr = @"public string GetModel(DataTable dt )
{          List<AimClass> modelOneList=new  List<AimClass>();
             foreach(DataRow itemRow in dt.Rows )
{      
AimClass oneAim = new AimClass();  
" +" string value = \"\"; ";
            EndStr = @"

     modelOneList.Add(oneAim); 
}

}


";
        }
        
        public override string intDeal(WordModel item)
        {
         //   string aimStr = " public Type name { get; set; }\n";
            string Kes = item.WordName;
            string aimStr = @"  Type KesType;
             " + "   value = itemRow[\"Kes\"].ToString();" + @" 
            Type.TryParse(value, out KesType);
            oneAim.Kes = KesType;
               ";

            aimStr = aimStr.Replace("Kes", Kes);
            aimStr = aimStr.Replace("Type", "int");
            resultStr += "\n" + aimStr + "\n";
            return "";

     
            //foreach (DataRow itemRow in dt.Rows)
            //{ 
            //    Type KesType;
            //    value = itemRow["Kes"].ToString();
            //    Type.TryParse(value, out m);
            //    oneAim.Kes = m;
              
           
            //}



                resultStr += aimStr.Replace("name", item.WordName);
            return "";
        }

        public override string DecimalDeal(WordModel item)
        {
            string Kes =  item.WordName  ;
            string aimStr = @"  Type KesType;
             "+"   value = itemRow[\"Kes\"].ToString();"+@" 
            Type.TryParse(value, out KesType);
            oneAim.Kes = KesType;
               ";

            aimStr = aimStr.Replace("Kes", Kes);
            aimStr = aimStr.Replace("Type",   "Decimal");
            //aimStr = aimStr.Replace("Kes", "Decimal");
            //  resultStr += aimStr.Replace("name", item.WordName);
            resultStr += "\n" + aimStr + "\n";
            return "";
        }

        public override string TimeSpanDeal(WordModel item)
        {
           // string aimStr = " public TimeSpan name { get; set; }\n";
            string Kes = item.WordName;
            string aimStr = @"  Type KesType;
             " + "   value = itemRow[\"Kes\"].ToString();" + @" 
            Type.TryParse(value, out KesType);
            oneAim.Kes = KesType;
               ";

            aimStr = aimStr.Replace("Kes", Kes);
            aimStr = aimStr.Replace("Type", "TimeSpan");
            resultStr += "\n" + aimStr + "\n";
            return "";
        }

        public override string DateTimeDeal(WordModel item)
        {
           // string aimStr = " public DateTime name { get; set; }\n";
            string Kes = item.WordName;
            string aimStr = @"  Type KesType;
             " + "   value = itemRow[\"Kes\"].ToString();" + @" 
            Type.TryParse(value, out KesType);
            oneAim.Kes = KesType;
               ";

            aimStr = aimStr.Replace("Kes", Kes);
            aimStr = aimStr.Replace("Type", "DateTime");
            resultStr += "\n" + aimStr + "\n";
            return "";
        }
        public override string StringSpanDeal(WordModel item)
        {
            string Kes = item.WordName;
            string aimStr =  "   value = itemRow[\"Kes\"].ToString();" + @" 
                  oneAim.Kes = value;
";
            aimStr = aimStr.Replace("Kes", Kes);
            aimStr = aimStr.Replace("Type", "DateTime");
            resultStr +="\n"+ aimStr+"\n";
            return "";
        }
    }
}
