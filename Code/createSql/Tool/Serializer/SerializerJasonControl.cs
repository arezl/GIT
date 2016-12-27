using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace createSql.Tool.Serializer
{
    class SerializerJasonControl
    {

        /// 将对象序列化为json文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例</param>
        /// <param name="path">存放路径</param>
        public static void ObjectToJson<T>(T t, string path) where T : class
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(stream, t);
            }
        }

        /// <summary>
        /// 将对象序列化为json字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实例</param>
        /// <returns>json字符串</returns>
        public static string ObjectToJson<T>(T t) where T : class
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.WriteObject(stream, t);
                string result = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                return result;
            }
        }

        /// <summary>
        /// json字符串转成对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="json">json格式字符串</param>
        /// <returns>对象</returns>
        public static T JsonToObject<T>(string json) where T : class
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Book));
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                T result = formatter.ReadObject(stream) as T;
                return result;
            }
        }



        #region 将JSON字符串转化为对象
        /// <summary>
        /// 将JSON字符串转化为对象
        /// </summary>
        /// <typeparam name='T'>要转换的T指代类型对象</typeparam>
        /// <param name='argJsonString'></param>
        /// <returns></returns>
        //public static T ToJSONObject<T>(this string argJso nString) where T : class
        //{
        //    try
        //    {
        //        //System.Runtime.Serialization.Json.DataContractJsonSerializer myJsonSerializtionService = new Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
        //        //System.IO.MemoryStream ms = new IO.MemoryStream(Encoding.UTF8.GetBytes(argJsonString));
        //        //object objResult = myJsonSerializtionService.ReadObject(ms);

        //        T objResult = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(argJsonString);
        //        return objResult;
        //    }
        //    catch (Exception exp)
        //    {
        //        return default(T);
        //    }
        //}
        #endregion
    }
}
