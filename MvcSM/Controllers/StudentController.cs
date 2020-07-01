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
  public class StudentController : Controller
  {
    private readonly MvcSMContext _context;
    public StudentController( MvcSMContext context)
    {
        _context  = context;
    }
    //get student;
    public async Task<IActionResult> Index(string searchString)
    {
      var students = from m in _context.Student
                    select m;
      if (!String.IsNullOrEmpty(searchString))
      {
          students = students.Where(s => s.Name.Contains(searchString));
      }
      //To remember
      /*The s => s.Title.Contains() code above is a Lambda Expression. 
      Lambdas are used in method-based LINQ queries as arguments to standard query operator methods such as the Where method or Contains (used in the code above).
      LINQ queries are not executed when they're defined or when they're modified by calling a method such as Where, Contains, or OrderBy. Rather, query execution is deferred.
      That means that the evaluation of an expression is delayed until its realized value is actually iterated over or the ToListAsync method is called
      */
      //ToListAsync method is called.  
      return View(await students.ToListAsync());
    }
    // GET: Student/Create
    public IActionResult Create()
    {
      return View("Create");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,DOB,Address,Email,Major")] Student student)
    {
      // if(student.DOB > DateTime.Now)
      // {
      //   //error Message;
      //   ViewBag.doberror = "Dude, this one have not been born yet!";
      // }
      if (ModelState.IsValid)
      {
        _context.Add(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View();
    }

    //Get Student/Edit
    public async Task<IActionResult> Edit(int? id){
      if (id == null)
      {
          return NotFound();
      }

      var student = await _context.Student.FindAsync(id);
      if (student == null)
      {
          return NotFound();
      }
      return View(student);
    } 
    //checkStudentExists
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DOB,Address,Email,Major")] Student student)
    {
      if (id != student.Id)
      {
        return NotFound();
      }
      // if(student.DOB > DateTime.Now)
      // {
      //    ViewBag.doberror = "Dude, this one have not been born yet!";
      // }
      if (ModelState.IsValid) 
      {
        try
        {
          _context.Update(student);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!StudentExists(student.Id))
          {
              return NotFound();
          }
          else
          {
              throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(student);
    }
   
    public async Task<IActionResult> Delete(int? id){
      if (id == null)
        {
            return NotFound();
        }
        var student = await _context.Student
            .FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Student.FindAsync(id);
        _context.Student.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
          return NotFound();
      }
      var student = await _context.Student
          .FirstOrDefaultAsync(m => m.Id == id);
      if (student == null)
      {
          return NotFound();
      }
      return View(student);
    }
    public JsonResult IsStudentNameAvailable(string Name)  
    {  
      return Json( !_context.Student.Any(e => e.Name == Name));
    }
    public JsonResult IsEmailAvailable(string Email)  
    {  
      return Json( !_context.Student.Any(e => e.Email == Email));
    }
    public JsonResult IsValidDate(DateTime DOB)  
    {  
      return Json(DateTime.Now >= DOB);
    }
    private bool StudentExists(int id)
    {
      return _context.Student.Any(e => e.Id == id);
    }  
    public string[] checkData(string name, DateTime dob){
      string[] result = new string[2];
      if (_context.Student.Any(e => e.Name == name)){
        result[0] = "Tên không được trùng"; 
      }
     
      if(DateTime.Now < dob){
        result[1] = "Ngày không hợp lệ";
      }

      return result;
    }
  }   
}


//remote[[func][controller][]]