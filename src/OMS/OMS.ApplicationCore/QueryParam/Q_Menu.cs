
namespace OMS.ApplicationCore
{
    public class Q_Menu
    {
        public string visible { get; set; }

        public int? parentIdEquals { get; set; }

        public int? parentIdNotEquals { get; set; }

        /// <summary>
        /// 是否启用更新
        /// </summary>
        public bool isTrack { get; set; }

        public bool isInclude { get; set; }
    }
}
