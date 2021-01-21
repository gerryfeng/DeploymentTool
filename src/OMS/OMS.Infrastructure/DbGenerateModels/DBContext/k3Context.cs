using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1.Models
{
    public partial class k3Context : DbContext
    {
        public k3Context()
        {
        }

        public k3Context(DbContextOptions<k3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Attenddetail> Attenddetails { get; set; }
        public virtual DbSet<AttrAudit> AttrAudits { get; set; }
        public virtual DbSet<CivCommonAttachment> CivCommonAttachments { get; set; }
        public virtual DbSet<CivDma用户台账表> CivDma用户台账表s { get; set; }
        public virtual DbSet<CivGdCaseback> CivGdCasebacks { get; set; }
        public virtual DbSet<CivGdCasedelay> CivGdCasedelays { get; set; }
        public virtual DbSet<CivGdPatrolevent> CivGdPatrolevents { get; set; }
        public virtual DbSet<CivGdWxCaseFlow> CivGdWxCaseFlows { get; set; }
        public virtual DbSet<CivGdWxCaseback> CivGdWxCasebacks { get; set; }
        public virtual DbSet<CivGdWxFeedback> CivGdWxFeedbacks { get; set; }
        public virtual DbSet<CivGdWxMaterialBiz> CivGdWxMaterialBizs { get; set; }
        public virtual DbSet<CivGdWxMaterialLib> CivGdWxMaterialLibs { get; set; }
        public virtual DbSet<CivGdWxReport> CivGdWxReports { get; set; }
        public virtual DbSet<CivGisgatherElement> CivGisgatherElements { get; set; }
        public virtual DbSet<CivGisgatherProject> CivGisgatherProjects { get; set; }
        public virtual DbSet<CivMobileMetadatum> CivMobileMetadata { get; set; }
        public virtual DbSet<CivMonitorLive> CivMonitorLives { get; set; }
        public virtual DbSet<CivOutputAuthority> CivOutputAuthorities { get; set; }
        public virtual DbSet<CivPatrolArea> CivPatrolAreas { get; set; }
        public virtual DbSet<CivPatrolAttProject> CivPatrolAttProjects { get; set; }
        public virtual DbSet<CivPatrolAttReport> CivPatrolAttReports { get; set; }
        public virtual DbSet<CivPatrolCheck> CivPatrolChecks { get; set; }
        public virtual DbSet<CivPatrolCycle> CivPatrolCycles { get; set; }
        public virtual DbSet<CivPatrolEventreport> CivPatrolEventreports { get; set; }
        public virtual DbSet<CivPatrolFeedback> CivPatrolFeedbacks { get; set; }
        public virtual DbSet<CivPatrolFeedbackDic> CivPatrolFeedbackDics { get; set; }
        public virtual DbSet<CivPatrolFilter> CivPatrolFilters { get; set; }
        public virtual DbSet<CivPatrolKeypoint> CivPatrolKeypoints { get; set; }
        public virtual DbSet<CivPatrolLog> CivPatrolLogs { get; set; }
        public virtual DbSet<CivPatrolNote> CivPatrolNotes { get; set; }
        public virtual DbSet<CivPatrolPlan> CivPatrolPlans { get; set; }
        public virtual DbSet<CivPatrolPlanLayer> CivPatrolPlanLayers { get; set; }
        public virtual DbSet<CivPatrolPlanPoint> CivPatrolPlanPoints { get; set; }
        public virtual DbSet<CivPatrolTask> CivPatrolTasks { get; set; }
        public virtual DbSet<CivPatrolTaskPoint> CivPatrolTaskPoints { get; set; }
        public virtual DbSet<Civrolemenu> Civrolemenus { get; set; }
        public virtual DbSet<DbstandardHistory> DbstandardHistories { get; set; }
        public virtual DbSet<Dma免费注册用户台账表> Dma免费注册用户台账表s { get; set; }
        public virtual DbSet<Dma分区表> Dma分区表s { get; set; }
        public virtual DbSet<Dma布点信息表> Dma布点信息表s { get; set; }
        public virtual DbSet<Dma建设过程表> Dma建设过程表s { get; set; }
        public virtual DbSet<Dma总表关系表> Dma总表关系表s { get; set; }
        public virtual DbSet<Dma户表关系表> Dma户表关系表s { get; set; }
        public virtual DbSet<Dma漏损月统计表> Dma漏损月统计表s { get; set; }
        public virtual DbSet<Dynamicpainting> Dynamicpaintings { get; set; }
        public virtual DbSet<ErrLog> ErrLogs { get; set; }
        public virtual DbSet<Especialarea> Especialareas { get; set; }
        public virtual DbSet<Eventinfo> Eventinfos { get; set; }
        public virtual DbSet<Eventtype> Eventtypes { get; set; }
        public virtual DbSet<FlowActivityPara> FlowActivityParas { get; set; }
        public virtual DbSet<FlowCaseinfo> FlowCaseinfos { get; set; }
        public virtual DbSet<FlowCasemeeting> FlowCasemeetings { get; set; }
        public virtual DbSet<FlowCasemeetingdetail> FlowCasemeetingdetails { get; set; }
        public virtual DbSet<FlowDepoist> FlowDepoists { get; set; }
        public virtual DbSet<FlowEntrust> FlowEntrusts { get; set; }
        public virtual DbSet<FlowEntrustTask> FlowEntrustTasks { get; set; }
        public virtual DbSet<FlowFuncodelib> FlowFuncodelibs { get; set; }
        public virtual DbSet<FlowGroup> FlowGroups { get; set; }
        public virtual DbSet<FlowGroupmanege> FlowGroupmaneges { get; set; }
        public virtual DbSet<FlowGroupsAdmin> FlowGroupsAdmins { get; set; }
        public virtual DbSet<FlowHoliday> FlowHolidays { get; set; }
        public virtual DbSet<FlowInstanceLog> FlowInstanceLogs { get; set; }
        public virtual DbSet<FlowLabel> FlowLabels { get; set; }
        public virtual DbSet<FlowLabelsetting> FlowLabelsettings { get; set; }
        public virtual DbSet<FlowOsfuncodelib> FlowOsfuncodelibs { get; set; }
        public virtual DbSet<FlowProcessPara> FlowProcessParas { get; set; }
        public virtual DbSet<FlowRoleFlow> FlowRoleFlows { get; set; }
        public virtual DbSet<FlowRolePurview> FlowRolePurviews { get; set; }
        public virtual DbSet<FlowStepHistory> FlowStepHistories { get; set; }
        public virtual DbSet<FlowSupervision> FlowSupervisions { get; set; }
        public virtual DbSet<FlowUser> FlowUsers { get; set; }
        public virtual DbSet<FlowUserFrozen> FlowUserFrozens { get; set; }
        public virtual DbSet<FlowUserHistory> FlowUserHistories { get; set; }
        public virtual DbSet<FlowUserRole> FlowUserRoles { get; set; }
        public virtual DbSet<Flowctrltbl> Flowctrltbls { get; set; }
        public virtual DbSet<Flowdoingcase> Flowdoingcases { get; set; }
        public virtual DbSet<Flownode> Flownodes { get; set; }
        public virtual DbSet<Flownodeextend> Flownodeextends { get; set; }
        public virtual DbSet<Flowrule> Flowrules { get; set; }
        public virtual DbSet<Flowtemprla> Flowtemprlas { get; set; }
        public virtual DbSet<Flowtemprna> Flowtemprnas { get; set; }
        public virtual DbSet<Functionrelation> Functionrelations { get; set; }
        public virtual DbSet<Fwsetting> Fwsettings { get; set; }
        public virtual DbSet<Gis工程角色管理表> Gis工程角色管理表s { get; set; }
        public virtual DbSet<Holidaytbl> Holidaytbls { get; set; }
        public virtual DbSet<Jianloudetail> Jianloudetails { get; set; }
        public virtual DbSet<Landflowglob> Landflowglobs { get; set; }
        public virtual DbSet<LayerRoleInfo> LayerRoleInfos { get; set; }
        public virtual DbSet<LayerRoleRoleLayer> LayerRoleRoleLayers { get; set; }
        public virtual DbSet<LayerRoleUserLayerRole> LayerRoleUserLayerRoles { get; set; }
        public virtual DbSet<Leaveapprovetbl> Leaveapprovetbls { get; set; }
        public virtual DbSet<Materiallisttbl> Materiallisttbls { get; set; }
        public virtual DbSet<MfWrxattachment> MfWrxattachments { get; set; }
        public virtual DbSet<MfWrxattachmentfolder> MfWrxattachmentfolders { get; set; }
        public virtual DbSet<MfWsattachment> MfWsattachments { get; set; }
        public virtual DbSet<NotificationInfoHistory> NotificationInfoHistories { get; set; }
        public virtual DbSet<NotificationInfoReal> NotificationInfoReals { get; set; }
        public virtual DbSet<NotificationNoticeHistory> NotificationNoticeHistories { get; set; }
        public virtual DbSet<NotificationStatus> NotificationStatuses { get; set; }
        public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public virtual DbSet<Notification消息模板表> Notification消息模板表s { get; set; }
        public virtual DbSet<Notification消息配置表> Notification消息配置表s { get; set; }
        public virtual DbSet<PatrolEquip> PatrolEquips { get; set; }
        public virtual DbSet<PatrolEventinfo> PatrolEventinfos { get; set; }
        public virtual DbSet<PatrolFbbaseinfo> PatrolFbbaseinfos { get; set; }
        public virtual DbSet<PatrolFbresult> PatrolFbresults { get; set; }
        public virtual DbSet<PatrolPhone> PatrolPhones { get; set; }
        public virtual DbSet<PatrolPlanarea> PatrolPlanareas { get; set; }
        public virtual DbSet<PatrolPlancycle> PatrolPlancycles { get; set; }
        public virtual DbSet<PatrolPlanflow> PatrolPlanflows { get; set; }
        public virtual DbSet<PatrolPlanpath> PatrolPlanpaths { get; set; }
        public virtual DbSet<PatrolPlantbl> PatrolPlantbls { get; set; }
        public virtual DbSet<PatrolPlantype> PatrolPlantypes { get; set; }
        public virtual DbSet<PatrolTaskunit> PatrolTaskunits { get; set; }
        public virtual DbSet<Patrolhistory> Patrolhistories { get; set; }
        public virtual DbSet<Patrolman> Patrolmen { get; set; }
        public virtual DbSet<PatrolmanWorktime> PatrolmanWorktimes { get; set; }
        public virtual DbSet<Patrolmanlog> Patrolmanlogs { get; set; }
        public virtual DbSet<Patrolmil> Patrolmils { get; set; }
        public virtual DbSet<Patrolpositon> Patrolpositons { get; set; }
        public virtual DbSet<Patrolshortmessage> Patrolshortmessages { get; set; }
        public virtual DbSet<Patrolstatistic> Patrolstatistics { get; set; }
        public virtual DbSet<PointAddress> PointAddresses { get; set; }
        public virtual DbSet<PointAddressEntry> PointAddressEntries { get; set; }
        public virtual DbSet<Recoveryuser> Recoveryusers { get; set; }
        public virtual DbSet<Relationoumenu> Relationoumenus { get; set; }
        public virtual DbSet<ScadaAlertFeedBack> ScadaAlertFeedBacks { get; set; }
        public virtual DbSet<ScadaAlertHistory> ScadaAlertHistories { get; set; }
        public virtual DbSet<ScadaAlertInfo> ScadaAlertInfos { get; set; }
        public virtual DbSet<ScadaAlertValue> ScadaAlertValues { get; set; }
        public virtual DbSet<ScadaDataKind> ScadaDataKinds { get; set; }
        public virtual DbSet<ScadaSensor> ScadaSensors { get; set; }
        public virtual DbSet<ScadaSensorHistory> ScadaSensorHistories { get; set; }
        public virtual DbSet<ScadaSensorHistoryTemp> ScadaSensorHistoryTemps { get; set; }
        public virtual DbSet<ScadaSensorRealTime> ScadaSensorRealTimes { get; set; }
        public virtual DbSet<ScadaSensorRealTimeTemp> ScadaSensorRealTimeTemps { get; set; }
        public virtual DbSet<ScadaSensorType> ScadaSensorTypes { get; set; }
        public virtual DbSet<ScadaStation> ScadaStations { get; set; }
        public virtual DbSet<ScadaStationAttention> ScadaStationAttentions { get; set; }
        public virtual DbSet<ScadaStationDivision> ScadaStationDivisions { get; set; }
        public virtual DbSet<ScadaStationType> ScadaStationTypes { get; set; }
        public virtual DbSet<Scada远程控制控制权限配置表> Scada远程控制控制权限配置表s { get; set; }
        public virtual DbSet<Scada远程控制控制配置表> Scada远程控制控制配置表s { get; set; }
        public virtual DbSet<Scada远程控制权限配置更新日志> Scada远程控制权限配置更新日志s { get; set; }
        public virtual DbSet<Scada远程控制远程控制操作日志> Scada远程控制远程控制操作日志s { get; set; }
        public virtual DbSet<Superviseinfo> Superviseinfos { get; set; }
        public virtual DbSet<SvcLog> SvcLogs { get; set; }
        public virtual DbSet<Sysdatadictionary> Sysdatadictionaries { get; set; }
        public virtual DbSet<Sysmenutree> Sysmenutrees { get; set; }
        public virtual DbSet<Syspagetool> Syspagetools { get; set; }
        public virtual DbSet<Syspurview> Syspurviews { get; set; }
        public virtual DbSet<Syspurviewtype> Syspurviewtypes { get; set; }
        public virtual DbSet<Syssequencetbl> Syssequencetbls { get; set; }
        public virtual DbSet<Systablerelastion> Systablerelastions { get; set; }
        public virtual DbSet<Sysucwidget> Sysucwidgets { get; set; }
        public virtual DbSet<Taskservice> Taskservices { get; set; }
        public virtual DbSet<Tianchongcitbl> Tianchongcitbls { get; set; }
        public virtual DbSet<Upfileslist> Upfileslists { get; set; }
        public virtual DbSet<Userlayerpurview> Userlayerpurviews { get; set; }
        public virtual DbSet<Userleavelog> Userleavelogs { get; set; }
        public virtual DbSet<Userloginfo> Userloginfos { get; set; }
        public virtual DbSet<Userstatetype> Userstatetypes { get; set; }
        public virtual DbSet<ValveRecord> ValveRecords { get; set; }
        public virtual DbSet<WebMapMarkTbl> WebMapMarkTbls { get; set; }
        public virtual DbSet<Widgetfilter> Widgetfilters { get; set; }
        public virtual DbSet<Worktimeset> Worktimesets { get; set; }
        public virtual DbSet<ZdbwfJoint> ZdbwfJoints { get; set; }
        public virtual DbSet<ZdbwfTempnodebussatt> ZdbwfTempnodebussatts { get; set; }
        public virtual DbSet<ZdbwfTempright> ZdbwfTemprights { get; set; }
        public virtual DbSet<事件漏点处理事件表> 事件漏点处理事件表s { get; set; }
        public virtual DbSet<事件维修处理事件表> 事件维修处理事件表s { get; set; }
        public virtual DbSet<导出cad权限表> 导出cad权限表s { get; set; }
        public virtual DbSet<导出cad记录表> 导出cad记录表s { get; set; }
        public virtual DbSet<巡检关键点记录表> 巡检关键点记录表s { get; set; }
        public virtual DbSet<巡检消防栓记录表> 巡检消防栓记录表s { get; set; }
        public virtual DbSet<巡检管段记录表> 巡检管段记录表s { get; set; }
        public virtual DbSet<巡检维修事件表> 巡检维修事件表s { get; set; }
        public virtual DbSet<巡检阀门记录表> 巡检阀门记录表s { get; set; }
        public virtual DbSet<工单事件关联表> 工单事件关联表s { get; set; }
        public virtual DbSet<工单事件工单关联表> 工单事件工单关联表s { get; set; }
        public virtual DbSet<工单事件模板表> 工单事件模板表s { get; set; }
        public virtual DbSet<工单事件流程配置表> 工单事件流程配置表s { get; set; }
        public virtual DbSet<工单事件辅助视图配置表> 工单事件辅助视图配置表s { get; set; }
        public virtual DbSet<工单事件配置表> 工单事件配置表s { get; set; }
        public virtual DbSet<工单功能集成配置表> 工单功能集成配置表s { get; set; }
        public virtual DbSet<工单历史操作记录表> 工单历史操作记录表s { get; set; }
        public virtual DbSet<工单台账模型配置表> 工单台账模型配置表s { get; set; }
        public virtual DbSet<工单周期反馈配置表> 工单周期反馈配置表s { get; set; }
        public virtual DbSet<工单时限规则配置表> 工单时限规则配置表s { get; set; }
        public virtual DbSet<工单时限记录表> 工单时限记录表s { get; set; }
        public virtual DbSet<工单材料使用表> 工单材料使用表s { get; set; }
        public virtual DbSet<工单材料库表> 工单材料库表s { get; set; }
        public virtual DbSet<工单材料配置表> 工单材料配置表s { get; set; }
        public virtual DbSet<工单步骤反馈配置表> 工单步骤反馈配置表s { get; set; }
        public virtual DbSet<工单流程状态表> 工单流程状态表s { get; set; }
        public virtual DbSet<工单流程节点配置表> 工单流程节点配置表s { get; set; }
        public virtual DbSet<工单流程辅助视图配置表> 工单流程辅助视图配置表s { get; set; }
        public virtual DbSet<工单流程配置表> 工单流程配置表s { get; set; }
        public virtual DbSet<工单漏点处理工单表> 工单漏点处理工单表s { get; set; }
        public virtual DbSet<工单用户关注表> 工单用户关注表s { get; set; }
        public virtual DbSet<工单维修处理工单表> 工单维修处理工单表s { get; set; }
        public virtual DbSet<工单表字段覆盖配置表> 工单表字段覆盖配置表s { get; set; }
        public virtual DbSet<工单表字段配置表> 工单表字段配置表s { get; set; }
        public virtual DbSet<工单表配置表> 工单表配置表s { get; set; }
        public virtual DbSet<工单设备反馈配置表> 工单设备反馈配置表s { get; set; }
        public virtual DbSet<工单设备编辑配置表> 工单设备编辑配置表s { get; set; }
        public virtual DbSet<工程现场上报表> 工程现场上报表s { get; set; }
        public virtual DbSet<报表方案配置表> 报表方案配置表s { get; set; }
        public virtual DbSet<报表条件配置表> 报表条件配置表s { get; set; }
        public virtual DbSet<报表视图子句配置表> 报表视图子句配置表s { get; set; }
        public virtual DbSet<报表视图配置表> 报表视图配置表s { get; set; }
        public virtual DbSet<报警传感器配置表> 报警传感器配置表s { get; set; }
        public virtual DbSet<报警地址方案配置表> 报警地址方案配置表s { get; set; }
        public virtual DbSet<报警多指标and缓存记录表传感器> 报警多指标and缓存记录表传感器s { get; set; }
        public virtual DbSet<报警多指标and缓存记录表地址方案> 报警多指标and缓存记录表地址方案s { get; set; }
        public virtual DbSet<报警多指标and缓存记录表设备类型> 报警多指标and缓存记录表设备类型s { get; set; }
        public virtual DbSet<报警多指标or缓存记录表传感器> 报警多指标or缓存记录表传感器s { get; set; }
        public virtual DbSet<报警多指标or缓存记录表地址方案> 报警多指标or缓存记录表地址方案s { get; set; }
        public virtual DbSet<报警多指标or缓存记录表设备类型> 报警多指标or缓存记录表设备类型s { get; set; }
        public virtual DbSet<报警方案配置表> 报警方案配置表s { get; set; }
        public virtual DbSet<报警记录表> 报警记录表s { get; set; }
        public virtual DbSet<报警设备类型配置表> 报警设备类型配置表s { get; set; }
        public virtual DbSet<探漏探漏结果表> 探漏探漏结果表s { get; set; }
        public virtual DbSet<探漏测试方案表> 探漏测试方案表s { get; set; }
        public virtual DbSet<探漏设备挂接表> 探漏设备挂接表s { get; set; }
        public virtual DbSet<数据历史二供机组> 数据历史二供机组s { get; set; }
        public virtual DbSet<数据历史二供泵房> 数据历史二供泵房s { get; set; }
        public virtual DbSet<数据历史便携式流量计> 数据历史便携式流量计s { get; set; }
        public virtual DbSet<数据历史便携式流量计1> 数据历史便携式流量计1s { get; set; }
        public virtual DbSet<数据历史便携式流量计2> 数据历史便携式流量计2s { get; set; }
        public virtual DbSet<数据历史压力表> 数据历史压力表s { get; set; }
        public virtual DbSet<数据历史户表> 数据历史户表s { get; set; }
        public virtual DbSet<数据历史数据模板表> 数据历史数据模板表s { get; set; }
        public virtual DbSet<数据历史水厂> 数据历史水厂s { get; set; }
        public virtual DbSet<数据历史水源井> 数据历史水源井s { get; set; }
        public virtual DbSet<数据历史流量计> 数据历史流量计s { get; set; }
        public virtual DbSet<数据历史熊猫水表> 数据历史熊猫水表s { get; set; }
        public virtual DbSet<数据实时二供机组> 数据实时二供机组s { get; set; }
        public virtual DbSet<数据实时二供泵房> 数据实时二供泵房s { get; set; }
        public virtual DbSet<数据实时便携式流量计> 数据实时便携式流量计s { get; set; }
        public virtual DbSet<数据实时压力表> 数据实时压力表s { get; set; }
        public virtual DbSet<数据实时户表> 数据实时户表s { get; set; }
        public virtual DbSet<数据实时数据模板表> 数据实时数据模板表s { get; set; }
        public virtual DbSet<数据实时水厂> 数据实时水厂s { get; set; }
        public virtual DbSet<数据实时水源井> 数据实时水源井s { get; set; }
        public virtual DbSet<数据实时流量计> 数据实时流量计s { get; set; }
        public virtual DbSet<数据实时熊猫水表> 数据实时熊猫水表s { get; set; }
        public virtual DbSet<数据统计二供机组> 数据统计二供机组s { get; set; }
        public virtual DbSet<数据统计二供泵房> 数据统计二供泵房s { get; set; }
        public virtual DbSet<数据统计便携式流量计> 数据统计便携式流量计s { get; set; }
        public virtual DbSet<数据统计压力表> 数据统计压力表s { get; set; }
        public virtual DbSet<数据统计周期脚本配置表> 数据统计周期脚本配置表s { get; set; }
        public virtual DbSet<数据统计户表> 数据统计户表s { get; set; }
        public virtual DbSet<数据统计数据模板表> 数据统计数据模板表s { get; set; }
        public virtual DbSet<数据统计水厂> 数据统计水厂s { get; set; }
        public virtual DbSet<数据统计水源井> 数据统计水源井s { get; set; }
        public virtual DbSet<数据统计流量计> 数据统计流量计s { get; set; }
        public virtual DbSet<数据统计熊猫水表> 数据统计熊猫水表s { get; set; }
        public virtual DbSet<数据统计配置表> 数据统计配置表s { get; set; }
        public virtual DbSet<用户登录记录表> 用户登录记录表s { get; set; }
        public virtual DbSet<监控二供巡检台账表> 监控二供巡检台账表s { get; set; }
        public virtual DbSet<监控二供水箱清洗台账表> 监控二供水箱清洗台账表s { get; set; }
        public virtual DbSet<监控二供水质检测台账表> 监控二供水质检测台账表s { get; set; }
        public virtual DbSet<监控二供泵房维修事件表> 监控二供泵房维修事件表s { get; set; }
        public virtual DbSet<监控二供泵房维修工单表> 监控二供泵房维修工单表s { get; set; }
        public virtual DbSet<监控二供维保台账表> 监控二供维保台账表s { get; set; }
        public virtual DbSet<监控二供维修台账表> 监控二供维修台账表s { get; set; }
        public virtual DbSet<组态属性表> 组态属性表s { get; set; }
        public virtual DbSet<组态模型信息表> 组态模型信息表s { get; set; }
        public virtual DbSet<组态模型类型表> 组态模型类型表s { get; set; }
        public virtual DbSet<组态模型表> 组态模型表s { get; set; }
        public virtual DbSet<组态画板> 组态画板s { get; set; }
        public virtual DbSet<组态画板类型表> 组态画板类型表s { get; set; }
        public virtual DbSet<组态设备配置表> 组态设备配置表s { get; set; }
        public virtual DbSet<维修处理反馈表> 维修处理反馈表s { get; set; }
        public virtual DbSet<维修处理工单表> 维修处理工单表s { get; set; }
        public virtual DbSet<设备信息台账模板表> 设备信息台账模板表s { get; set; }
        public virtual DbSet<设备关系配置表> 设备关系配置表s { get; set; }
        public virtual DbSet<设备养护任务模板表> 设备养护任务模板表s { get; set; }
        public virtual DbSet<设备养护关键点> 设备养护关键点s { get; set; }
        public virtual DbSet<设备养护区域表> 设备养护区域表s { get; set; }
        public virtual DbSet<设备养护反馈配置表> 设备养护反馈配置表s { get; set; }
        public virtual DbSet<设备养护周期表> 设备养护周期表s { get; set; }
        public virtual DbSet<设备养护审核表> 设备养护审核表s { get; set; }
        public virtual DbSet<设备养护调压器记录表> 设备养护调压器记录表s { get; set; }
        public virtual DbSet<设备养护配置表> 设备养护配置表s { get; set; }
        public virtual DbSet<设备养护阀门记录表> 设备养护阀门记录表s { get; set; }
        public virtual DbSet<设备匹配分析结论表> 设备匹配分析结论表s { get; set; }
        public virtual DbSet<设备台账二供机组> 设备台账二供机组s { get; set; }
        public virtual DbSet<设备台账二供泵房> 设备台账二供泵房s { get; set; }
        public virtual DbSet<设备台账便携式流量计> 设备台账便携式流量计s { get; set; }
        public virtual DbSet<设备台账压力表> 设备台账压力表s { get; set; }
        public virtual DbSet<设备台账户表> 设备台账户表s { get; set; }
        public virtual DbSet<设备台账模板表> 设备台账模板表s { get; set; }
        public virtual DbSet<设备台账水厂> 设备台账水厂s { get; set; }
        public virtual DbSet<设备台账水源井> 设备台账水源井s { get; set; }
        public virtual DbSet<设备台账流量计> 设备台账流量计s { get; set; }
        public virtual DbSet<设备台账熊猫水表> 设备台账熊猫水表s { get; set; }
        public virtual DbSet<设备型号台账表> 设备型号台账表s { get; set; }
        public virtual DbSet<设备巡维保任务表> 设备巡维保任务表s { get; set; }
        public virtual DbSet<设备巡维保计划表> 设备巡维保计划表s { get; set; }
        public virtual DbSet<设备门禁信息表> 设备门禁信息表s { get; set; }
        public virtual DbSet<配置地图复位范围配置表> 配置地图复位范围配置表s { get; set; }
        public virtual DbSet<配置巡维保计划模板表> 配置巡维保计划模板表s { get; set; }
        public virtual DbSet<配置物联设备类型配置表> 配置物联设备类型配置表s { get; set; }
        public virtual DbSet<配置系统信息表> 配置系统信息表s { get; set; }
        public virtual DbSet<配置视频信息表> 配置视频信息表s { get; set; }
        public virtual DbSet<配置设备信息拓展表> 配置设备信息拓展表s { get; set; }
        public virtual DbSet<配置设备分组关系表> 配置设备分组关系表s { get; set; }
        public virtual DbSet<配置设备指标配置表> 配置设备指标配置表s { get; set; }
        public virtual DbSet<配置设备监控模型配置表> 配置设备监控模型配置表s { get; set; }
        public virtual DbSet<阀门任务表> 阀门任务表s { get; set; }
        public virtual DbSet<阀门台账表> 阀门台账表s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=k3;User ID=sa;Password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attenddetail>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__ATTENDDE__C49703DE7F60ED59");

                entity.ToTable("ATTENDDETAIL");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0")
                    .HasComment("主键(主键)");

                entity.Property(e => e.Aftintime)
                    .HasColumnType("datetime")
                    .HasColumnName("AFTINTIME")
                    .HasComment("下午登陆时间");

                entity.Property(e => e.Aftisabsence)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AFTISABSENCE")
                    .HasComment("下午是否缺勤（0：否；1或空：是）");

                entity.Property(e => e.Aftislate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AFTISLATE")
                    .HasComment("下午是否迟到（0：否；1或空：是）");

                entity.Property(e => e.Aftisleave)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AFTISLEAVE")
                    .HasComment("下午是否早退（0：否；1或空：是）");

                entity.Property(e => e.Aftofftime)
                    .HasColumnType("datetime")
                    .HasColumnName("AFTOFFTIME")
                    .HasComment("下午退出时间");

                entity.Property(e => e.Groupcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUPCODE")
                    .HasComment("用户机构代码");

                entity.Property(e => e.Isholiday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISHOLIDAY")
                    .HasComment("是否是假期（0：否；1或空：是）");

                entity.Property(e => e.Mornintime)
                    .HasColumnType("datetime")
                    .HasColumnName("MORNINTIME")
                    .HasComment("上午登陆时间");

                entity.Property(e => e.Mornisabsence)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MORNISABSENCE")
                    .HasComment("上午是否缺勤（0：否；1或空：是）");

                entity.Property(e => e.Mornislate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MORNISLATE")
                    .HasComment("上午是否迟到（0：否；1或空：是）");

                entity.Property(e => e.Mornisleave)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MORNISLEAVE")
                    .HasComment("上午是否早退（0：否；1或空：是）");

                entity.Property(e => e.Mornofftime)
                    .HasColumnType("datetime")
                    .HasColumnName("MORNOFFTIME")
                    .HasComment("上午退出时间");

                entity.Property(e => e.Nowdate)
                    .HasColumnType("datetime")
                    .HasColumnName("NOWDATE")
                    .HasComment("当天日期");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME")
                    .HasComment("用户姓名姓名");
            });

            modelBuilder.Entity<AttrAudit>(entity =>
            {
                entity.ToTable("ATTR_AUDIT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO")
                    .HasComment("CASENO");

                entity.Property(e => e.EventId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_ID")
                    .HasComment("EVENT_ID");

                entity.Property(e => e.几何类型)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("几何类型");

                entity.Property(e => e.几何范围)
                    .HasColumnType("text")
                    .HasComment("几何范围");

                entity.Property(e => e.原值)
                    .HasColumnType("text")
                    .HasComment("原值");

                entity.Property(e => e.图层标识)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("图层标识");

                entity.Property(e => e.审核人)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("审核人");

                entity.Property(e => e.审核信息)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("审核信息");

                entity.Property(e => e.审核时间)
                    .HasColumnType("datetime")
                    .HasComment("审核时间");

                entity.Property(e => e.审核状态)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("审核状态");

                entity.Property(e => e.属性字段)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("属性字段");

                entity.Property(e => e.描述)
                    .HasColumnType("text")
                    .HasComment("描述");

                entity.Property(e => e.提交人)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("提交人");

                entity.Property(e => e.提交人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("提交人部门");

                entity.Property(e => e.提交时间)
                    .HasColumnType("datetime")
                    .HasComment("提交时间");

                entity.Property(e => e.操作)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("操作");

                entity.Property(e => e.操作名称)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("操作名称");

                entity.Property(e => e.新值)
                    .HasColumnType("text")
                    .HasComment("新值");

                entity.Property(e => e.设备标识)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("设备标识");
            });

            modelBuilder.Entity<CivCommonAttachment>(entity =>
            {
                entity.ToTable("CIV_COMMON_ATTACHMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATETIME");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILENAME");

                entity.Property(e => e.Filesize)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FILESIZE");

                entity.Property(e => e.Path)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PATH");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Userid).HasColumnName("USERID");
            });

            modelBuilder.Entity<CivDma用户台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_DMA_用户台账表");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.GisCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("gisCode");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.一卡通号)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.小区名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.更新时间)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.水价类别)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.用户名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.用户状态)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.用户类型)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.用水类别)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.联系人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.联系人电话)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.联系方式)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.营业区域)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.表册)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivGdCaseback>(entity =>
            {
                entity.ToTable("CIV_GD_CASEBACK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVENAME");

                entity.Property(e => e.Backman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BACKMAN");

                entity.Property(e => e.Backmandepart)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BACKMANDEPART");

                entity.Property(e => e.Backtime)
                    .HasColumnType("datetime")
                    .HasColumnName("BACKTIME");

                entity.Property(e => e.Caseid).HasColumnName("CASEID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REASON");
            });

            modelBuilder.Entity<CivGdCasedelay>(entity =>
            {
                entity.ToTable("CIV_GD_CASEDELAY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Applyfinishtime)
                    .HasColumnType("datetime")
                    .HasColumnName("APPLYFINISHTIME");

                entity.Property(e => e.Applygroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLYGROUP");

                entity.Property(e => e.Applyman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLYMAN");

                entity.Property(e => e.Applytime)
                    .HasColumnType("datetime")
                    .HasColumnName("APPLYTIME");

                entity.Property(e => e.Caseid).HasColumnName("CASEID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATE");

                entity.Property(e => e.Verifygroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VERIFYGROUP");

                entity.Property(e => e.Verifyman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VERIFYMAN");

                entity.Property(e => e.Verifytime)
                    .HasColumnType("datetime")
                    .HasColumnName("VERIFYTIME");
            });

            modelBuilder.Entity<CivGdPatrolevent>(entity =>
            {
                entity.ToTable("CIV_GD_PATROLEVENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Audios)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("AUDIOS");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Districtname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICTNAME");

                entity.Property(e => e.Eventclass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENTCLASS");

                entity.Property(e => e.Eventcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENTCODE");

                entity.Property(e => e.Eventsource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENTSOURCE");

                entity.Property(e => e.Eventstate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENTSTATE");

                entity.Property(e => e.Eventtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENTTYPE");

                entity.Property(e => e.Exist).HasColumnName("EXIST");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Images)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGES");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSITION");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.Reportergroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTERGROUP");

                entity.Property(e => e.Reporterid).HasColumnName("REPORTERID");

                entity.Property(e => e.Reportername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTERNAME");

                entity.Property(e => e.Reporttime)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTTIME");

                entity.Property(e => e.Taskid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TASKID");

                entity.Property(e => e.Usercode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Usertel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERTEL");
            });

            modelBuilder.Entity<CivGdWxCaseFlow>(entity =>
            {
                entity.ToTable("CIV_GD_WX_CASE_FLOW");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caseid).HasColumnName("CASEID");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATETIME");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Finishflag).HasColumnName("FINISHFLAG");
            });

            modelBuilder.Entity<CivGdWxCaseback>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_GD_WX_CASEBACK");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.原因)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.退单人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.退单人id)
                    .HasMaxLength(10)
                    .HasColumnName("退单人ID")
                    .IsFixedLength(true);

                entity.Property(e => e.退单时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<CivGdWxFeedback>(entity =>
            {
                entity.ToTable("CIV_GD_WX_FEEDBACK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caseid).HasColumnName("CASEID");

                entity.Property(e => e.上报人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("上报人ID");

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.修复时间).HasColumnType("datetime");

                entity.Property(e => e.分派人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.分派人员id).HasColumnName("分派人员ID");

                entity.Property(e => e.分派时间).HasColumnType("datetime");

                entity.Property(e => e.分派部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.处理状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.审核人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.审核人员id).HasColumnName("审核人员ID");

                entity.Property(e => e.审核时间).HasColumnType("datetime");

                entity.Property(e => e.审核部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.延期完成时间).HasColumnType("datetime");

                entity.Property(e => e.接单时间).HasColumnType("datetime");

                entity.Property(e => e.维修人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修人员id).HasColumnName("维修人员ID");

                entity.Property(e => e.维修时间).HasColumnType("datetime");

                entity.Property(e => e.维修部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.阅单时间).HasColumnType("datetime");

                entity.Property(e => e.预计完成时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<CivGdWxMaterialBiz>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_GD_WX_MATERIAL_BIZ");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料编码");

                entity.Property(e => e.Count)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("数量");

                entity.Property(e => e.Exist).HasComment("标识");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Maker)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("生产厂家");

                entity.Property(e => e.MaterialMark)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料名称");

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单价");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料规格");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料类型");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单位");
            });

            modelBuilder.Entity<CivGdWxMaterialLib>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_GD_WX_MATERIAL_LIB");

                entity.HasComment("材料库");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料编码");

                entity.Property(e => e.Count)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("数量");

                entity.Property(e => e.Exist).HasComment("标识");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Maker)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("生产厂家");

                entity.Property(e => e.MaterialMark)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("材料备注");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料名称");

                entity.Property(e => e.OperateTime)
                    .HasColumnType("datetime")
                    .HasComment("入库时间");

                entity.Property(e => e.Operator)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("入库人");

                entity.Property(e => e.OperatorId).HasComment("入库人Id");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单价");

                entity.Property(e => e.SMakerMark)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sMakerMark")
                    .HasComment("生产厂家备注");

                entity.Property(e => e.SMakerQualificaton)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sMakerQualificaton")
                    .HasComment("生产厂家资质");

                entity.Property(e => e.SPruduceTime)
                    .HasColumnType("datetime")
                    .HasColumnName("sPruduceTime")
                    .HasComment("生产日期");

                entity.Property(e => e.SQualityLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sQualityLevel")
                    .HasComment("材料质量标准");

                entity.Property(e => e.SSubType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sSubType")
                    .HasComment("材料子类型");

                entity.Property(e => e.SUseDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sUseDuration")
                    .HasComment("使用年限");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料规格");

                entity.Property(e => e.SurePriceTime)
                    .HasColumnType("datetime")
                    .HasComment("定价时间");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材料类型");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单位");
            });

            modelBuilder.Entity<CivGdWxReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_GD_WX_REPORT");

                entity.Property(e => e.Caseid).HasColumnName("CASEID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.上报人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人id).HasColumnName("上报人ID");

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.录音)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.照片)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.类型名)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivGisgatherElement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_GISGATHER_ELEMENT");

                entity.Property(e => e.ElemId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ElemID");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeomType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Images)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewAtt)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.NewGeom)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.OldAtt)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.OldGeom)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivGisgatherProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_GISGATHER_PROJECT");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CaseNO");

                entity.Property(e => e.EventCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Range)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivMobileMetadatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_MOBILE_METADATA");

                entity.Property(e => e.FieldList)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.HighlightField)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MapName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivMonitorLive>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("CIV_Monitor_Live");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.OperTime).HasColumnType("datetime");

                entity.Property(e => e.PreviewImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StreamID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivOutputAuthority>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_OUTPUT_AUTHORITY");

                entity.Property(e => e.Area).HasColumnName("AREA");

                entity.Property(e => e.Roleid).HasColumnName("ROLEID");
            });

            modelBuilder.Entity<CivPatrolArea>(entity =>
            {
                entity.ToTable("CIV_PATROL_AREA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaPolygon).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PathPolygon).IsUnicode(false);

                entity.Property(e => e.Station)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("station");

                entity.Property(e => e.UserIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UserIDs");

                entity.Property(e => e.UserNames)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolAttProject>(entity =>
            {
                entity.ToTable("CIV_PATROL_ATT_PROJECT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.入库人)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.入库时间).HasColumnType("datetime");

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.外包矩形)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.完结人)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.工程名称)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.是否导出过点线表)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('否')");

                entity.Property(e => e.是否采集完成).HasDefaultValueSql("((0))");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.采集人)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<CivPatrolAttReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_ATT_REPORT");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeomType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalGeom)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NewAtt)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.NewGeom)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OldAtt)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.OldGeom)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.TotalLayer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolCheck>(entity =>
            {
                entity.ToTable("CIV_PATROL_CHECK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CheckTime).HasColumnType("datetime");

                entity.Property(e => e.CheckerId).HasColumnName("CheckerID");

                entity.Property(e => e.CheckerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人id).HasColumnName("上报人ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolCycle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_CYCLE");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolEventreport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_EVENTREPORT");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AttachedId).HasColumnName("AttachedID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Desciption)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventSource)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PointId).HasColumnName("PointID");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportTime).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CivPatrolFeedback>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_FEEDBACK");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PointId).HasColumnName("PointID");

                entity.Property(e => e.Value).IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolFeedbackDic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_FEEDBACK_DIC");

                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValues)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FeedbackType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilterId).HasColumnName("FilterID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
            });

            modelBuilder.Entity<CivPatrolFilter>(entity =>
            {
                entity.ToTable("CIV_PATROL_FILTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LayerFilter)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolKeypoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_KEYPOINT");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Geometry)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolLog>(entity =>
            {
                entity.ToTable("CIV_PATROL_LOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报日期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.填报人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.日志描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolNote>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_NOTE");

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.NoteTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CivPatrolPlan>(entity =>
            {
                entity.ToTable("CIV_PATROL_PLAN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatorDept)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CycleId).HasColumnName("CycleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FilterIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FilterIDs");

                entity.Property(e => e.FilterNames)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeedId).HasColumnName("SeedID");

                entity.Property(e => e.StartMonth)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StartWeek)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartWeekday)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Station)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Time1)
                    .HasColumnType("datetime")
                    .HasColumnName("time1");

                entity.Property(e => e.Time2)
                    .HasColumnType("datetime")
                    .HasColumnName("time2");

                entity.Property(e => e.Travel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UserIDs");

                entity.Property(e => e.UserNames)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolPlanLayer>(entity =>
            {
                entity.ToTable("CIV_PATROL_PLAN_LAYERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fields)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LayerId).HasColumnName("LayerID");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");
            });

            modelBuilder.Entity<CivPatrolPlanPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIV_PATROL_PLAN_POINT");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GisLayer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolTask>(entity =>
            {
                entity.ToTable("CIV_PATROL_TASK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.CheckId).HasColumnName("CheckID");

                entity.Property(e => e.CheckState)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CycleId).HasColumnName("CycleID");

                entity.Property(e => e.CycleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FilterId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FilterID");

                entity.Property(e => e.FilterName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Station)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TaskState)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFbsum).HasColumnName("TotalFBSum");

                entity.Property(e => e.Travel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIds)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UserIDs");

                entity.Property(e => e.UserNames)
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CivPatrolTaskPoint>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("CIV_PATROL_TASK_POINT");

                //entity.HasIndex(e => new { e.Type, e.IsArrive, e.ArriveTime }, "ArriveIndex");

                //entity.HasIndex(e => new { e.Type, e.IsFeedback, e.FeedbackTime }, "FeedBackIndex");

                //entity.HasIndex(e => e.TaskId, "TaskID")
                //    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArriveTime).HasColumnType("datetime");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.FeedbackTime).HasColumnType("datetime");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Geom)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.GisLayer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Remark1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remark2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remark3)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.Type).HasComment("1 点 2线 3区");
            });

            modelBuilder.Entity<Civrolemenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CIVROLEMENU");

                entity.Property(e => e.菜单id).HasColumnName("菜单ID");

                entity.Property(e => e.角色id).HasColumnName("角色ID");
            });

            modelBuilder.Entity<DbstandardHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DBStandardHistory");

                entity.Property(e => e.Content).IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Represent).IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UpdateBY");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma免费注册用户台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DMA_免费注册用户台账表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.分区编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.户表名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.抄表年月)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.抄表日期).HasColumnType("datetime");

                entity.Property(e => e.用户名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma分区表>(entity =>
            {
                entity.ToTable("DMA_分区表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.关注程度)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.分区名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.分区编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.分区边界).IsUnicode(false);

                entity.Property(e => e.区域颜色)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父分区编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.瞬流监控).HasDefaultValueSql("((0))");

                entity.Property(e => e.责任人)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma布点信息表>(entity =>
            {
                entity.ToTable("DMA_布点信息表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.分区编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.材质)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.点位位置)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("内部/出口/入口");

                entity.Property(e => e.点位名称)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.点位坐标)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.点位类型)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("管网交点/布点");

                entity.Property(e => e.管径)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma建设过程表>(entity =>
            {
                entity.ToTable("DMA_建设过程表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.分区编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.建设内容)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.建设模块)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.建设环节)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.建设详情)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.责任人)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma总表关系表>(entity =>
            {
                entity.ToTable("DMA_总表关系表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.分区编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.压力指标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('压力')");

                entity.Property(e => e.备注)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.挂接说明)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.瞬流指标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('瞬时流量')");

                entity.Property(e => e.累流指标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('累计流量')");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma户表关系表>(entity =>
            {
                entity.ToTable("DMA_户表关系表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.分区编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.累流指标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('累计流量')");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dma漏损月统计表>(entity =>
            {
                entity.ToTable("DMA_漏损月统计表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.分区编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dynamicpainting>(entity =>
            {
                entity.ToTable("DYNAMICPAINTING");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Graphics)
                    .HasColumnType("text")
                    .HasColumnName("GRAPHICS")
                    .HasComment("标绘的几何图形");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .HasComment("保存的名称");
            });

            modelBuilder.Entity<ErrLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ERR_LOG");

                entity.Property(e => e.Assemblyname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASSEMBLYNAME");

                entity.Property(e => e.Event)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT");

                entity.Property(e => e.Exceptionmessage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EXCEPTIONMESSAGE");

                entity.Property(e => e.Exceptionname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXCEPTIONNAME");

                entity.Property(e => e.Filename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FILENAME");

                entity.Property(e => e.Hostname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("HOSTNAME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Linenumber).HasColumnName("LINENUMBER");

                entity.Property(e => e.Machinename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MACHINENAME");

                entity.Property(e => e.Memberaccessed)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MEMBERACCESSED");

                entity.Property(e => e.Providedfault)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROVIDEDFAULT");

                entity.Property(e => e.Providedmessage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROVIDEDMESSAGE");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME");

                entity.Property(e => e.Typename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TYPENAME");
            });

            modelBuilder.Entity<Especialarea>(entity =>
            {
                entity.HasKey(e => e.Eareaid)
                    .HasName("PK__ESPECIAL__EBB3AE1B3B75D760");

                entity.ToTable("ESPECIALAREA");

                entity.Property(e => e.Eareaid)
                    .HasColumnName("EAREAID")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Areatype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREATYPE");

                entity.Property(e => e.Areaworktype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREAWORKTYPE");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CheckerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHECKER_NAME");

                entity.Property(e => e.EareaDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EAREA_DESC");

                entity.Property(e => e.EareaName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EAREA_NAME");

                entity.Property(e => e.Earearange)
                    .HasColumnType("text")
                    .HasColumnName("EAREARANGE");

                entity.Property(e => e.EventId).HasColumnName("EVENT_ID");

                entity.Property(e => e.Geomtype).HasColumnName("GEOMTYPE");

                entity.Property(e => e.Recordtime)
                    .HasColumnType("datetime")
                    .HasColumnName("RECORDTIME");
            });

            modelBuilder.Entity<Eventinfo>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__EVENTINF__241A510C3F466844");

                entity.ToTable("EVENTINFO");

                entity.Property(e => e.EventId)
                    .HasColumnName("EVENT_ID")
                    .HasComment("事件信息ID(主键)");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.EventSid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_SID")
                    .HasComment("事件所属表中唯一ID");

                entity.Property(e => e.EventSource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_SOURCE")
                    .HasComment("事件来源");

                entity.Property(e => e.EventTypeid)
                    .HasColumnName("EVENT_TYPEID")
                    .HasComment("事件类型ID");

                entity.Property(e => e.Eventaddr)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EVENTADDR")
                    .HasComment("事件发生地址");

                entity.Property(e => e.Eventdesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EVENTDESC")
                    .HasComment("事件详情");

                entity.Property(e => e.Handlevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HANDLEVEL")
                    .HasComment("处理级别");

                entity.Property(e => e.Patrolposition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATROLPOSITION")
                    .HasComment("事件位置");

                entity.Property(e => e.ReportTime)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORT_TIME")
                    .HasComment("事件上报时间");

                entity.Property(e => e.Reporter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTER")
                    .HasComment("上报人");

                entity.Property(e => e.Reporterid)
                    .HasColumnName("REPORTERID")
                    .HasComment("事件人ID");

                entity.Property(e => e.Tel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TEL")
                    .HasComment("上报人电话");
            });

            modelBuilder.Entity<Eventtype>(entity =>
            {
                entity.ToTable("EVENTTYPE");

                entity.Property(e => e.EventTypeid)
                    .HasColumnName("EVENT_TYPEID")
                    .HasComment("事件类型ID(主键)");

                entity.Property(e => e.EventSource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_SOURCE")
                    .HasComment("事件来源（热线，上报等）");

                entity.Property(e => e.EventType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_TYPE")
                    .HasComment("事件类型（漏水，阀门丢失等）");

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .HasComment("父节点id");
            });

            modelBuilder.Entity<FlowActivityPara>(entity =>
            {
                entity.HasKey(e => new { e.活动id, e.事件号, e.参数id })
                    .HasName("PK__FLOW_ACT__58C73D415EBF139D");

                entity.ToTable("FLOW_ACTIVITY_PARA");

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.事件号)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.参数id).HasColumnName("参数ID");

                entity.Property(e => e.参数值来源)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.参数值来源类型)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.参数名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.参数方向)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.参数类型)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowCaseinfo>(entity =>
            {
                entity.HasKey(e => e.案件编号)
                    .HasName("PK__FLOW_CAS__FD21EE93628FA481");

                entity.ToTable("FLOW_CASEINFO");

                entity.Property(e => e.案件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.办结时间).HasColumnType("datetime");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.案件名称)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.申请单位)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.联系方式)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowCasemeeting>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_CAS__C49703DE6D0D32F4");

                entity.ToTable("FLOW_CASEMEETING");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Activeid).HasColumnName("ACTIVEID");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Chargemanid).HasColumnName("CHARGEMANID");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Resultopinion)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("RESULTOPINION");

                entity.Property(e => e.Starttime)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTTIME");

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Submituserid).HasColumnName("SUBMITUSERID");
            });

            modelBuilder.Entity<FlowCasemeetingdetail>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_CAS__C49703DE71D1E811");

                entity.ToTable("FLOW_CASEMEETINGDETAIL");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Meetingid0).HasColumnName("MEETINGID0");

                entity.Property(e => e.Opinion)
                    .HasColumnName("OPINION")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Opinionex)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("OPINIONEX");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATETIME");

                entity.Property(e => e.Userid).HasColumnName("USERID");
            });

            modelBuilder.Entity<FlowDepoist>(entity =>
            {
                entity.HasKey(e => e.沉淀id)
                    .HasName("PK__FLOW_DEP__98DDF55676969D2E");

                entity.ToTable("FLOW_DEPOIST");

                entity.Property(e => e.沉淀id).HasColumnName("沉淀ID");

                entity.Property(e => e.备注)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.沉淀意见)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.沉淀时间).HasColumnType("datetime");

                entity.Property(e => e.沉淀状态).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FlowEntrust>(entity =>
            {
                entity.HasKey(e => e.委托id)
                    .HasName("PK__FLOW_ENT__B8C03DA47C4F7684");

                entity.ToTable("FLOW_ENTRUST");

                entity.Property(e => e.委托id)
                    .ValueGeneratedNever()
                    .HasColumnName("委托ID");

                entity.Property(e => e.主管人id).HasColumnName("主管人ID");

                entity.Property(e => e.代理人)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.代理人id).HasColumnName("代理人ID");

                entity.Property(e => e.取消日期).HasColumnType("datetime");

                entity.Property(e => e.备注)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.委托人)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.委托人id).HasColumnName("委托人ID");

                entity.Property(e => e.委托日期).HasColumnType("datetime");

                entity.Property(e => e.委托类型)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.生效日期).HasColumnType("datetime");
            });

            modelBuilder.Entity<FlowEntrustTask>(entity =>
            {
                entity.HasKey(e => new { e.委托id, e.活动id })
                    .HasName("PK__FLOW_ENT__06659B2704E4BC85");

                entity.ToTable("FLOW_ENTRUST_TASK");

                entity.Property(e => e.委托id).HasColumnName("委托ID");

                entity.Property(e => e.活动id).HasColumnName("活动ID");
            });

            modelBuilder.Entity<FlowFuncodelib>(entity =>
            {
                entity.HasKey(e => new { e.事件号, e.活动id })
                    .HasName("PK__FLOW_FUN__009FB6EE09A971A2");

                entity.ToTable("FLOW_FUNCODELIB");

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.Formid).HasColumnName("FORMID");

                entity.Property(e => e.Pagetoolcodes)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PAGETOOLCODES");

                entity.Property(e => e.事件名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.备用1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.备用2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.页面url)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("页面URL");
            });

            modelBuilder.Entity<FlowGroup>(entity =>
            {
                entity.HasKey(e => e.机构id);

                entity.ToTable("FLOW_GROUPS");

                //entity.HasIndex(e => e.编码, "UNIQUE_FLOW_GROUPS_CODE")
                //    .IsUnique();

                entity.Property(e => e.机构id)
                    .ValueGeneratedNever()
                    .HasColumnName("机构ID");

                entity.Property(e => e.Ecode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ECODE");

                entity.Property(e => e.Indexorder).HasColumnName("INDEXORDER");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Visible)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VISIBLE");

                entity.Property(e => e.功能访问规则)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.名称)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.城市)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.数据访问规则)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.行政区划)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowGroupmanege>(entity =>
            {
                entity.HasKey(e => new { e.机构用户id, e.类型, e.机构id })
                    .HasName("PK__FLOW_GRO__E2DCE2920D7A0286");

                entity.ToTable("FLOW_GROUPMANEGE");

                entity.Property(e => e.机构用户id).HasColumnName("机构用户ID");

                entity.Property(e => e.机构id).HasColumnName("机构ID");
            });

            modelBuilder.Entity<FlowGroupsAdmin>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_GRO__C49703DE151B244E");

                entity.ToTable("FLOW_GROUPS_ADMIN");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Adminlevel)
                    .HasColumnName("ADMINLEVEL")
                    .HasDefaultValueSql("((0))")
                    .HasComment("管理员级别");

                entity.Property(e => e.Admintarget)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADMINTARGET")
                    .HasComment("管理对象角色组");

                entity.Property(e => e.Admintype)
                    .HasColumnName("ADMINTYPE")
                    .HasDefaultValueSql("((1))")
                    .HasComment("管理员类型");

                entity.Property(e => e.Adminuserid)
                    .HasColumnName("ADMINUSERID")
                    .HasComment("管理员用户ID，可为空(与管理员角色互补)");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATETIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Groupcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUPCODE")
                    .HasComment("管理员角色组，可为空，与管理员用户ID互补");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");
            });

            modelBuilder.Entity<FlowHoliday>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_HOL__C49703DE1AD3FDA4");

                entity.ToTable("FLOW_HOLIDAY");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.Daydate)
                    .HasColumnType("datetime")
                    .HasColumnName("DAYDATE");

                entity.Property(e => e.Dayname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DAYNAME");

                entity.Property(e => e.Daytype).HasColumnName("DAYTYPE");

                entity.Property(e => e.Isdefaulttime).HasColumnName("ISDEFAULTTIME");

                entity.Property(e => e.Remark)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.WorktimeAftFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTIME_AFT_FROM");

                entity.Property(e => e.WorktimeAftTo)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTIME_AFT_TO");

                entity.Property(e => e.WorktimeEveFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTIME_EVE_FROM");

                entity.Property(e => e.WorktimeEveTo)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTIME_EVE_TO");

                entity.Property(e => e.WorktimeMorFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTIME_MOR_FROM");

                entity.Property(e => e.WorktimeMorTo)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTIME_MOR_TO");
            });

            modelBuilder.Entity<FlowInstanceLog>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_INS__C49703DE1EA48E88");

                entity.ToTable("FLOW_INSTANCE_LOG");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.实例名称)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.活动名称)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.活动异常描述)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.活动操作者)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.流程名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.起始时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<FlowLabel>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_LAB__C49703DE2645B050");

                entity.ToTable("FLOW_LABEL");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.图片路径)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.用户id).HasColumnName("用户ID");

                entity.Property(e => e.类型名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.类型颜色)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowLabelsetting>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_LABELSETTIN__56B3DD81");

                entity.ToTable("FLOW_LABELSETTINGS");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.标签id).HasColumnName("标签ID");

                entity.Property(e => e.案件编号)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.用户id).HasColumnName("用户ID");
            });

            modelBuilder.Entity<FlowOsfuncodelib>(entity =>
            {
                entity.HasKey(e => new { e.事件号, e.活动id })
                    .HasName("PK__FLOW_OSF__009FB6EE2BFE89A6");

                entity.ToTable("FLOW_OSFUNCODELIB");

                entity.Property(e => e.事件号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.功能名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.对象来源类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowProcessPara>(entity =>
            {
                entity.HasKey(e => new { e.流程id, e.参数id })
                    .HasName("PK__FLOW_PRO__23997F5F2FCF1A8A");

                entity.ToTable("FLOW_PROCESS_PARA");

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.参数id).HasColumnName("参数ID");

                entity.Property(e => e.参数名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.参数方向)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.参数类型)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.页面元素)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.默认值)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowRoleFlow>(entity =>
            {
                entity.HasKey(e => new { e.机构id, e.流程id })
                    .HasName("PK__FLOW_ROL__FBF46D51339FAB6E");

                entity.ToTable("FLOW_ROLE_FLOW");

                entity.Property(e => e.机构id).HasColumnName("机构ID");

                entity.Property(e => e.流程id).HasColumnName("流程ID");
            });

            modelBuilder.Entity<FlowRolePurview>(entity =>
            {
                entity.HasKey(e => new { e.活动id, e.机构id })
                    .HasName("PK__FLOW_ROL__6C5158D737703C52");

                entity.ToTable("FLOW_ROLE_PURVIEW");

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.机构id).HasColumnName("机构ID");

                entity.Property(e => e.备注)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.默认承办人)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowStepHistory>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_STE__C49703DE3B40CD36");

                entity.ToTable("FLOW_STEP_HISTORY");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Ip)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Prestep).HasColumnName("PRESTEP");

                entity.Property(e => e.States).HasColumnName("STATES");

                entity.Property(e => e.保留字段1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.保留字段2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.分组id).HasColumnName("分组ID");

                entity.Property(e => e.办结时间).HasColumnType("datetime");

                entity.Property(e => e.备注)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.工作所花时间)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.已办事件)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.延迟时间).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.承办人id).HasColumnName("承办人ID");

                entity.Property(e => e.承办意见)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.承办时间).HasColumnType("datetime");

                entity.Property(e => e.案件名称)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.案件状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.案件编号)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.母流程入口id0).HasColumnName("母流程入口ID0");

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.现状标志).HasDefaultValueSql("((1))");

                entity.Property(e => e.督办id).HasColumnName("督办ID");
            });

            modelBuilder.Entity<FlowSupervision>(entity =>
            {
                entity.HasKey(e => e.督办id)
                    .HasName("PK__FLOW_SUP__9597FC2544CA3770");

                entity.ToTable("FLOW_SUPERVISION");

                entity.Property(e => e.督办id)
                    .ValueGeneratedNever()
                    .HasColumnName("督办ID");

                entity.Property(e => e.督办人id).HasColumnName("督办人ID");

                entity.Property(e => e.督办人名称)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.督办意见)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.督办时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<FlowUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FLOW_USERS");

                entity.Property(e => e.Coordinate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COORDINATE");

                entity.Property(e => e.Ddid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ddid");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Indexorder).HasColumnName("INDEXORDER");

                entity.Property(e => e.Mark)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("mark");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.Tokenexpiration).HasColumnName("tokenexpiration");

                entity.Property(e => e.Userimge)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("USERIMGE");

                entity.Property(e => e.Wxid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("wxid");

                entity.Property(e => e.企业微信)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.名称)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.工号)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.用户id).HasColumnName("用户ID");
            });

            modelBuilder.Entity<FlowUserFrozen>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_USE__C49703DE4A8310C6");

                entity.ToTable("FLOW_USER_FROZEN");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Frozen)
                    .HasColumnName("FROZEN")
                    .HasDefaultValueSql("((1))")
                    .HasComment("冻结");

                entity.Property(e => e.Frozentime)
                    .HasColumnType("datetime")
                    .HasColumnName("FROZENTIME")
                    .HasComment("冻结时间");

                entity.Property(e => e.Operater)
                    .HasColumnName("OPERATER")
                    .HasComment("操作员");

                entity.Property(e => e.Remaek)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMAEK")
                    .HasComment("备注");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<FlowUserHistory>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOW_USE__C49703DE4F47C5E3");

                entity.ToTable("FLOW_USER_HISTORY");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.任现职时间).HasColumnType("datetime");

                entity.Property(e => e.住宅电话)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.入党年月).HasColumnType("datetime");

                entity.Property(e => e.办公室房号)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.单位)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.变更时间).HasColumnType("datetime");

                entity.Property(e => e.变更类型)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.名称)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.外语水平)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.学历)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.审核签字)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.家庭住址)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.岗位)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.工作时间).HasColumnType("datetime");

                entity.Property(e => e.工作电话)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.工号)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.所学专业)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.政治面貌)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.文化程度)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.毕业时间).HasColumnType("datetime");

                entity.Property(e => e.毕业院校)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.民族)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.现任职务)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.生日).HasColumnType("datetime");

                entity.Property(e => e.用户id).HasColumnName("用户ID");

                entity.Property(e => e.电子邮件)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.相片).HasColumnType("image");

                entity.Property(e => e.移动电话)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.籍贯)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.职称)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.职称评定时间).HasColumnType("datetime");

                entity.Property(e => e.职级)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.职能)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.行政级别)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.记录状态).HasDefaultValueSql("((1))");

                entity.Property(e => e.身份证号)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.邮政编码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.部门)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FLOW_USER_ROLE");

                entity.Property(e => e.机构id).HasColumnName("机构ID");

                entity.Property(e => e.用户id).HasColumnName("用户ID");
            });

            modelBuilder.Entity<Flowctrltbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FLOWCTRLTBL");

                entity.Property(e => e.Nextcaseno).HasColumnName("NEXTCASENO");

                entity.Property(e => e.创建人)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.创建时间).HasColumnType("datetime");

                entity.Property(e => e.备注)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.所属系统)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.流程名称)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.流程描述)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.流程时限).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.流程版本)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.编号前缀)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flowdoingcase>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__FLOWDOIN__C49703DE48CFD27E");

                entity.ToTable("FLOWDOINGCASE");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.主承办人id).HasColumnName("主承办人ID");

                entity.Property(e => e.前承办人)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.前活动)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.剩余时限).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.备注)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.延迟时间).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.承办人)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.承办人id).HasColumnName("承办人ID");

                entity.Property(e => e.承办意见)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.承办时间).HasColumnType("datetime");

                entity.Property(e => e.案件名称)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.案件状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.案件编号)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.活动名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.活动时限).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.流程名称)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flownode>(entity =>
            {
                entity.HasKey(e => e.活动id)
                    .HasName("PK__FLOWNODE__EA5A683A52593CB8");

                entity.ToTable("FLOWNODE");

                entity.Property(e => e.活动id)
                    .ValueGeneratedNever()
                    .HasColumnName("活动ID");

                entity.Property(e => e.Canend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANEND");

                entity.Property(e => e.Keynode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("KEYNODE")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Prenodes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("PRENODES");

                entity.Property(e => e.Readonly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("READONLY");

                entity.Property(e => e.Sendmsm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SENDMSM");

                entity.Property(e => e.Sendsms)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SENDSMS");

                entity.Property(e => e.会办角色id).HasColumnName("会办角色ID");

                entity.Property(e => e.办理时限).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.备注)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.子流程id).HasColumnName("子流程ID");

                entity.Property(e => e.子流程属性)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.最短时限)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.节点id).HasColumnName("节点ID");

                entity.Property(e => e.节点名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.限时提醒)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flownodeextend>(entity =>
            {
                entity.HasKey(e => e.Activeid)
                    .HasName("PK__FLOWNODEEXTEND__61316BF4");

                entity.ToTable("FLOWNODEEXTEND");

                entity.Property(e => e.Activeid)
                    .ValueGeneratedNever()
                    .HasColumnName("ACTIVEID");

                entity.Property(e => e.Istocomer).HasColumnName("ISTOCOMER");
            });

            modelBuilder.Entity<Flowrule>(entity =>
            {
                entity.HasKey(e => e.规则id)
                    .HasName("PK__FLOWRULE__264FCA6559063A47");

                entity.ToTable("FLOWRULE");

                entity.Property(e => e.规则id)
                    .ValueGeneratedNever()
                    .HasColumnName("规则ID")
                    .HasComment("规则ID(主键)");

                entity.Property(e => e.Assembly)
                    .HasColumnType("image")
                    .HasColumnName("ASSEMBLY")
                    .HasComment("编译的程序集");

                entity.Property(e => e.Iscompile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCOMPILE")
                    .HasComment("是否编译");

                entity.Property(e => e.参数列表)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.描述信息)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComment("错误信息");

                entity.Property(e => e.规则名称)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComment("规则名称");

                entity.Property(e => e.规则表达式)
                    .HasColumnType("text")
                    .HasComment("规则表达式");
            });

            modelBuilder.Entity<Flowtemprla>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FLOWTEMPRLA");

                entity.Property(e => e.Dat)
                    .HasColumnType("image")
                    .HasColumnName("DAT");

                entity.Property(e => e.Endnod).HasColumnName("ENDNOD");

                entity.Property(e => e.Len).HasColumnName("LEN");

                entity.Property(e => e.Stnod).HasColumnName("STNOD");

                entity.Property(e => e.备注)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.条件表达式)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.线id).HasColumnName("线ID");

                entity.Property(e => e.规则id).HasColumnName("规则ID");
            });

            modelBuilder.Entity<Flowtemprna>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FLOWTEMPRNA");

                entity.Property(e => e.X).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Y).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.反转图象)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.反转图象源).HasColumnType("image");

                entity.Property(e => e.备注)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.字体宽).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.字体高).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.字符尺寸).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.显示宽度).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.显示高度).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.正常图象)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.正常图象源).HasColumnType("image");

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.节点id).HasColumnName("节点ID");

                entity.Property(e => e.节点名称)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Functionrelation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FUNCTIONRELATION");

                entity.Property(e => e.Functionname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTIONNAME");

                entity.Property(e => e.Roleid).HasColumnName("ROLEID");
            });

            modelBuilder.Entity<Fwsetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FWSETTING");

                entity.Property(e => e.Catalog)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATALOG");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Keyvalue)
                    .HasColumnType("text")
                    .HasColumnName("KEYVALUE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Gis工程角色管理表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GIS_工程角色管理表");

                entity.Property(e => e.关联角色).HasMaxLength(512);

                entity.Property(e => e.工程名).HasMaxLength(512);

                entity.Property(e => e.范围).HasMaxLength(2000);

                entity.Property(e => e.解决方案).HasMaxLength(512);
            });

            modelBuilder.Entity<Holidaytbl>(entity =>
            {
                entity.ToTable("HOLIDAYTBL");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("ID");

                entity.Property(e => e.Dateend)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEEND")
                    .HasComment("节假日截止时间");

                entity.Property(e => e.Datestart)
                    .HasColumnType("datetime")
                    .HasColumnName("DATESTART")
                    .HasComment("节假日起始时间");

                entity.Property(e => e.Holidaytype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOLIDAYTYPE")
                    .HasComment("节假日类型");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");
            });

            modelBuilder.Entity<Jianloudetail>(entity =>
            {
                entity.ToTable("JIANLOUDETAIL");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("ID(主键)");

                entity.Property(e => e.EventId)
                    .HasColumnName("EVENT_ID")
                    .HasComment("外键,与EVENTINFO表关联");

                entity.Property(e => e.分公司)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("分公司");

                entity.Property(e => e.初判级别)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("初判级别");

                entity.Property(e => e.区块)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("区块");

                entity.Property(e => e.坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("坐标");

                entity.Property(e => e.日期)
                    .HasColumnType("datetime")
                    .HasComment("日期");

                entity.Property(e => e.材质)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("材质");

                entity.Property(e => e.检漏情况)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("检漏情况");

                entity.Property(e => e.漏点位置)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("漏点位置");

                entity.Property(e => e.漏点地面)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("漏点地面");

                entity.Property(e => e.漏点大小)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("漏点大小");

                entity.Property(e => e.漏点管径).HasComment("漏点管径");

                entity.Property(e => e.漏点类型)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("漏点类型");

                entity.Property(e => e.登记时间)
                    .HasColumnType("datetime")
                    .HasComment("登记时间");

                entity.Property(e => e.破损部位)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("破损部位");

                entity.Property(e => e.管径)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("管径");

                entity.Property(e => e.管线位置)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("管线位置");

                entity.Property(e => e.管线编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("管线编号");

                entity.Property(e => e.管道埋设)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("管道埋设");
            });

            modelBuilder.Entity<Landflowglob>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__LANDFLOW__C49703DE5E8A0973");

                entity.ToTable("LANDFLOWGLOB");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Coid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("COID");

                entity.Property(e => e.Decideinfo)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("DECIDEINFO");

                entity.Property(e => e.Ip)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Isdel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDEL");

                entity.Property(e => e.Jointid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("JOINTID");

                entity.Property(e => e.PresetHour)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("PRESET_HOUR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Prestep).HasColumnName("PRESTEP");

                entity.Property(e => e.States).HasColumnName("STATES");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.保留字段1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.保留字段2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.分组id).HasColumnName("分组ID");

                entity.Property(e => e.办结时间).HasColumnType("datetime");

                entity.Property(e => e.备注)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.工作所花时间)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.已办事件)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.延迟时间).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.承办人id).HasColumnName("承办人ID");

                entity.Property(e => e.承办意见)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.承办时间).HasColumnType("datetime");

                entity.Property(e => e.收费异常)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.案件名称)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.案件状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.案件编号)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.母流程入口id0).HasColumnName("母流程入口ID0");

                entity.Property(e => e.活动id).HasColumnName("活动ID");

                entity.Property(e => e.流程id).HasColumnName("流程ID");

                entity.Property(e => e.现状标志).HasDefaultValueSql("((1))");

                entity.Property(e => e.督办id).HasColumnName("督办ID");
            });

            modelBuilder.Entity<LayerRoleInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LayerRole_Info");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.LayerRoleId).HasColumnName("LayerRoleID");

                entity.Property(e => e.LayerRoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Visible)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("visible");
            });

            modelBuilder.Entity<LayerRoleRoleLayer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LayerRole_Role_Layer");

                entity.Property(e => e.LayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LayerRoleId).HasColumnName("LayerRoleID");

                entity.Property(e => e.MapServerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LayerRoleUserLayerRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LayerRole_User_LayerRole");

                entity.Property(e => e.LayerRoleId).HasColumnName("LayerRoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Leaveapprovetbl>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__LEAVEAPP__C49703DE6BE40491");

                entity.ToTable("LEAVEAPPROVETBL");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0")
                    .HasComment("主键(主键)");

                entity.Property(e => e.Applydate)
                    .HasColumnType("datetime")
                    .HasColumnName("APPLYDATE")
                    .HasComment("申请日期");

                entity.Property(e => e.Applymancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLYMANCODE")
                    .HasComment("申请人机构代码");

                entity.Property(e => e.Applymandepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLYMANDEPART")
                    .HasComment("申请人部门");

                entity.Property(e => e.Applymanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLYMANNAME")
                    .HasComment("申请人名称");

                entity.Property(e => e.Archivesdate)
                    .HasColumnType("datetime")
                    .HasColumnName("ARCHIVESDATE")
                    .HasComment("归档日期");

                entity.Property(e => e.Archivesidea)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ARCHIVESIDEA")
                    .HasComment("归档意见");

                entity.Property(e => e.Archivesmancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARCHIVESMANCODE")
                    .HasComment("归档人代码");

                entity.Property(e => e.Archivesmandepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARCHIVESMANDEPART")
                    .HasComment("归档人部门");

                entity.Property(e => e.Archivesmanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ARCHIVESMANNAME")
                    .HasComment("归档人姓名");

                entity.Property(e => e.Casename)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CASENAME")
                    .HasComment("案件名称");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO")
                    .HasComment("案件编号");

                entity.Property(e => e.Deputyappdate)
                    .HasColumnType("datetime")
                    .HasColumnName("DEPUTYAPPDATE")
                    .HasComment("副局长审批日期");

                entity.Property(e => e.Deputyappidea)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DEPUTYAPPIDEA")
                    .HasComment("副局长审批意见");

                entity.Property(e => e.Deputymancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPUTYMANCODE")
                    .HasComment("副局长机构代码");

                entity.Property(e => e.Deputymandepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPUTYMANDEPART")
                    .HasComment("副局长部门");

                entity.Property(e => e.Deputymanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPUTYMANNAME")
                    .HasComment("副局长姓名");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE")
                    .HasComment("请假终止日期");

                entity.Property(e => e.Historyflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HISTORYFLAG")
                    .HasComment("历史标记");

                entity.Property(e => e.Leaderappdate)
                    .HasColumnType("datetime")
                    .HasColumnName("LEADERAPPDATE")
                    .HasComment("局长审批日期");

                entity.Property(e => e.Leaderappidea)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("LEADERAPPIDEA")
                    .HasComment("局长审批意见");

                entity.Property(e => e.Leadercode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEADERCODE")
                    .HasComment("局长机构代码");

                entity.Property(e => e.Leaderdepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEADERDEPART")
                    .HasComment("局长部门");

                entity.Property(e => e.Leadername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEADERNAME")
                    .HasComment("局长姓名");

                entity.Property(e => e.Leavedays)
                    .HasColumnName("LEAVEDAYS")
                    .HasComment("请假天数");

                entity.Property(e => e.Leavereason)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("LEAVEREASON")
                    .HasComment("请假原因");

                entity.Property(e => e.Leavetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEAVETYPE")
                    .HasComment("请假类型");

                entity.Property(e => e.Registerdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REGISTERDATE")
                    .HasComment("登记日期");

                entity.Property(e => e.Registeridea)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("REGISTERIDEA")
                    .HasComment("登记意见");

                entity.Property(e => e.Registermancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTERMANCODE")
                    .HasComment("登记人代码");

                entity.Property(e => e.Registermandepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTERMANDEPART")
                    .HasComment("登记人部门");

                entity.Property(e => e.Registermanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTERMANNAME")
                    .HasComment("登记人姓名");

                entity.Property(e => e.Sectionappdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SECTIONAPPDATE")
                    .HasComment("部门审批日期");

                entity.Property(e => e.Sectionappidea)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONAPPIDEA")
                    .HasComment("部门审批意见");

                entity.Property(e => e.Sectionmancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONMANCODE")
                    .HasComment("部门审批人机构代码");

                entity.Property(e => e.Sectionmandepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONMANDEPART")
                    .HasComment("部门审批人部门");

                entity.Property(e => e.Sectionmanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONMANNAME")
                    .HasComment("部门审批人名称");

                entity.Property(e => e.Signdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SIGNDATE")
                    .HasComment("签收日期");

                entity.Property(e => e.Signidea)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("SIGNIDEA")
                    .HasComment("签收意见");

                entity.Property(e => e.Signmancode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNMANCODE")
                    .HasComment("签收人代码");

                entity.Property(e => e.Signmandepart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNMANDEPART")
                    .HasComment("签收人部门");

                entity.Property(e => e.Signmanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNMANNAME")
                    .HasComment("签收人姓名");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE")
                    .HasComment("请假起始日期");
            });

            modelBuilder.Entity<Materiallisttbl>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__MATERIAL__C49703DE6FB49575");

                entity.ToTable("MATERIALLISTTBL");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Casename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CASENAME")
                    .HasComment("案件名称");

                entity.Property(e => e.Flowid)
                    .HasColumnName("FLOWID")
                    .HasComment("流程编号");

                entity.Property(e => e.Ismust)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISMUST")
                    .HasComment("是和否");

                entity.Property(e => e.Materialid)
                    .HasColumnName("MATERIALID")
                    .HasComment("材料编号(非空)");

                entity.Property(e => e.Materialname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MATERIALNAME")
                    .HasComment("材料名称");

                entity.Property(e => e.Pagecontent)
                    .HasColumnName("PAGECONTENT")
                    .HasComment("材料页数");

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1")
                    .HasComment("备用1");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2")
                    .HasComment("备用2");

                entity.Property(e => e.Upmaterialtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPMATERIALTYPE")
                    .HasComment("上传文件类型（是窗口上传得扫描件，还是流程中上传的文件）");
            });

            modelBuilder.Entity<MfWrxattachment>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__MF_WRXAT__C49703DE73852659");

                entity.ToTable("MF_WRXATTACHMENT");

                entity.Property(e => e.Id0)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID0")
                    .HasComment("ID");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CASENO")
                    .HasComment("案卷编号");

                entity.Property(e => e.Extractcode)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("EXTRACTCODE")
                    .HasComment("文件提取码");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILENAME")
                    .HasComment("文件名称");

                entity.Property(e => e.Filesize)
                    .HasColumnName("FILESIZE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Folderid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FOLDERID");

                entity.Property(e => e.Operator)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("OPERATOR")
                    .HasComment("操作人Id");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");

                entity.Property(e => e.Uploadtime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPLOADTIME")
                    .HasComment("上传时间");
            });

            modelBuilder.Entity<MfWrxattachmentfolder>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__MF_WRXAT__C49703DE7849DB76");

                entity.ToTable("MF_WRXATTACHMENTFOLDER");

                entity.Property(e => e.Id0)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID0");

                entity.Property(e => e.Attachmentfolder)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ATTACHMENTFOLDER");

                entity.Property(e => e.Caseno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Catalog)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATALOG");

                entity.Property(e => e.Optional).HasColumnName("OPTIONAL");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Stepid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("STEPID");

                entity.Property(e => e.Template)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEMPLATE");
            });

            modelBuilder.Entity<MfWsattachment>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__MF_WSATT__C49703DE7C1A6C5A");

                entity.ToTable("MF_WSATTACHMENT");

                entity.Property(e => e.Id0)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID0")
                    .HasComment("Id");

                entity.Property(e => e.Activityid)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITYID")
                    .HasComment("活动Id");

                entity.Property(e => e.Attachmentfolder)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ATTACHMENTFOLDER")
                    .HasComment("附件名称");

                entity.Property(e => e.Catalog)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATALOG")
                    .HasComment("目录");

                entity.Property(e => e.Flowcode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("FLOWCODE")
                    .HasComment("流程编码");

                entity.Property(e => e.Optional)
                    .HasColumnName("OPTIONAL")
                    .HasComment("可选标志");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");
            });

            modelBuilder.Entity<NotificationInfoHistory>(entity =>
            {
                entity.ToTable("Notification_Info_History");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("主键id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("修改日期");

                entity.Property(e => e.InfoContent)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("infoContent")
                    .HasComment("消息内容");

                entity.Property(e => e.InfoDistribution)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("infoDistribution")
                    .HasComment("推送方式，为空时各处均推送，短信/公众号/小程序/APP/WEB");

                entity.Property(e => e.InfoLevel)
                    .HasColumnName("infoLevel")
                    .HasDefaultValueSql("((0))")
                    .HasComment("消息紧急程度，0-普通(默认)；1-急；2-加急；3-特急");

                entity.Property(e => e.InfoType)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("infoType")
                    .HasComment("消息类型 消息类型有Scada报警 二供报警 工单流程等");

                entity.Property(e => e.MessTypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MessTypeID");

                entity.Property(e => e.Tousers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tousers")
                    .HasComment("消息发送人 用户之间用，号隔开 当值为null或则为all时表示广播群发");
            });

            modelBuilder.Entity<NotificationInfoReal>(entity =>
            {
                entity.ToTable("Notification_Info_Real");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("主键id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("修改日期");

                entity.Property(e => e.InfoContent)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("infoContent")
                    .HasComment("消息内容");

                entity.Property(e => e.InfoDistribution)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("infoDistribution");

                entity.Property(e => e.InfoLevel)
                    .HasColumnName("infoLevel")
                    .HasDefaultValueSql("((0))")
                    .HasComment("消息紧急程度，0-普通(默认)；1-急；2-加急；3-特急");

                entity.Property(e => e.InfoType)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("infoType")
                    .HasComment("消息类型 消息类型有Scada报警 二供报警 工单流程等");

                entity.Property(e => e.MessTypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MessTypeID");

                entity.Property(e => e.Tousers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tousers")
                    .HasComment("消息发送人 用户之间用，号隔开 当值为null或则为all时表示广播群发");
            });

            modelBuilder.Entity<NotificationNoticeHistory>(entity =>
            {
                entity.ToTable("Notification_Notice_History");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateMen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.InfoType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoticeContent)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NoticeId).HasColumnName("NoticeID");

                entity.Property(e => e.NoticeTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoticeType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToUsers)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<NotificationStatus>(entity =>
            {
                entity.ToTable("Notification_Status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("主键id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("修改日期");

                entity.Property(e => e.InfoId).HasColumnName("infoId");

                entity.Property(e => e.IsRead)
                    .HasColumnName("isRead")
                    .HasComment("是否已读 0表示未读 1表示已读(sqlServer 无枚举类型)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasComment("用户");

                entity.HasOne(d => d.Info)
                    .WithMany(p => p.NotificationStatuses)
                    .HasForeignKey(d => d.InfoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pk_forgin");
            });

            modelBuilder.Entity<NotificationTemplate>(entity =>
            {
                entity.ToTable("Notification_Template");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.InfoType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoticeContent)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NoticeTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoticeType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToUsers)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Notification消息模板表>(entity =>
            {
                entity.ToTable("Notification_消息模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.案例展示)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.模板别名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.模板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.模板类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.模板编号)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.模板解析规则)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notification消息配置表>(entity =>
            {
                entity.ToTable("Notification_消息配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.App功能路径)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("APP功能路径");

                entity.Property(e => e.App模板id).HasColumnName("APP模板ID");

                entity.Property(e => e.App配置)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("APP配置");

                entity.Property(e => e.Web功能路径)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Web模板id).HasColumnName("WEB模板ID");

                entity.Property(e => e.Web配置)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.主题名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.公众号模板id)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("公众号模板ID");

                entity.Property(e => e.公众号路径)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.公众号配置)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.小程序路由)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.推送人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.推送方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.推送组)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.推送路径)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.是否启动)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.消息类型)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.短信模板id).HasColumnName("短信模板ID");

                entity.Property(e => e.短信模板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.短信模板编号)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.短信配置)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatrolEquip>(entity =>
            {
                entity.ToTable("PATROL_EQUIPS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检设备ID(主键)");

                entity.Property(e => e.EquipEntities)
                    .HasColumnType("text")
                    .HasColumnName("EQUIP_ENTITIES")
                    .HasComment("设备实体集,用|和逗号分隔");

                entity.Property(e => e.EquipPos)
                    .HasColumnType("text")
                    .HasColumnName("EQUIP_POS")
                    .HasComment("区域范围");

                entity.Property(e => e.EquipType)
                    .HasColumnType("text")
                    .HasColumnName("EQUIP_TYPE")
                    .HasComment("可多个设备类型(图层)，用逗号分隔");

                entity.Property(e => e.Equiparea)
                    .HasColumnName("EQUIPAREA")
                    .HasComment("区域范围ID");
            });

            modelBuilder.Entity<PatrolEventinfo>(entity =>
            {
                entity.ToTable("PATROL_EVENTINFO");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("事件ID(主键)");

                entity.Property(e => e.Backmedia)
                    .HasColumnType("image")
                    .HasColumnName("BACKMEDIA")
                    .HasComment("多媒体（4）（预留）");

                entity.Property(e => e.Backpics)
                    .HasColumnType("image")
                    .HasColumnName("BACKPICS")
                    .HasComment("多媒体（3）（预留）");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO")
                    .HasComment("案卷编号（与工作流关联）");

                entity.Property(e => e.CheckerGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHECKER_GROUP")
                    .HasComment("上报人部门");

                entity.Property(e => e.CheckerId)
                    .HasColumnName("CHECKER_ID")
                    .HasComment("上报人ID");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDTIME")
                    .HasComment("结束时间（预留）");

                entity.Property(e => e.EventCommit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_COMMIT")
                    .HasComment("事件处理意见（预留）");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_DESC")
                    .HasComment("事件详情");

                entity.Property(e => e.EventPosition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_POSITION")
                    .HasComment("事件位置");

                entity.Property(e => e.EventResult)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_RESULT")
                    .HasComment("事件结果（预留）");

                entity.Property(e => e.EventRoad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_ROAD")
                    .HasComment("事件发生道路");

                entity.Property(e => e.EventTypeid)
                    .HasColumnName("EVENT_TYPEID")
                    .HasComment("事件类型ID");

                entity.Property(e => e.Firstmedia)
                    .HasColumnType("image")
                    .HasColumnName("FIRSTMEDIA")
                    .HasComment("多媒体（2）（预留）");

                entity.Property(e => e.Firstpics)
                    .HasColumnType("image")
                    .HasColumnName("FIRSTPICS")
                    .HasComment("多媒体（1）");

                entity.Property(e => e.Happentime)
                    .HasColumnType("datetime")
                    .HasColumnName("HAPPENTIME")
                    .HasComment("反馈时间");

                entity.Property(e => e.Pipeid0)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIPEID0")
                    .HasComment("关联设备ID0");

                entity.Property(e => e.PlanId)
                    .HasColumnName("PLAN_ID")
                    .HasComment("计划ID");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_NAME")
                    .HasComment("事件发生道路");

                entity.Property(e => e.Tablename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TABLENAME")
                    .HasComment("关联设备表名");
            });

            modelBuilder.Entity<PatrolFbbaseinfo>(entity =>
            {
                entity.ToTable("PATROL_FBBASEINFO");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检计划ID(主键)");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_DESC")
                    .HasComment("事件描述");

                entity.Property(e => e.FbDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FB_DESC")
                    .HasComment("反馈描述");

                entity.Property(e => e.FbGroup)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FB_GROUP")
                    .HasComment("反馈分组");

                entity.Property(e => e.FbType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FB_TYPE")
                    .HasComment("反馈值类型");

                entity.Property(e => e.Istrigger)
                    .HasColumnName("ISTRIGGER")
                    .HasComment("是否触发事件");

                entity.Property(e => e.Must).HasColumnName("MUST");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Plantypeid)
                    .HasColumnName("PLANTYPEID")
                    .HasComment("关联计划类型ID");

                entity.Property(e => e.TrigCondition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRIG_CONDITION")
                    .HasComment("触发条件");
            });

            modelBuilder.Entity<PatrolFbresult>(entity =>
            {
                entity.HasKey(e => e.FbResultid)
                    .HasName("PK__PATROL_F__B5E9BACA40C49C62");

                entity.ToTable("PATROL_FBRESULTS");

                entity.Property(e => e.FbResultid)
                    .HasColumnName("FB_RESULTID")
                    .HasComment("反馈结果ID(主键)");

                entity.Property(e => e.FbDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FB_DESC")
                    .HasComment("反馈描述");

                entity.Property(e => e.FbImage)
                    .HasColumnType("image")
                    .HasColumnName("FB_IMAGE")
                    .HasComment("反馈值为图片");

                entity.Property(e => e.FbTime)
                    .HasColumnType("datetime")
                    .HasColumnName("FB_TIME")
                    .HasComment("反馈时间");

                entity.Property(e => e.FbValue)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("FB_VALUE")
                    .HasComment("反馈值");

                entity.Property(e => e.Taskid)
                    .HasColumnName("TASKID")
                    .HasComment("任务ID");
            });

            modelBuilder.Entity<PatrolPhone>(entity =>
            {
                entity.HasKey(e => e.PhoneId)
                    .HasName("PK__PATROL_P__1BB5AF5F44952D46");

                entity.ToTable("PATROL_PHONE");

                entity.Property(e => e.PhoneId)
                    .HasColumnName("PHONE_ID")
                    .HasComment("PATROL_PHONE(主键)");

                entity.Property(e => e.PhoneFactory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_FACTORY");

                entity.Property(e => e.PhoneModel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_MODEL");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.PhoneUsed)
                    .HasColumnName("PHONE_USED")
                    .HasComment("是否已使用");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");
            });

            modelBuilder.Entity<PatrolPlanarea>(entity =>
            {
                entity.ToTable("PATROL_PLANAREA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Areaname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AREANAME");

                entity.Property(e => e.Arearange)
                    .HasColumnType("text")
                    .HasColumnName("AREARANGE");

                entity.Property(e => e.Areatype).HasColumnName("AREATYPE");

                entity.Property(e => e.EquipEntityids).HasColumnName("EQUIP_ENTITYIDS");

                entity.Property(e => e.Isexit).HasColumnName("ISEXIT");

                entity.Property(e => e.Parentid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARENTID");

                entity.Property(e => e.Pathid).HasColumnName("PATHID");

                entity.Property(e => e.Patrolmanid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATROLMANID");
            });

            modelBuilder.Entity<PatrolPlancycle>(entity =>
            {
                entity.ToTable("PATROL_PLANCYCLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检计划周期ID(主键)");

                entity.Property(e => e.Isexist)
                    .HasColumnName("ISEXIST")
                    .HasComment("是否存在");

                entity.Property(e => e.Plancycle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLANCYCLE")
                    .HasComment("计划周期");

                entity.Property(e => e.Timelen)
                    .HasColumnName("TIMELEN")
                    .HasComment("时间长度");

                entity.Property(e => e.Times)
                    .HasColumnName("TIMES")
                    .HasComment("执行次数");

                entity.Property(e => e.Timeunit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIMEUNIT")
                    .HasComment("时间单位");
            });

            modelBuilder.Entity<PatrolPlanflow>(entity =>
            {
                entity.ToTable("PATROL_PLANFLOW");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检计划流程ID(主键)");

                entity.Property(e => e.AssignTime)
                    .HasColumnType("datetime")
                    .HasColumnName("ASSIGN_TIME")
                    .HasComment("分配时间");

                entity.Property(e => e.Assigner)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNER")
                    .HasComment("分配人");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO")
                    .HasComment("案卷编号");

                entity.Property(e => e.Isfeedbacked)
                    .HasColumnName("ISFEEDBACKED")
                    .HasComment("是否已反馈");

                entity.Property(e => e.PatrolAgency)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATROL_AGENCY")
                    .HasComment("巡检单位");

                entity.Property(e => e.Patrolmanname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATROLMANNAME")
                    .HasComment("巡检员名称");

                entity.Property(e => e.PlanEndtime)
                    .HasColumnType("datetime")
                    .HasColumnName("PLAN_ENDTIME")
                    .HasComment("计划结束时间");

                entity.Property(e => e.PlanId)
                    .HasColumnName("PLAN_ID")
                    .HasComment("计划ID");

                entity.Property(e => e.PlanStarttime)
                    .HasColumnType("datetime")
                    .HasColumnName("PLAN_STARTTIME")
                    .HasComment("计划开始时间");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasComment("巡检员ID");
            });

            modelBuilder.Entity<PatrolPlanpath>(entity =>
            {
                entity.ToTable("PATROL_PLANPATH");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检路径ID(主键)");

                entity.Property(e => e.Pathname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATHNAME")
                    .HasComment("路径名称");

                entity.Property(e => e.Pathpoly)
                    .HasColumnType("text")
                    .HasColumnName("PATHPOLY")
                    .HasComment("路径多边形范围");

                entity.Property(e => e.Pathrange)
                    .HasColumnType("text")
                    .HasColumnName("PATHRANGE")
                    .HasComment("路径点线范围");
            });

            modelBuilder.Entity<PatrolPlantbl>(entity =>
            {
                entity.ToTable("PATROL_PLANTBL");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检计划ID(主键)");

                entity.Property(e => e.Areaid)
                    .HasColumnName("AREAID")
                    .HasComment("关联区域类型ID");

                entity.Property(e => e.EquipEntityids)
                    .HasColumnName("EQUIP_ENTITYIDS")
                    .HasComment("关联设备实体ID");

                entity.Property(e => e.Isexit)
                    .HasColumnName("ISEXIT")
                    .HasComment("是否存在");

                entity.Property(e => e.Isfeedback)
                    .HasColumnName("ISFEEDBACK")
                    .HasDefaultValueSql("((0))")
                    .HasComment("是否需要反馈");

                entity.Property(e => e.Isopen)
                    .HasColumnName("ISOPEN")
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否启用");

                entity.Property(e => e.Istemp)
                    .HasColumnName("ISTEMP")
                    .HasDefaultValueSql("((0))")
                    .HasComment("是否临时计划");

                entity.Property(e => e.Pathid)
                    .HasColumnName("PATHID")
                    .HasComment("关联路径ID");

                entity.Property(e => e.PipeEntityids)
                    .HasColumnName("PIPE_ENTITYIDS")
                    .HasComment("关联管线实体ID");

                entity.Property(e => e.PlanCreatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("PLAN_CREATETIME")
                    .HasComment("计划制定时间");

                entity.Property(e => e.PlanMaker)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLAN_MAKER")
                    .HasComment("计划制定人");

                entity.Property(e => e.PlanMakerid)
                    .HasColumnName("PLAN_MAKERID")
                    .HasComment("计划制定人ID");

                entity.Property(e => e.Plancycleid)
                    .HasColumnName("PLANCYCLEID")
                    .HasComment("计划周期ID");

                entity.Property(e => e.Planname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLANNAME")
                    .HasComment("计划名称");

                entity.Property(e => e.Plantypeid)
                    .HasColumnName("PLANTYPEID")
                    .HasComment("关联计划类型ID");
            });

            modelBuilder.Entity<PatrolPlantype>(entity =>
            {
                entity.ToTable("PATROL_PLANTYPE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("巡检计划类型ID(主键)");

                entity.Property(e => e.Exist)
                    .HasColumnName("EXIST")
                    .HasComment("是否存在");

                entity.Property(e => e.Layerfilter)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LAYERFILTER")
                    .HasComment("巡检计划过滤条件");

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .HasComment("父节点ID");

                entity.Property(e => e.Plantype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLANTYPE")
                    .HasComment("巡检计划类型");
            });

            modelBuilder.Entity<PatrolTaskunit>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__PATROL_T__42E0049A6225902D");

                entity.ToTable("PATROL_TASKUNIT");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TASK_ID")
                    .HasComment("任务ID(主键)");

                entity.Property(e => e.Arrive)
                    .HasColumnName("ARRIVE")
                    .HasComment("已到位次数");

                entity.Property(e => e.Arrivesum)
                    .HasColumnName("ARRIVESUM")
                    .HasComment("总到位次数");

                entity.Property(e => e.Feedback)
                    .HasColumnName("FEEDBACK")
                    .HasComment("已反馈次数");

                entity.Property(e => e.Feedbacksum)
                    .HasColumnName("FEEDBACKSUM")
                    .HasComment("总反馈次数");

                entity.Property(e => e.Isarrive)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("ISARRIVE")
                    .HasComment("是否到位（不同任务初始化不同）");

                entity.Property(e => e.Isfeedback)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("ISFEEDBACK")
                    .HasComment("是否反馈");

                entity.Property(e => e.Isread)
                    .HasColumnName("ISREAD")
                    .HasDefaultValueSql("((0))")
                    .HasComment("是否已读");

                entity.Property(e => e.Planflowid)
                    .HasColumnName("PLANFLOWID")
                    .HasComment("流程ID");

                entity.Property(e => e.Taskend)
                    .HasColumnType("datetime")
                    .HasColumnName("TASKEND")
                    .HasComment("任务结束时间");

                entity.Property(e => e.Taskstart)
                    .HasColumnType("datetime")
                    .HasColumnName("TASKSTART")
                    .HasComment("任务开始时间");

                entity.Property(e => e.Taskstate)
                    .HasColumnName("TASKSTATE")
                    .HasComment("任务状态");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<Patrolhistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLHISTORY");

                //entity.HasIndex(e => e.Patrolerid, "PATROLERID")
                //    .IsClustered();

                entity.Property(e => e.Errortype)
                    .HasColumnName("ERRORTYPE")
                    .HasDefaultValueSql("((0))")
                    .HasComment("异常类型");

                entity.Property(e => e.Isover)
                    .HasColumnName("ISOVER")
                    .HasDefaultValueSql("((0))")
                    .HasComment("此条记录是否结束存储点");

                entity.Property(e => e.Lastx)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("LASTX")
                    .HasComment("此长记录结束存储点前最后一点X");

                entity.Property(e => e.Lasty)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("LASTY")
                    .HasComment("此长记录结束存储点前最后一点y");

                entity.Property(e => e.Patrolerid)
                    .HasColumnName("PATROLERID")
                    .HasComment("巡线人员编号PATROLMANID");

                entity.Property(e => e.Patroltime)
                    .HasColumnType("datetime")
                    .HasColumnName("PATROLTIME")
                    .HasComment("日期");

                entity.Property(e => e.Tracedistance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("TRACEDISTANCE")
                    .HasDefaultValueSql("((0))")
                    .HasComment("距离");

                entity.Property(e => e.Tracestr)
                    .HasColumnType("text")
                    .HasColumnName("TRACESTR")
                    .HasComment("轨迹串");
            });

            modelBuilder.Entity<Patrolman>(entity =>
            {
                entity.ToTable("PATROLMAN");

                entity.Property(e => e.Patrolmanid)
                    .HasColumnName("PATROLMANID")
                    .HasComment("PATROLMANID(主键)");

                entity.Property(e => e.Exist)
                    .HasColumnName("EXIST")
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否有手机");

                entity.Property(e => e.PhoneId).HasColumnName("PHONE_ID");

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasComment("状态");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasComment("USERID");
            });

            modelBuilder.Entity<PatrolmanWorktime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLMAN_WORKTIME");

                //entity.HasIndex(e => e.Id, "UQ__PATROLMA__3214EC261F63A897")
                //    .IsUnique();

                entity.Property(e => e.Flag)
                    .HasColumnName("FLAG")
                    .HasComment("标识");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    .HasComment("ID");

                entity.Property(e => e.Wendtime)
                    .HasColumnType("datetime")
                    .HasColumnName("WENDTIME")
                    .HasComment("结束时间");

                entity.Property(e => e.Wstarttime)
                    .HasColumnType("datetime")
                    .HasColumnName("WSTARTTIME")
                    .HasComment("开始时间");
            });

            modelBuilder.Entity<Patrolmanlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLMANLOG");

                //entity.HasIndex(e => e.Id, "UQ__PATROLMA__3214EC261B9317B3")
                //    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    .HasComment("id");

                entity.Property(e => e.操作时间)
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.操作类型)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("操作类型");

                entity.Property(e => e.用户编号).HasComment("用户编号");
            });

            modelBuilder.Entity<Patrolmil>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLMIL");

                entity.Property(e => e.Errcnt)
                    .HasColumnName("ERRCNT")
                    .HasComment("异常次数");

                entity.Property(e => e.Outarea)
                    .HasColumnName("OUTAREA")
                    .HasComment("出界次数");

                entity.Property(e => e.Patrolerid)
                    .HasColumnName("PATROLERID")
                    .HasComment("巡线人员ID");

                entity.Property(e => e.Patroltime)
                    .HasColumnType("datetime")
                    .HasColumnName("PATROLTIME")
                    .HasComment("正常轨迹开始时间");

                entity.Property(e => e.Realdistance)
                    .HasColumnName("REALDISTANCE")
                    .HasComment("有效距离");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TASK_ID")
                    .HasComment("任务ID");

                entity.Property(e => e.Timelen)
                    .HasColumnName("TIMELEN")
                    .HasComment("时长");
            });

            modelBuilder.Entity<Patrolpositon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLPOSITON");

                entity.Property(e => e.Patrolerid)
                    .HasColumnName("PATROLERID")
                    .HasComment("巡检人员ID(主键)");

                entity.Property(e => e.Patrolposition)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATROLPOSITION")
                    .HasComment("位置(x,y)");

                entity.Property(e => e.Patroltime)
                    .HasColumnType("datetime")
                    .HasColumnName("PATROLTIME")
                    .HasComment("上报点坐标事件");
            });

            modelBuilder.Entity<Patrolshortmessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLSHORTMESSAGE");

                //entity.HasIndex(e => e.MsgId, "UQ__PATROLSH__825DA51D27F8EE98")
                //    .IsUnique();

                entity.Property(e => e.Isget)
                    .HasColumnName("ISGET")
                    .HasComment("ISGET");

                entity.Property(e => e.MsgDetail)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("MSG_DETAIL")
                    .HasComment("消息内容");

                entity.Property(e => e.MsgId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MSG_ID")
                    .HasComment("消息ID");

                entity.Property(e => e.MsgTime)
                    .HasColumnType("datetime")
                    .HasColumnName("MSG_TIME")
                    .HasComment("消息时间");

                entity.Property(e => e.Patrolerid)
                    .HasColumnName("PATROLERID")
                    .HasComment("巡检员ID");

                entity.Property(e => e.Senderid)
                    .HasColumnName("SENDERID")
                    .HasComment("发送人ID");
            });

            modelBuilder.Entity<Patrolstatistic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATROLSTATISTICS");

                //entity.HasIndex(e => e.Id, "UQ__PATROLST__3214EC262BC97F7C")
                //    .IsUnique();

                //entity.HasIndex(e => e.在线日期, "在线日期")
                //    .IsClustered();

                //entity.HasIndex(e => new { e.用户编号, e.在线日期 }, "用户日期");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    .HasComment("id");

                entity.Property(e => e.出圈次数)
                    .HasDefaultValueSql("((0))")
                    .HasComment("出圈次数");

                entity.Property(e => e.前一坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("前一坐标");

                entity.Property(e => e.前一时间)
                    .HasColumnType("datetime")
                    .HasComment("前一时间");

                entity.Property(e => e.在线日期)
                    .HasColumnType("datetime")
                    .HasComment("在线日期");

                entity.Property(e => e.在线时长)
                    .HasDefaultValueSql("((0))")
                    .HasComment("在线时长");

                entity.Property(e => e.在线里程)
                    .HasDefaultValueSql("((0))")
                    .HasComment("在线里程");

                entity.Property(e => e.有效时长)
                    .HasDefaultValueSql("((0))")
                    .HasComment("有效时长");

                entity.Property(e => e.有效里程)
                    .HasDefaultValueSql("((0))")
                    .HasComment("有效里程");

                entity.Property(e => e.用户编号).HasComment("用户编号");

                entity.Property(e => e.登出时间).HasColumnType("datetime");

                entity.Property(e => e.登录时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<PointAddress>(entity =>
            {
                entity.ToTable("PointAddress");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FaddressLength).HasColumnName("FAddressLength");

                entity.Property(e => e.FcreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FCreateDate");

                entity.Property(e => e.FcreateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FCreateUser");

                entity.Property(e => e.FdelDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FDelDate");

                entity.Property(e => e.FdelUser).HasColumnName("FDelUser");

                entity.Property(e => e.FisBaseScheme).HasColumnName("FIsBaseScheme");

                entity.Property(e => e.FisDelete).HasColumnName("FIsDelete");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Fnote)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FNote");

                entity.Property(e => e.ForderBy).HasColumnName("FOrderBy");

                entity.Property(e => e.FstartAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FStartAddress");

                entity.Property(e => e.Ftype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FType");

                entity.Property(e => e.FupdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FUpdDate");

                entity.Property(e => e.FupdUser).HasColumnName("FUpdUser");

                entity.Property(e => e.Fversion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FVersion");

                entity.Property(e => e.分组名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.脚本内容).IsUnicode(false);

                entity.Property(e => e.脚本语言)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PointAddressEntry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PointAddressEntry");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Plc地址)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("plc地址");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.传感器类型id).HasColumnName("传感器类型ID");

                entity.Property(e => e.值描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.偏移地址)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.创建人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.创建时间).HasColumnType("datetime");

                entity.Property(e => e.名称)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.巡检分组)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.指标类型)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.控制脚本).IsUnicode(false);

                entity.Property(e => e.数据源地址)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.数据源集)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.数据类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.点明细id).HasColumnName("点明细ID");

                entity.Property(e => e.点来源)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.父标签名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.版本id).HasColumnName("版本ID");

                entity.Property(e => e.脚本内容).IsUnicode(false);

                entity.Property(e => e.脚本语言)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recoveryuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RECOVERYUSER");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.名称)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.工号)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.恢复时间).HasColumnType("datetime");

                entity.Property(e => e.插入时间).HasColumnType("datetime");

                entity.Property(e => e.机构id).HasColumnName("机构ID");

                entity.Property(e => e.机构名称)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.用户id).HasColumnName("用户ID");

                entity.Property(e => e.用户信息)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Relationoumenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RELATIONOUMENU");

                entity.Property(e => e.Nodeid).HasColumnName("NODEID");

                entity.Property(e => e.机构id).HasColumnName("机构ID");
            });

            modelBuilder.Entity<ScadaAlertFeedBack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCADA_AlertFeedBack");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.反馈人)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.反馈内容)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.反馈时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<ScadaAlertHistory>(entity =>
            {
                entity.ToTable("SCADA_AlertHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.Pv).HasColumnName("PV");

                entity.Property(e => e.SensorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SensorID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScadaAlertInfo>(entity =>
            {
                entity.ToTable("SCADA_AlertInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlertName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AlertType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Divisions)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Notify)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("notify");

                entity.Property(e => e.Person)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("person");

                entity.Property(e => e.Sensors).IsUnicode(false);

                entity.Property(e => e.Stations)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScadaAlertValue>(entity =>
            {
                entity.ToTable("SCADA_AlertValue");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValueType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScadaDataKind>(entity =>
            {
                entity.ToTable("SCADA_DataKind");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataKindCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Format)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Style)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScadaSensor>(entity =>
            {
                entity.ToTable("SCADA_Sensor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.Guid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PointAddressId).HasColumnName("PointAddressID");

                entity.Property(e => e.SensorTypeId).HasColumnName("SensorTypeID");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.Property(e => e.ValDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.二维坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.是否同步历史数据).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ScadaSensorHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCADA_SensorHistory");

                //entity.HasIndex(e => e.Pt, "PT")
                //    .IsClustered();

                //entity.HasIndex(e => e.SensorId, "SensorID");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pt)
                    .HasColumnType("datetime")
                    .HasColumnName("PT");

                entity.Property(e => e.Pv).HasColumnName("PV");

                entity.Property(e => e.SensorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SensorID");
            });

            modelBuilder.Entity<ScadaSensorHistoryTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCADA_SensorHistoryTemp");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pt)
                    .HasColumnType("datetime")
                    .HasColumnName("PT");

                entity.Property(e => e.Pv).HasColumnName("PV");

                entity.Property(e => e.SensorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SensorID");
            });

            modelBuilder.Entity<ScadaSensorRealTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCADA_SensorRealTime");

                entity.Property(e => e.LastTime).HasColumnType("datetime");

                entity.Property(e => e.SensorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SensorID");
            });

            modelBuilder.Entity<ScadaSensorRealTimeTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCADA_SensorRealTimeTemp");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pt)
                    .HasColumnType("datetime")
                    .HasColumnName("PT");

                entity.Property(e => e.Pv).HasColumnName("PV");

                entity.Property(e => e.SensorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SensorID");
            });

            modelBuilder.Entity<ScadaSensorType>(entity =>
            {
                entity.ToTable("SCADA_SensorType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataKindId).HasColumnName("DataKindID");

                entity.Property(e => e.Format)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Style)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.Property(e => e.备注)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScadaStation>(entity =>
            {
                entity.ToTable("SCADA_Station");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddrSchemeId).HasColumnName("AddrSchemeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AreaName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.ControlType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionId).HasColumnName("DivisionID");

                entity.Property(e => e.FopcdeviceName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FOPCDeviceName");

                entity.Property(e => e.FopcserverName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOPCServerName");

                entity.Property(e => e.Fplcip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FPLCIP");

                entity.Property(e => e.Guid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GUID");

                entity.Property(e => e.LedgerId).HasColumnName("LedgerID");

                entity.Property(e => e.LedgerTable)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.ReadMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StationNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StationTypeId).HasColumnName("StationTypeID");

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.采集频度)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScadaStationAttention>(entity =>
            {
                entity.ToTable("SCADA_StationAttention");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ScadaStationDivision>(entity =>
            {
                entity.ToTable("SCADA_StationDivision");

                //entity.HasIndex(e => e.Guid, "UC_SCADA_ StationDivision")
                //    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GUID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<ScadaStationType>(entity =>
            {
                entity.ToTable("SCADA_StationType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sn)
                    .HasMaxLength(50)
                    .HasColumnName("SN");
            });

            modelBuilder.Entity<Scada远程控制控制权限配置表>(entity =>
            {
                entity.ToTable("SCADA_远程控制_控制权限配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.修改人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.修改时间).HasColumnType("datetime");

                entity.Property(e => e.创建人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.创建时间).HasColumnType("datetime");

                entity.Property(e => e.控制口令)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.控制点位)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.权限说明)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scada远程控制控制配置表>(entity =>
            {
                entity.ToTable("SCADA_远程控制_控制配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SensorId).HasColumnName("SensorID");
            });

            modelBuilder.Entity<Scada远程控制权限配置更新日志>(entity =>
            {
                entity.ToTable("SCADA_远程控制_权限配置更新日志");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.修改配置)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.初始配置)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.操作人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.操作时间).HasColumnType("datetime");

                entity.Property(e => e.配置编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scada远程控制远程控制操作日志>(entity =>
            {
                entity.ToTable("SCADA_远程控制_远程控制操作日志");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.初始状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.实际状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.控制点位)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.控制类型)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.控制结果)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.操作人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.操作时间).HasColumnType("datetime");

                entity.Property(e => e.服务返回信息)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.目标状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.策略类型)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.请求路径)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Superviseinfo>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__SUPERVIS__C49703DE6F7F8B4B");

                entity.ToTable("SUPERVISEINFO");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Flowids)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("FLOWIDS")
                    .HasComment("督办类型代码列表，以；号分割");

                entity.Property(e => e.Flownames)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("FLOWNAMES")
                    .HasComment("督办类型名称列表，以；号分割");

                entity.Property(e => e.Ownercode)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNERCODE")
                    .HasComment("督办拥有者代码(非空)");

                entity.Property(e => e.Ownername)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNERNAME")
                    .HasComment("督办拥有者名称(非空)");
            });

            modelBuilder.Entity<SvcLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SVC_LOG");

                entity.Property(e => e.Browserinfo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BROWSERINFO");

                entity.Property(e => e.Contract)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT");

                entity.Property(e => e.Elapsedmillisecond).HasColumnName("ELAPSEDMILLISECOND");

                entity.Property(e => e.Function)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTION");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPADDRESS");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Operationname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONNAME");

                entity.Property(e => e.Port)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PORT");

                entity.Property(e => e.Service)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE");

                entity.Property(e => e.Throughput).HasColumnName("THROUGHPUT");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("TIME");

                entity.Property(e => e.Username)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Sysdatadictionary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SYSDATADICTIONARY");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.Nodeid).HasColumnName("NODEID");

                entity.Property(e => e.Nodename)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NODENAME");

                entity.Property(e => e.Nodevalue)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NODEVALUE");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2");
            });

            modelBuilder.Entity<Sysmenutree>(entity =>
            {
                entity.HasKey(e => e.Nodeid);

                entity.ToTable("SYSMENUTREE");

                entity.Property(e => e.Nodeid)
                    .ValueGeneratedNever()
                    .HasColumnName("NODEID");

                entity.Property(e => e.Bottom)
                    .HasColumnName("BOTTOM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Buttongroup)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUTTONGROUP");

                entity.Property(e => e.Config)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONFIG");

                entity.Property(e => e.Defaultimgurl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULTIMGURL");

                entity.Property(e => e.Editgroupcode)
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("EDITGROUPCODE");

                entity.Property(e => e.Expandimgurl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EXPANDIMGURL");

                entity.Property(e => e.Extauth)
                    .HasColumnName("EXTAUTH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Grouplabel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GROUPLABEL");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.Independentpurviw)
                    .HasColumnName("INDEPENDENTPURVIW")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Iscanmanage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANMANAGE");

                entity.Property(e => e.Ishidden)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISHIDDEN");

                entity.Property(e => e.Left)
                    .HasColumnName("LEFT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Menuview)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MENUVIEW");

                entity.Property(e => e.Nodename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NODENAME");

                entity.Property(e => e.Nodeshortname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NODESHORTNAME");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Ownergroupcode)
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("OWNERGROUPCODE");

                entity.Property(e => e.Pageurl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("PAGEURL");

                entity.Property(e => e.Param)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.Right)
                    .HasColumnName("RIGHT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Selectimgurl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SELECTIMGURL");

                entity.Property(e => e.Subpageurl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("SUBPAGEURL");

                entity.Property(e => e.Tableid).HasColumnName("TABLEID");

                entity.Property(e => e.Top)
                    .HasColumnName("TOP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Visible)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VISIBLE");
            });

            modelBuilder.Entity<Syspagetool>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__SYSPAGET__C49703DE7DCDAAA2");

                entity.ToTable("SYSPAGETOOLS");

                entity.Property(e => e.Id0)
                    .HasColumnName("ID0")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Orderid)
                    .HasColumnName("ORDERID")
                    .HasComment("同一级树种的显示顺序");

                entity.Property(e => e.Parentid)
                    .HasColumnName("PARENTID")
                    .HasComment("父节点ID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("描述信息");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1")
                    .HasComment("备用1");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2")
                    .HasComment("备用2");

                entity.Property(e => e.Toolid)
                    .HasColumnName("TOOLID")
                    .HasComment("工具ID(唯一)");

                entity.Property(e => e.Toolname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TOOLNAME")
                    .HasComment("工具名称");

                entity.Property(e => e.Toolurl)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("TOOLURL")
                    .HasComment("工具页面Url");
            });

            modelBuilder.Entity<Syspurview>(entity =>
            {
                entity.HasKey(e => new { e.Resid, e.Rolecode });

                entity.ToTable("SYSPURVIEW");

                entity.Property(e => e.Resid).HasColumnName("RESID");

                entity.Property(e => e.Rolecode)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ROLECODE");

                entity.Property(e => e.Grantordeny)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GRANTORDENY");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.Purview).HasColumnName("PURVIEW");

                entity.Property(e => e.Restype).HasColumnName("RESTYPE");

                entity.Property(e => e.Roletype).HasColumnName("ROLETYPE");

                entity.HasOne(d => d.Res)
                    .WithMany(p => p.Syspurviews)
                    .HasForeignKey(d => d.Resid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSPURVIEW_SYSMENUTREE");

                entity.HasOne(d => d.RolecodeNavigation)
                    .WithMany(p => p.Syspurviews)
                    .HasPrincipalKey(p => p.编码)
                    .HasForeignKey(d => d.Rolecode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SYSPURVIEW_FLOW_GROUPS");
            });

            modelBuilder.Entity<Syspurviewtype>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__SYSPURVI__C49703DE056ECC6A");

                entity.ToTable("SYSPURVIEWTYPE");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Friendlyname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FRIENDLYNAME");

                entity.Property(e => e.Purviewname)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PURVIEWNAME");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Sysdef)
                    .HasColumnName("SYSDEF")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Syssequencetbl>(entity =>
            {
                entity.HasKey(e => new { e.Tblname, e.Fieldname })
                    .HasName("PK__SYSSEQUE__E68F31F02077C861");

                entity.ToTable("SYSSEQUENCETBL");

                entity.Property(e => e.Tblname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("TBLNAME")
                    .HasComment("表名");

                entity.Property(e => e.Fieldname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("FIELDNAME");

                entity.Property(e => e.Currentvalue)
                    .HasColumnName("CURRENTVALUE")
                    .HasComment("序列当前值");
            });

            modelBuilder.Entity<Systablerelastion>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__SYSTABLE__C49703DE0C1BC9F9");

                entity.ToTable("SYSTABLERELASTION");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Indexfield)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("INDEXFIELD")
                    .HasComment("索引字段(非空)");

                entity.Property(e => e.Parenttblname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PARENTTBLNAME")
                    .HasComment("父表表名(非空)");

                entity.Property(e => e.Prttblfilter)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PRTTBLFILTER")
                    .HasComment("父表过滤字段");

                entity.Property(e => e.Prttblfltvalue)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PRTTBLFLTVALUE")
                    .HasComment("父表过滤字段值");

                entity.Property(e => e.Prttblindexname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PRTTBLINDEXNAME")
                    .HasComment("父表索引字段(非空)");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1")
                    .HasComment("备用1");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2")
                    .HasComment("备用2");

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("TABLENAME")
                    .HasComment("表名(非空)");
            });

            modelBuilder.Entity<Sysucwidget>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__SYSUCWID__C49703DE0FEC5ADD");

                entity.ToTable("SYSUCWIDGET");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0");

                entity.Property(e => e.Wdescription)
                    .HasColumnType("text")
                    .HasColumnName("WDESCRIPTION")
                    .HasComment("说明");

                entity.Property(e => e.Wname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WNAME")
                    .HasComment("名称");

                entity.Property(e => e.Wparameter)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("WPARAMETER")
                    .HasComment("附加参数");

                entity.Property(e => e.Wtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WTYPE")
                    .HasDefaultValueSql("((0))")
                    .HasComment(" Widget类型");

                entity.Property(e => e.Wurl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("WURL")
                    .HasComment("URL");
            });

            modelBuilder.Entity<Taskservice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TASKSERVICES");

                entity.Property(e => e.Ctime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTIME");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Tianchongcitbl>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__TIANCHON__C49703DE15A53433");

                entity.ToTable("TIANCHONGCITBL");

                entity.Property(e => e.Id0)
                    .ValueGeneratedNever()
                    .HasColumnName("ID0")
                    .HasComment("主键(主键)");

                entity.Property(e => e.Casetype)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CASETYPE")
                    .HasComment("案卷类型");

                entity.Property(e => e.Ownertype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OWNERTYPE")
                    .HasComment("拥有者类型，Common公共");

                entity.Property(e => e.Spcontent)
                    .HasColumnType("text")
                    .HasColumnName("SPCONTENT")
                    .HasComment("审批语内容");

                entity.Property(e => e.Tctype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TCTYPE")
                    .HasComment("填充词类型");

                entity.Property(e => e.Unused1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UNUSED1")
                    .HasComment("备用");

                entity.Property(e => e.Unused2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UNUSED2")
                    .HasComment("备用");

                entity.Property(e => e.Userid)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USERID")
                    .HasComment("用户序号");
            });

            modelBuilder.Entity<Upfileslist>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__UPFILESL__C49703DE1975C517");

                entity.ToTable("UPFILESLIST");

                entity.Property(e => e.Id0)
                    .HasColumnName("ID0")
                    .HasComment("编号(主键)");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Filecontent)
                    .HasColumnType("image")
                    .HasColumnName("FILECONTENT")
                    .HasComment("文件内容");

                entity.Property(e => e.Filename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FILENAME")
                    .HasComment("文件名称");

                entity.Property(e => e.Fileno)
                    .HasColumnName("FILENO")
                    .HasComment("文件编号(页码)(非空)");

                entity.Property(e => e.Materialid)
                    .HasColumnName("MATERIALID")
                    .HasComment("材料编号(非空)");

                entity.Property(e => e.Materialname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MATERIALNAME")
                    .HasComment("材料名称");

                entity.Property(e => e.Pagecontent)
                    .HasColumnName("PAGECONTENT")
                    .HasComment("材料页数");

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");

                entity.Property(e => e.Reserve1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE1")
                    .HasComment("备用1");

                entity.Property(e => e.Reserve2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RESERVE2")
                    .HasComment("备用2");
            });

            modelBuilder.Entity<Userlayerpurview>(entity =>
            {
                entity.HasKey(e => new { e.用户id, e.图层名称 })
                    .HasName("PK__USERLAYE__18F2B5351D4655FB");

                entity.ToTable("USERLAYERPURVIEW");

                entity.Property(e => e.用户id)
                    .HasColumnName("用户ID")
                    .HasComment("编号(主键)");

                entity.Property(e => e.图层名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Userleavelog>(entity =>
            {
                entity.ToTable("USERLEAVELOG");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("ID");

                entity.Property(e => e.Dateend)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEEND")
                    .HasComment("请假截止时间");

                entity.Property(e => e.Datestart)
                    .HasColumnType("datetime")
                    .HasColumnName("DATESTART")
                    .HasComment("请假起始时间");

                entity.Property(e => e.Leavetypeid)
                    .HasColumnName("LEAVETYPEID")
                    .HasComment("请假类型ID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasComment("USERID");
            });

            modelBuilder.Entity<Userloginfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USERLOGINFO");

                entity.Property(e => e.Att1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ATT1");

                entity.Property(e => e.Att2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ATT2");

                entity.Property(e => e.Att3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ATT3");

                entity.Property(e => e.Funmenuexpand)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FUNMENUEXPAND");

                entity.Property(e => e.Hours).HasColumnName("HOURS");

                entity.Property(e => e.Id0).HasColumnName("ID0");

                entity.Property(e => e.Ip)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Line)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LINE");

                entity.Property(e => e.Linedate)
                    .HasColumnType("datetime")
                    .HasColumnName("LINEDATE");

                entity.Property(e => e.Loadcount).HasColumnName("LOADCOUNT");

                entity.Property(e => e.Lsloadtime)
                    .HasColumnType("datetime")
                    .HasColumnName("LSLOADTIME");

                entity.Property(e => e.Lsofftime)
                    .HasColumnType("datetime")
                    .HasColumnName("LSOFFTIME");

                entity.Property(e => e.Messagetype).HasColumnName("MESSAGETYPE");

                entity.Property(e => e.Pagesize).HasColumnName("PAGESIZE");

                entity.Property(e => e.Skin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKIN");

                entity.Property(e => e.Userid).HasColumnName("USERID");
            });

            modelBuilder.Entity<Userstatetype>(entity =>
            {
                entity.HasKey(e => e.Typeid)
                    .HasName("PK__USERSTAT__B2802A0125DB9BFC");

                entity.ToTable("USERSTATETYPE");

                entity.Property(e => e.Typeid)
                    .HasColumnName("TYPEID")
                    .HasComment("TYPEID");

                entity.Property(e => e.Exist)
                    .HasColumnName("EXIST")
                    .HasComment("是否存在");

                entity.Property(e => e.Typename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPENAME")
                    .HasComment("状态名称");

                entity.Property(e => e.Typeorder)
                    .HasColumnName("TYPEORDER")
                    .HasComment("顺序");
            });

            modelBuilder.Entity<ValveRecord>(entity =>
            {
                entity.HasKey(e => e.Id0)
                    .HasName("PK__VALVE_RE__C49703DE29AC2CE0");

                entity.ToTable("VALVE_RECORD");

                entity.Property(e => e.Id0)
                    .HasColumnName("ID0")
                    .HasComment("ID0(主键)");

                entity.Property(e => e.井内情况)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("井内情况");

                entity.Property(e => e.关闭时间)
                    .HasColumnType("datetime")
                    .HasComment("关闭时间");

                entity.Property(e => e.图层名称)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("图层名称");

                entity.Property(e => e.备注)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.开启时间)
                    .HasColumnType("datetime")
                    .HasComment("开启时间");

                entity.Property(e => e.操作人员)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("操作人员");

                entity.Property(e => e.操作原因)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("操作原因");

                entity.Property(e => e.目前状况)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("目前状况");

                entity.Property(e => e.系统中的开关状态)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("系统中的开关状态");

                entity.Property(e => e.记录编号)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("记录编号");

                entity.Property(e => e.阀门编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("阀门编号");

                entity.Property(e => e.需要更新启闭状态)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("需要更新启闭状态");
            });

            modelBuilder.Entity<WebMapMarkTbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WebMapMarkTBL");

                entity.Property(e => e.CtreateTime).HasColumnName("ctreateTime");

                entity.Property(e => e.Geometry)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("geometry");

                entity.Property(e => e.GeometryType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("geometryType");

                entity.Property(e => e.Gonghao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gonghao");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MarkName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("markName");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(255)
                    .HasColumnName("symbol");
            });

            modelBuilder.Entity<Widgetfilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WIDGETFILTER");

                entity.Property(e => e.Style)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STYLE");

                entity.Property(e => e.Widget)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("WIDGET");

                entity.Property(e => e.用户id).HasColumnName("用户ID");
            });

            modelBuilder.Entity<Worktimeset>(entity =>
            {
                entity.HasKey(e => e.Timeid)
                    .HasName("PK__WORKTIME__0F3D72F92E70E1FD");

                entity.ToTable("WORKTIMESET");

                entity.Property(e => e.Timeid)
                    .HasColumnName("TIMEID")
                    .HasComment("TIMEID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARK")
                    .HasComment("备注");

                entity.Property(e => e.Timeend)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIMEEND")
                    .HasComment("下班时间");

                entity.Property(e => e.Timestart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIMESTART")
                    .HasComment("上班时间");
            });

            modelBuilder.Entity<ZdbwfJoint>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__ZDBWF_JOINT__25DB9BFC");

                entity.ToTable("ZDBWF_JOINT");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("UID");

                entity.Property(e => e.Allsubuser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALLSUBUSER");

                entity.Property(e => e.Isback)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISBACK");

                entity.Property(e => e.Needusers).HasColumnName("NEEDUSERS");

                entity.Property(e => e.Stepid).HasColumnName("STEPID");

                entity.Property(e => e.Tonode).HasColumnName("TONODE");

                entity.Property(e => e.Touser).HasColumnName("TOUSER");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Utime)
                    .HasColumnType("datetime")
                    .HasColumnName("UTIME");
            });

            modelBuilder.Entity<ZdbwfTempnodebussatt>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__ZDBWF_TEMPNODEBU__26CFC035");

                entity.ToTable("ZDBWF_TEMPNODEBUSSATT");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("UID");

                entity.Property(e => e.Btntext)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("BTNTEXT");

                entity.Property(e => e.Enabled)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENABLED");

                entity.Property(e => e.Isallusers)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISALLUSERS");

                entity.Property(e => e.Islinktodep)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISLINKTODEP");

                entity.Property(e => e.Istousers)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISTOUSERS");

                entity.Property(e => e.Nodeid).HasColumnName("NODEID");

                entity.Property(e => e.Type).HasColumnName("TYPE");
            });

            modelBuilder.Entity<ZdbwfTempright>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__ZDBWF_TEMPRIGHT__27C3E46E");

                entity.ToTable("ZDBWF_TEMPRIGHT");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("UID");

                entity.Property(e => e.Grantobjid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRANTOBJID");

                entity.Property(e => e.Granttype).HasColumnName("GRANTTYPE");

                entity.Property(e => e.Nodeattribleid).HasColumnName("NODEATTRIBLEID");
            });

            modelBuilder.Entity<事件漏点处理事件表>(entity =>
            {
                entity.ToTable("事件_漏点处理事件表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.漏失程度).HasMaxLength(50);

                entity.Property(e => e.漏点位置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.漏点类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.管径).HasMaxLength(50);

                entity.Property(e => e.管材).HasMaxLength(50);
            });

            modelBuilder.Entity<事件维修处理事件表>(entity =>
            {
                entity.ToTable("事件_维修处理事件表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反映内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<导出cad权限表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("导出CAD权限表");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.用户id).HasColumnName("用户ID");
            });

            modelBuilder.Entity<导出cad记录表>(entity =>
            {
                entity.ToTable("导出CAD记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.地图服务名)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.导出时间).HasColumnType("datetime");

                entity.Property(e => e.文件名)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.用户id).HasColumnName("用户ID");

                entity.Property(e => e.范围)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<巡检关键点记录表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("巡检关键点记录表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS坐标");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.关键点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.关键点状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈距离)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.拍照)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<巡检消防栓记录表>(entity =>
            {
                entity.ToTable("巡检消防栓记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS坐标");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.反馈坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈距离)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.拍照)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.是否完好)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.状态)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<巡检管段记录表>(entity =>
            {
                entity.ToTable("巡检管段记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS坐标");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.反馈坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈距离)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.拍照)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<巡检维修事件表>(entity =>
            {
                entity.ToTable("巡检维修事件表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事发地址)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.到场描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理时限)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.处理紧急程度)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理结果)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.完工照片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.审核意见)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.建议处理方法)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.接单描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.接单时间).HasColumnType("datetime");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.用户名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.用户电话)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.用户编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<巡检阀门记录表>(entity =>
            {
                entity.ToTable("巡检阀门记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS坐标");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.反馈坐标)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈距离)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.拍照)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.是否完好)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.状态)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单事件关联表>(entity =>
            {
                entity.ToTable("工单事件关联表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.子事件主表)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.子事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.子事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.父事件主表)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.父事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.父事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单事件工单关联表>(entity =>
            {
                entity.ToTable("工单事件工单关联表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.业务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单事件模板表>(entity =>
            {
                entity.ToTable("工单事件模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单事件流程配置表>(entity =>
            {
                entity.ToTable("工单事件流程配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.业务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程权限)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单事件辅助视图配置表>(entity =>
            {
                entity.ToTable("工单事件辅助视图配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持视图参数)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持视图标签)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持视图模块)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.视图参数)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图标签)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图模块)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单事件配置表>(entity =>
            {
                entity.ToTable("工单事件配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.业务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.业务编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件主表)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件接口配置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.事件权限)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.关联事件)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.关联字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.前端处理视图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.图片表达)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.摘要字段)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.显示字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.编辑字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.置顶条件)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.视图模块)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.转单字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单功能集成配置表>(entity =>
            {
                entity.ToTable("工单功能集成配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.标签名称)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.组名)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图模块)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单历史操作记录表>(entity =>
            {
                entity.ToTable("工单历史操作记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.图片)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录音)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.操作人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.操作人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.操作时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.节点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.附件)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单台账模型配置表>(entity =>
            {
                entity.ToTable("工单台账模型配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Scada反馈名称)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SCADA反馈名称");

                entity.Property(e => e.业务反馈名称)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.业务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.前端显示字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.台账名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.台账字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.台账添加字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.台账类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.台账编辑字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.台账表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持显示字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.接口配置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.检索字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.父台账名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备图标)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单周期反馈配置表>(entity =>
            {
                entity.ToTable("工单周期反馈配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.反馈表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.字段集)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.节点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单时限规则配置表>(entity =>
            {
                entity.ToTable("工单时限规则配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.开始节点)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.时限单位)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.时限对应字段)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.结束节点)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.规则名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.超期对应字段)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单时限记录表>(entity =>
            {
                entity.ToTable("工单时限记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.实际完成时间).HasColumnType("datetime");

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.规则id).HasColumnName("规则ID");

                entity.Property(e => e.预计完成时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<工单材料使用表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("工单材料使用表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.单位)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.厂商)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.是否删除)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材料名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材料类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材料编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.添加人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.规格)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单材料库表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("工单材料库表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.单位)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.厂商)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材料名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材料类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材料编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.规格)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单材料配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("工单材料配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.保养类型)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.材料名称)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.材料默认值)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单步骤反馈配置表>(entity =>
            {
                entity.ToTable("工单步骤反馈配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.反馈表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.字段集)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.步骤名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.节点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单流程状态表>(entity =>
            {
                entity.ToTable("工单流程状态表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.结束时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<工单流程节点配置表>(entity =>
            {
                entity.ToTable("工单流程节点配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.反馈名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.回退至节点)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.手持视图模块)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.操作类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.查看字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.移交方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.节点别名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.节点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图参数)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图模块)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单流程辅助视图配置表>(entity =>
            {
                entity.ToTable("工单流程辅助视图配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.手持视图参数)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持视图标签)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持视图模块)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.节点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图参数)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图标签)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视图模块)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单流程配置表>(entity =>
            {
                entity.ToTable("工单流程配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.办理页面)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.手持办理页面)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.接口配置)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单漏点处理工单表>(entity =>
            {
                entity.ToTable("工单_漏点处理工单表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.复核意见)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.现场描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单用户关注表>(entity =>
            {
                entity.ToTable("工单用户关注表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.工单编号)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.用户id).HasColumnName("用户ID");
            });

            modelBuilder.Entity<工单维修处理工单表>(entity =>
            {
                entity.ToTable("工单_维修处理工单表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.到场描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.处理时限)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理紧急程度)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理结果)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.完工照片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.审核意见)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.审核时间).HasColumnType("smalldatetime");

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.建议处理方法)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.接单描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.接单时间).HasColumnType("datetime");

                entity.Property(e => e.派单信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.维修内容)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.维修时间).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<工单表字段覆盖配置表>(entity =>
            {
                entity.ToTable("工单表字段覆盖配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.别名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.单位).HasMaxLength(50);

                entity.Property(e => e.字段名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.形态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.界面分组)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.表名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.配置信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.预设值)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.验证规则)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单表字段配置表>(entity =>
            {
                entity.ToTable("工单表字段配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.别名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.单位).HasMaxLength(50);

                entity.Property(e => e.字段名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.形态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.界面分组)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.表名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.触发事件)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.触发事件字段集)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.触发异常值)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.配置信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.预设值)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.验证规则)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单表配置表>(entity =>
            {
                entity.ToTable("工单表配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.别名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.导出模板)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.接口配置)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.显示模板)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.表格样式)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单设备反馈配置表>(entity =>
            {
                entity.ToTable("工单设备反馈配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis过滤条件)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GIS过滤条件");

                entity.Property(e => e.分组类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.图层名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.字段集)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.流程名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.站点)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.节点名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.触发事件)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.触发异常值)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工单设备编辑配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("工单设备编辑配置表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis过滤条件)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GIS过滤条件");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.反馈表名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.图层名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.字段集)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<工程现场上报表>(entity =>
            {
                entity.ToTable("工程现场上报表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.安全隐患描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.当前进度)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.施工现场情况)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报表方案配置表>(entity =>
            {
                entity.ToTable("报表方案配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.前端模板)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.导出方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.导出模板)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.方案分组)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.查询数据库)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报表条件配置表>(entity =>
            {
                entity.ToTable("报表条件配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.别名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.单位)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.形态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.条件名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.配置信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.预设值)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报表视图子句配置表>(entity =>
            {
                entity.ToTable("报表视图子句配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.子句名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.条件名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.表达式).IsUnicode(false);

                entity.Property(e => e.视图名)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报表视图配置表>(entity =>
            {
                entity.ToTable("报表视图配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.表达式).IsUnicode(false);

                entity.Property(e => e.视图名)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报警传感器配置表>(entity =>
            {
                entity.ToTable("报警_传感器配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SensorId).HasColumnName("sensorID");

                entity.Property(e => e.取值方式)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.生效开始日期).HasColumnType("date");

                entity.Property(e => e.生效开始时间段)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.生效结束日期).HasColumnType("date");

                entity.Property(e => e.生效结束时间段)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报警地址方案配置表>(entity =>
            {
                entity.ToTable("报警_地址方案配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PointAddressEntryId).HasColumnName("pointAddressEntryID");

                entity.Property(e => e.取值方式)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.生效开始日期).HasColumnType("date");

                entity.Property(e => e.生效开始时间段)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.生效结束日期).HasColumnType("date");

                entity.Property(e => e.生效结束时间段)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报警多指标and缓存记录表传感器>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("报警_多指标and缓存记录表_传感器");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警多指标and缓存记录表地址方案>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("报警_多指标and缓存记录表_地址方案");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警多指标and缓存记录表设备类型>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("报警_多指标and缓存记录表_设备类型");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警多指标or缓存记录表传感器>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("报警_多指标or缓存记录表_传感器");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警多指标or缓存记录表地址方案>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("报警_多指标or缓存记录表_地址方案");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警多指标or缓存记录表设备类型>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("报警_多指标or缓存记录表_设备类型");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警方案配置表>(entity =>
            {
                entity.ToTable("报警_方案配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.报警类型)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.推送人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.推送方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.组合规则)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<报警记录表>(entity =>
            {
                entity.ToTable("报警_记录表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SensorId).HasColumnName("SensorID");

                entity.Property(e => e.反馈id).HasColumnName("反馈ID");

                entity.Property(e => e.备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.报警值)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.报警内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.报警规则)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.报警限值)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.配置id).HasColumnName("配置ID");
            });

            modelBuilder.Entity<报警设备类型配置表>(entity =>
            {
                entity.ToTable("报警_设备类型配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.取值方式)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.方案id).HasColumnName("方案ID");

                entity.Property(e => e.标签名)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.生效开始日期).HasColumnType("date");

                entity.Property(e => e.生效开始时间段)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.生效结束日期).HasColumnType("date");

                entity.Property(e => e.生效结束时间段)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<探漏探漏结果表>(entity =>
            {
                entity.ToTable("探漏_探漏结果表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.漏损上限)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.漏损下限)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.结论)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<探漏测试方案表>(entity =>
            {
                entity.ToTable("探漏_测试方案表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.停止时间).HasColumnType("datetime");

                entity.Property(e => e.分区范围).IsUnicode(false);

                entity.Property(e => e.分析模式)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.方案名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.测试结果)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.漏损率)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<探漏设备挂接表>(entity =>
            {
                entity.ToTable("探漏_设备挂接表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.安装位置).IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备级别)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史二供机组>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_二供机组");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.Plc程序版本号).HasColumnName("PLC程序版本号");

                entity.Property(e => e.Ups电源异常).HasColumnName("UPS电源异常");

                entity.Property(e => e._1变频器运行频率).HasColumnName("1#变频器运行频率");

                entity.Property(e => e._1排水泵状态).HasColumnName("1#排水泵状态");

                entity.Property(e => e._1水箱低位报警).HasColumnName("1#水箱低位报警");

                entity.Property(e => e._1水箱液位).HasColumnName("1#水箱液位");

                entity.Property(e => e._1水箱高位报警).HasColumnName("1#水箱高位报警");

                entity.Property(e => e._1滞留时间).HasColumnName("1#滞留时间");

                entity.Property(e => e._1电动阀在全关位置).HasColumnName("1#电动阀在全关位置");

                entity.Property(e => e._1电动阀在全开位置).HasColumnName("1#电动阀在全开位置");

                entity.Property(e => e._1电动阀开度).HasColumnName("1#电动阀开度");

                entity.Property(e => e._1电动阀异常).HasColumnName("1#电动阀异常");

                entity.Property(e => e._1补水时间).HasColumnName("1#补水时间");

                entity.Property(e => e._2变频器运行频率).HasColumnName("2#变频器运行频率");

                entity.Property(e => e._2排水泵状态).HasColumnName("2#排水泵状态");

                entity.Property(e => e._2水箱低位报警).HasColumnName("2#水箱低位报警");

                entity.Property(e => e._2水箱液位).HasColumnName("2#水箱液位");

                entity.Property(e => e._2水箱高位报警).HasColumnName("2#水箱高位报警");

                entity.Property(e => e._2滞留时间).HasColumnName("2#滞留时间");

                entity.Property(e => e._2电动阀在全关位置).HasColumnName("2#电动阀在全关位置");

                entity.Property(e => e._2电动阀在全开位置).HasColumnName("2#电动阀在全开位置");

                entity.Property(e => e._2电动阀开度).HasColumnName("2#电动阀开度");

                entity.Property(e => e._2电动阀异常).HasColumnName("2#电动阀异常");

                entity.Property(e => e._2补水时间).HasColumnName("2#补水时间");

                entity.Property(e => e._3变频器运行频率).HasColumnName("3#变频器运行频率");

                entity.Property(e => e._3排水泵状态).HasColumnName("3#排水泵状态");

                entity.Property(e => e._3水箱液位).HasColumnName("3#水箱液位");

                entity.Property(e => e._4变频器运行频率).HasColumnName("4#变频器运行频率");

                entity.Property(e => e._4排水泵状态).HasColumnName("4#排水泵状态");

                entity.Property(e => e._4水箱液位).HasColumnName("4#水箱液位");

                entity.Property(e => e._5变频器运行频率).HasColumnName("5#变频器运行频率");

                entity.Property(e => e._6变频器运行频率).HasColumnName("6#变频器运行频率");

                entity.Property(e => e._7变频器运行频率).HasColumnName("7#变频器运行频率");

                entity.Property(e => e._8变频器运行频率).HasColumnName("8#变频器运行频率");

                entity.Property(e => e.智能电表A相功率).HasColumnName("智能电表 A相功率");

                entity.Property(e => e.智能电表B相功率).HasColumnName("智能电表 B相功率");

                entity.Property(e => e.智能电表C相功率).HasColumnName("智能电表 C相功率");

                entity.Property(e => e.智能电表ia).HasColumnName("智能电表Ia");

                entity.Property(e => e.智能电表ib).HasColumnName("智能电表Ib");

                entity.Property(e => e.智能电表ic).HasColumnName("智能电表Ic");

                entity.Property(e => e.智能电表ua).HasColumnName("智能电表Ua");

                entity.Property(e => e.智能电表ub).HasColumnName("智能电表Ub");

                entity.Property(e => e.智能电表uc).HasColumnName("智能电表Uc");

                entity.Property(e => e.智能电表功率因素cos).HasColumnName("智能电表-功率因素cos");

                entity.Property(e => e.智能电表温度).HasColumnName("智能电表-温度");

                entity.Property(e => e.智能电表漏电流).HasColumnName("智能电表-漏电流");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.累计电量泵运行时).HasColumnName("累计电量_泵运行时");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设置1电动阀开度).HasColumnName("设置1#电动阀开度");

                entity.Property(e => e.设置2电动阀开度).HasColumnName("设置2#电动阀开度");

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史二供泵房>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_二供泵房");

                //entity.HasIndex(e => e.采集时间, "采集时间_index");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e._1水箱液位).HasColumnName("1#水箱液位");

                entity.Property(e => e._2水箱液位).HasColumnName("2#水箱液位");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史便携式流量计>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_便携式流量计");

                //entity.HasIndex(e => e.采集时间, "采集时间_index");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史便携式流量计1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_便携式流量计1");

                //entity.HasIndex(e => e.采集时间, "采集时间_index");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史便携式流量计2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_便携式流量计2");

                //entity.HasIndex(e => e.采集时间, "采集时间_index");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史压力表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_压力表");

                entity.Property(e => e.FonLine).HasColumnName("FOnLine");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史户表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_户表");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.抄表年月)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.抄表日期).HasColumnType("datetime");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史数据模板表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史数据模板表");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史水厂>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_水厂");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<数据历史水源井>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_水源井");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<数据历史流量计>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_流量计");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据历史熊猫水表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_历史_熊猫水表");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时二供机组>(entity =>
            {
                entity.ToTable("数据_实时_二供机组");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.Plc程序版本号).HasColumnName("PLC程序版本号");

                entity.Property(e => e.Ups电源异常).HasColumnName("UPS电源异常");

                entity.Property(e => e._1变频器运行频率).HasColumnName("1#变频器运行频率");

                entity.Property(e => e._1排水泵状态).HasColumnName("1#排水泵状态");

                entity.Property(e => e._1水箱低位报警).HasColumnName("1#水箱低位报警");

                entity.Property(e => e._1水箱液位).HasColumnName("1#水箱液位");

                entity.Property(e => e._1水箱高位报警).HasColumnName("1#水箱高位报警");

                entity.Property(e => e._1滞留时间).HasColumnName("1#滞留时间");

                entity.Property(e => e._1电动阀在全关位置).HasColumnName("1#电动阀在全关位置");

                entity.Property(e => e._1电动阀在全开位置).HasColumnName("1#电动阀在全开位置");

                entity.Property(e => e._1电动阀开度).HasColumnName("1#电动阀开度");

                entity.Property(e => e._1电动阀异常).HasColumnName("1#电动阀异常");

                entity.Property(e => e._1补水时间).HasColumnName("1#补水时间");

                entity.Property(e => e._2变频器运行频率).HasColumnName("2#变频器运行频率");

                entity.Property(e => e._2排水泵状态).HasColumnName("2#排水泵状态");

                entity.Property(e => e._2水箱低位报警).HasColumnName("2#水箱低位报警");

                entity.Property(e => e._2水箱液位).HasColumnName("2#水箱液位");

                entity.Property(e => e._2水箱高位报警).HasColumnName("2#水箱高位报警");

                entity.Property(e => e._2滞留时间).HasColumnName("2#滞留时间");

                entity.Property(e => e._2电动阀在全关位置).HasColumnName("2#电动阀在全关位置");

                entity.Property(e => e._2电动阀在全开位置).HasColumnName("2#电动阀在全开位置");

                entity.Property(e => e._2电动阀开度).HasColumnName("2#电动阀开度");

                entity.Property(e => e._2电动阀异常).HasColumnName("2#电动阀异常");

                entity.Property(e => e._2补水时间).HasColumnName("2#补水时间");

                entity.Property(e => e._3变频器运行频率).HasColumnName("3#变频器运行频率");

                entity.Property(e => e._3排水泵状态).HasColumnName("3#排水泵状态");

                entity.Property(e => e._3水箱液位).HasColumnName("3#水箱液位");

                entity.Property(e => e._4变频器运行频率).HasColumnName("4#变频器运行频率");

                entity.Property(e => e._4排水泵状态).HasColumnName("4#排水泵状态");

                entity.Property(e => e._4水箱液位).HasColumnName("4#水箱液位");

                entity.Property(e => e._5变频器运行频率).HasColumnName("5#变频器运行频率");

                entity.Property(e => e._6变频器运行频率).HasColumnName("6#变频器运行频率");

                entity.Property(e => e._7变频器运行频率).HasColumnName("7#变频器运行频率");

                entity.Property(e => e._8变频器运行频率).HasColumnName("8#变频器运行频率");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.智能电表A相功率).HasColumnName("智能电表 A相功率");

                entity.Property(e => e.智能电表B相功率).HasColumnName("智能电表 B相功率");

                entity.Property(e => e.智能电表C相功率).HasColumnName("智能电表 C相功率");

                entity.Property(e => e.智能电表ia).HasColumnName("智能电表Ia");

                entity.Property(e => e.智能电表ib).HasColumnName("智能电表Ib");

                entity.Property(e => e.智能电表ic).HasColumnName("智能电表Ic");

                entity.Property(e => e.智能电表ua).HasColumnName("智能电表Ua");

                entity.Property(e => e.智能电表ub).HasColumnName("智能电表Ub");

                entity.Property(e => e.智能电表uc).HasColumnName("智能电表Uc");

                entity.Property(e => e.智能电表功率因素cos).HasColumnName("智能电表-功率因素cos");

                entity.Property(e => e.智能电表温度).HasColumnName("智能电表-温度");

                entity.Property(e => e.智能电表漏电流).HasColumnName("智能电表-漏电流");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.累计电量泵运行时).HasColumnName("累计电量_泵运行时");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设置1电动阀开度).HasColumnName("设置1#电动阀开度");

                entity.Property(e => e.设置2电动阀开度).HasColumnName("设置2#电动阀开度");

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时二供泵房>(entity =>
            {
                entity.ToTable("数据_实时_二供泵房");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e._1水箱液位).HasColumnName("1#水箱液位");

                entity.Property(e => e._2水箱液位).HasColumnName("2#水箱液位");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时便携式流量计>(entity =>
            {
                entity.ToTable("数据_实时_便携式流量计");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时压力表>(entity =>
            {
                entity.ToTable("数据_实时_压力表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FonLine).HasColumnName("FOnLine");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时户表>(entity =>
            {
                entity.ToTable("数据_实时_户表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.抄表年月)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.抄表日期).HasColumnType("datetime");

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时数据模板表>(entity =>
            {
                entity.ToTable("数据_实时数据模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时水厂>(entity =>
            {
                entity.ToTable("数据_实时_水厂");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BpRt1).HasColumnName("BP_RT1");

                entity.Property(e => e.BpRt2).HasColumnName("BP_RT2");

                entity.Property(e => e.BpRt3).HasColumnName("BP_RT3");

                entity.Property(e => e.BpRt4).HasColumnName("BP_RT4");

                entity.Property(e => e.BpRt5).HasColumnName("BP_RT5");

                entity.Property(e => e._1上限).HasColumnName("1#上限");

                entity.Property(e => e._1投入).HasColumnName("1#投入");

                entity.Property(e => e._1水位报警).HasColumnName("1#水位报警");

                entity.Property(e => e._2上限).HasColumnName("2#上限");

                entity.Property(e => e._2投入).HasColumnName("2#投入");

                entity.Property(e => e._2水位报警).HasColumnName("2#水位报警");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.变频1启动).HasColumnName("变频1#启动");

                entity.Property(e => e.变频1故障).HasColumnName("变频1#故障");

                entity.Property(e => e.变频1电流).HasColumnName("变频1#电流");

                entity.Property(e => e.变频1运行).HasColumnName("变频1#运行");

                entity.Property(e => e.变频1通讯故障).HasColumnName("变频1#通讯故障");

                entity.Property(e => e.变频1频率).HasColumnName("变频1#频率");

                entity.Property(e => e.变频2启动).HasColumnName("变频2#启动");

                entity.Property(e => e.变频2故障).HasColumnName("变频2#故障");

                entity.Property(e => e.变频2电流).HasColumnName("变频2#电流");

                entity.Property(e => e.变频2运行).HasColumnName("变频2#运行");

                entity.Property(e => e.变频2通讯故障).HasColumnName("变频2#通讯故障");

                entity.Property(e => e.变频2频率).HasColumnName("变频2#频率");

                entity.Property(e => e.变频3启动).HasColumnName("变频3#启动");

                entity.Property(e => e.变频3故障).HasColumnName("变频3#故障");

                entity.Property(e => e.变频3电流).HasColumnName("变频3#电流");

                entity.Property(e => e.变频3运行).HasColumnName("变频3#运行");

                entity.Property(e => e.变频3通讯故障).HasColumnName("变频3#通讯故障");

                entity.Property(e => e.变频3频率).HasColumnName("变频3#频率");

                entity.Property(e => e.变频4启动).HasColumnName("变频4#启动");

                entity.Property(e => e.变频4故障).HasColumnName("变频4#故障");

                entity.Property(e => e.变频4电流).HasColumnName("变频4#电流");

                entity.Property(e => e.变频4运行).HasColumnName("变频4#运行");

                entity.Property(e => e.变频4通讯故障).HasColumnName("变频4#通讯故障");

                entity.Property(e => e.变频4频率).HasColumnName("变频4#频率");

                entity.Property(e => e.变频5启动).HasColumnName("变频5#启动");

                entity.Property(e => e.变频5故障).HasColumnName("变频5#故障");

                entity.Property(e => e.变频5电流).HasColumnName("变频5#电流");

                entity.Property(e => e.变频5运行).HasColumnName("变频5#运行");

                entity.Property(e => e.变频5通讯故障).HasColumnName("变频5#通讯故障");

                entity.Property(e => e.变频5频率).HasColumnName("变频5#频率");

                entity.Property(e => e.变频手动给定值1).HasColumnName("变频手动给定值_1");

                entity.Property(e => e.变频手动给定值2).HasColumnName("变频手动给定值_2");

                entity.Property(e => e.变频手动给定值3).HasColumnName("变频手动给定值_3");

                entity.Property(e => e.变频手动给定值4).HasColumnName("变频手动给定值_4");

                entity.Property(e => e.变频手动给定值5).HasColumnName("变频手动给定值_5");

                entity.Property(e => e.启用手动值1).HasColumnName("启用手动值_1");

                entity.Property(e => e.启用手动值2).HasColumnName("启用手动值_2");

                entity.Property(e => e.启用手动值3).HasColumnName("启用手动值_3");

                entity.Property(e => e.启用手动值4).HasColumnName("启用手动值_4");

                entity.Property(e => e.启用手动值5).HasColumnName("启用手动值_5");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.泵1压力).HasColumnName("泵1#压力");

                entity.Property(e => e.泵1流量).HasColumnName("泵1#流量");

                entity.Property(e => e.泵1电流).HasColumnName("泵1#电流");

                entity.Property(e => e.泵1累计流量).HasColumnName("泵1#累计流量");

                entity.Property(e => e.泵1频率).HasColumnName("泵1#频率");

                entity.Property(e => e.泵2压力).HasColumnName("泵2#压力");

                entity.Property(e => e.泵2流量).HasColumnName("泵2#流量");

                entity.Property(e => e.泵2电流).HasColumnName("泵2#电流");

                entity.Property(e => e.泵2累计流量).HasColumnName("泵2#累计流量");

                entity.Property(e => e.泵2频率).HasColumnName("泵2#频率");

                entity.Property(e => e.泵3压力).HasColumnName("泵3#压力");

                entity.Property(e => e.泵3流量).HasColumnName("泵3#流量");

                entity.Property(e => e.泵3电流).HasColumnName("泵3#电流");

                entity.Property(e => e.泵3累计流量).HasColumnName("泵3#累计流量");

                entity.Property(e => e.泵3频率).HasColumnName("泵3#频率");

                entity.Property(e => e.泵4压力).HasColumnName("泵4#压力");

                entity.Property(e => e.泵4流量).HasColumnName("泵4#流量");

                entity.Property(e => e.泵4电流).HasColumnName("泵4#电流");

                entity.Property(e => e.泵4累计流量).HasColumnName("泵4#累计流量");

                entity.Property(e => e.泵4频率).HasColumnName("泵4#频率");

                entity.Property(e => e.泵5压力).HasColumnName("泵5#压力");

                entity.Property(e => e.泵5流量).HasColumnName("泵5#流量");

                entity.Property(e => e.泵5电流).HasColumnName("泵5#电流");

                entity.Property(e => e.泵5累计流量).HasColumnName("泵5#累计流量");

                entity.Property(e => e.泵5频率).HasColumnName("泵5#频率");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.老城区压力低报警1).HasColumnName("老城区压力低报警_1");

                entity.Property(e => e.老城区流量高报警1).HasColumnName("老城区流量高报警_1");

                entity.Property(e => e.表aa1).HasColumnName("表AA_1");

                entity.Property(e => e.表aa2).HasColumnName("表AA_2");

                entity.Property(e => e.表aa3).HasColumnName("表AA_3");

                entity.Property(e => e.表aa4).HasColumnName("表AA_4");

                entity.Property(e => e.表aa5).HasColumnName("表AA_5");

                entity.Property(e => e.表ab1).HasColumnName("表AB_1");

                entity.Property(e => e.表ab2).HasColumnName("表AB_2");

                entity.Property(e => e.表ab3).HasColumnName("表AB_3");

                entity.Property(e => e.表ab4).HasColumnName("表AB_4");

                entity.Property(e => e.表ab5).HasColumnName("表AB_5");

                entity.Property(e => e.表ac1).HasColumnName("表AC_1");

                entity.Property(e => e.表ac2).HasColumnName("表AC_2");

                entity.Property(e => e.表ac3).HasColumnName("表AC_3");

                entity.Property(e => e.表ac4).HasColumnName("表AC_4");

                entity.Property(e => e.表ac5).HasColumnName("表AC_5");

                entity.Property(e => e.表glys1).HasColumnName("表GLYS_1");

                entity.Property(e => e.表glys2).HasColumnName("表GLYS_2");

                entity.Property(e => e.表glys3).HasColumnName("表GLYS_3");

                entity.Property(e => e.表glys4).HasColumnName("表GLYS_4");

                entity.Property(e => e.表glys5).HasColumnName("表GLYS_5");

                entity.Property(e => e.表ua1).HasColumnName("表UA_1");

                entity.Property(e => e.表ua2).HasColumnName("表UA_2");

                entity.Property(e => e.表ua3).HasColumnName("表UA_3");

                entity.Property(e => e.表ua4).HasColumnName("表UA_4");

                entity.Property(e => e.表ua5).HasColumnName("表UA_5");

                entity.Property(e => e.表ub1).HasColumnName("表UB_1");

                entity.Property(e => e.表ub2).HasColumnName("表UB_2");

                entity.Property(e => e.表ub3).HasColumnName("表UB_3");

                entity.Property(e => e.表ub4).HasColumnName("表UB_4");

                entity.Property(e => e.表ub5).HasColumnName("表UB_5");

                entity.Property(e => e.表uc1).HasColumnName("表UC_1");

                entity.Property(e => e.表uc2).HasColumnName("表UC_2");

                entity.Property(e => e.表uc3).HasColumnName("表UC_3");

                entity.Property(e => e.表uc4).HasColumnName("表UC_4");

                entity.Property(e => e.表uc5).HasColumnName("表UC_5");

                entity.Property(e => e.表wgdn1).HasColumnName("表WGDN_1");

                entity.Property(e => e.表wgdn2).HasColumnName("表WGDN_2");

                entity.Property(e => e.表wgdn3).HasColumnName("表WGDN_3");

                entity.Property(e => e.表wgdn4).HasColumnName("表WGDN_4");

                entity.Property(e => e.表wgdn5).HasColumnName("表WGDN_5");

                entity.Property(e => e.表ygdn1).HasColumnName("表YGDN_1");

                entity.Property(e => e.表ygdn2).HasColumnName("表YGDN_2");

                entity.Property(e => e.表ygdn3).HasColumnName("表YGDN_3");

                entity.Property(e => e.表ygdn4).HasColumnName("表YGDN_4");

                entity.Property(e => e.表ygdn5).HasColumnName("表YGDN_5");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.阀1故障).HasColumnName("阀1#故障");

                entity.Property(e => e.阀2故障).HasColumnName("阀2#故障");

                entity.Property(e => e.阀3故障).HasColumnName("阀3#故障");

                entity.Property(e => e.阀4故障).HasColumnName("阀4#故障");

                entity.Property(e => e.阀5故障).HasColumnName("阀5#故障");

                entity.Property(e => e.阀门1关阀).HasColumnName("阀门1#关阀");

                entity.Property(e => e.阀门1开阀).HasColumnName("阀门1#开阀");

                entity.Property(e => e.阀门2关阀).HasColumnName("阀门2#关阀");

                entity.Property(e => e.阀门2开阀).HasColumnName("阀门2#开阀");

                entity.Property(e => e.阀门3关阀).HasColumnName("阀门3#关阀");

                entity.Property(e => e.阀门3开阀).HasColumnName("阀门3#开阀");

                entity.Property(e => e.阀门4关阀).HasColumnName("阀门4#关阀");

                entity.Property(e => e.阀门4开阀).HasColumnName("阀门4#开阀");

                entity.Property(e => e.阀门5关阀).HasColumnName("阀门5#关阀");

                entity.Property(e => e.阀门5开阀).HasColumnName("阀门5#开阀");
            });

            modelBuilder.Entity<数据实时水源井>(entity =>
            {
                entity.ToTable("数据_实时_水源井");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Md初始化代码).HasColumnName("MD初始化代码");

                entity.Property(e => e.Md初始完成).HasColumnName("MD初始完成");

                entity.Property(e => e.Md通讯错误代码).HasColumnName("MD通讯错误代码");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<数据实时流量计>(entity =>
            {
                entity.ToTable("数据_实时_流量计");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据实时熊猫水表>(entity =>
            {
                entity.ToTable("数据_实时_熊猫水表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gprs电压).HasColumnName("GPRS电压");

                entity.Property(e => e.上线时间).HasColumnType("datetime");

                entity.Property(e => e.当前报警)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.离线时间).HasColumnType("datetime");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集时间).HasColumnType("datetime");

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计二供机组>(entity =>
            {
                entity.ToTable("数据_统计_二供机组");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计二供泵房>(entity =>
            {
                entity.ToTable("数据_统计_二供泵房");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计便携式流量计>(entity =>
            {
                entity.ToTable("数据_统计_便携式流量计");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计压力表>(entity =>
            {
                entity.ToTable("数据_统计_压力表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计周期脚本配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("数据_统计_周期脚本配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.缓存周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.缓存类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.缓存类型名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.脚本).IsUnicode(false);
            });

            modelBuilder.Entity<数据统计户表>(entity =>
            {
                entity.ToTable("数据_统计_户表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计数据模板表>(entity =>
            {
                entity.ToTable("数据_统计数据模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计水厂>(entity =>
            {
                entity.ToTable("数据_统计_水厂");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计水源井>(entity =>
            {
                entity.ToTable("数据_统计_水源井");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计流量计>(entity =>
            {
                entity.ToTable("数据_统计_流量计");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计熊猫水表>(entity =>
            {
                entity.ToTable("数据_统计_熊猫水表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.指标名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.统计值发生时间).HasColumnType("datetime");

                entity.Property(e => e.统计周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.统计类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<数据统计配置表>(entity =>
            {
                entity.ToTable("数据_统计_配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.备注).IsUnicode(false);

                entity.Property(e => e.字段集).IsUnicode(false);

                entity.Property(e => e.数据源集)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.缓存周期)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.脚本内容).IsUnicode(false);

                entity.Property(e => e.脚本语言)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.表名)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型名)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<用户登录记录表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("用户登录记录表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.用户名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.用户登录名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.登录时间).HasColumnType("datetime");

                entity.Property(e => e.系统类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.终端)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<监控二供巡检台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("监控_二供_巡检台账表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.信号指示灯)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.元器件)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.出压检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.卫生状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈信息)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.变频器)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.噪音状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.安防系统)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.室内温度)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.室内湿度)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.巡检人员)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.巡检总结)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.巡检时间).HasColumnType("datetime");

                entity.Property(e => e.巡检编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.所属泵房)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.排污设备)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.控制柜plc)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("控制柜PLC");

                entity.Property(e => e.控制柜状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.散热检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.文本显示器)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.泵体振动)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.泵运行状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.消毒设备)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.液位检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.液位状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.渗透状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.温度状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.湿度状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.现场照片).IsUnicode(false);

                entity.Property(e => e.电压检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.电压状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.电流检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.电流状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.电量检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.电量状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.管道检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.管道状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.视频系统)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.触摸屏)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.设备噪音)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.设备渗漏)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.设备锈蚀)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.进出水压力状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.进压检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.通讯设备)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.通风设备)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.门禁状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.门禁系统)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.阀件检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.阀件状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.除湿设备)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.频率检测)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.频率状态)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<监控二供水箱清洗台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("监控_二供_水箱清洗台账表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.主任)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.停水时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.公示现场照片)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.取报告人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.取报告日期).HasColumnType("date");

                entity.Property(e => e.取样地点)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.取样数).HasComment("单位:升");

                entity.Property(e => e.工程主管)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.所属泵房)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.报告编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.样品性状)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.检测水样单位)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.水质取样人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.水质检测结果)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.消毒放水开始时间).HasColumnType("datetime");

                entity.Property(e => e.消毒放水结束时间).HasColumnType("datetime");

                entity.Property(e => e.消毒用药品名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.消毒药品用量)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.消毒药品见证人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.消毒药品配置人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.清洗人员)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.清洗单位)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.清洗开始时间).HasColumnType("datetime");

                entity.Property(e => e.清洗持续时间).HasComment("单位:小时");

                entity.Property(e => e.清洗排水开始时间).HasColumnType("datetime");

                entity.Property(e => e.清洗排水持续时间).HasComment("单位:小时");

                entity.Property(e => e.清洗排水结束时间).HasColumnType("datetime");

                entity.Property(e => e.清洗日期).HasColumnType("date");

                entity.Property(e => e.清洗消毒情况记录)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.清洗结束时间).HasColumnType("datetime");

                entity.Property(e => e.记录编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.责任人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.送检人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.送检时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<监控二供水质检测台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("监控_二供_水质检测台账表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.公示现场照片)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.取样位置)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.委托单位)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.委托日期)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.委方地址)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.所属泵房)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.报告日期).HasColumnType("date");

                entity.Property(e => e.报告编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.收样日期)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.来样方式)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.样品名称)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.样品性状)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.样品种类)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.检测人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.检测单位)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.检测报告)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.检测日期).HasColumnType("date");

                entity.Property(e => e.检测结果)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.检测结论).IsUnicode(false);

                entity.Property(e => e.检验类别)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.评价依据)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.送样日期).HasColumnType("date");

                entity.Property(e => e.采样位置)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采样日期)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<监控二供泵房维修事件表>(entity =>
            {
                entity.ToTable("监控_二供_泵房维修事件表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.事件内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.所属泵房)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.故障内容)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.故障描述).IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.机组信息)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<监控二供泵房维修工单表>(entity =>
            {
                entity.ToTable("监控_二供_泵房维修工单表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.事件内容).IsUnicode(false);

                entity.Property(e => e.事件类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.到场录音).IsUnicode(false);

                entity.Property(e => e.到场描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.到场照片).IsUnicode(false);

                entity.Property(e => e.处理时限)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理紧急程度)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.完工图片).IsUnicode(false);

                entity.Property(e => e.完工录音).IsUnicode(false);

                entity.Property(e => e.完工描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.完工时间).HasColumnType("datetime");

                entity.Property(e => e.审核意见)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.建议处理方法)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.接单描述)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.接单时间).HasColumnType("datetime");

                entity.Property(e => e.是否完成维修)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.现场核实人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修图片).IsUnicode(false);

                entity.Property(e => e.维修录音).IsUnicode(false);

                entity.Property(e => e.维修描述).IsUnicode(false);

                entity.Property(e => e.维修方式)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.维修时间).HasColumnType("datetime");

                entity.Property(e => e.预计维修结束时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<监控二供维保台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("监控_二供_维保台账表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.保养人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.保养周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.保养时间).HasColumnType("datetime");

                entity.Property(e => e.保养状态)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.保养编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.保养说明)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.保养项目)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.所属泵房)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.是否维修)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.现场照片).IsUnicode(false);

                entity.Property(e => e.维保人员)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维保时间).HasColumnType("datetime");

                entity.Property(e => e.维保状态)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.维保编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维保说明)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.维保项目)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修说明)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<监控二供维修台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("监控_二供_维修台账表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.完工时间).HasColumnType("datetime");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.所属泵房)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.报障时间).HasColumnType("datetime");

                entity.Property(e => e.故障现象).IsUnicode(false);

                entity.Property(e => e.更换材料)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.现场照片).IsUnicode(false);

                entity.Property(e => e.紧急程度)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.维修人员)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.维修描述)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.维修时间).HasColumnType("datetime");

                entity.Property(e => e.维修来源)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.维修状态)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.维修编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修设备)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.维修说明)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<组态属性表>(entity =>
            {
                entity.ToTable("组态_属性表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.属性名称).HasMaxLength(1024);

                entity.Property(e => e.属性类型).HasMaxLength(64);
            });

            modelBuilder.Entity<组态模型信息表>(entity =>
            {
                entity.ToTable("组态_模型信息表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Value)
                    .HasMaxLength(64)
                    .HasColumnName("VALUE");

                entity.Property(e => e.属性id).HasColumnName("属性ID");

                entity.Property(e => e.模型名称).HasMaxLength(64);

                entity.Property(e => e.维度)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<组态模型类型表>(entity =>
            {
                entity.ToTable("组态_模型类型表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.创建人).HasMaxLength(16);

                entity.Property(e => e.创建日期).HasColumnType("datetime");

                entity.Property(e => e.类型名称).HasMaxLength(64);
            });

            modelBuilder.Entity<组态模型表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("组态_模型表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.创建人).HasMaxLength(16);

                entity.Property(e => e.创建日期).HasColumnType("datetime");

                entity.Property(e => e.图标路径).HasMaxLength(255);

                entity.Property(e => e.是否编辑)
                    .HasDefaultValueSql("((0))")
                    .HasComment("默认为0 可编辑  1 不可编辑");

                entity.Property(e => e.材质文件路径)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.模型名称).HasMaxLength(64);

                entity.Property(e => e.模型存储路径).HasMaxLength(255);

                entity.Property(e => e.模型长宽高)
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.特征)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.类型名称).HasMaxLength(64);

                entity.Property(e => e.维度).HasMaxLength(4);
            });

            modelBuilder.Entity<组态画板>(entity =>
            {
                entity.ToTable("组态_画板");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SiteCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("siteCode")
                    .HasComment("站点编号");

                entity.Property(e => e.全景模型)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.关联三维模型名称)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasComment("二维画板关联的三维模型");

                entity.Property(e => e.摄相机xyz)
                    .HasMaxLength(16)
                    .HasColumnName("摄相机XYZ");

                entity.Property(e => e.是否删除)
                    .HasDefaultValueSql("((0))")
                    .HasComment("1已删除 0未删除");

                entity.Property(e => e.是否样板).HasDefaultValueSql("((0))");

                entity.Property(e => e.是否模板).HasComment("1表示是模板其他(0或者null)表示不是模板");

                entity.Property(e => e.点表版本)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasComment("pointAddress的外键");

                entity.Property(e => e.热度).HasDefaultValueSql("((0))");

                entity.Property(e => e.画板json).HasColumnName("画板Json");

                entity.Property(e => e.画板名称)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.站点信息)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.类型id).HasColumnName("类型ID");

                entity.Property(e => e.维度).HasMaxLength(4);

                entity.Property(e => e.缩略图url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("缩略图Url")
                    .HasComment("画板png图片");

                entity.Property(e => e.配置文件url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("配置文件Url");

                entity.Property(e => e.项目简称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<组态画板类型表>(entity =>
            {
                entity.ToTable("组态_画板类型表");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.创建时间).HasColumnType("datetime");

                entity.Property(e => e.名称)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<组态设备配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("组态_设备配置表");

                entity.Property(e => e.传感器名称).HasMaxLength(128);

                entity.Property(e => e.坐标zyz)
                    .HasMaxLength(255)
                    .HasColumnName("坐标ZYZ");

                entity.Property(e => e.大小xyz)
                    .HasMaxLength(255)
                    .HasColumnName("大小XYZ");

                entity.Property(e => e.控制服务url)
                    .HasMaxLength(64)
                    .HasColumnName("控制服务Url");

                entity.Property(e => e.旋转角度xyz)
                    .HasMaxLength(255)
                    .HasColumnName("旋转角度XYZ");

                entity.Property(e => e.模型名称).HasMaxLength(64);

                entity.Property(e => e.画板id).HasColumnName("画板ID");
            });

            modelBuilder.Entity<维修处理反馈表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("维修处理反馈表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.工单编号)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.现场描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场照片)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<维修处理工单表>(entity =>
            {
                entity.ToTable("维修处理工单表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.到场描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.处理时限)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理紧急程度)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.处理结果)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.完工照片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.审核意见)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.建议处理方法)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.接单描述)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.接单时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<设备信息台账模板表>(entity =>
            {
                entity.ToTable("设备_信息台账模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备关系配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备关系配置表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis条件)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS条件");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.台账字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.台账显示字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.手持台账显示字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.父设备名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备台账表)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护任务模板表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护任务模板表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务养护人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护人id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("养护人ID");

                entity.Property(e => e.养护类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈id).HasColumnName("反馈ID");

                entity.Property(e => e.反馈人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.完成时间).HasColumnType("datetime");

                entity.Property(e => e.审核id).HasColumnName("审核ID");

                entity.Property(e => e.审核状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.延期人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.延期原因)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.延期时间).HasColumnType("datetime");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.所属站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.最迟完成时间).HasColumnType("datetime");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.计划id).HasColumnName("计划ID");

                entity.Property(e => e.计划养护类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.计划类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.退单人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.退单原因)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.退单时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<设备养护关键点>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护关键点");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.区域id).HasColumnName("区域ID");

                entity.Property(e => e.区域名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.坐标)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护区域表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护区域表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.上级区域id).HasColumnName("上级区域ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.区域名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.区域坐标).IsUnicode(false);

                entity.Property(e => e.用户id)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("用户ID");

                entity.Property(e => e.用户名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.站点)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.路径坐标).IsUnicode(false);
            });

            modelBuilder.Entity<设备养护反馈配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护反馈配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护内容)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.前端列表字段)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.包含字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.反馈类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈角色)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.手持列表字段)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.排除字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.触发事件)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.触发事件字段集)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.触发异常值)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备反馈表)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.过滤条件值)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.过滤条件字段)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.部件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护周期表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护周期表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.养护周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.周期单位)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.容忍时间单位)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护审核表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护审核表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.上报人id).HasColumnName("上报人ID");

                entity.Property(e => e.上报人名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报人部门)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.上报时间).HasColumnType("datetime");

                entity.Property(e => e.上报站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.不通过原因)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.处理站点)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.审核人id).HasColumnName("审核人ID");

                entity.Property(e => e.审核人姓名)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.审核时间).HasColumnType("datetime");

                entity.Property(e => e.工单编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.更新时间).HasColumnType("datetime");

                entity.Property(e => e.更新状态)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.现场图片)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.现场录音)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.送审名称)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护调压器记录表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护调压器记录表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.O型圈是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.主控阀杆是否灵活)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.主调o型圈是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("主调O型圈是否正常");

                entity.Property(e => e.主调总承是否清洗)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.信号管是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.停气告知确认)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.关闭压力)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护耗材)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.切断o型圈是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("切断O型圈是否正常");

                entity.Property(e => e.切断主控弹簧是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.切断信号管是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.切断压力)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.切断总承是否清洗)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.切断皮膜是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.切断阀口垫是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.切断阀杆是否灵活)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.到场拍照)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.压力波动是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.恢复供气确认)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.放散压力)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.是否检查气密性)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.有无喘振)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.滤芯总承是否清洗)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.滤芯是否清洗)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.甲烷浓度是否大于90)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.皮膜主控弹簧是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.皮膜是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.结束拍照)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.设备及各连接点有无燃气泄漏)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备各部件是否有油污)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备周边是否存在异常振动)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备周边是否有土壤塌陷)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备周边是否有堆积垃圾或杂物)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备周边是否有易燃易爆危险物品)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备箱外观是否整洁干净)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备箱护栏警示标识是否丢失或损坏)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备箱柜井内是否有积水)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.设备箱锁具有无损坏)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.调压器保养完成是否气密性检查)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.调压器表面是否清洗)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.调压器进出口阀门启闭是否灵活)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.调压器进出口阀门是否内漏)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.运行压力)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.阀口垫是否正常)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护配置表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis条件)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GIS条件");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.任务审核列表字段)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.任务显示字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.任务编码前缀)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.关联事件)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.养护人员角色)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.台账字段集)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.台账显示字段)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.基准时间字段)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.手持任务列表字段)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.手持任务列表字段描述)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.能否gis分区).HasColumnName("能否GIS分区");

                entity.Property(e => e.能否同步数据).HasComment("1能,0不能");

                entity.Property(e => e.能否添加台账).HasComment("1能,0不能");

                entity.Property(e => e.计划养护类型)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备任务表)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备台账表)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备养护阀门记录表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备养护阀门记录表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.使用状态)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.到场拍照)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.反馈坐标)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.材质)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.结束拍照)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.维护耗材)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.规格型号)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.阀门类型)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备匹配分析结论表>(entity =>
            {
                entity.ToTable("设备_匹配分析结论表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.结论).IsUnicode(false);

                entity.Property(e => e.联系方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备型号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.过载流量)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账二供机组>(entity =>
            {
                entity.ToTable("设备_台账_二供机组");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码).IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账二供泵房>(entity =>
            {
                entity.ToTable("设备_台账_二供泵房");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.供水方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码).IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账便携式流量计>(entity =>
            {
                entity.ToTable("设备_台账_便携式流量计");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账压力表>(entity =>
            {
                entity.ToTable("设备_台账_压力表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账户表>(entity =>
            {
                entity.ToTable("设备_台账_户表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.用户名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.用户编号)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码).IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账模板表>(entity =>
            {
                entity.ToTable("设备台账模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.上次养护时间).HasColumnType("datetime");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.位置)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.养护人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.养护周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.区域名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.所属站点)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.状态)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.计划养护开始时间).HasColumnType("datetime");

                entity.Property(e => e.计划养护结束时间).HasColumnType("datetime");

                entity.Property(e => e.设备名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账水厂>(entity =>
            {
                entity.ToTable("设备_台账_水厂");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码).IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账水源井>(entity =>
            {
                entity.ToTable("设备_台账_水源井");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.厂家)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码).IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账流量计>(entity =>
            {
                entity.ToTable("设备_台账_流量计");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备台账熊猫水表>(entity =>
            {
                entity.ToTable("设备_台账_熊猫水表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gis编码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编码");

                entity.Property(e => e.Sn码)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SN码");

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案版本)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.录入人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.录入人id).HasColumnName("录入人ID");

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.父设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.物联返回信息)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频缩略图)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.设备分类)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备简称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.详细地址)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.采集协议)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.采集编码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.风貌图)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备型号台账表>(entity =>
            {
                entity.ToTable("设备型号台账表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ReadMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.公称直径)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.分界流量)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.压力)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.图片)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.地址版本id).HasColumnName("地址版本ID");

                entity.Property(e => e.常用流量)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.所属站点)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.最小流量)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.水表等级)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.测量范围)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.生产厂家)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.编码规则)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.设备型号)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.过载流量)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.重量)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.量程比)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.防护等级)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备巡维保任务表>(entity =>
            {
                entity.ToTable("设备_巡维保任务表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.事件编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务状态)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.任务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.分派人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.分派时间).HasColumnType("datetime");

                entity.Property(e => e.反馈距离)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈间隔)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.完成人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.完成时间).HasColumnType("datetime");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.执行人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.模板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.计划编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备巡维保计划表>(entity =>
            {
                entity.ToTable("设备_巡维保计划表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.上次完成时间).HasColumnType("datetime");

                entity.Property(e => e.下次计划开始时间).HasColumnType("datetime");

                entity.Property(e => e.下次计划结束时间).HasColumnType("datetime");

                entity.Property(e => e.执行人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.模板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.计划编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<设备门禁信息表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("设备门禁信息表");

                entity.Property(e => e.Hls).HasMaxLength(200);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Rtmp).HasMaxLength(200);

                entity.Property(e => e.品牌)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.型号)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.密码)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.用户名).HasMaxLength(50);

                entity.Property(e => e.第三方编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.门禁名称)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<配置地图复位范围配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("配置_地图_复位范围配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.区域名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.地图范围)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.机构id).HasColumnName("机构ID");
            });

            modelBuilder.Entity<配置巡维保计划模板表>(entity =>
            {
                entity.ToTable("配置_巡维保计划模板表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.业务类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.反馈名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.台账名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.台账过滤条件)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.启停)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.在线任务量)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.执行周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.执行角色)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.是否删除).HasDefaultValueSql("((0))");

                entity.Property(e => e.是否送审)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.预生成天数)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<配置物联设备类型配置表>(entity =>
            {
                entity.ToTable("配置_物联设备类型配置表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.分组名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.历史数据表名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.台账表名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.存储频率).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.实时数据表名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.父类型名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.统计数据表名)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.采集频率).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<配置系统信息表>(entity =>
            {
                entity.ToTable("配置_系统信息表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.是否启用).HasDefaultValueSql("((1))");

                entity.Property(e => e.父配置项id).HasColumnName("父配置项ID");

                entity.Property(e => e.配置项值)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.配置项名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<配置视频信息表>(entity =>
            {
                entity.ToTable("配置_视频信息表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Hls路径)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("HLS路径");

                entity.Property(e => e.名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.录入时间).HasColumnType("datetime");

                entity.Property(e => e.播放零通道)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.流媒体端口)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.登录ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("登录IP");

                entity.Property(e => e.登录名)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.登录密码)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.码流类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频厂商)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频名称)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.视频端口)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.视频类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.视频路径)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.设备序列号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备端口)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.通道id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("通道ID");
            });

            modelBuilder.Entity<配置设备信息拓展表>(entity =>
            {
                entity.ToTable("配置_设备信息拓展表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tip画板参数L)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Tip画板参数_L");

                entity.Property(e => e.Tip画板参数M)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Tip画板参数_M");

                entity.Property(e => e.Tip画板参数S)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Tip画板参数_S");

                entity.Property(e => e.Tip画板名称L)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tip画板名称_L");

                entity.Property(e => e.Tip画板名称M)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tip画板名称_M");

                entity.Property(e => e.Tip画板名称S)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tip画板名称_S");

                entity.Property(e => e.列表画板参数)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.列表画板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.卡片画板参数)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.卡片画板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.地址方案)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.工艺画板参数)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.工艺画板名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备编码)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<配置设备分组关系表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("配置_设备分组关系表");

                entity.Property(e => e.机构id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("机构ID");

                entity.Property(e => e.设备编码)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<配置设备指标配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("配置_设备指标配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务指标)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.指标名称)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<配置设备监控模型配置表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("配置_设备监控模型配置表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.列表指标)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.单指标tip指标)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("单指标Tip指标");

                entity.Property(e => e.卡片指标)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.卡片模板).HasMaxLength(50);

                entity.Property(e => e.卡片重点指标)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.大tip指标)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("大Tip指标");

                entity.Property(e => e.生效条件)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.画板参数)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.画板名称)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.画板设备类型)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.表格指标)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.设备图例)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备类型简称)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.详情指标).IsUnicode(false);

                entity.Property(e => e.详情模板).HasMaxLength(50);

                entity.Property(e => e.配置规则)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<阀门任务表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("阀门任务表");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.任务养护人)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.任务编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护人id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("养护人ID");

                entity.Property(e => e.养护类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.到场时间).HasColumnType("datetime");

                entity.Property(e => e.反馈id).HasColumnName("反馈ID");

                entity.Property(e => e.反馈人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.完成时间).HasColumnType("datetime");

                entity.Property(e => e.审核id).HasColumnName("审核ID");

                entity.Property(e => e.审核状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.延期人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.延期原因)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.延期时间).HasColumnType("datetime");

                entity.Property(e => e.开始时间).HasColumnType("datetime");

                entity.Property(e => e.所属站点)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.最迟完成时间).HasColumnType("datetime");

                entity.Property(e => e.结束时间).HasColumnType("datetime");

                entity.Property(e => e.计划id).HasColumnName("计划ID");

                entity.Property(e => e.计划类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.退单人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.退单原因)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.退单时间).HasColumnType("datetime");
            });

            modelBuilder.Entity<阀门台账表>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("阀门台账表");

                entity.Property(e => e.Gis图层)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS图层");

                entity.Property(e => e.Gis编号)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GIS编号");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.上次养护时间).HasColumnType("datetime");

                entity.Property(e => e.业务名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.位置)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.供气范围)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.养护人)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.养护人id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("养护人ID");

                entity.Property(e => e.养护周期)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.养护类型)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.出厂日期).HasColumnType("datetime");

                entity.Property(e => e.出厂编号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.区域名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.启用时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.坐标位置)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.备注)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.所属站点)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.投运时间)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.是否停用或故障)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.材质)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.状态)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.生产厂家)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.联系人)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.联系方式)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.规格型号)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.计划养护开始时间).HasColumnType("datetime");

                entity.Property(e => e.计划养护结束时间).HasColumnType("datetime");

                entity.Property(e => e.设备名称)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.设备级别)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.运行状况)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.阀门性质)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
