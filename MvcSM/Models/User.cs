using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
namespace MvcSM.Models
{

  // $(".name").text(result[0]);
  // $(".dob").text(result[1]);   
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [StringLength(32)]
    public string Username { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    
    public string Password{ get; set; }
    public string Role{ get; set; }
  }
}