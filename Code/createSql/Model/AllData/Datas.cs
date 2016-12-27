using System;
namespace createSql.Model
{
    /// <summary>
    /// Datas:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Datas
    {
        public Datas()
        { }
        #region Model
        private string _columnname;
        private string _value;
        private int? _cancelsignupnum = 0;
        /// <summary>
        /// 
        /// </summary>
        public string columnName
        {
            set { _columnname = value; }
            get { return _columnname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CancelSignUpNum
        {
            set { _cancelsignupnum = value; }
            get { return _cancelsignupnum; }
        }
        #endregion Model

    }
}

