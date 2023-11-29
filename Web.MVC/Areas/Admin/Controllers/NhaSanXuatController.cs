using DataModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class NhaSanXuatController : Controller
    {
        public ActionResult Index()
        {
            var nhaSanXuatDto = new NhaSanXuatDto();
            var list = nhaSanXuatDto.GetAll();
            return View(list);
        }

        
    }
}