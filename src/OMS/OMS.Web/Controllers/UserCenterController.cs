using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using ConfigBridge;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OMS.ApplicationCore;

namespace OMS.Web
{
    /// <summary>
    ///用户中心
    /// </summary>
    public class UserCenterController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IFlowGroupService _groupService;
        private readonly IFlowUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private readonly IOperationLogService _operationLogService;
        private readonly IFlowGroupRepository _repository;
        private readonly ISysProductRepository _productRepository;

        public UserCenterController(IMapper mapper, IFlowGroupService groupService, IFlowUserService userService, IWebHostEnvironment environment,
            IOperationLogService operationLogService, IFlowGroupRepository repository, ISysProductRepository productRepository)
        {
            _mapper = mapper;
            _groupService = groupService;
            _userService = userService;
            _environment = environment;
            _operationLogService = operationLogService;
            _repository = repository;
            _productRepository = productRepository;
        }


        #region 角色管理
        /// <summary>
        /// 根据机构id获取子机构及所有机构下用户
        /// </summary>
        /// <param name="groupId">机构id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GroupUser> GroupUserList([Required] int groupId)
        {
            if (groupId == 0)
            {
                throw new Exception("机构id不能为空！");
            }
            return await _groupService.GetGroupUser(groupId);
        }

        /// <summary>
        /// 角色列表按产品分组
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<RoleGroupResult> RoleGroupList(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new Exception ("用户id不能为空！");
            }
    
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            XmlDocument doc = config.GetWebXml();

            List<SubSystemModel> subSystems = config.AllSubSystem.Select(x =>
            {
                return new SubSystemModel()
                {
                    title = x.title,
                    value = x.value,
                    folder = x.folder,
                    location = x.location,
                    mode = x.mode,
                    topTitle = x.topTitle
                };
            }).ToList();

            return await _groupService.GetUserRelationAsync(userId, doc, subSystems, config.RootPath, ConfigBridge.ConfigBridge.WorkflowConnectionString, false);
        } 
        #endregion

        #region 用户管理
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        
        public void UpdateUserPassword(ModifyPwdModel model)
        {
            bool flag = Util.UserPasswordValid(model.NewPassWord, OMSState.State["UserPasswordSolution"]);
            if (!flag)
            {
                string exMsg = "登陆密码要求至少8位，且包含大写字母、小写字母、数字或特殊符号中的三个";
                _operationLogService.AddOperationLog("UpdateUserPassword", "[用户中心]-[用户管理]-修改密码", 3, JsonConvert.SerializeObject(model), JsonConvert.SerializeObject(new ResponseBase<string> { code=-1,msg=exMsg}));
                throw new Exception(exMsg);
            }
            _userService.UpdateUserPassword(model);
            _operationLogService.AddOperationLog("UpdateUserPassword", "[用户中心]-[用户管理]-修改密码", 3,JsonConvert.SerializeObject(model),JsonConvert.SerializeObject(new ResponseBase<string> { code = 0, msg = "Ok" }));
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="userIds">多个用户id之间用逗号分隔</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> DeleteUsers([Required] string userIds)
        {
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            config.DeserializeConnConfig();
            string result= await _userService.DeleteUsersAsync(userIds, config.connConfig.workflow.Value);
            _operationLogService.AddOperationLog("DeleteUsers", "[用户中心]-[用户管理]-批量删除用户",3,$"userIds={userIds}", JsonConvert.SerializeObject(new ResponseBase<string>(result)));
            return result;
        }

        /// <summary>
        /// 批量设置设置用户角色关联关系
        /// </summary>
        /// <param name="userIds">多个用户id之间用逗号分隔</param>
        /// <param name="roleIds">多个机构id之间用逗号分隔</param>
        /// <param name="stationList">站点角色,多个之间用逗号隔开</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> SetUserRoleMap(
            [Required] string userIds,
            [Required] string roleIds,
            string stationList)
        {
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            config.DeserializeConnConfig();
            string result= await _userService.SetUserRoleMapAsync(userIds, roleIds, stationList, config.connConfig.workflow.Value);           
            _operationLogService.AddOperationLog("SetUserRoleMap", "[用户中心]-[用户管理]-批量关联角色", 2,$"userIds={userIds}&roleIds={roleIds}" ,JsonConvert.SerializeObject(new ResponseBase<string>(result)));
            return result;
        }

        /// <summary>
        /// 用户批量更改机构
        /// </summary>
        /// <param name="userIds">多个用户id之间用逗号分隔</param>
        /// <param name="oldGroupIds">多个旧机构id之间用逗号分隔</param>
        /// <param name="newGroupId">新机构id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> ModifyUserRole(
            [Required] string userIds,
            [Required] string oldGroupIds,
            [Required] int newGroupId)
        {           
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            config.DeserializeConnConfig();
            string result= await _userService.ModifyUserRoleAsync(userIds, oldGroupIds, newGroupId, config.connConfig.workflow.Value);
            _operationLogService.AddOperationLog("ModifyUserRole", "[用户中心]-[用户管理]-批量更改机构",2, $"userIds={userIds}&oldGroupIds={oldGroupIds}&newGroupId={newGroupId}", JsonConvert.SerializeObject(new ResponseBase<string>(result)));
            return result;
        }
        #endregion

        #region 站点管理
        /// <summary>
        /// 分页获取机构列表及用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public PagedList<GroupUserModel> GroupUserPagingList(Q_Group where)
        {
              return _groupService.GroupUserPagingList(where); 
        }



        /// <summary>
        /// 获取所有机构列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<SimpleGroup>> GetAllGroup()
        {
            List<Flow_Groups> groups = await _repository.GetListAsync(new Q_Group() { type=1});
            return groups.OrderByDescending(x => x.INDEXORDER).ThenBy(x => x.机构ID).Select(x => new SimpleGroup() { GroupId = x.机构ID, GroupName = x.名称 }).ToList();
        }

        /// <summary>
        /// 获取某个机构下所有用户列表
        /// </summary>
        /// <param name="groupId">机构id</param>
        /// <param name="stationId">站点id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserItem>> GetStationUserList([Required]int groupId ,  int stationId)
        {
               return await _groupService.GetStationUserList(groupId, stationId);
        }
        #endregion


        #region 配置_系统产品表

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Sys_Product>> ProductList([Required] Q_SysProduct where)
        {
               return await _productRepository.GetListAsync(where);
        }

        /// <summary>
        /// 新增或修改产品列表
        /// Id为0时新增，Id大于0时修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> ModifyProduct([Required] Sys_Product model)
        {
            if (model.Id == 0)
            {
                if (_productRepository.ExistName(model.ProductName))
                {
                    throw new Exception("产品名称不允许重复！");
                }
                return await _productRepository.AddAsync(model);
            }
            else
            {
                return _productRepository.Update(model);
            }
        }


        /// <summary>
        /// 删除产品列表
        /// </summary>
        /// <param name="ids">多个id之间用逗号隔开</param>WebModuleTree
        /// <returns></returns>
        [HttpGet]
        public async Task<int> DelProductList([Required] string ids)
        {
            List<Sys_Product> products = await _productRepository.GetListAsync(new Q_SysProduct() { IsAsTrack = true, ids = ids });
            if (products?.Count == 0)
                throw new Exception ("未查询对应的产品数据！");

            int res = _productRepository.RemoveRange(products);

            if (res == 0)
            {
                throw new Exception("删除失败！");
            }
            return res;
        }
        #endregion
    }
}
