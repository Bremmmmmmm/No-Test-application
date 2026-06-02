using Microsoft.AspNetCore.Mvc;
using NoTestApplication.Models;
using NoTestApplication.Services;

namespace NoTestApplication.Controllers;

/// <summary>
/// Controller for managing objects with CRUD operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ObjectsController : ControllerBase
{
    private readonly IObjectService _objectService;

    /// <summary>
    /// Initialize the controller with the object service.
    /// </summary>
    public ObjectsController(IObjectService objectService)
    {
        _objectService = objectService;
    }

    /// <summary>
    /// Get all objects.
    /// </summary>
    /// <returns>A list of all objects.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ObjectModel>> GetAll()
    {
        var objects = _objectService.GetAll();
        return Ok(objects);
    }

    /// <summary>
    /// Get a specific object by ID.
    /// </summary>
    /// <param name="id">The ID of the object to retrieve.</param>
    /// <returns>The requested object or a 404 if not found.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ObjectModel> GetById(int id)
    {
        var obj = _objectService.GetById(id);
        if (obj == null)
        {
            return NotFound(new { message = $"Object with ID {id} not found." });
        }

        return Ok(obj);
    }

    /// <summary>
    /// Create a new object.
    /// </summary>
    /// <param name="request">The object creation request.</param>
    /// <returns>The created object.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ObjectModel> Create([FromBody] CreateObjectRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdObject = _objectService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = createdObject.Id }, createdObject);
    }

    /// <summary>
    /// Update an existing object.
    /// </summary>
    /// <param name="id">The ID of the object to update.</param>
    /// <param name="request">The object update request.</param>
    /// <returns>No content if successful, 404 if not found.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update(int id, [FromBody] UpdateObjectRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = _objectService.Update(id, request);
        if (!success)
        {
            return NotFound(new { message = $"Object with ID {id} not found." });
        }

        return NoContent();
    }

    /// <summary>
    /// Delete an object by ID.
    /// </summary>
    /// <param name="id">The ID of the object to delete.</param>
    /// <returns>No content if successful, 404 if not found.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var success = _objectService.Delete(id);
        if (!success)
        {
            return NotFound(new { message = $"Object with ID {id} not found." });
        }

        return NoContent();
    }
}
