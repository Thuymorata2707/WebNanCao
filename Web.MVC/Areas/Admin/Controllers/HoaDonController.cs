using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class HoaDonController : Controller
    {
        // GET: Admin/HoaDon
        public ActionResult Index()
        {
            return View();
        }
    }
}