using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (alreadyAdded)
            {
                throw new InvalidOperationException("Book already added to collection.");
            }

            var userBook = new IdentityUserBook
            {
                CollectorId = userId,
                BookId = book.Id
            };

            await dbContext.IdentityUserBooks.AddAsync(userBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MineBooksViewModel>> GetMineBooksAsync(string userId)
        {
            return await dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new MineBooksViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                }).ToListAsync();
        }
    }
}
