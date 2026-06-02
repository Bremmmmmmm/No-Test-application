namespace NoTestApplication.Models;

/// <summary>
/// Request model for updating an existing object.
/// </summary>
public class UpdateObjectRequest
{
    /// <summary>
    /// Name of the object.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Date associated with the object.
    /// </summary>
    public DateTime Date { get; set; }
}
