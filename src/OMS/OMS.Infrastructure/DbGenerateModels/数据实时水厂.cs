﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据实时水厂
    {
        public int Id { get; set; }
        public string 设备编码 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public DateTime? 采集时间 { get; set; }
        public int? 是否在线 { get; set; }
        public DateTime? 上线时间 { get; set; }
        public float? 在线时长 { get; set; }
        public DateTime? 离线时间 { get; set; }
        public float? 离线时长 { get; set; }
        public int? 是否报警 { get; set; }
        public string 当前报警 { get; set; }
        public float? 报警时长 { get; set; }
        public float? 泵1压力 { get; set; }
        public float? 泵1流量 { get; set; }
        public float? 泵1电流 { get; set; }
        public float? 泵1频率 { get; set; }
        public float? 泵2压力 { get; set; }
        public float? 泵2流量 { get; set; }
        public float? 泵2电流 { get; set; }
        public float? 泵2频率 { get; set; }
        public float? 泵3压力 { get; set; }
        public float? 泵3流量 { get; set; }
        public float? 泵3电流 { get; set; }
        public float? 泵3频率 { get; set; }
        public float? 泵4压力 { get; set; }
        public float? 泵4流量 { get; set; }
        public float? 泵4电流 { get; set; }
        public float? 泵4频率 { get; set; }
        public float? 泵5压力 { get; set; }
        public float? 泵5流量 { get; set; }
        public float? 泵5电流 { get; set; }
        public float? 泵5频率 { get; set; }
        public float? 余氯 { get; set; }
        public float? 加药频率1 { get; set; }
        public float? 加药频率2 { get; set; }
        public float? 余氯值 { get; set; }
        public float? 出厂压力2 { get; set; }
        public float? 出厂压力1 { get; set; }
        public float? 浊度 { get; set; }
        public float? 清水池液位1 { get; set; }
        public float? 清水池液位2 { get; set; }
        public float? 进厂流量 { get; set; }
        public float? 出厂流量1 { get; set; }
        public float? 出厂流量2 { get; set; }
        public int? 变频1故障 { get; set; }
        public int? 阀1故障 { get; set; }
        public int? 变频2故障 { get; set; }
        public int? 阀2故障 { get; set; }
        public int? 变频3故障 { get; set; }
        public int? 阀3故障 { get; set; }
        public int? 变频4故障 { get; set; }
        public int? 阀4故障 { get; set; }
        public int? 变频5故障 { get; set; }
        public int? 阀5故障 { get; set; }
        public int? 变频1启动 { get; set; }
        public int? 变频1通讯故障 { get; set; }
        public int? 阀门1关阀 { get; set; }
        public int? 阀门1开阀 { get; set; }
        public int? 变频2启动 { get; set; }
        public int? 变频2通讯故障 { get; set; }
        public int? 阀门2关阀 { get; set; }
        public int? 阀门2开阀 { get; set; }
        public int? 变频3启动 { get; set; }
        public int? 变频3通讯故障 { get; set; }
        public int? 阀门3关阀 { get; set; }
        public int? 阀门3开阀 { get; set; }
        public int? 变频4启动 { get; set; }
        public int? 变频4通讯故障 { get; set; }
        public int? 阀门4关阀 { get; set; }
        public int? 阀门4开阀 { get; set; }
        public int? 变频5启动 { get; set; }
        public int? 变频5通讯故障 { get; set; }
        public int? 阀门5关阀 { get; set; }
        public int? 阀门5开阀 { get; set; }
        public float? 表ygdn1 { get; set; }
        public float? 表ygdn3 { get; set; }
        public float? 表ygdn5 { get; set; }
        public float? 进水累计流量 { get; set; }
        public int? 变频1运行 { get; set; }
        public float? 泵1累计流量 { get; set; }
        public int? 变频2运行 { get; set; }
        public float? 泵2累计流量 { get; set; }
        public int? 变频3运行 { get; set; }
        public float? 泵3累计流量 { get; set; }
        public int? 变频4运行 { get; set; }
        public float? 泵4累计流量 { get; set; }
        public int? 变频5运行 { get; set; }
        public float? 泵5累计流量 { get; set; }
        public float? BpRt1 { get; set; }
        public float? BpRt2 { get; set; }
        public float? BpRt3 { get; set; }
        public float? BpRt4 { get; set; }
        public float? BpRt5 { get; set; }
        public float? 出水累计流量1 { get; set; }
        public float? 出水累计流量2 { get; set; }
        public float? 变频手动给定值1 { get; set; }
        public float? 变频手动给定值2 { get; set; }
        public float? 变频手动给定值3 { get; set; }
        public float? 变频手动给定值4 { get; set; }
        public float? 变频手动给定值5 { get; set; }
        public int? 启用手动值1 { get; set; }
        public int? 启用手动值2 { get; set; }
        public int? 启用手动值3 { get; set; }
        public int? 启用手动值4 { get; set; }
        public int? 启用手动值5 { get; set; }
        public float? 变频1频率 { get; set; }
        public float? 变频2频率 { get; set; }
        public float? 变频3频率 { get; set; }
        public float? 变频4频率 { get; set; }
        public float? 变频5频率 { get; set; }
        public float? 变频1电流 { get; set; }
        public float? 变频2电流 { get; set; }
        public float? 变频3电流 { get; set; }
        public float? 变频4电流 { get; set; }
        public float? 变频5电流 { get; set; }
        public float? 表ua1 { get; set; }
        public float? 表ua2 { get; set; }
        public float? 表ua3 { get; set; }
        public float? 表ua4 { get; set; }
        public float? 表ua5 { get; set; }
        public float? 表ub1 { get; set; }
        public float? 表ub2 { get; set; }
        public float? 表ub3 { get; set; }
        public float? 表ub4 { get; set; }
        public float? 表ub5 { get; set; }
        public float? 表uc1 { get; set; }
        public float? 表uc2 { get; set; }
        public float? 表uc3 { get; set; }
        public float? 表uc4 { get; set; }
        public float? 表uc5 { get; set; }
        public float? 表aa1 { get; set; }
        public float? 表aa2 { get; set; }
        public float? 表aa3 { get; set; }
        public float? 表aa4 { get; set; }
        public float? 表aa5 { get; set; }
        public float? 表ab1 { get; set; }
        public float? 表ab2 { get; set; }
        public float? 表ab3 { get; set; }
        public float? 表ab4 { get; set; }
        public float? 表ab5 { get; set; }
        public float? 表ac1 { get; set; }
        public float? 表ac2 { get; set; }
        public float? 表ac3 { get; set; }
        public float? 表ac4 { get; set; }
        public float? 表ac5 { get; set; }
        public float? 表wgdn1 { get; set; }
        public float? 表wgdn2 { get; set; }
        public float? 表wgdn3 { get; set; }
        public float? 表wgdn4 { get; set; }
        public float? 表wgdn5 { get; set; }
        public float? 表glys1 { get; set; }
        public float? 表glys2 { get; set; }
        public float? 表glys3 { get; set; }
        public float? 表glys4 { get; set; }
        public float? 表glys5 { get; set; }
        public float? _1上限 { get; set; }
        public float? _2上限 { get; set; }
        public int? _1投入 { get; set; }
        public int? _2投入 { get; set; }
        public int? _1水位报警 { get; set; }
        public int? _2水位报警 { get; set; }
        public int? 新城区流量高报警 { get; set; }
        public int? 老城区流量高报警1 { get; set; }
        public int? 新城区压力低报警 { get; set; }
        public int? 老城区压力低报警1 { get; set; }
        public float? 当天进厂流量 { get; set; }
        public float? 当天出厂流量 { get; set; }
        public float? 当天电能 { get; set; }
        public float? 前天进厂流量 { get; set; }
        public float? 前天出厂流量 { get; set; }
        public float? 前天电能 { get; set; }
        public float? 当月进厂流量 { get; set; }
        public float? 当月出厂流量 { get; set; }
        public float? 当月电能 { get; set; }
        public float? 前月进厂流量 { get; set; }
        public float? 前月出厂流量 { get; set; }
        public float? 前月电能 { get; set; }
        public float? 当天能耗 { get; set; }
        public float? 前天能耗 { get; set; }
        public float? 当月能耗 { get; set; }
        public float? 前月能耗 { get; set; }
        public float? 当年进厂流量 { get; set; }
        public float? 当年出厂流量 { get; set; }
        public float? 当年电能 { get; set; }
        public float? 当年能耗 { get; set; }
        public float? 站点在线状态 { get; set; }
        public float? 表ygdn2 { get; set; }
        public float? 表ygdn4 { get; set; }
    }
}
