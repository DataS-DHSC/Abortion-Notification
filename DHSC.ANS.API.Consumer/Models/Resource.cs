namespace DHSC.ANS.API.Consumer.Models;

public abstract class Resource
{
    public List<Link> Links { get; set; } = new List<Link>();
}
