using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
    public class SqliteHelper
    {
        public static string ConnectionString { get; set; }

        private static SqliteConnection Connection;

        //public SqliteHelper()
        //{
        //    ConnectionString = "Data Source=d:/dapperTest.db";
        //}


        private static SqliteConnection CreateConnection()
        {
            if (Connection == null)
                Connection = new SqliteConnection(ConnectionString);

            return Connection;
        }

        public static SqliteTransaction GetTransaction()
        {
            return CreateConnection().BeginTransaction();
        }

        private static void PrepareCommand(SqliteCommand command, SqliteConnection connection, SqliteTransaction transaction, CommandType commandType, string commandText, SqliteParameter[] parms)
        {
            if (connection.State != ConnectionState.Open) connection.Open();

            command.Connection = connection;
            //command.CommandTimeout = CommandTimeOut;
            // 设置命令文本(存储过程名或SQL语句)
            command.CommandText = commandText;
            // 分配事务
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            // 设置命令类型.
            command.CommandType = commandType;
            if (parms != null && parms.Length > 0)
            {
                //预处理SqlParameter参数数组，将为NULL的参数赋值为DBNull.Value;
                foreach (SqliteParameter parameter in parms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
                command.Parameters.AddRange(parms);
            }
        }

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string commandText, params SqliteParameter[] parms)
        {
            return ExecuteNonQuery(CreateConnection(), commandText, parms);
        }

        public static int ExecuteNonQuery(SqliteConnection connection, string commandText, params SqliteParameter[] parms)
        {
            return ExecuteNonQuery(connection, CommandType.Text, commandText, parms);
        }

        /// <summary>
        /// 执行SQL语句,返回影响的行数
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="commandType">命令类型(存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">SQL语句或存储过程名称</param>
        /// <param name="parms">查询参数</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(SqliteConnection connection, CommandType commandType, string commandText, params SqliteParameter[] parms)
        {
            return ExecuteNonQuery(connection, null, commandType, commandText, parms);
        }

        /// <summary>
        /// 执行SQL语句,返回影响的行数
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型(存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">SQL语句或存储过程名称</param>
        /// <param name="parms">查询参数</param>
        /// <returns>返回影响的行数</returns>
        public static int ExecuteNonQuery(SqliteTransaction transaction, CommandType commandType, string commandText, params SqliteParameter[] parms)
        {
            return ExecuteNonQuery(transaction.Connection, transaction, commandType, commandText, parms);

        }

        /// <summary>
        /// 执行SQL语句,返回影响的行数
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型(存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">SQL语句或存储过程名称</param>
        /// <param name="parms">查询参数</param>
        /// <returns>返回影响的行数</returns>
        private static int ExecuteNonQuery(SqliteConnection connection, SqliteTransaction transaction, CommandType commandType, string commandText, params SqliteParameter[] parms)
        {
            SqliteCommand command = new SqliteCommand();
            PrepareCommand(command, connection, transaction, commandType, commandText, parms);
            int retval = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return retval;
        }

        #endregion ExecuteNonQuery

        #region ExecuteScalar
        /// <summary>
        /// 执行SQL语句,返回结果集中的第一行第一列
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parms">查询参数</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public static object ExecuteScalar(string commandText, params SqliteParameter[] parms)
        {
            return ExecuteScalar(CreateConnection(), commandText, parms);
        }

        public static object ExecuteScalar(SqliteConnection connection, string commandText, SqliteParameter[] parms)
        {
            return ExecuteScalar(connection, CommandType.Text, commandText, parms);
        }

        public static object ExecuteScalar(SqliteConnection connection, CommandType commandType, string commandText, SqliteParameter[] parms)
        {
            SqliteCommand command = new SqliteCommand();
            PrepareCommand(command, connection, null, commandType, commandText, parms);
            object retval = command.ExecuteScalar();
            command.Parameters.Clear();
            return retval;
        }


        #endregion

        #region ExecuteDataSet
        //public static DataSet ExecuteDataSet(string commandText, params SqliteParameter[] parms)
        //{
        //    return ExecuteDataSet(CreateConnection(), commandText, parms);
        //}

        //public static DataSet ExecuteDataSet(SqliteConnection connection, string commandText, SqliteParameter[] parms)
        //{
        //    return ExecuteDataSet(connection, CommandType.Text, commandText, parms);
        //}

        //public static DataSet ExecuteDataSet(SqliteConnection connection, CommandType commandType, string commandText, SqliteParameter[] parms)
        //{
        //    return ExecuteDataSet(connection, null, commandType, commandText, parms);
        //}

        ///// <summary>
        ///// 执行SQL语句,返回结果集
        ///// </summary>
        ///// <param name="transaction">事务</param>
        ///// <param name="commandType">命令类型(存储过程,命令文本, 其它.)</param>
        ///// <param name="commandText">SQL语句或存储过程名称</param>
        ///// <param name="parms">查询参数</param>
        ///// <returns>返回结果集</returns>
        //public static DataSet ExecuteDataSet(SqliteTransaction transaction, CommandType commandType, string commandText, params SqliteParameter[] parms)
        //{
        //    return ExecuteDataSet(transaction.Connection, transaction, commandType, commandText, parms);
        //}

        //private static DataSet ExecuteDataSet(SqliteConnection connection, SqliteTransaction transaction, CommandType commandType, string commandText, SqliteParameter[] parms)
        //{
        //    SqliteCommand command = new SqliteCommand();
        //    PrepareCommand(command, connection, transaction, commandType, commandText, parms);
        //    SqliteDataAdapter adapter = new SqliteDataAdapter(command);
        //    DataSet ds = new DataSet();
        //    adapter.Fill(ds);
        //    command.Parameters.Clear();
        //    return ds;
        //}
        #endregion

        // public static void Close()
        //{
        //    if (Connection != null && Connection.State == ConnectionState.Open)
        //    {
        //        Connection.Close();
        //        SqliteConnection.ClearPool(Connection);//清除连接池，否则数据库文件不会被释放。
        //    }
        //}

    }


}
