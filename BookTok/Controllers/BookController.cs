using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookTok.Data;
using BookTok.Models;

namespace BookTok.Controllers
{
    public class BookController : Controller
    {
        private readonly BookTokContext _context;
        private readonly Reviews _reviews;

        public BookController(BookTokContext context)
        {
            _context = context;
            _reviews = new Reviews();
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        // GET: Book/Reviews/5
        [HttpGet("/Reviews/{id}")]
        public async Task<IActionResult> Reviews(int id)
        {
            IEnumerable<Review> reviews = await _reviews.getBookReviews(id);
            foreach(Review review in reviews){
                review.Costumer = await _context.Costumer.FirstOrDefaultAsync(m => m.Id == review.CostumerId);
            }
            return View(reviews);
        }

        // GET: Book/DetailsReview/5
        public async Task<IActionResult> DetailsReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviews.getReview(id);
            if (review == null)
            {
                return NotFound();
            }

            review.Costumer = await _context.Costumer
                .FirstOrDefaultAsync(m => m.Id == review.CostumerId);
            review.Book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == review.BookId);


            return View(review);
        }


        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Book/AddReview/5
        public IActionResult AddReview(int id)
        {
            ViewData["CostumerId"] = new SelectList(_context.Costumer, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview([Bind("ReviewText,Rating,Date,CostumerId")] Review review, int id)
        {
            if (ModelState.IsValid)
            {
                review.BookId = id;
                
                await _reviews.addReview(review);
                return RedirectToAction(nameof(Reviews), new {id=id});
            
            }

            ViewData["CostumerId"] = new SelectList(_context.Costumer, "Id", "Name");
            return View(review);
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Year,Genre,Publisher,Quantity,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/EditReview/5
        public async Task<IActionResult> EditReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviews.getReview(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Book/EditReview/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, [Bind("Id,BookId,CostumerId,ReviewText,Rating,Date")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _reviews.updateReview(review);
                return RedirectToAction(nameof(Reviews), new{id=review.BookId});
            }
            return View(review);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Year,Genre,Publisher,Quantity,Price")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/DeleteReview/5
        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviews.getReview(id);
            if (review == null)
            {
                return NotFound();
            }

            review.Costumer = await _context.Costumer
                .FirstOrDefaultAsync(m => m.Id == review.CostumerId);
            review.Book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == review.BookId);


            return View(review);
        }

        // POST: Book/DeleteReview/5
        [HttpPost, ActionName("DeleteReview")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _reviews.getReview(id);
            if (review != null)
            {
                await _reviews.deleteReview(id);
            }

            return RedirectToAction(nameof(Reviews), new {id=review.BookId});
        }



        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
