using System.Collections.Generic;

namespace OMS.ApplicationCore
{
    /// <summary>
    /// web菜单树
    /// </summary>
    public class Web4ModuleTreeItem
    {
        public Web4ModuleTreeItem()
        {
            children = new List<Web4ModuleTreeItem>();
        }

        public string id { get; set; }
        public string text { get; set; }
        public string visible { get; set; }
        public string iconCls { get; set; }
        public List<Web4ModuleTreeItem> children { get; set; }
        public bool expanded { get; set; }
        public bool leaf { get; set; }
        public string description { get; set; }
        public bool allowDrag { get; set; }
        public bool allowDrop { get; set; }
        public bool draggable { get; set; }
        public bool isTarget { get; set; }
        public string dragAttribute { get; set; }

        public string stationID { get; set; }
        public string roleID { get; set; }
        public string menuID { get; set; }
        public string offlineHead { get; set; }
        public string headType { get; set; }

        public string group { get; set; }//角色分组

        public string groupName { get; set; }//工单功能集成配置表的组名

        public string menuType { get; set; }
        public string clickType { get; set; }

        public string product { get; set; }
    }

    /// <summary>
    /// 手持菜单树
    /// </summary>
    public class MobileMenu
    {
        public MobileMenu()
        {
            MapToolBars = new List<MobileMenuItem>();
            MapMoreMenus = new List<MobileMenuItem>();
            MainMenus = new List<MobileMenuItem>();
        }

        public string Title { get; set; }
        public List<MobileMenuItem> MapToolBars { get; set; }
        public List<MobileMenuItem> MapMoreMenus { get; set; }
        public List<MobileMenuItem> MainMenus { get; set; }
    }

    public class MobileMenuItem
    {
        public MobileMenuItem()
        {
            children = new List<MobileMenuItem>();
        }

        public string MenuID { get; set; }
        public string parentID { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string visible { get; set; }
        public List<MobileMenuItem> children { get; set; }
    }

    #region 系统菜单
    public class WebSiteConfig
    {
        public WebSiteConfig()
        {
            mapsettings = new MapConfig();
            widgets = new List<Widgets>();
            uiwidgets = new List<UIWigets>();
        }
        public string mode { get; set; }
        public string style { get; set; }
        public string client { get; set; }
        public string shortcutIcon { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string logo { get; set; }
        public string bannerLogo { get; set; }
        public string project { get; set; }
        public int expiration { get; set; } = 43200000;
        public int pagesize { get; set; } = 20;
        //public string homepage;
        public string loginTemplate { get; set; }
        public string theme { get; set; }
        public string menu { get; set; }
        public string mdi { get; set; }
        public string alarmWays { get; set; }
        public string qrcode { get; set; }
        public string useCoverMap { get; set; }
        public string mapVersion { get; set; }
        public bool waterMark { get; set; }//地图水印
        public bool hideMap { get; set; }//不显示地图
        public MapConfig mapsettings { get; set; }
        public List<Widgets> widgets { get; set; }
        public List<UIWigets> uiwidgets { get; set; }
    }

    public class MapConfig
    {
        public MapConfig()
        {
            environment = new EnvironmentInfo();
            constraints = new ConstraintsInfo();
            viewpoint = new ViewpointInfo();
            basemaps = new List<Basemaps>();
            layers = new List<Layers>();
        }
        public string type { get; set; } = "2d";
        public string viewingMode { get; set; } = "global";
        public string proxyUrl { get; set; } = "";
        public EnvironmentInfo environment { get; set; }
        public ConstraintsInfo constraints { get; set; }
        public ViewpointInfo viewpoint { get; set; }
        public List<Basemaps> basemaps { get; set; }
        public List<Layers> layers { get; set; }
        public AreaSettings areasettings { get; set; }
    }

    public class EnvironmentInfo
    {
        public string atmosphere { get; set; } = null;
        public bool starsEnabled { get; set; } = true;
    }

    public class ConstraintsInfo
    {
        public ConstraintsInfo()
        {
            tilt = new TiltInfo();
            collision = new CollisionInfo();
        }
        public bool rotationEnabled { get; set; } = false;
        public TiltInfo tilt { get; set; }
        public CollisionInfo collision { get; set; }
    }

    public class TiltInfo
    {
        public double max { get; set; } = 179.5;
    }

    public class CollisionInfo
    {
        public bool enabled { get; set; } = false;
    }

    public class ViewpointInfo
    {
        public ViewpointInfo()
        {
            camera = new CameraInfo();
            targetGeometry = new TargetGeometry();
        }
        public CameraInfo camera { get; set; }
        public TargetGeometry targetGeometry { get; set; }
    }

