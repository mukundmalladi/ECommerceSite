using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using EcommerceMvc.Dapper;
using EcommerceMvc.Helper;
using EcommerceMvc.Models;
using EcommerceMvc.Pocos;
using User = EcommerceMvc.Helper.User;


namespace EcommerceMvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISaveToDatabase _saveToDatabase;

       
        public HomeController(ISaveToDatabase saveToDatabase)
        {
            this._saveToDatabase = saveToDatabase;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ecommerce website";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//TODO check this
        public JsonResult RegisterSave(RegisterModel registerModel)
        {
            var salt = GenerateSalt();

            var person = new Person()
            {
                Password = registerModel.Password,
                CreateDate = DateTime.Now,
                CreatedBy = HttpContext.User.Identity.Name,
                EmailId = registerModel.EmailId,
                LastName = registerModel.LastName,
                FirstName = registerModel.FirstName,
                UserName = registerModel.UserName,
                Salt = Convert.ToBase64String(salt)
            };
            var password = GenerateHash(salt, registerModel.Password);
            person.Password = password;
          _saveToDatabase.Save(person);

          return new JsonResult();
        }
    
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {

            var getUserFromDataBase = new PersonQuery().GetFromDatabase(loginModel.UserName);
    
            var salt = Convert.FromBase64String(getUserFromDataBase.Salt);

            var generatehash = GenerateHash(salt, loginModel.Password);
            
            if (generatehash == getUserFromDataBase.Password)
            {
                var user = new User() {LastName = getUserFromDataBase.LastName, FirstName = getUserFromDataBase.FirstName, EmailId = getUserFromDataBase.EmailId, Id = getUserFromDataBase.Id};

                var serializer = new JavaScriptSerializer();

                var userData = serializer.Serialize(user);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    user.FullName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    false,
                    userData);
                
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
                
                return RedirectToAction("Index", "Home");
            }

            //TODO error page
            return new JsonResult();
        }
        
        private string GenerateHash(byte[] salt, string password)
        {
            var passwordByte = Encoding.UTF32.GetBytes(password);
            var argon2 = new Rfc2898DeriveBytes(passwordByte, salt, 10);
            var hash = argon2.GetBytes(20);
             
            var com = hash.Concat(salt).ToArray();

            return Convert.ToBase64String(com);
        }

        private byte[] GenerateSalt()
        {
            byte[] bytes;
            using (RNGCryptoServiceProvider gen = new RNGCryptoServiceProvider())
            {
                bytes = new byte[16];
                gen.GetBytes(bytes);
            }
          return bytes;
        }
    }
}