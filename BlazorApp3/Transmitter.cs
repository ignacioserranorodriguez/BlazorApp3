using System.ComponentModel.DataAnnotations;

namespace BlazorApp3.Models;

public class Transmitter : Device
{
    [Required]
    public string Url { get; set; }
}