using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCoreDemo.Core.Const;
using NetCoreDemo.Core.Enums;
using NetCoreDemo.Core.Options;
using NetCoreDemo.Core.Permission;
using NetCoreDemo.Services;
using NetCoreDemo.Web.Dto.User;
using Newtonsoft.Json;

namespace NetCoreDemo.Web.Controllers.SystemManager
{
    /// <summary>
    /// 菜单需配置所属模块(即Controller前缀)
    /// </summary>
    [Permission("用户管理", "SystemManager", (int)PermissionEnum.Menu, "fa fa-circle-o text-aqua")]
    public class UserController : Controller
    {
        private JWTBearerOptions jWTBearerOptions;
        private readonly ISys_AdminService sys_AdminService;
        //public UserController(IUserService userService, IOptions<JWTBearerOptions> option)
        public UserController(IOptions<JWTBearerOptions> option, ISys_AdminService _sys_AdminService)
        {
            sys_AdminService = _sys_AdminService;
            jWTBearerOptions = option.Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Permission("查询", "User", (int)PermissionEnum.Button, CssClassConst.BtnQuery)]
        [Route("User/Query")]
        public IActionResult Query()
        {
            var list = sys_AdminService.GetAllAdmin();
            var result = new { total = list.Count(), rows = list.ToList() };
            return Json(result);
        }
        [HttpPost]
        [Permission("新增", "User", (int)PermissionEnum.Button, CssClassConst.BtnAdd)]
        [Route("User/Add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        [Permission("详细", "User", (int)PermissionEnum.Button, CssClassConst.BtnDetail)]
        [Route("User/Detail")]
        public IActionResult Detail()
        {
            return View();
        }
        [HttpGet]
        [Permission("删除", (int)PermissionEnum.Button, CssClassConst.BtnDelete)]
        public IActionResult Delete()
        {
            return View();
        }
        /// <summary>
        /// 登录并获取验证token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login([FromBody]LoginInput input)
        {
            //if (!userService.ValidateUser(input.UserName, input.Password))
            //{
            //    return BadRequest();
            //}
            var userModel = new { ID = 1, Name = "123" }; //userService.GetUser(input.UserName);
            if (userModel == null) return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jWTBearerOptions.Secret);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience,jWTBearerOptions.Audience),
                    new Claim(JwtClaimTypes.Issuer,jWTBearerOptions.Issuer),
                    //new Claim(JwtClaimTypes.Id, userModel.ID.ToString()),
                    //new Claim(JwtClaimTypes.Name, userModel.Name),
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    sid = userModel.ID,
                    name = userModel.Name,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }
    }

}