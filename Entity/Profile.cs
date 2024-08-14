namespace BoshaTuft.Entity;

public sealed class Profile
{
    private string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public required string About { get; set; }
    public string Pic { get; set; } = "";
    public string Alt { get; set; } = "";
    public string DatedAt { get; set; } = DateTime.UtcNow.ToString("s");
    public List<Anchor> Anchors { get; set; } = new List<Anchor>();
}
