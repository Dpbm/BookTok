using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTok.Models;


public class Sale
{
    public int Id { get; set; }
 
    [Required]
    public Costumer Costumer {get; set;}

    [Required]
    public virtual ICollection<Book> Books {get;set;}

    [Range(1, 1000000000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(10, 2)")]
    [Required]
    public float Amount {get;set;}
}