using Microsoft.AspNetCore.Mvc;
using ShipmentAndLotoutResolver.Models;

namespace ShipmentAndLotoutResolver.Controllers
{
    public class HomeController : Controller
    {
        private readonly InterfaceUser interfaceUser;
        private readonly IFileRepository fileRepository;

        public HomeController(InterfaceUser interfaceUser, IFileRepository fileRepository)
        {
            this.interfaceUser = interfaceUser;
            this.fileRepository = fileRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ShipmentAndLotout");
            }
        }
        [HttpPost]
        public IActionResult Login(string UserName)
        {
            if (UserName != null)
            {
                UserModel? result = interfaceUser.UserLogin(UserName);
                if (result != null)
                {
                    HttpContext.Session.SetString("UserName", result.Full_name);
                    HttpContext.Session.SetString("CodeNumber", result.User_name);
                    TempData["AlertMessageSuccess"] = "Login Success !! Welcome " + result.Full_name;
                    return RedirectToAction("ShipmentAndLotout");
                }
                else
                {
                    TempData["AlertMessageError"] = "Login Failed !! Please enter the correct code.";
                    return View("Index");
                }
            }
            else
            {
                TempData["AlertMessageError"] = "Login Failed !! Please enter code number.";
                return View("Index");
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult ShipmentAndLotout()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult InputLot(string InputLot)
        {
            string? StringMessageFromReturn = "";
            try
            {
                StringMessageFromReturn = fileRepository.FileName(InputLot);
                TempData["AlertMessageFileAction"] = StringMessageFromReturn;
                return RedirectToAction("ShipmentAndLotout");
            }
            catch
            {
                TempData["AlertMessageFileAction"] = StringMessageFromReturn;
                return RedirectToAction("ShipmentAndLotout");
            }
        }
    }
}