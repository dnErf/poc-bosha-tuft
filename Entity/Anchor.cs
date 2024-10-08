﻿namespace BoshaTuft.Entity;

public sealed class Anchor
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProfileId { get; set; } = "";
    public required string Description { get; set; } = "";
    public required string LinkTo { get; set; } = "";
    public string Pic { get; set; } = "";
    public string Alt { get; set; } = "";
    public string DatedAt { get; set; } = DateTime.UtcNow.ToString("s");
}
