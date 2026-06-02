using NoTestApplication.Models;

namespace NoTestApplication.Services;

/// <summary>
/// Service for managing objects with in-memory storage.
/// </summary>
public class ObjectService : IObjectService
{
    private static readonly Dictionary<int, ObjectModel> _objects = new();
    private static int _nextId = 1;

    /// <summary>
    /// Get all objects.
    /// </summary>
    public IEnumerable<ObjectModel> GetAll()
    {
        return _objects.Values.ToList();
    }

    /// <summary>
    /// Get an object by its ID.
    /// </summary>
    public ObjectModel? GetById(int id)
    {
        return _objects.TryGetValue(id, out var obj) ? obj : null;
    }

    /// <summary>
    /// Create a new object.
    /// </summary>
    public ObjectModel Create(CreateObjectRequest request)
    {
        var obj = new ObjectModel
        {
            Id = _nextId++,
            Name = request.Name,
            Date = request.Date
        };

        _objects[obj.Id] = obj;
        return obj;
    }

    /// <summary>
    /// Update an existing object.
    /// </summary>
    public bool Update(int id, UpdateObjectRequest request)
    {
        if (!_objects.TryGetValue(id, out var obj))
        {
            return false;
        }

        obj.Name = request.Name;
        obj.Date = request.Date;
        return true;
    }

    /// <summary>
    /// Delete an object by its ID.
    /// </summary>
    public bool Delete(int id)
    {
        return _objects.Remove(id);
    }
}
