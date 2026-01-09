using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Models;

// TODO Summaries
public record DeveloperToBe
{
    public string? PictureUri { get; init; }

    public string Name { get; init; } = string.Empty;
}
