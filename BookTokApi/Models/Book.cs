namespace BookTokApi.Models;

public class Book
{
    public int Id { get; set; }

    public String Title {get; set;}

    public String Author {get;set;}

    public int Year {get;set;}

    public String Genre {get;set;}

    public String Publisher {get;set;}

    public int Quantity {get;set;} //private

    public float Price {get;set;}
}