namespace NoTestApplication.Models;

/// <summary>
/// Request model for creating a new object.
/// </summary>
public class CreateObjectRequest
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
