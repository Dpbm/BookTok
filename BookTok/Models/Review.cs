namespace BookTok.Models;

public class Review
{
    public int Id { get; set; }

    public String ReviewText { get; set; }

    public int Rating {get;set;}

    public String Date {get;set;}

    public int CostumerId {get;set;}

    public virtual Costumer Costumer {get; set;}
}