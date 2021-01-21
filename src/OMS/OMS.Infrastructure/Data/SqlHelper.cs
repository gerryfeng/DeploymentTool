using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OMS.Infrastructure
{
     public class SqlHelper
    {
        private static string sql = "";

        public static bool ConnectionTest(string ip, string dbName, string userName, string password, out string errMsg)
        {
            DataTable dt = new DataTable();
            errMsg = "";
            try
            {
                ip = ip.Trim();
                dbName = dbName.Trim();
                userName = userName.Trim();
                password = password.Trim();

                using (SqlConnection connection = new SqlConnection("server=" + ip + ";database='" + dbName + "';User id=" + userName + ";password=" + password + ";Integrated Security=false"))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT Name FROM SysObjects Where XType='U' ORDER BY Name";
                        command.CommandTimeout = 10;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);

                        command.Dispose();
                    }

                    connection.Close();
                    connection.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        public static int ExecuteNonQuery(string sql, string connString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string ExecuteScalar(string sql, string connString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        object o = command.ExecuteScalar();
                        if (o != null && o != DBNull.Value)
                            return command.ExecuteScalar().ToString();
                        else
                            return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static DataTable ExecuteDataTable(string sql, string connString)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ExecuteNonQuery(List<string> sqlList, string connString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;

                        for (int i = 0; i < sqlList.Count; i++)
                        {
                            sql = sqlList[i];
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        #region DataTable转换为List集合
        /// <summary>
        /// 将DataTable转换为list集合
        /// </summary>
        /// <typeparam name="T">要解析的实体类型</typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> DataTableToIList<T>(DataTable dataTable)
        {
            // 返回值初始化 
            List<T> result = new List<T>();

            if (dataTable == null || dataTable.Rows.Count == 0) return result;

            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (pi.Name.ToUpper().Equals(dataTable.Columns[i].ColumnName.ToUpper()))
                        {
                            try
                            {
                                // 数据库NULL值单独处理 
                                if (dataTable.Rows[j][i] != DBNull.Value)
                                {
                                    var objValue = dataTable.Rows[j][i];
                                    if (pi.PropertyType != dataTable.Columns[i].DataType)
                                    {
                                        objValue = ChangeType(dataTable.Rows[j][i], pi.PropertyType);
                                    }
                                    pi.SetValue(_t, objValue, null);
                                }
                                else
                                {
                                    //若为null此处可默认为属性赋初始值
                                    pi.SetValue(_t, null, null);
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(string.Format("{0},{1}", pi.Name, ex.Message));
                            }
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        /// <summary>
        /// 判断实体中是否有枚举类型、List<T>等
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        static public object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;

            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }

            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }

            if (value is string && type == typeof(Guid)) return new Guid(value as string);

            if (value is string && type == typeof(Version)) return new Version(value as string);

            if (!(value is IConvertible)) return value;

            return Convert.ChangeType(value, type);
        }
        #endregion

    }
}
