using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTok.Models;


public class Book
{
    public int Id { get; set; }
 
    [StringLength(80, MinimumLength = 1)]
    [Required]
    public String Title {get; set;}

    [StringLength(50, MinimumLength =1)]
    [Required]
    public String Author {get;set;}

    [Range(1, 9999)]
    [Display(Name ="Publishing year")]
    [Required]
    public int Year {get;set;}

    [StringLength(60, MinimumLength =4)]
    [Required]
    public String Genre {get;set;}

    [StringLength(60, MinimumLength =1)]
    [Required]
    public String Publisher {get;set;}

    [Range(0, 1000)]
    [Required]
    public int Quantity {get;set;}

    [Range(1, 1000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(6, 2)")]
    [Required]
    public float Price {get;set;}

}
