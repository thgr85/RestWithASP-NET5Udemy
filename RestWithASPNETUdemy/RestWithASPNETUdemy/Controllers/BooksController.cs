using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.HyperMedia.Filters;

namespace RestWithASPNETUdemy.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private IBookBusiness _bookBusiness;

    public BooksController(ILogger<BooksController> logger, IBookBusiness bookBusiness)
    {
        _logger = logger;
        _bookBusiness = bookBusiness;
    }

    [HttpGet]
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {
        return Ok(_bookBusiness.FindAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((201), Type = typeof(PersonVO))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
        var book = _bookBusiness.FindById(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType((201), Type = typeof(PersonVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] BookVO book)
    {
        if (book == null) return BadRequest();
        return Ok(_bookBusiness.Create(book));
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] BookVO book)
    {
        if (book == null) return BadRequest();
        return Ok(_bookBusiness.Update(book));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Delete(long id)
    {
        _bookBusiness.Delete(id);
        return NoContent();
    }
}
