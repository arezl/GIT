using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using createSql.Model.CrSql;

namespace createSql.Model
{
    class PublicInfo
    {
        public static string ConfigPath = "Config.ini";

        public static string ICodeModelPath = "CodeModelPath.ini";

        public static List<WordModel> AllColumnModes { get; internal set; }
        public static TableModel TalbeModel { get; internal set; }
        public static string TalbeName { get; internal set; }
    }
}
