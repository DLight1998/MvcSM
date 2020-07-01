using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
namespace MvcSM.Models
{

  // $(".name").text(result[0]);
  // $(".dob").text(result[1]);   
  public class Student
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Student name is required")]
    //[Remote("IsStudentNameAvailable", "Student", ErrorMessage = "Student's name is already available")]
    [StringLength(35)]
    
    public string Name { get; set; }
    [Display(Name = "Date of Birth")]
    //[DataType(DataType.Date)]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date of Birth is required")]
    //[Remote("IsValidDate", "Student", ErrorMessage = "Dude, this one have not been born yet!")]
    //DOB = Date_of_Birth
    public DateTime DOB { get; set; }
    [Required(ErrorMessage = "Address is required")]
    [StringLength(300)]
    public string Address { get; set; }
    //email
    //[DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email address is required")]
    [Display(Name = "Email Address")]
    /* email addresses must start with 1 character + email address is a combination of characters a-z, 0-9 
    and may contain characters such as dots, underscore.
    The minimum length of emails is 3, the maximum length is 32 + email domains can be either level 1 or 2 */
    [RegularExpression(@"[a-z][a-z0-9_\.]{3,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$")]
    //[Remote("IsEmailAvailable", "Student", ErrorMessage = "Email is already available")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Student's major is required")]
    public string Major { get; set; }
  }
}