﻿namespace Eleshop.Domain.Entites.Telephones;

public class Telephone : Auditable
{
    public long CategoryId { get; set; }

    public long UserId { get; set; }

    public string Name { get; set; } = String.Empty;

    public float UnitPrice { get; set; }

    public string ImagePath { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string Company { get; set; } = String.Empty;

    public string Ram { get; set; } = String.Empty;

    public string Memory { get; set; } = String.Empty;

    public string Version { get; set; } = String.Empty;
}
