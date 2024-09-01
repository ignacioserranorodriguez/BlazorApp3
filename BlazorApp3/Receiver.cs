using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp3.Models;

public class Receiver : Device
{
    [ForeignKey("TransmitterId")]
    public Transmitter Transmitter { get; set; }
    public int? TransmitterId { get; set; }
}