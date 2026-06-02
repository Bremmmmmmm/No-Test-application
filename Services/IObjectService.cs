using NoTestApplication.Models;

namespace NoTestApplication.Services;

/// <summary>
/// Service interface for managing objects.
/// </summary>
public interface IObjectService
{
    /// <summary>
    /// Get all objects.
    /// </summary>
    IEnumerable<ObjectModel> GetAll();

    /// <summary>
    /// Get an object by its ID.
    /// </summary>
    ObjectModel? GetById(int id);

    /// <summary>
    /// Create a new object.
    /// </summary>
    ObjectModel Create(CreateObjectRequest request);

    /// <summary>
    /// Update an existing object.
    /// </summary>
    bool Update(int id, UpdateObjectRequest request);

    /// <summary>
    /// Delete an object by its ID.
    /// </summary>
    bool Delete(int id);
}
