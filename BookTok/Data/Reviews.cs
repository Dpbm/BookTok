namespace BookTok.Data;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using BookTok.Models;

public class Reviews{
    private HttpClient _client; 

    public Reviews(){
        _client = new HttpClient();
        _client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("API_BASE_URL"));
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<IEnumerable<Review>> getBookReviews(int id){
        try{
            HttpResponseMessage response = await _client.GetAsync("Reviews/Book/"+id);

            response.EnsureSuccessStatusCode();

            List<Review> data = await response.Content.ReadAsAsync<List<Review>>();

            foreach (Review review in data){
                Console.WriteLine(review.ReviewText);
            }

            return data;

        }catch(HttpRequestException e){
            Console.WriteLine("HTTP GET request FAILED!!");
            Console.WriteLine(e.Message);
            return new List<Review>();
        }
        
    }
}