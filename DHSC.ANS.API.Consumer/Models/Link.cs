namespace DHSC.ANS.API.Consumer.Models;

public class Link
{
    public string Rel { get; set; }     // e.g. self, next, update, delete
    public string Href { get; set; }
    public string Method { get; set; }  // GET, POST, etc.
}