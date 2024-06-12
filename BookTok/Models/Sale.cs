using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTok.Models;


public class Sale
{
    public int Id { get; set; }
    public int CostumerId {get;set;}
    public int BookId {get;set;}
 
    
    public virtual Costumer Costumer {get; set;}

    public virtual Book Book {get;set;}
}