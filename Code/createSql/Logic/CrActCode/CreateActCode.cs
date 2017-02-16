using createSql.DAL;
using createSql.Logic.CrActCode;
using createSql.Logic.CrActCode.CreateCode;
using createSql.Logic.CrActCode.FunctionTag;
using createSql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace createSql.Logic.CrActCode
{
    class CreateActCode
    {
        public Dictionary<Word, string> replaceDic = new Dictionary<Word, string>();
        private ICodeModel m_codeMode;
        public static string UserIdStr = ",string userID";
     public   List<ACondictionCreate> AllCondiction = new List<ACondictionCreate>();

        public CreateActCode()
        {
         
            m_codeMode = new ICodeModel();
            replaceDic.Clear();
            replaceDic.Add(Word.ActInfofkBranchGet, "");
            replaceDic.Add(Word.PARAWithStr, "");
            replaceDic.Add(Word.PARA, "");

          
        }

        private void SetInfo()
        {
            replaceDic[Word.ActInfofkBranchGet] = FunctionNameStr;
            replaceDic[Word.PARAWithStr] = ParaWithStr;
            replaceDic[Word.PARA] = Para;
        }

        public string FunctionNameStr { get; internal set; }
        public bool IsPage { get; internal set; }
        public bool IsUser { get; internal set; }
        List<string> ParasArray = new List<string>();
        string ParaWithStr = "";
        private string _Para = "";
        private string _ParaOrig = "";
        public List<string> ParasList =new  List<string>();
     

        public string ParaOrig
        {
            get { return _ParaOrig; }
            set {
                ParasList.Clear();
                foreach (string item in value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string itemS = item.Trim();
                    ParasList.Add(itemS);
                }

                    _ParaOrig =value;
                Para = value;
            }
        }
        public string Para {
            get { return _Para; } 
            internal set { _Para = value;
                ParasArray = _Para.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries).ToList();
                ParaWithStr = "";
                foreach (string item in ParasArray)
                {
                    ParaWithStr += " ,string " + item;
                }
                SetInfo();
            } 
        }

        public string ResultPara { get; internal set; }
        public Dictionary<string, IFunctionTag> FunctionTagDic = new Dictionary<string, IFunctionTag>();
        public string ClassName { get; internal set; }

        internal string GetDocument()
        {
            string OringStr = m_codeMode.actDocumentStr;
            OringStr = GetAimResutStr(OringStr);
            return OringStr;
        }
        internal string GetAct()
        {
            return GetAimResutStr(m_codeMode.ActStr);
        }

        internal string GetIAct()
        {
            return GetAimResutStr(m_codeMode.IActStr);
        }

        internal string GetActInfo()
        {
            return GetAimResutStr(m_codeMode.act_infoStr);
        }

        internal string GetmActionInfo()
        {
            return GetAimResutStr(m_codeMode.mActinfoStr);
        }
        protected virtual string GetAimResutStr(string OringStr)
        {
            foreach (ACondictionCreate itemCrete in AllCondiction)
            {
                OringStr = itemCrete.PreReplace(OringStr);
            }

            return OringStr;
        }

        internal void AllPrePare()
        {
            SetInfo();
            //  replaceDic.Add(Word.userID, ",string userID");
            if (IsUser)
            {
                AllCondiction.Add(new UserIdCreate(this));
            }
            if (IsPage)
            {
                AllCondiction.Add(new PageCreate(this));
            }

            AllCondiction.Add(new MainCreate(this));
        }

        internal void LoadModulInfo(string path)
        {
            
                m_codeMode.LoadModulInfo(path);
            
          
        }
    }

   
    
   

    enum Word
    {
        ActInfofkBranchGet,
        PARAWithStr,
        PARA,
        userID,
    }
}
