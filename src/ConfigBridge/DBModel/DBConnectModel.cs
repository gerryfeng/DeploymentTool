


using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigBridge
{
   public class DBConnectModel : BaseResult
    {
        public DBConnectModel()
        {
            allSqlDir = new List<string>();
        }

        public string ip;
        public string dbName;
        public string userName;
        public string password;

        public string tableSQLDirName;
        public string inUse;
        public List<string> allSqlDir;

        public string maxConnectionRecordCount;
    }


    public class SolutionModuleTreeItem
    {
        public SolutionModuleTreeItem()
        {
            children = new List<SolutionModuleTreeItem>();
        }

        public string id;
        public string text;
        public string code;
        public string description;
        public string level;
        public string visible;
        public string iconCls;
        public List<SolutionModuleTreeItem> children;
        public bool expanded;
        public bool leaf;

        public string nodeID;
        public string menuID;

        public string menuType;
        public string clickType;
    }

    public class BaseModuleTreeItem
    {
        public BaseModuleTreeItem()
        {
            children = new List<BaseModuleTreeItem>();
        }

        public string id;
        public string text;
        public string code;
        public string description;
        public string level;
        public string visible;
        public string iconCls;
        public List<BaseModuleTreeItem> children;
        public bool expanded;
        public bool leaf;

        public string nodeID;
        public string menuID;

        public string menuType;
        public string clickType;
    }

    public class GetSolutionList : BaseResult
    {
        public string currentSolution;
        public bool disabled;
        public List<string> solutions;
    }

    public class DBConnectionInfo
    {
        public string name;

        public string dbType;

        public string dbName;

        public string ip;

        public string userName;

        public string password;
    }

    public class MongoDBConnectionInfo
    {
        public string name;

        public string dbType;

        public string dbName;

        public string ip;

        public string port;

        public string type;

        public string replicaSet;
    }

    public class MongodbDataTest
    {
        public MongodbDataTest()
        {
            time = new DateTime();
        }
        public string oper;

        public DateTime time;
    }

    public class GeTransferLogResult : BaseResult
    {
        public string content;
        public bool finish;
    }

    public class LogInfoItem
    {
        public LogInfoItem()
        {
            lastWriteTime = new DateTime();
        }
        //public ObjectId _id;
        public string context;
        public DateTime lastWriteTime;
    }

    public class UrlConnectionInfo
    {
        public string name;

        public string url;
    }
    public class DbOperationResult
    {
        public DbOperationResult()
        {
            Say = new SayClass();
            GetMe = false;
        }

        public SayClass Say { get; set; }

        public bool GetMe { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class SayClass
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class GetOMSLoginConfigResult : BaseResult
    {
        public string loginMode;
        public string loginName;
        public string password;

        public string OMSManager;
    }

    public class GetDataBaseConfigResult : BaseResult
    {
        public GetDataBaseConfigResult()
        {
            allSqlDir = new List<string>();
        }

        public string ip;
        public string dbName;
        public string userName;
        public string password;

        public string tableSQLDirName;
        public string inUse;
        public List<string> allSqlDir;

        public string maxConnectionRecordCount;
    }

    public class GetDataBaseListResult : BaseResult
    {
        public GetDataBaseListResult()
        {
            root = new List<GetDataBaseListItem>();
        }

        public List<GetDataBaseListItem> root;
    }

    public class GetDataBaseListItem
    {
        public string text;
        public string value;

        /// <summary>
        /// 0-数据库未初始化 1-数据库已初始化
        /// </summary>
        public string type;
    }

    public class ConnRecordItem
    {
        public string ip;
        public string database;
        public string user;
        public string password;
        public string saveTime;
        public string desc;
    }

    public class ConnRecordResultItem
    {
        public string ip;
        public string dbName;
        public string userName;
        public string password;
        public string saveTime;
        public string desc;
    }

   

    public class GetOMSLogResult : BaseResult
    {
        public GetOMSLogResult()
        {
            root = new List<LogItemInGrid>();
            totalProperty = 0;
        }

        public List<LogItemInGrid> root;
        public int totalProperty;
    }

    public class LogItemInGrid
    {
        public string ID;
        public string logTime;
        public string IP;
        public string functionName;
        public string label;
        public string shortInfo;
    }

    public class GetOMSLogDistinctFunctionResult : BaseResult
    {
        public GetOMSLogDistinctFunctionResult()
        {
            root = new List<GetOMSLogDistinctFunctionItem>();
        }

        public List<GetOMSLogDistinctFunctionItem> root;
    }

    public class GetOMSLogDistinctFunctionItem
    {
        public string text;
        public string value;
    }

    public class GetOMSLogDistinctIPResult : BaseResult
    {
        public GetOMSLogDistinctIPResult()
        {
            root = new List<GetOMSLogDistinctIPItem>();
        }

        public List<GetOMSLogDistinctIPItem> root;
    }

    public class GetOMSLogDistinctIPItem
    {
        public string text;
        public string value;
    }

    public class GetOMSLogDistinctLabelResult : BaseResult
    {
        public GetOMSLogDistinctLabelResult()
        {
            root = new List<GetOMSLogDistinctLabelItem>();
        }

        public List<GetOMSLogDistinctLabelItem> root;
    }

    public class GetOMSLogDistinctLabelItem
    {
        public string text;
        public string value;
    }

    public class GetOMSLogInitTimeResult : BaseResult
    {
        public string startDate;
        public string startTime;
        public string endDate;
        public string endTime;
    }

    public class GetOperationLogStateResult : BaseResult
    {
        public int operationLogState;
    }

    public class GetInitDBLogResult : BaseResult
    {
        public string content;
        public bool finish;
    }

    public class GetServiceLogInitTimeResult : BaseResult
    {
        public string queryDate;
        public string startTime;
        public string endTime;
    }

    public class GetServiceLogResult : BaseResult
    {
        public GetServiceLogResult()
        {
            root = new List<ServiceLogItem>();
            totalProperty = 0;
        }

        public List<ServiceLogItem> root;
        public int totalProperty;
    }

    public class ServiceLogItem
    {
        public string ID;
        public string logTime;
        public string IP;
        public string operation;
        public string module;
        public string useTime;
        public string logType;
        public string description;
    }

    public class GetServiceLogNewResult : BaseResult
    {
        public GetServiceLogNewResult()
        {
            root = new List<ServiceLogNewItem>();
            totalProperty = 0;
        }

        public List<ServiceLogNewItem> root;
        public int totalProperty;
    }

    public class ServiceLogNewItem
    {
        public string ID;
        public string logTime;
        public string IP;
        public string operation;
        public string module;
        public string useTime;
        public string logType;
        public string description;
        public string method;
        public string user;
        public string url;
    }

    public class GetServiceLogDistinctFunctionResult : BaseResult
    {
        public GetServiceLogDistinctFunctionResult()
        {
            root = new List<GetServiceLogDistinctFunctionItem>();
        }

        public List<GetServiceLogDistinctFunctionItem> root;
    }

    public class GetServiceLogDistinctFunctionItem
    {
        public string text;
        public string value;
    }

    public class VersionValidItem
    {
        public string file;
        public string fileMD5;
        public string calMD5;
        public string lastWriteTime;
        public string state;
    }

    public class ExecuteDataTableResult : BaseResult
    {
        public ExecuteDataTableResult()
        {
            dataArray = new List<List<string>>();
            fieldList = new List<string>();
        }

        public List<List<string>> dataArray;
        public string store;
        public string gridPanel;
        public List<string> fieldList;
    }

    public class GetLoginLogResult : BaseResult
    {
        public GetLoginLogResult()
        {
            root = new List<LoginLogItem>();
            totalProperty = 0;
        }

        public List<LoginLogItem> root;
        public int totalProperty;
    }

    public class LoginLogItem
    {
        public string ID;
        public string loginName;
        public string userName;
        public string systemType;
        public string terminal;
        public string IP;
        public string logTime;
    }

    public class LoginComonResult : BaseResult
    {
        public LoginComonResult()
        {
            root = new List<LoginCommonItem>();
        }

        public List<LoginCommonItem> root;
    }

    public class LoginCommonItem
    {
        public string text;
        public string value;
    }

    public class MQConfig
    {
        public string key;
        public string value;
    }
}
