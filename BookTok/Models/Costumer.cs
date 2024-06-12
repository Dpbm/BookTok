using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTok.Models;

public class Costumer
{
    public int Id { get; set; }
 
    [StringLength(60, MinimumLength =1)]
    [Required]
    public String Name {get;set;}

    [DataType(DataType.PhoneNumber)]    
    [Required]
    public String Phone {get;set;}
    
    [DataType(DataType.EmailAddress)]
    public String Email {get;set;}

    [StringLength(11, MinimumLength =11)]
    [Required]
    public String CPF {get;set;}
}
