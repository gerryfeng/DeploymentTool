using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护调压器记录表
    {
        public int Id { get; set; }
        public string 调压器表面是否清洗 { get; set; }
        public string 设备周边是否有土壤塌陷 { get; set; }
        public string 设备周边是否有堆积垃圾或杂物 { get; set; }
        public string 设备及各连接点有无燃气泄漏 { get; set; }
        public string 设备箱柜井内是否有积水 { get; set; }
        public string 设备各部件是否有油污 { get; set; }
        public string 设备箱护栏警示标识是否丢失或损坏 { get; set; }
        public string 设备箱外观是否整洁干净 { get; set; }
        public string 设备周边是否存在异常振动 { get; set; }
        public string 设备箱锁具有无损坏 { get; set; }
        public string 设备周边是否有易燃易爆危险物品 { get; set; }
        public string 有无喘振 { get; set; }
        public string 压力波动是否正常 { get; set; }
        public string 是否检查气密性 { get; set; }
        public string 滤芯总承是否清洗 { get; set; }
        public string 滤芯是否清洗 { get; set; }
        public string O型圈是否正常 { get; set; }
        public string 皮膜是否正常 { get; set; }
        public string 主调o型圈是否正常 { get; set; }
        public string 阀口垫是否正常 { get; set; }
        public string 皮膜主控弹簧是否正常 { get; set; }
        public string 主调总承是否清洗 { get; set; }
        public string 主控阀杆是否灵活 { get; set; }
        public string 信号管是否正常 { get; set; }
        public string 切断皮膜是否正常 { get; set; }
        public string 切断o型圈是否正常 { get; set; }
        public string 切断阀口垫是否正常 { get; set; }
        public string 切断主控弹簧是否正常 { get; set; }
        public string 切断总承是否清洗 { get; set; }
        public string 切断阀杆是否灵活 { get; set; }
        public string 切断信号管是否正常 { get; set; }
        public string 调压器保养完成是否气密性检查 { get; set; }
        public string 调压器进出口阀门启闭是否灵活 { get; set; }
        public string 调压器进出口阀门是否内漏 { get; set; }
        public string 甲烷浓度是否大于90 { get; set; }
        public string 养护类型 { get; set; }
        public string 运行压力 { get; set; }
        public string 关闭压力 { get; set; }
        public string 切断压力 { get; set; }
        public string 放散压力 { get; set; }
        public string 到场拍照 { get; set; }
        public string 结束拍照 { get; set; }
        public string 养护耗材 { get; set; }
        public string Gis图层 { get; set; }
        public string Gis编号 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public string 停气告知确认 { get; set; }
        public string 恢复供气确认 { get; set; }
    }
}
