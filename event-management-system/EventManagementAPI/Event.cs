public class Event
{
    public int Id { get; set; }


    public required string Title { get; set; }

    public required string Description { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public int MaxAttendees { get; set; }
}
