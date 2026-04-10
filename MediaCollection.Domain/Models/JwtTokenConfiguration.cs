using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Models;

[ExcludeFromCodeCoverage]
public class JwtTokenConfiguration
{
    public string? Issuer { get; set; }

    public string? Audience { get; set; }

    public string? Secret { get; set; }

    public double AccessTokenExpiration { get; set; }

    public double RefreshTokenExpiration { get; set; }
}
