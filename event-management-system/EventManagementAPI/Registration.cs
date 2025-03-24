using Microsoft.EntityFrameworkCore;

public class Registration
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public required Event Event { get; set; }
}