    public class CameraInfo
    {
        public CameraInfo()
        {
            position = new Position();
        }
        public Position position { get; set; }
        public double heading { get; set; } = 0;
        public double tilt { get; set; } = 0;
        public double fov { get; set; } = 55;
    }

    public class Position
    {
        public Position()
        {
            spatialReference = new SpatialReferenceInfo();
        }
        public double x { get; set; } = 0;
        public double y { get; set; } = 0;
        public double z { get; set; } = 0;
        public SpatialReferenceInfo spatialReference { get; set; }
    }

    public class SpatialReferenceInfo
    {
        public double wkid { get; set; } = 4526;
    }

    public class TargetGeometry
    {
        public TargetGeometry()
        {
            spatialReference = new SpatialReferenceInfo();
        }
        public double xmin { get; set; } = 0;
        public double ymin { get; set; } = 0;
        public double xmax { get; set; } = 0;
        public double ymax { get; set; } = 0;
        public SpatialReferenceInfo spatialReference { get; set; }
    }

    public class Basemaps
    {
        public Basemaps()
        {
            baseLayers = new List<BaseLayers>();
        }
        public string id { get; set; }
        public string title { get; set; }
        public string thumbnailUrl { get; set; } = "assets/images/thumbnail/thumbnail_1.jpg";
        public List<BaseLayers> baseLayers { get; set; }
    }

    public class BaseLayers
    {
        public string title { get; set; }
        public string icon { get; set; }
        public string layerType { get; set; } = "TileLayer";
        public string url { get; set; }
        public double opacity { get; set; } = 1;
        public bool visible { get; set; } = true;
        public bool useProxy { get; set; } = false;
        public string proxyUrl { get; set; } = "";
        public string style { get; set; }
        public string extent { get; set; } = "";
        public string baseLayer { get; set; } = "";
        public string levelStart { get; set; }
        public string levelEnd { get; set; }
        public string resolution { get; set; } = "";
        public string origin { get; set; } = "";
        public string tileMatrix { get; set; } = "";
    }

    public class Layers
    {
        public Layers()
        {
            basemaps = new List<Basemaps>();
        }
        public string id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string layerType { get; set; } = "MapImageLayer";
        public string url { get; set; }
        public double opacity { get; set; }
        public bool showLegend { get; set; } = true;
        public bool visible { get; set; } = true;
        public bool useProxy { get; set; } = true;
        public string proxyUrl { get; set; } = "";
        public string extent { get; set; } = "";
        public string baseLayer { get; set; } = "";
        public string levelStart { get; set; }
        public string levelEnd { get; set; }
        public string resolution { get; set; } = "";
        public string origin { get; set; } = "";
        public string tileMatrix { get; set; } = "";
        public string wmtsUrl { get; set; } = "";

        // 版本3(有方案) 新增
        public string schemename { get; set; } = "";
        public string roles { get; set; } = "";
        public string areaName { get; set; } = "";
        // 行政区边界颜色
        public string boundColor { get; set; } = "#86c8f8";
        // 背景色
        public string backgroundColor { get; set; } = "#000000";
        // 边界宽度
        public string boundWidth { get; set; } = "10px";
        // 背景透明度
        public string backgroundOpacity { get; set; } = "0.6";

        public List<Basemaps> basemaps { get; set; }
    }

    public class Widgets
    {
        public Widgets()
        {
            widgets = new List<Widgets>();
        }
        public List<Widgets> widgets { get; set; }
        public string label { get; set; }
        public string shortName { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public string config { get; set; }
        public string product { get; set; }
        public bool visible { get; set; }
    }

    public class UIWigets
    {
        public string label { get; set; }
        public string url { get; set; }
        public string left { get; set; }
        public string top { get; set; }
        public string bottom { get; set; }
        public string right { get; set; }
        public string config { get; set; }
    }

    public class AreaSettings
    {
        public string boundColor { get; set; }
        public string boundWidth { get; set; }
        public string backgroundColor { get; set; }
        public string backgroundOpacity { get; set; }
        public string areaName { get; set; }
        public string extent { get; set; }
        public string rings { get; set; }
    }
    #endregion


    #region 当前解决方案
    public class Web4GetSolutionList 
    {
        public string currentSolution { get; set; }
        public bool disabled { get; set; }
        public List<string> solutions { get; set; } = new List<string>();

        /// <summary>
        /// 网站类别列表
        /// </summary>
        public List<website> sites { get; set; } = new List<website>();
    }

    public class website
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 网站类别
        /// </summary>
        public string product { get; set; } 
    }


    
    #endregion

}
