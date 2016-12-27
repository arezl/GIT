using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;

using word = Microsoft.Office.Interop.Word;
using System.IO;

namespace Maticsoft.Common
{
    
      
   public class WordDeal
    {
      public  word.ApplicationClass wordapp = null;   //这是WORD程序，在这个程序下，可以同时打开多个文档，尽量不要同时打开多个Word程序，否则会出错的。
        public word.Document doc = null;  //第一个需要打开的WORD文档
        public word.Document doc2 = null;  //另一个需要打开的WORD文档
        public int ParagraphsCount;
        string DocFileName;
        object oMissing = System.Reflection.Missing.Value;  //一个编程时需要经常使用的一个参数
        public static WordDeal Instance = new WordDeal();
        private WordDeal() {


        }
        public void OpenDocFile(string docName)
        {
          
         


            wordapp = new word.ApplicationClass();
            wordapp.Visible = true; //所打开的WORD程序，是否是可见的。

            object docObject = docName;  //由于COM操作中，都是使用的 object ,所以，需要做一些转变                       
            if (File.Exists(docName))   // 如果要打开的文件名存在，那就使用doc来打开 
            {
                doc = wordapp.Documents.Add(ref docObject, ref oMissing, ref oMissing, ref oMissing);
                doc.Activate();   //将当前文件设定为活动文档
                ParagraphsCount = doc.Content.Paragraphs.Count;   //此文档中，段落的数量，也就是这个文档中，有几个段落。
                string test = Paragraph(11);
               // doc.Content.Paragraphs[10];
            }
            else   //如果文件名不存在，那就使用doc2来打开
            {
                doc2 = wordapp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                DocFileName = docName;
                doc2.Activate();   //将当前文件设定为活动文档  

            }


        }
        public string Paragraph(int index)
        {
            word.Paragraph para;
            if (doc.Content.Paragraphs.Count>index)
            {
                try
                {
                    para = doc.Content.Paragraphs[index];
                }
                catch (Exception)
                {

                    return "";
                }
       
                return para.Range.Text;
            }
             ///这是一个设定对应的某一段              
            return "" ;
        }
        /// <summary>
        /// 将doc某一段的内容复制到剪贴板上
        /// </summary>
        /// <param name="index">段的序号</param>
        public void CopyParagraph(int index)
        {
            word.Paragraph para;
            para = doc.Content.Paragraphs[index];
            para.Range.Copy();

        }
        /// <summary>
        /// 将剪贴板的内容粘贴到doc2文档中
        /// </summary>
        public void PasteParagraph()
        {
            if (doc2 != null)
            {
                word.Paragraph para = doc2.Content.Paragraphs.Add(ref oMissing);
                try
                {
                    para.Range.Paste();
                    para.Range.InsertParagraphBefore();//添加一次回车
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// 关闭 word程序
        /// </summary>
        public void CloseWord()
        {
            if (wordapp != null)
            {
                if (doc != null)
                {
                    word._Document docc = doc as word._Document;
                    docc.Close(ref oMissing, ref oMissing, ref oMissing);
                }

                if (doc2 != null)
                {
                    word._Document docc = doc2 as word._Document;
                    docc.Close(ref oMissing, ref oMissing, ref oMissing);
                }

                wordapp.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
        }
        /// <summary>
        /// 替换文档中的内容
        /// </summary>
        /// <param name="oldString">原有内容</param>
        /// <param name="newString">替换后的内容</param>
        public void Replace(string oldString, string newString)
        {
            doc2.Content.Find.Text = oldString;
            object FindText, ReplaceWith, ReplaceAll;

            FindText = oldString;
            ReplaceWith = newString;
            ReplaceAll = word.WdReplace.wdReplaceAll;
            doc2.Content.Find.Execute(ref FindText,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref ReplaceWith,
                                      ref ReplaceAll,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing,
                                      ref oMissing);

        }
        /// <summary>
        /// 保存word文档（只保存doc2）
        /// </summary>
        public void SaveDocFile()
        {
            if (doc2 != null)
            {
                if (!string.IsNullOrEmpty(DocFileName))
                {
                    object docname = DocFileName;//要保存的文件名称，包括路径
                    Replace("^p^p", "^p");
                    doc2.SaveAs2(ref docname,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing,
                                 ref oMissing);
                }
            }

        }
        /// <summary>
        /// 复制文档的内容，从开始到结束（包括结束与开始的段落）的段落内容。
        /// </summary>
        /// <param name="first">开始的段落号</param>
        /// <param name="next">结束的段落号</param>
        public void CopyParagraph2(int first, int next)
        {
            word.Range range = doc.Range();

            word.Paragraph para1;
            para1 = doc.Content.Paragraphs[first];
            range.Start = para1.Range.Start;

            word.Paragraph para2;
            para2 = doc.Content.Paragraphs[next];
            range.End = para2.Range.End;

            range.Copy();

        }
//        在这个复制过程中，重新建立了一个区域 word.Range range = doc.Range(); 这个区域包括文档的所有内容。
//然后根据段落的要求分别设定区域的Start 和 End ，如果在 Start  和 End 之间有一个表格的话，那么表格也会被正确复制过去
    }
}
