using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace createSql.Tool.Serializer
{
   

    public class SerializerBinaryControl
    {
        #region 文件序列化
        /// <summary>
        /// 将对象序列化为字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例</param>
        /// <returns>字符串</returns>
        public static string ObjectToString<T>(T t)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, t);
                string result = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                return result;
            }
        }

        /// <summary>
        /// 将对象序列化为文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例</param>
        /// <param name="path">存放路径</param>
        public static void ObjectToFile<T>(T t, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, t);
                stream.Flush();
            }
        }

        /// <summary>
        /// 将字符串反序列为类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="s">字符串</param>
        /// <returns>对象</returns>
        public static T StringToObject<T>(string s) where T : class
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(s);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                T result = formatter.Deserialize(stream) as T;
                return result;
            }
        }

        /// <summary>
        /// 将文件反序列化为对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="path">路径</param>
        /// <returns>对象</returns>
        public static T FileToObject<T>(string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                T result = formatter.Deserialize(stream) as T;
                return result;
            }
        }
        #endregion
    }


}
