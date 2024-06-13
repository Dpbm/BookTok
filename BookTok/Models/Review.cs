using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTok.Models;

public class Review
{
    public int Id { get; set; }

    [Required]
    [Display(Name="Review")]
    [StringLength(200,MinimumLength =1)]
    public String ReviewText { get; set; }

    [Required]
    [Range(0, 5)]
    public int Rating {get;set;}

    [Required]
    [DataType(DataType.Date)]
    public String Date {get;set;}

    public int CostumerId {get;set;}
    public int BookId {get;set;}

    public virtual Costumer Costumer {get; set;}
}