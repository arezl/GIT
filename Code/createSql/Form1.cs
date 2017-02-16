using createSql.Logic;
using createSql.Logic.CrActCode;
using createSql.Logic.CrSql;
using createSql.Model;
using createSql.Model.CrSql;
using createSql.Tool.Serializer;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maticsoft.Common;
using createSql.DAL;
using createSql.Logic.CrActCode.FunctionTag;

namespace createSql
{
    public partial class Form1 : Form
    {
        private ConfigModel m_configModel = new ConfigModel();
        private ICodeModel m_ICodeModel = new ICodeModel();

        public Form1()
        {
            InitializeComponent();
            m_configModel = SerializerBinaryControl.FileToObject<ConfigModel>(PublicInfo.ConfigPath);

            txtDelet.Text = m_configModel.DeleteFilePath;
            txtUpdate.Text = m_configModel.UpdateFilePath;
            txtInsert.Text = m_configModel.InsertFilePath;
            m_ICodeModel = SerializerBinaryControl.FileToObject<ICodeModel>(PublicInfo.ICodeModelPath);
            txtAct.Text = m_ICodeModel.Act;
            txtIAct.Text = m_ICodeModel.IAct;
            txtmActinfo.Text = m_ICodeModel.mActinfo;
            txtActInfo.Text = m_ICodeModel.Actinfo;

            //string tempStr ="111.23";

            //if (tempStr.IndexOf(".") > -1)
            //{
            //    tempStr = tempStr.Substring(tempStr.IndexOf("."));
            //    if (tempStr.Length > 3)
            //    {
                  
            //    }
            //}

            //string[] defaultAddStr = File.ReadAllLines("1.sql");
            //string resultStr = "";
            //string Tales = "";
            //foreach (var item in defaultAddStr)
            //{
               
                
            //    if (!Regex.IsMatch(item, @"\bdefault\b")&& item.Trim().EndsWith(","))
            //    {
            //        if (Regex.IsMatch(item, @"\bint\b")|| Regex.IsMatch(item, @"\bnumeric\b"))
            //        {
            //            string temp = Regex.Replace(item.Trim(), ",$", " default 0 ,");
            //           // string temp = item.Replace(",", " default 0 ,");
            //            resultStr += temp + "\n";
            //            continue;

            //        }

            //    }
            //    resultStr += item + "\n"; 
            //}

            List<string> oriSqls = richTxtOrigData.Text.Split('\n').ToList();

            DbHelperSQL.connectionString = DbHelperSQL.connectionString.Replace("WX_Activity", "test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clearData = "";
            //    string clearData= @"(
            //    string act_name, string act_code, string status, string date_start, string date_end, string time_start, string time_end, string branch_no, string act_obj, string is_need_sign,
            //string sign_time_start, string sign_time_end, string sign_max, string is_need_money, string sign_money, string money_time, string release_man, string release_time, string sign_man_max, string act_img,
            //string act_detial, string act_more_img, string act_more_link, string act_tel, string act_addrs, string is_send_wx, string is_send_msg, string write_man, string write_time, string is_release)";
            clearData = clearData.Replace("string ", "");
            List<string> oriSqls = richTxtOrigData.Text.Split('\n').ToList();
            //  List<string> oriSqls = File.ReadLines("datas.txt").ToList();
            string aimSql = "\"insert into act_info(";
            //     oriSqls[2] = oriSqls[2].Replace(")", "");
          
            List<WordModel> WordList = GetAllWord(oriSqls);
            TableModel tableModel = new TableModel();
            PublicInfo.TalbeModel = tableModel;
            string columnStr = "";
            if (richTxtOrigData.Text.Trim()=="")
            {
                WordList = PublicInfo.AllColumnModes;

                PublicInfo.TalbeModel.ParaStr = richTextPureStr.Text;
            }
            else
            {
                if (oriSqls.Count < 2)
                {
                    return;
                }
              columnStr = oriSqls[2];
                //columnStr = columnStr.Replace("\"","");
                //columnStr = columnStr.Replace(")", "");
                //columnStr = Regex.Match(columnStr, @"(?<=\().*?(?=;)").Value;
                txtAllItem.Text = columnStr;
                columnStr = columnStr.Substring(columnStr.IndexOf('"') + 1);
                columnStr = columnStr.Substring(0, columnStr.IndexOf(')'));
                tableModel.ParaStr = columnStr;
                ///
            }
            string[] columns = columnStr.Split(',');
            PublicInfo.AllColumnModes = WordList;

            ///
         
            bool isfirst = true;
            aimSql += columnStr;
          
          
         
           // string tableStr = oriSqls[1];
            //foreach (var item in columns)
            //{
            //    if (isfirst)
            //    {
            //        aimSql += item;
            //    }
            //    else
            //    {
            //        aimSql += "," + item;
            //    }
            //    isfirst = false;
            //}
            aimSql += ")values (";

            asqlCrete temCreate = new insertSal(WordList);

            aimSql = "";

            isfirst = CreateSql(oriSqls, out aimSql, columns, temCreate);
            richtxtInsert.Text = aimSql;

            temCreate = new UpdateSql(WordList);
            aimSql = "";

            isfirst = CreateSql(oriSqls, out aimSql, columns, temCreate);
            richtxtUpdate.Text = aimSql ;
            
            /// if (actname != "") set += " actname= '" + actname + "',";

        }

        private List<WordModel> GetAllWord(List<string> oriSqls)
        {
            List<WordModel> result = new List<WordModel>();
            // string test= "new SqlParameter(\"@act_no\", SqlDbType.VarChar,12),";
            foreach (string item in oriSqls)
            {
                string test = item;
                if (item.IndexOf("SqlDbType") > -1)
                {
                    WordModel oneModel = new WordModel();
                    string WordName = Regex.Match(test, "\".*\"").Value;
                    oneModel.WordName = WordName.Replace("\"", "").Replace("@", ""); ;
                    oneModel.WordType = Regex.Match(test, "\\..*?,").Value.Replace(",", "").Replace(".", "");
                    String LenStr = Regex.Match(test, "\\d*?\\)").Value.Replace(")", "");
                    int len;
                    int.TryParse(LenStr, out len);
                    oneModel.Length = len;
                    result.Add(oneModel);
                }

            }
            return result;
        }

        private bool CreateSql(List<string> oriSqls, out string aimSql, string[] columns, asqlCrete temCreate)
        {
            aimSql = "";
            int i = 0;
            string headStr = temCreate.GetHeadSql();
            bool isfirst = true;

            CreSqlModel.AllDataType.Add("Int32");
            CreSqlModel.AllDataType.Add("DateTime");
            
            foreach (WordModel oneModel in PublicInfo.AllColumnModes)
            {
               // string resut = asqlCrete.AddDou(ref isfirst);
                if (CreSqlModel.AllDataType.Contains(oneModel.WordType)) {

                    temCreate.createSqlWithOutOuter(ref isfirst, ref aimSql, oneModel.WordName);

                    i++;
                    continue;
                }
                temCreate.createSqlWithOuter(ref isfirst, ref aimSql, oneModel.WordName);
                // aimSql += AddDou(ref isfirst) + "'\"+" + columns[i] + "+\"'";
                i++;
                continue;
            }
        
            //foreach (string item in oriSqls)
            //{

            //    string resut = asqlCrete.AddDou(ref isfirst);

            //    if (item.IndexOf("SqlDbType.Int") > -1)
            //    {
            //        temCreate.createSqlWithOutOuter(ref isfirst, ref aimSql, columns[i]);

            //        i++;
            //        continue;
            //    }
            //    else if (item.IndexOf("SqlDbType.Decimal") > -1)
            //    {
            //        temCreate.createSqlWithOutOuter(ref isfirst, ref aimSql, columns[i]);

            //        i++;
            //        continue;
            //    }
            //    else if (item.IndexOf("SqlDbType.") > -1)
            //    {
            //        temCreate.createSqlWithOuter(ref isfirst, ref aimSql, columns[i]);
            //        // aimSql += AddDou(ref isfirst) + "'\"+" + columns[i] + "+\"'";
            //        i++;
            //        continue;
            //    }








            aimSql = temCreate.GetHeadSql() + aimSql + temCreate.GetEndSql();

            aimSql.Replace("[act_info]", "[" + txtHead.Text + "]");
            aimSql = aimSql.Replace("[WX_Activity].[dbo].[act_info]", PublicInfo.TalbeName);
            return isfirst;
        }






        private void button2_Click(object sender, EventArgs e)
        {
            string paraStr = txtPara.Text;
            string functionNameStr = txtFunctionName.Text;
            CreateActCode create = new CreateActCode();
            create.FunctionNameStr = functionNameStr;
            string flagStr = txtFlag.Text;
            List<string> flags = flagStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            create.IsPage = false;
            create.IsUser = false;
            if (flags.Count == 2)
            {
                if (flags[0] == "1")
                {
                    create.IsPage = true;
                }

                if (flags[1] == "1")
                {

                    create.IsUser = true;
                }

            }

            //参数设置必须再para的前面完成
            create.ParaOrig = paraStr;
            create.ClassName = txtClassName.Text;
            create.ResultPara = richTextPureStr.Text;
            create.FunctionTagDic.Add("StramPara", new StramParaGet());
            create.FunctionTagDic.Add("StramParaContainJuge", new StramParaContainJugeGet());
            
            string Path = comboBox1.Text;
            create.LoadModulInfo(Path);
            create.AllPrePare();
            richtxtDocument.Text = create.GetDocument();
            richtxtAct.Text = create.GetAct();
            richTxtIAct.Text = create.GetIAct();
            richtxtmActinfo.Text = create.GetmActionInfo();
            richtxtActInfo.Text = create.GetActInfo();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            m_configModel.DeleteFilePath = txtDelet.Text;
            m_configModel.UpdateFilePath = txtUpdate.Text;
            m_configModel.InsertFilePath = txtInsert.Text;

            SerializerBinaryControl.ObjectToFile<ConfigModel>(m_configModel, PublicInfo.ConfigPath);

            m_ICodeModel.Act = txtAct.Text;
            m_ICodeModel.IAct = txtIAct.Text;
            m_ICodeModel.mActinfo = txtmActinfo.Text;
            m_ICodeModel.Actinfo = txtActInfo.Text;
            SerializerBinaryControl.ObjectToFile<ICodeModel>(m_ICodeModel, PublicInfo.ICodeModelPath);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string Sql = richTextSql.Text;
            PublicInfo.TalbeName =Regex.Match(Sql, @"(?<=FROM\s)[^\s]+").Value;
            DataSet resutSet = DbHelperSQL.QuerySchema(Sql);
            CreatWhere CreateWhere = new CreatWhere();
           
            if (resutSet.Tables.Count > 0)
            {
                DataTable dt = resutSet.Tables[0];
                int rowIndex = 0;
                int colIndex = 0;
                string ParaStr  ;
                string PureStr;
           richTextWhere.Text=     CreateWhere.CreateSql(dt,out  ParaStr,out PureStr);
                richTextPara.Text = ParaStr;
                richTextPureStr.Text = PureStr;
                //foreach (DataColumn col in dt.Columns)
                //{
                //    colIndex++;
                //    if (col.DataType == System.Type.GetType("System.DateTime"))
                //    {
                //        if ()
                //        {

                //        }


                //    }
                //}
                //foreach (DataRow row in dt.Rows)
                //{
                //    rowIndex++;
                //    colIndex = 1;
                //    foreach (DataColumn col in dt.Columns)
                //    {
                //        colIndex++;
                //        if (col.DataType == System.Type.GetType("System.DateTime"))
                //        {

                //        }
                //    }
                //}
            }
        }

        private void btnLoadDocumentDoc_Click(object sender, EventArgs e)
        {
            //WordDeal.Instance.OpenDocFile(@"G:\工作\SVNCode\3 开发文档\接口文档\活动信息接口文档.doc");
            //string resultStr = "";
            //for (int i = 0; i < WordDeal.Instance.ParagraphsCount; i++)
            //{
            //    resultStr+= WordDeal.Instance.Paragraph(i);
            //}
            //WordDeal.Instance.CloseWord();
            string datasStr = richTextBoxWord.Text;
            string[] DataStr;
            if (string.IsNullOrWhiteSpace(datasStr))
            {
                DataStr = File.ReadAllLines(@"G:\工作\tool\createSql\createSql\bin\Debug\Resource\活动信息接口文档.txt");
            }
            DataStr = datasStr.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> wordDic = new Dictionary<string, string>();
           
            DatasDal datadal = new DatasDal();
            for (int i = 0; i < DataStr.Length; i++)
            {
                string itemStr = DataStr[i];
               //[{
                itemStr = Regex.Replace(itemStr,@"\bstring\b","");
                itemStr = Regex.Replace(itemStr, @"\[", "");
                itemStr = Regex.Replace(itemStr, @"\]", "");
                itemStr = Regex.Replace(itemStr, @"\{", "");
                itemStr = Regex.Replace(itemStr, @"\}", "");
                itemStr = Regex.Replace(itemStr, "\"", "");
                if (HasStr(itemStr, "(string key")  || HasStr(itemStr, "参数:") || HasStr(itemStr, "返回:"))
                {
                    continue;
                }
                if (Regex.IsMatch(itemStr,@"\d+.\d+"))
                {
                    continue;
                }
                MatchCollection datas = Regex.Matches(itemStr,@"\b\w+\b");
                if (itemStr.IndexOf(":")>-1)
                {

                }
              
                //if (datas.Count==2)
                //{
                //    //if (!wordDic.Keys.Contains(datas[0].Value))
                //    //{

                //    //    wordDic.Add(datas[0].Value, datas[1].Value);

                //    //}
                //    //wordDic[datas[0].Value] = datas[1].Value.Trim();
                //    if (!datadal.ExistscolumnName(datas[0].Value))
                //    {
                //        datadal.Add(vdata);
                //    }
                //    else
                //    {
                //        datadal.Update(vdata);
                //    }
                //    continue;
                //}
                //else
                //{
                //    if (!datadal.ExistscolumnName(datas[0].Value))
                //    {
                //        datadal.Add(vdata);
                //    }
                //    else
                //    {
                //        vdata.columnName =itemStr.Replace(vdata.columnName,"");
                //        datadal.Update(vdata);
                //    }

                //}
                if (datas.Count >= 2)
                {
                    if (itemStr.IndexOf(",") > -1)
                    {

                    }
                    string KeyStr = datas[0].Value;
                    string ValueStr = datas[1].Value;
                    ValueStr = itemStr.Replace(KeyStr, "");
                    AddOneModel(datadal, KeyStr, ValueStr);

                }
            }
        }

        private static void AddOneModel(DatasDal datadal, string KeyStr, string ValueStr)
        {
            Datas vdata = new Datas();

            vdata.Value = ValueStr;
            vdata.columnName = KeyStr;
            if (!datadal.ExistscolumnName(KeyStr))
            {
                datadal.Add(vdata);
            }
            else
            {

                datadal.Update(vdata);
            }
        }

        private bool HasStr(string v,string mark)
        {
            if (v.IndexOf(mark) > -1)
            {
                return true;
            }
            else return false;
        }

        private void btnLoadDoc_Click(object sender, EventArgs e)
        {
            string docStr = richTextDoc.Text;
            docStr = docStr.Replace("\t", "");
            string[] docs = docStr.Split(new char[] { '\n'},StringSplitOptions.RemoveEmptyEntries);
            DatasDal datadal = new DatasDal();
            for (int i = 0; i < docs.Length; i++)
            {
                if (i%2==0)
                {
                    AddOneModel(datadal, docs[i+1], docs[i]);
                }
               
            }
          
        }
    }
    [Serializable]
    class ConfigModel
    {
        public string DeleteFilePath { get; internal set; }
        public string InsertFilePath { get; internal set; }
        public string UpdateFilePath { get; internal set; }
    }
}