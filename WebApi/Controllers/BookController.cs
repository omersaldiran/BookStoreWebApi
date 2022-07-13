using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result =  query.Handle();
            return Ok(result);
        }

         [HttpGet("{id}")]
        public IActionResult GetById(int id){
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
            try
            {   
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        //  [HttpGet]
        // public Book Get([FromQuery] string id){
        //     var book = BookList.Where(book=> book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook){
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                command.BookId = id;
                command.Model = updatedBook;
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();

        } 
    }
}