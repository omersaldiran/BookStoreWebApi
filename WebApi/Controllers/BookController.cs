using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        public static List<Book> BookList = new List<Book>(){
            new Book{
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1, // Personel Growth
                PageCount = 200,
                PublishDate = new DateTime(2001,6,12) 
            },
            new Book{
                Id = 2,
                Title = "Herland",
                GenreId = 2, // Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,5,23) 
            },
            new Book{
                Id = 3,
                Title = "Dune",
                GenreId = 2, // Personel Growth
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21) 
            }
        };
    }
}