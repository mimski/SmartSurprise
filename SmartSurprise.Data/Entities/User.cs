namespace SmartSurprise.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<Poll> Polls { get; set; }
    public ICollection<Vote> Votes { get; set; }
}

