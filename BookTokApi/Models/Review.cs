namespace BookTokApi.Models;

public class Review
{
    public int Id { get; set; }

    public String ReviewText { get; set; }

    public int Rating {get;set;}

    public DateTime Date {get;set;}

    public int CostumerId {get;set;}


}