using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Web.MVC.Models;

namespace Web.MVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private NhaSachEntities db = new NhaSachEntities();
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DataModels.EF.NguoiDung obj, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Kiểm tra đăng nhập của người dùng
                var crrObj = db.NguoiDung.FirstOrDefault(m => m.TaiKhoan == obj.TaiKhoan && m.MatKhau == obj.MatKhau);
                if (crrObj == null)
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
                else
                {
                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    //C1: Lưu lại trạng thái đăng nhập của người dùng và kiểm soát việc đăng nhập trong quá trình hoạt động của trang web
                    //Session["User"] = crrObj;
                    //return RedirectToAction("Index", "Home");

                    //C2: Lưu trạng thái đăng nhập của người dùng vào Form-cookie
                    FormsAuthentication.SetAuthCookie(crrObj.TaiKhoan, false); // false: Không lưu trạng thái
                    //Điều hướng về trang cuối cùng mà người dùng làm việc trước khi mất phiên đăng nhập
                    if (ReturnUrl == null)
                    {
                        FormsAuthentication.SetAuthCookie(ReturnUrl, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }

                }


            }

            return View(obj);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}