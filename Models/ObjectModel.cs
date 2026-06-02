namespace NoTestApplication.Models;

/// <summary>
/// Represents an object with a name and date.
/// </summary>
public class ObjectModel
{
    /// <summary>
    /// Unique identifier for the object.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the object.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Date associated with the object.
    /// </summary>
    public DateTime Date { get; set; }
}
