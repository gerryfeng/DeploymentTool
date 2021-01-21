using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigBridge
{
    public class OMSState
    {

        private static Dictionary<string, string> m_state = null;

        public static Dictionary<string, string> State
        {
            get
            {
                if (m_state != null)
                {
                    for (int i = 0; i < defaultState.Count; i++)
                    {
                        if (!m_state.ContainsKey(defaultState.ElementAt(i).Key))
                        {
                            m_state.Add(defaultState.ElementAt(i).Key, defaultState.ElementAt(i).Value);
                        }
                    }

                    return m_state;
                }
                else
                {
                    if (File.Exists(OMSPath.pathOMSConfig + "OMSState.txt"))
                    {
                        m_state = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(OMSPath.pathOMSConfig + "OMSState.txt"));
                    }
                    else
                    {
                        m_state = new Dictionary<string, string>();
                    }

                    for (int i = 0; i < defaultState.Count; i++)
                    {
                        if (!m_state.ContainsKey(defaultState.ElementAt(i).Key))
                        {
                            m_state.Add(defaultState.ElementAt(i).Key, defaultState.ElementAt(i).Value);
                        }
                    }

                    return m_state;
                }
            }
        }

        public static void RefreshOMSState()
        {

            if (File.Exists(OMSPath.pathOMSConfig + "OMSState.txt"))
            {
                m_state = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(OMSPath.pathOMSConfig + "OMSState.txt"));

                if(m_state == null)
                {
                    Console.Write("/OMS/OMSState.txt文件中内容为空");
                    throw new Exception("/OMS/OMSState.txt文件中内容为空！");
                }
            }
            else
            {
                m_state = new Dictionary<string, string>();
            }

            for (int i = 0; i < defaultState.Count; i++)
            {
                if (!m_state.ContainsKey(defaultState.ElementAt(i).Key))
                {
                    m_state.Add(defaultState.ElementAt(i).Key, defaultState.ElementAt(i).Value);
                }
            }

           // Utility.ToolSaveFile(OMSPath.pathOMSConfig + "OMSState.txt");

            File.WriteAllText(OMSPath.pathOMSConfig + "OMSState.txt", JsonConvert.SerializeObject(m_state, Formatting.Indented));
        }

        public static void SetOMSState(string key, string value)
        {
            if (File.Exists(OMSPath.pathOMSConfig + "OMSState.txt"))
            {
                m_state = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(OMSPath.pathOMSConfig + "OMSState.txt"));
            }
            else
            {
                m_state = new Dictionary<string, string>();
            }

            if (m_state.ContainsKey(key))
            {
                m_state[key] = value;
            }
            else
            {
                m_state.Add(key, value);
            }

           // Utility.ToolSaveFile(OMSPath.pathOMSConfig + "OMSState.txt");

            File.WriteAllText(OMSPath.pathOMSConfig + "OMSState.txt", JsonConvert.SerializeObject(m_state, Formatting.Indented));
        }

        //运维系统状态设置的名称及其默认值
        private static Dictionary<string, string> defaultState = new Dictionary<string, string>()
        {
            //是否记录运维操作日志 0-仅记录部分输入输出 1-记录输入输出和中间信息 2-不记录，此变量由omsa用户通过界面操作进行维护
            {"RecordOperationLog","0"},

            //初始化数据库时，增量脚本使用的文件夹名称，此变量由omsa用户通过界面操作进行维护
            {"TableSQLDirName","产品方案 (WebGIS 巡检工单)"},

            //解决方案管理-验证与更新功能，在验证文件时，是否使用排除性列表，0 - 不使用，1 - 使用，此变量由omsa用户通过界面操作进行维护
            {"UseExclusionForValidFiles","1"},

            //近期保存的数据库连接数目上限，此变量由omsa用户通过界面操作进行维护
            {"MaxConnectionRecordCount","30"},

            //是否对CityServer.OMS.dll进行md5码校验，0 - 不使用，其它值 - 使用，此变量手动维护
            {"CheckOMSDLL","1"},

            //是否在关键节点（非强制状态）自动备份数据库中的运维表，1 - 备份，其它值 - 不备份，此变量手动维护
            {"AutoSaveDatabase","1"},

            //初始化数据库时，是否添加约束，1 - 添加，其它值 - 不添加，此变量手动维护
            {"InitDatabaseUseCheck","1"},

            //用户密码方案 0 - 无限制，1 - 复杂密码
            {"UserPasswordSolution", "0"},

            //是否检查目录中存在SVN更新冲突，以及global.js中项目目录有多行未注释
            {"CheckSVNState","1"},

            //工单流程中心 展示设置，0 - 展示全部，1 - 展示表/字段、事件，2 - 全都隐藏
            { "CaseManager", "0"},
        };
    }
}
