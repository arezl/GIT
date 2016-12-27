using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using createSql.Model;

namespace createSql.DAL
{
    /// <summary>
    /// 数据访问类:Datas
    /// </summary>
    public partial class DatasDal
    {
        public DatasDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string columnName, string Value, int CancelSignUpNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Datas");
            strSql.Append(" where columnName=@columnName and Value=@Value and CancelSignUpNum=@CancelSignUpNum ");
            SqlParameter[] parameters = {
                    new SqlParameter("@columnName", SqlDbType.VarChar,300),
                    new SqlParameter("@Value", SqlDbType.VarChar,300),
                    new SqlParameter("@CancelSignUpNum", SqlDbType.Int,4)           };
            parameters[0].Value = columnName;
            parameters[1].Value = Value;
            parameters[2].Value = CancelSignUpNum;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistscolumnName(string columnName )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Datas");
            strSql.Append(" where columnName=@columnName   ");
            SqlParameter[] parameters = {
                    new SqlParameter("@columnName", SqlDbType.VarChar,300),
                      };
            parameters[0].Value = columnName;
         

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Datas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Datas(");
            strSql.Append("columnName,Value,CancelSignUpNum)");
            strSql.Append(" values (");
            strSql.Append("@columnName,@Value,@CancelSignUpNum)");
            SqlParameter[] parameters = {
                    new SqlParameter("@columnName", SqlDbType.VarChar,300),
                    new SqlParameter("@Value", SqlDbType.VarChar,300),
                    new SqlParameter("@CancelSignUpNum", SqlDbType.Int,4)};
            parameters[0].Value = model.columnName;
            parameters[1].Value = model.Value;
            parameters[2].Value = model.CancelSignUpNum;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Datas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Datas set ");
            strSql.Append("columnName=@columnName,");
            strSql.Append("Value=@Value,");
            strSql.Append("CancelSignUpNum=@CancelSignUpNum");
            strSql.Append(" where columnName=@columnName   ");
            SqlParameter[] parameters = {
                    new SqlParameter("@columnName", SqlDbType.VarChar,300),
                    new SqlParameter("@Value", SqlDbType.VarChar,300),
                    new SqlParameter("@CancelSignUpNum", SqlDbType.Int,4)};
            parameters[0].Value = model.columnName;
            parameters[1].Value = model.Value;
            parameters[2].Value = model.CancelSignUpNum;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string columnName, string Value, int CancelSignUpNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Datas ");
            strSql.Append(" where columnName=@columnName and Value=@Value and CancelSignUpNum=@CancelSignUpNum ");
            SqlParameter[] parameters = {
                    new SqlParameter("@columnName", SqlDbType.VarChar,300),
                    new SqlParameter("@Value", SqlDbType.VarChar,300),
                    new SqlParameter("@CancelSignUpNum", SqlDbType.Int,4)           };
            parameters[0].Value = columnName;
            parameters[1].Value = Value;
            parameters[2].Value = CancelSignUpNum;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Datas GetModel(string columnName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 columnName,Value,CancelSignUpNum from Datas ");
            strSql.Append(" where columnName=@columnName  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@columnName", SqlDbType.VarChar,300),
                              };
            parameters[0].Value = columnName;
           

            Datas model = new Datas();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Datas DataRowToModel(DataRow row)
        {
            Datas model = new Datas();
            if (row != null)
            {
                if (row["columnName"] != null)
                {
                    model.columnName = row["columnName"].ToString();
                }
                if (row["Value"] != null)
                {
                    model.Value = row["Value"].ToString();
                }
                if (row["CancelSignUpNum"] != null && row["CancelSignUpNum"].ToString() != "")
                {
                    model.CancelSignUpNum = int.Parse(row["CancelSignUpNum"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select columnName,Value,CancelSignUpNum ");
            strSql.Append(" FROM Datas ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" columnName,Value,CancelSignUpNum ");
            strSql.Append(" FROM Datas ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Datas ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CancelSignUpNum desc");
            }
            strSql.Append(")AS Row, T.*  from Datas T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Datas";
			parameters[1].Value = "CancelSignUpNum";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

