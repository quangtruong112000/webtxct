using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webtx.DAO;
using webtx.Models;

namespace webtx.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.LoginForCus(model.UserName, GetMD5(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserID = user.iduser;
                    userSession.Name = user.name;
                    userSession.Email = user.gmail;
                    userSession.Phone = user.phone;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng!");
                }
            }
            return View("Login");
        }
        public static string GetMD5(string text)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));

            }
            return sbHash.ToString();

        }
        /*[HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng")]
        public ActionResult Register(RegisterModel model)
        {
            var dao = new UserDao();
            if (dao.ckeckUserName(model.UserName))
            {
                ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
            }
            else if (dao.checkEmail(model.Email))
            {
                ModelState.AddModelError("", "Email đã tồn tại");
            }
            else if (model.Password == model.ConfirmPassword)
            {
                var user = new User();
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.Password = Encryptor.GetMD5(model.Password);
                user.Phone = model.Phone;
                user.Email = model.Email;
                user.Address = model.Address;
                user.CreatedDate = DateTime.Now;
                user.DistrictID = int.Parse(model.DistrictID);
                user.ProvinceID = int.Parse(model.ProvinceID);
                user.Status = true;
                if (!string.IsNullOrEmpty(model.DistrictID))
                {
                    user.DistrictID = int.Parse(model.DistrictID);
                }
                if (!string.IsNullOrEmpty(model.ProvinceID))
                {
                    user.ProvinceID = int.Parse(model.ProvinceID);
                }
                var result = dao.Insert(user);
                if (result > 0)
                {
                    ViewBag.Success = "Đăng kí thành công";
                    model = new RegisterModel();
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "Đăng kí không thành công");
                }
            }
            return View("Register");
        }*/
    }
}