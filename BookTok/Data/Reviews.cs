namespace BookTok.Data;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
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

            return data;

        }catch(HttpRequestException e){
            Console.WriteLine("HTTP GET request FAILED!!");
            Console.WriteLine(e.Message);
            return new List<Review>();
        }
        
    }

    public async Task addReview(Review review){
         try{

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(review),
                Encoding.UTF8,
                "application/json");


            using HttpResponseMessage response = await _client.PostAsync(
                "Reviews",
                jsonContent);

            response.EnsureSuccessStatusCode();
            
        }catch(HttpRequestException e){
            Console.WriteLine("HTTP POST request FAILED!!");
            Console.WriteLine(e.Message);
        }
    }

    public async Task<Review> getReview(int? id){
        try{
            HttpResponseMessage response = await _client.GetAsync("Reviews/"+id);

            response.EnsureSuccessStatusCode();

            Review data = await response.Content.ReadAsAsync<Review>();

            return data;

        }catch(HttpRequestException e){
            Console.WriteLine("HTTP GET request FAILED!!");
            Console.WriteLine(e.Message);
            return null;
        }
        
    }

    public async Task deleteReview(int id){
        try{
            HttpResponseMessage response = await _client.DeleteAsync("Reviews/"+id);
            response.EnsureSuccessStatusCode();

        }catch(HttpRequestException e){
            Console.WriteLine("HTTP DELETE request FAILED!!");
            Console.WriteLine(e.Message);
        }
        
    }
}