using createSql.Tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createSql.Model
{
    [Serializable]
    class ICodeModel
    {
        internal string mActinfo;
        public ICodeModel()
        {
            LoadModulInfo("Normal");
//            IActStr = @"[OperationContract]
//        string ActInfofkBranchGet(string key ,string userID PARAWithStr);
//";
//            ActStr = @" public string ActInfofkBranchGet(string key,string userID PARAWithStr)
//        {
//            return mActinfo.ActInfofkBranchGet(PARA);
//        }
//";
//            mActinfoStr = @"       public static string ActInfofkBranchGet(PARAWithStr)
//        {
//            act_info_branch act_info_branchs = new act_info_branch();
//            DataTable dt;
//            string ret = act_info_branchs.ActInfofkBranchGet(  out dt PARA);
//        "+"    if (ret != \"\")"+@"
//            {
//                return globals.pub.soa_return_json(false, ret);
//            }
//            string jsion = DataSetToJsonAndXml.DataTable2Json(dt);
//            return globals.pub.soa_return_json(true, jsion);

//        }
//";
//            act_infoStr = File.ReadAllText(@"Resource\actInfo\actInfo.txt");
//            actDocumentStr = File.ReadAllText(@"Resource\actInfo\actDocument.txt");


        }
        public string Act { get; internal set; }
        public string Actinfo { get; internal set; }
        public string IAct { get; internal set; }
        public string IActStr { get; set; }
        public string ActStr { get; set; }
        public string mActinfoStr { get; set; }
        public string act_infoStr { get; set; }
        public string actDocumentStr { get; set; }

        internal void LoadModulInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            string Path = @"Resource\" + @"Interface\" + path+ @"\";
            DynamicMethod<ICodeModel> temp = new DynamicMethod<ICodeModel>();
           
            SetValue(Path, temp, "IAct");
            SetValue(Path, temp, "Act");
            SetValue(Path, temp, "mActinfo");
            SetValue(Path, temp, "act_info");
            SetValue(Path, temp, "actDocument");


           
        }

        private void SetValue(string Path, DynamicMethod<ICodeModel> temp, string act)
        {
            string path = Path + act + @".txt";
            if (File.Exists(path))
            {
                temp.SetValue(this, act + "Str", File.ReadAllText(path));

            }
          
        }
    }
}
