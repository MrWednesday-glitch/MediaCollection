using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Models;

[ExcludeFromCodeCoverage]
public class JwtAuthorityResult
{
    public string AccessToken { get; set; }

    public RefreshToken RefreshToken { get; set; }
}
