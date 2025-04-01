namespace DHSC.ANS.API.Consumer.DTOs;

/// <summary>
/// A structured error response indicating that one or more validation errors occurred.
/// </summary>
public class ValidationErrorResponse
{
    /// <summary>
    /// A short, human-readable summary of the problem.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The HTTP status code.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// A human-readable explanation specific to this occurrence of the problem.
    /// </summary>
    public string Detail { get; set; }

    /// <summary>
    /// A map of property names to arrays of error messages.
    /// </summary>
    public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}