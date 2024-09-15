public class Profile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Connection> Connections { get; set; } = new List<Connection>();
}