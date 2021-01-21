using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Utils
{
    public class PageQuerySql
    {

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="orderField">分页字段</param>
        /// <param name="startNum">起始页</param>
        /// <param name="endNum">条数</param>
        /// <param name="isDesc">升序</param>
        /// <returns></returns>
        public static string GetPagedQuerySql(string sql, string orderField, int startNum, int endNum, bool isDesc)
        {
            string strSql = "";
            string strSqlTemp = "";
            if (isDesc)
            {
                strSqlTemp = " desc ";
            }
            strSql = "select * from (select row_number() over ( order by " + orderField + strSqlTemp + " ) r,* from ("
                + sql + ") t) t where t.r >= " + startNum + " and t.r < " + endNum;
            return strSql;
        }

    }
}
