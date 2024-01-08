using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApplication.Data;
using BankApplication.Models.User;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Xml;
using System.Data;
using Banking.Business.AppUserBo;

namespace BankApplication.Controllers
{
    public class UserViewController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AppUserBo _appUserBo;
        public UserViewController(IConfiguration configuration, AppUserBo service)
        {
            this._configuration = configuration;
            this._appUserBo = service;
        }

        // GET: UserView
        public IActionResult Index()
        {
              return View();
        }

        // GET: UserView/AddOrEdit/5
        public IActionResult AddOrEdit(long? id)
        {            
            UserViewModel userViewModel = new UserViewModel();  
            return View(userViewModel);
        }

        // POST: UserView/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(long id, [Bind("userid,username,password,createduser,action")] UserViewModel userViewModel)
        {
            
            if (ModelState.IsValid)
            {
                var result = _appUserBo.CreateAppUser(userViewModel);
                TempData["NotificationMessage"] = result.massage;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: UserView/Delete/5
        public IActionResult Delete(long? id)
        {          
            return View();
        }

        // POST: UserView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {           
            return RedirectToAction(nameof(Index));
        }
                
    }
}
