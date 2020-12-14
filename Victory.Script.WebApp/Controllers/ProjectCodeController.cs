using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Core.Models;
using Victory.Script.DataAccess.CodeGenerator;
using Victory.Script.Entity;
using Victory.Script.Entity.CodeGenerator;
using Victory.Script.WebApp.Attribute;
using static Victory.Script.Entity.Enums.CodeEnum;

namespace Victory.Script.WebApp.Controllers
{
    public class ProjectCodeController : TopControllerBase
    {
       

        [Permission(PowerName = "访问")]
        public IActionResult Index()
        {
            return View();
        }

        [Permission(PowerName = "激活码查询")]
        [HttpPost]
        public IActionResult CodeList(int projectid,string keyword, int pageIndex, int pageSize)
        {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;

            var data = DataAccess.DbContext.Db.Select<Tscript_Project,Tscript_Code>()
                .LeftJoin((a,b)=>b.Project_Id==a.Id)
                .Where((a,b)=>b.Project_Id==projectid);

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where((a, b) => a.Name.Contains(keyword) || b.Device.Contains(keyword));
            }

            page.TotalCount = (int)data.Count();


            var list = data.Page(page.PageIndex, page.PageSize)
                .OrderBy((a,b)=>b.Id)
                .ToList((a,b)=>new { 
                    
                    ProjectName= a.Name,
                    b.Id,
                    b.Activation,
                    b.Agent,
                    b.Code,
                    b.Createtime,
                    b.Device,
                    b.Expiration,
                    b.Status,
                    b.Type,
                    b.Project_Id
            });
            return SuccessResultList(list, page);
        }

        [Permission(PowerName = "激活码添加")]
        [HttpPost]
        public IActionResult CodeAdd(Tscript_Code model)
        {
            model.Code = Entity.CreateCode.Create();
            model.Createtime = DateTime.Now;
            model.Status = 0;
            model.Agent = 1;

            Tscript_Code_Da da = new Tscript_Code_Da();
            da.Insert(model);
            return SuccessMessage("添加成功！");

        }


        [Permission(PowerName = "激活码修改")]
        [HttpPost]
        public IActionResult CodeUpdate(Tscript_Code model)
        {
            Tscript_Code_Da da = new Tscript_Code_Da();
            da.Update(model);
            return SuccessMessage("成功！");
        }


        [Permission(PowerName = "激活码删除")]
        [HttpPost]
        public IActionResult CodeDel(int id)
        {
            Tscript_Code_Da da = new Tscript_Code_Da();

            if (da.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage("已删除！");

            }
            return FailMessage();
        }

        [HttpPost]
        [Permission(PowerName = "批量生成激活码")]
        public IActionResult BatchAdd(int projectid,int count, CodeType type, int agent=0)
        {
            List<Tscript_Code> list = new List<Tscript_Code>();

            for (int i = 0; i < count; i++)
            {
                Tscript_Code model = new Tscript_Code();

                model.Agent = agent;
                model.Code =Entity.CreateCode.Create();
                model.Createtime = DateTime.Now;
                model.Device = string.Empty;
                model.Type = (int)type;
                model.Status = (int)CodeStatus.未激活;
                model.Project_Id = projectid;
                model.Expiration = DateTimeHelper.CodeTypeDate(type);

                list.Add(model);
            }

            int nums = DataAccess.DbContext.Db.Insert<Tscript_Code>(list).ExecuteAffrows();

            if (nums > 0)
            {
                return SuccessMessage("添加成功！");
            }
            return FailMessage("添加失败");
       
        }

        [Permission(PowerName = "生成激活码")]
        [HttpPost]
        public IActionResult CreateCode()
        {
            return SuccessResult(Entity.CreateCode.Create());

        }


        [Permission(PowerName = "项目查询")]
        [HttpPost]
        public IActionResult ProjectList(string keyword)
        {

            var data = DataAccess.DbContext.Db.Select<Tscript_Project>();
              
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where((a) => a.Name.Contains(keyword));
            }

            var list = data .OrderBy((a) => a.Id)
                .ToList();
            return SuccessResultList(list);
        }




        [Permission(PowerName = "项目添加")]
        [HttpPost]
        public IActionResult ProjectAdd(string name)
        {
            Tscript_Project model = new Tscript_Project();
            model.Name = name;
            model.Createtime = DateTime.Now;
            
            Tscript_Project_Da da = new Tscript_Project_Da();
            da.Insert(model);
            return SuccessMessage("添加成功！");

        }


        [Permission(PowerName = "项目修改")]
        [HttpPost]
        public IActionResult ProjectUpdate(Tscript_Project model)
        {
            Tscript_Project_Da da = new Tscript_Project_Da();
            da.Update(model);
            return SuccessMessage("成功！");
        }


        [Permission(PowerName = "项目删除")]
        [HttpPost]
        public IActionResult ProjectDel(int id)
        {
            Tscript_Project_Da da = new Tscript_Project_Da();

            if (da.Delete(s => s.Id == id) > 0)
            {
                return SuccessMessage("已删除！");

            }
            return FailMessage();
        }


    }
}
