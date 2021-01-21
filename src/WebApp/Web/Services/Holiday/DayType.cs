using System.ComponentModel;

namespace Web.DayModule
{
    /// <summary>
    /// 节假日枚举类型
    /// </summary>
    public enum DayType
    {
        [Description("工作日")]
        // 工作日
        工作日 = 0,
        [Description("周末")]
        周末 = 1,
        [Description("元旦")]
        元旦 = 2,
        [Description("春节")]
        春节 = 3,
        [Description("清明节")]
        清明节 = 4,
        [Description("端午节")]
        端午节 = 5,
        [Description("中秋节")]
        中秋节 = 6,
        [Description("国庆节")]
        国庆节 = 7,
        [Description("调休")]
        调休 = 8,
    }
}
