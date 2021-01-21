using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.DTO.IOTTools;
using Web.Models.IOTPlatform.IOTTools;
using Web.Repository.IOTTolls;
using Web.Utils.IOTTools;

namespace Web.Services.IOTPlatform.IOTTools
{

    public class DataCoverService : IDataCoverService
    {

        //每次操作条数
        private int Number = 10000;

        //任务执行百分比
        private static Dictionary<string,DataCoverResult> resultDictionary = new Dictionary<string,DataCoverResult>();

        /// <summary>
        /// 获取竖表信息
        /// </summary>
        /// <param name="ConnectionStr"></param>
        /// <param name="SiteCodes"></param>
        /// <returns></returns>
        public async Task<HistoryCountReslut> HistoryInfoMation(string ConnectionStr,string SiteCodes)
        {
            IOTToolsRepository toolsRepository = new IOTToolsRepository(ConnectionStr);

            //获取设备类型,站点及传感器
            List<DbIotEquipType> IotEquipTypes = await Task.Run(() => toolsRepository.dbIotEquipTypes.ToList());

            if (!string.IsNullOrEmpty(SiteCodes))
            {
                SiteCodes = string.Join(",", SiteCodes.Split(',').Select(tn => $"'{tn}'"));
                string stationSQL = string.Format(@" select * from scada_station where Code in ({0}) ",SiteCodes);
                List<DbIotScation> scations = await Task.Run(() => toolsRepository.dbIotScations.FromSqlRaw(stationSQL).ToList());
                List<int> typeIDs = scations.Select(x => x.LedgerID).Distinct().ToList();
                if (typeIDs.Count > 0) IotEquipTypes = IotEquipTypes.Where(t => typeIDs.Contains(t.ID)).ToList();
            }

            foreach (DbIotEquipType equipType in IotEquipTypes) 
            {
                //获取设备类型表对应的列名
               string dbAddressNameSQL = string.Format(" SELECT COLUMN_NAME 名称 FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME= '{0}'", equipType.HistoryTableName);
               List<AddressEnress> AddresList = await Task.Run(() => toolsRepository.dbAddressName.FromSqlRaw(dbAddressNameSQL).ToList());
               List<string> Cloums = AddresList.Select(t => t.Name).Where(x => !(x.Contains("设备编码") || x.Contains("采集时间"))).ToList();
               equipType.AddressEntrss = Cloums.ToList();
            }
           
            //获取竖表信息
            string sql = " SELECT ( SELECT rows FROM sysindexes WHERE id = OBJECT_ID('[dbo].[SCADA_SensorHistory]') AND indid < 2 ) 总数,  MAX(PT) [起始时间] ,MIN(PT) [结束时间] FROM SCADA_SensorHistory ";
            HistoryCountReslut  countReslut = await Task.Run(() => toolsRepository.countResluts.FromSqlRaw(sql).ToList().First());
            countReslut.Keys = Guid.NewGuid().ToString();
           
            //开始执行异步任务
            if (IotEquipTypes.Count>0) RunWithTasksAsync(IotEquipTypes, countReslut, ConnectionStr,SiteCodes);

            return countReslut;
        }


        /// <summary>
        /// 开始异步任务
        /// </summary>
        /// <returns></returns>
        private async Task RunWithTasksAsync(List<DbIotEquipType> dbIotEquipTypes, HistoryCountReslut historyCountReslut,string ConnectionStr,string SiteCodes) {

            if (dbIotEquipTypes.Count <= 0 || historyCountReslut == null) 
                return;

            //计算执行周期总次数,以及每次执行时间段
            //计算拆分份数,是否可以整除，不能整除+1
            int count = historyCountReslut.CountNumber % Number == 0 ? historyCountReslut.CountNumber / Number : historyCountReslut.CountNumber / Number + 1;

            //拆分时间间隔,计算每个时间段毫秒数
            TimeSpan difTime = historyCountReslut.startTime - historyCountReslut.endTime;
            int TimeCycle = (int)(difTime.TotalSeconds % count == 0 ? difTime.TotalSeconds / count : difTime.TotalSeconds / count + 1);

            DateTime startTime = historyCountReslut.startTime;
            DateTime endTime = historyCountReslut.endTime;

            List<Dictionary<DateTime, DateTime>> timeDataList = new List<Dictionary<DateTime, DateTime>>();

            for (int i = 0; i < count; i++)
            {
                Dictionary<DateTime, DateTime> times = new Dictionary<DateTime, DateTime>();

                    //计算当前时间段末尾时间
                    DateTime time = startTime.AddSeconds(-TimeCycle);
                    //当前时间小于最小时间
                    if (time < endTime) {
                       time = endTime;
                    }

                    times.Add(startTime,time);
                    timeDataList.Add(times);

                    if (time == endTime)
                        break;
                    startTime = time;
            }

            DataCoverResult coverResult = new DataCoverResult {
                TotalNum = timeDataList.Count * dbIotEquipTypes.Count
            };
            string keys = historyCountReslut.Keys;
            resultDictionary.Add(keys, coverResult);

            dbIotEquipTypes.All(equipType =>
            {
                AddTypeCallL(equipType, historyCountReslut, ConnectionStr, SiteCodes,timeDataList);
                return true;
            });
        }


