using BlazorApp3.Models;

public class Connection
{
    public int Id { get; set; }
    public int TransmitterId { get; set; }
    public Transmitter Transmitter { get; set; }
    public int ReceiverId { get; set; }
    public Receiver Receiver { get; set; }
    public int ProfileId { get; set; }
    public Profile Profile { get; set; }
}