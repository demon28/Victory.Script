using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Script.DataAccess.CodeGenerator;
using Victory.Script.Entity.Enums;
using Victory.Script.WebApp.Attribute;

namespace Victory.Script.WebApp.WebApi
{



    public class VerifyController : ApiControllerBase
    {
        /// <summary>
        /// 设备验证码激活
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="code"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        [WebApiFilter]
        [HttpGet]
        public IActionResult Activate(int projectId, string code,string device,string phoneType)
        {

            Tscript_Code_Da da = new Tscript_Code_Da();

             var data= da.Select.Where(s => s.Project_Id == projectId && s.Code==code).ToOne();

            if (data==null)
            {
                return FailMessage("激活失败！请输入正确的激活码！");
            }

            if (data.Status == (int)CodeStatus.已使用 && data.Device==device)
            {
                return SuccessResult("激活成功！感谢您的使用！");
            }

            if (data.Status==(int)CodeStatus.已使用 && data.Device != device)
            {
                return FailMessage("激活失败！激活码已在其他设备使用！");
            }

            if (data.Expiration>DateTime.Now)
            {
                return FailMessage("激活失败！激活码已过期！");
            }

            data.Device = device;
            data.Activation = DateTime.Now;
            data.PhoneType = phoneType;
            data.Status =(int) CodeStatus.已使用;

            if (da.Update(data)<1)
            {
                return FailMessage("激活失败！服务器故障！请联系管理员！");
            }
       
            return SuccessResult("激活成功！感谢您的使用！");
        }

    }
}