        private async Task AddTypeCallL(DbIotEquipType equipType, HistoryCountReslut historyCountReslut,string ConnectionStr,string SiteCodes, List<Dictionary<DateTime, DateTime>> timeDataList)
        {
                try
                {
                    CallLater _Call = null;
                    _Call = new CallLater(o =>
                    {
                        string keys = historyCountReslut.Keys;
                        DataCoverResult coverResult = resultDictionary[keys];
                        foreach (Dictionary<DateTime, DateTime> pairs in timeDataList) {
                            try
                            {
                                foreach (KeyValuePair<DateTime, DateTime> kvp in pairs)
                                {
                                    Console.WriteLine("开始时间：{0},结束时间：{1}", kvp.Key, kvp.Value);
                                    DataCoverAysc(equipType, kvp.Key, kvp.Value, SiteCodes, ConnectionStr);

                                    coverResult.Time = kvp.Value.ToString();
                                }
                                coverResult.CurrentNum = ++coverResult.CurrentNum;
                                coverResult.percentage = ((double)coverResult.CurrentNum/coverResult.TotalNum).ToString("0.00%");
                                resultDictionary[keys] = coverResult;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("错误:" + e.ToString());
                            }
                        }
                    }, null,Timeout.Infinite);
                    _Call?.Later(Convert.ToInt32(5000));
                }
                catch (Exception e)
                {
                  Console.WriteLine("erro" + e.ToString());
                }
        }


        /// <summary>
        ///  数据转换
        /// </summary>
        /// <param name="equipType">设备类型</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="SiteCodes">设备编码</param>
        /// <param name="ConnectionStr">数据库连接</param>
        /// <returns></returns>
        private async Task DataCoverAysc(DbIotEquipType equipType,DateTime startTime,DateTime endTime,string SiteCodes,string ConnectionStr) {

            string commandText;
            string begin = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string end = endTime.ToString("yyyy-MM-dd HH:mm:ss");

            commandText = "create table #temp_History( 设备编码 varchar(50), 名称 varchar(50), PV float, 采集时间 datetime );\n" +
                "insert into #temp_History ( 设备编码, 名称, PV, 采集时间)\n";

            commandText +=  $"  select sa.CODE 设备编码 , sor.Name 名称, sh.PV, sh.PT 采集时间 \n" +
                            $" from SCADA_Station sa \n" +
                            $" JOIN SCADA_Sensor sor ON sa.ID = sor.StationID\n" +
                            $" JOIN SCADA_SensorHistory sh ON sh.SensorID = sor.ID \n" +
                            $" WHERE (sor.是否删除 != 1 OR sor.是否删除 IS NULL) \n" +
                            $"  AND sa.LedgerID = '{equipType.ID}' \n" +
                            $"  AND sh.PT > '{end}'\n" +
                            $"  AND sh.PT <= '{begin}'";

            if (!string.IsNullOrEmpty(SiteCodes))
                commandText += $" AND sa.CODE in ({ SiteCodes }) ";

            using (DbConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();

                    //根据设备编码和PT 组合数据
                    string colums = string.Join(",", equipType.AddressEntrss.Select(tn => $"[{tn}]"));
                    command.CommandText = $" select * from #temp_History AS tem PIVOT ( SUM ( tem.pv ) FOR tem.名称 IN ({ colums })) AS T ORDER BY 设备编码 ";
                    try
                    {
                        DataTable dt = new DataTable();
                        using (DbDataReader dataReader = command.ExecuteReader())
                        {
                            if (!dataReader.HasRows) return;

                            dt.Load(dataReader);
                            if (dt.Rows.Count <= 0) return;

                            DataTableToSQLServer(dt, equipType.HistoryTableName, ConnectionStr);
                        }
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        Console.WriteLine("转换异常:" + e.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName">表名</param>
        /// <param name="ConnectionStr">数据库名</param>
        /// <returns></returns>
        public async Task DataTableToSQLServer(DataTable dt, string tableName,string ConnectionStr)
        {
            using (SqlConnection destinationConnection = new SqlConnection(ConnectionStr))
            {
                destinationConnection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = tableName;//要插入的表的表名
                        bulkCopy.BatchSize = dt.Rows.Count;
                        foreach (DataColumn col in dt.Columns)
                        {
                            //映射字段名 DataTable列名 ,数据库 对应的列名
                            bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }
                        bulkCopy.WriteToServer(dt);
                        destinationConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        destinationConnection.Close();
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }



        /// <summary>
        /// 获取当前任务执行进度
        /// </summary>
        /// <returns></returns>
        public async Task<DataCoverResult> GetDataCover(string keys)
        {
            return resultDictionary[keys];
        }
    }


}
