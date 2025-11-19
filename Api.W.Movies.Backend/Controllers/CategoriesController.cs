using Api.W.Movies.Backend.DAL.Models.Dtos;
using Api.W.Movies.Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.W.Movies.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryServices _categoryServices;

    public CategoriesController(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoryAsync()
    {
        var categories = await _categoryServices.GetCategoryAsync();
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetCategoryAsync(int id)")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
    {
        var categories = await _categoryServices.GetCategoryAsync(id);
        return Ok(categories);
    }

    [HttpGet("{name}", Name = "GetCategoryAsync(string name)")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDto>> GetCategoryAsync(string name)
    {
        var categories = await _categoryServices.GetCategoryAsync(name);
        return Ok(categories);
    }

    [HttpPost(Name = "CreateCategoryAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CategoryDto>> GetCategoryAsync([FromBody] CategoryCreateDto categoryCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createCategory = await _categoryServices.CreateCategoryAsync(categoryCreateDto);

            //return 201 create

            return CreatedAtRoute("GetCategoryAsync(int id)",
                new { id = createCategory.Id },
                createCategory);
        }
        catch (InvalidOperationException ex2) when (ex2.Message.Contains("Ya existe"))
        {
            return Conflict(new { ex2.Message });
        }
        catch (Exception ex1)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex1.Message);
        }
    }
}  