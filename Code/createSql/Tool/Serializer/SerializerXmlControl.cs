using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace createSql.Tool.Serializer
{
  

        public class SerializerXmlControl
        {
            /// <summary>
            /// 将对象序列化为xml文件
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="t">对象</param>
            /// <param name="path">xml存放路径</param>
            public static void ObjectToXml<T>(T t, string path) where T : class
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(stream, t);
                }
            }

            /// <summary>
            /// 将对象序列化为xml字符串
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="t">对象</param>
            public static string ObjectToXml<T>(T t) where T : class
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, t);
                    string result = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                    return result;
                }
            }

            /// <summary>
            /// 将xml文件反序列化为对象
            /// </summary>
            /// <typeparam name="T">类型</typeparam>
            /// <param name="t">对象</param>
            /// <param name="path">xml路径</param>
            /// <returns>对象</returns>
            public static T XmlToObject<T>(T t, string path) where T : class
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    XmlReader xmlReader = new XmlTextReader(stream);
                    T result = formatter.Deserialize(xmlReader) as T;
                    return result;
                }
            }
        }
    }
 
