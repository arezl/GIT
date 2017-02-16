using createSql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode.CreateCode
{
    class MainCreate : ACondictionCreate
    {


        public MainCreate(CreateActCode createActCode)
        {
            this.createActCode = createActCode;
            Rate = 10;
        }

        override public string PreReplace(string OringStr)
        {
         //   createActCode.Para = createActCode.ParaOrig;
            string DealStr= createActCode.ParaOrig;
            string documentstr = "";
            foreach (string tagKey in createActCode.FunctionTagDic.Keys)
            {
                OringStr = Regex.Replace(OringStr, @"\b" + tagKey + @"\b", createActCode.FunctionTagDic[tagKey].ParaStrDeal(createActCode));
          
            }  

            foreach (string item in DealStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
          string   itemS = item.Trim();
                if (m_DatasDal.ExistscolumnName(itemS))
                {
                    Datas itemStr = m_DatasDal.GetModel(itemS);
                    itemStr.Value = itemStr.Value.Replace(",", "").Replace(":", "");
                    documentstr += "\"" + itemS + "\",         " + itemStr.Value + "\n";
                }
                else
                {
                    documentstr += "\"" + itemS + "\",         \n";
                }


            }

           // create.ResultParav
          OringStr = Regex.Replace(OringStr, @"\b" + "DocumentPara" + @"\b", documentstr);

            DealStr = createActCode.ResultPara;
            documentstr = "[{";
            foreach (var item in DealStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string itemS = item.Trim();
                if (m_DatasDal.ExistscolumnName(itemS))
                {
                    Datas itemStr = m_DatasDal.GetModel(itemS);
                  //  itemStr.Value = itemStr.Value.Replace(",", "").Replace(":", "");
                    documentstr += "\"" + itemS + " "+  itemStr.Value + "\n";
                }
                else
                {
                    documentstr += "\"" + itemS + "\",         \n";
                }


            }
            OringStr = Regex.Replace(OringStr, @"\b" + "DocumentResultPara" + @"\b", documentstr+ "}]");


            foreach (Word itemTargetStr in createActCode.replaceDic.Keys)
            {
                OringStr = Regex.Replace(OringStr, @"\b" + itemTargetStr.ToString() + @"\b", createActCode.replaceDic[itemTargetStr]);
            }
             OringStr = OringStr.Replace("act_info_branch", createActCode.ClassName);
            //进行常规替换
            return OringStr;
        }
    }
}
