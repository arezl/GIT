using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode.FunctionTag
{
    interface IFunctionTag
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createActCode">各种数据都传进去 ，要什么数据自己取用</param>
        /// <returns></returns>
     string    ParaStrDeal(CreateActCode createActCode);
   

    }
    class StramParaGet : IFunctionTag
    {
        public string ParaStrDeal(CreateActCode createActCode) {
            string result = "";
            foreach (var item in createActCode.ParasList)
            {
           string onePara=     " \n string actname = paras.DicParaters[\"actname\"];\n";
                result+=onePara.Replace("actname", item);
            }
            return result;
        }
    }
    class StramParaContainJugeGet : IFunctionTag
    {
        public string ParaStrDeal(CreateActCode createActCode)
        {
            string result = "";
            int i = 1;
            foreach (var item in createActCode.ParasList)
            {
               // string onePara = " paras.DicParaters.ContainsKey("actname") && paras.DicParaters.ContainsKey("id")";
                string onePara = " paras.DicParaters.ContainsKey(\"actname\")";
                if (i!= createActCode.ParasList.Count())
                {
                    result += onePara.Replace("actname", item) + "&&";
                }
                else
                {
                    result += onePara.Replace("actname", item)  ;
                }
               
                i++;
            }
            return result;
        }
    }


}
