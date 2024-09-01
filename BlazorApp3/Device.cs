using System.ComponentModel.DataAnnotations;

namespace BlazorApp3.Models;

public class Device
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Ip { get; set; }
    [Range(0, 3)]
    public int Status { get; set; }
}