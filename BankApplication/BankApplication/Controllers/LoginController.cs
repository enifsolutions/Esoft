
using BankApplication.Models.Login;
using BankApplication.Models.User;
using Banking.Business.LoginBo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BankApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly LoginBo _loginBo;
        public LoginController(IConfiguration configuration, LoginBo service)
        {
            this._configuration = configuration;
            this._loginBo = service;
        }

        // GET: LoginView
        public IActionResult Index()
        {
            return View();
        }

        // GET: Login/Login/5
        public IActionResult Login(long? id)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        // POST: UserView/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(long id, [Bind("username,password")] LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = _loginBo.CheckUserCredentials(loginViewModel);

                if (result.code=="1")
                {
                    HttpContext.Session.SetString("current_user", loginViewModel.username);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View();
        }

        
    }
}
