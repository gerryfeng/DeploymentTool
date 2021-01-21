using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMS.ApplicationCore
{
    /// <summary>
    /// 登录Model
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage ="登录名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="密码不能为空")]
        public string PassWord { get; set; }
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    public class ModifyPwdModel
    {
        [Required(ErrorMessage ="用户id不能为空")]
        public int UserId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "新密码不能为空")]
        public string NewPassWord { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "旧密码不能为空")]
        public string OldPassWord { get; set; }
    }



    /// <summary>
    /// 手持配置菜单
    /// </summary>
    public class MobileModuleTreeItem
    {
        public MobileModuleTreeItem()
        {
            children = new List<MobileModuleTreeItem>();
        }

        public string id{ get; set; }
        public string text{ get; set; }
        public string code{ get; set; }
        public string level{ get; set; }
        public string visible{ get; set; }
        public string iconCls{ get; set; }
        public List<MobileModuleTreeItem> children{ get; set; }
        public bool expanded{ get; set; }
        public bool leaf{ get; set; }

        public bool allowDrag{ get; set; }
        public bool allowDrop{ get; set; }
        public bool draggable{ get; set; }
        public bool isTarget{ get; set; }
        public string dragAttribute{ get; set; }

        public string file{ get; set; }//地图配置文件

        public string roleID{ get; set; }
        public string group{ get; set; }
        public string description{ get; set; }

        public string menuID{ get; set; }

        public string menuType{ get; set; }
        public string clickType{ get; set; }
    }

    /// <summary>
    /// 获取机构用户Model
    /// </summary>
    public class GroupModel
    {
        /// <summary>
        /// 机构id数组
        /// </summary>
       public  List<int> GroupIds { get; set; }
    }
}
