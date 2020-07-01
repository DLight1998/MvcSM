using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSM.Data;
using MvcSM.Models;

namespace MvcSM.Controllers{
  public class UserController : Controller
  {
    private readonly MvcSMContext _context;
    public UserController( MvcSMContext context)
    {
        _context  = context;
    }
    // public IActionResult isLogin(){

    // }
    [HttpPost]
    public  async Task <IActionResult> Login(string username, string password)
    {
        //User user = new User();
    if(_context.User.Any(e => e.Username == username) &&
            _context.User.Any(e =>  e.Password == password)){
        return View("~/Views/Home/Index.cshtml");
        }
        else return PartialView("Login");
    }
  }    
}


//remote[[func][controller][]]