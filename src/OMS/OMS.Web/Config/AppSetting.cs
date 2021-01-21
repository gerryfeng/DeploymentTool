
namespace OMS.Web
{
    public class AppSetting
    {
        public string IdentityServerUrl { get; set; }
        /// <summary>
        /// 是否启用网关
        /// </summary>
        public string IsGateWay { get; set; }

        public string ApiScops { get; set; }

        public string ClientId { get; set; }

        public string Secret { get; set; }
    }
}
