using TicketManager.Model.Enums;
using TicketManager.Model.Exceptions;

namespace TicketManager.Model.Models;

public class Ticket : BaseModel
{
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public Status Status { get; private set; }
    public int UserId { get; private set; }
    public virtual User? User { get; private set; }

    public Ticket(int userId, string title, string description)
    {
        this.UserId = userId;
        this.Title = title;
        this.Description = description;
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
        this.IsValid();
    }

    private void IsValid()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new ModelException("Title cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Description))
            throw new ModelException("Description cannot be null or empty.");

        if (UserId <= 0)
            throw new ModelException("User not found.");
    }
}