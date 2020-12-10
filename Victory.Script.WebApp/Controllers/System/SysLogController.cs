﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Core.Models;
using Victory.Script.DataAccess.CodeGenerator;
using Victory.Script.Entity.Enums;
using Victory.Script.WebApp.Attribute;

namespace Victory.Script.WebApp.Controllers
{
    [Authorize]
    public class SysLogController : TopControllerBase
    {



        [Permission(PowerName = "系统日志")]
        public IActionResult Index()
        {
            return View();
        }



        [Permission(PowerName = "查询")]
        [HttpPost]
        public IActionResult List(string keyword, DateTime? keystartime, DateTime? keyendTime, int keytype, int pageIndex, int pageSize)
        {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;


            Tsys_Log_Da da = new Tsys_Log_Da();
            var list = da.ListByWhere(keyword, (SysLogType)keytype, keystartime, keyendTime, ref page);


            return SuccessResultList(list, page);



        }


    }
}
