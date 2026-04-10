using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Models;

[ExcludeFromCodeCoverage]
public class RefreshToken
{
    public string UserName { get; set; }

    public string TokenString { get; set; }

    public DateTime ExpireAt { get; set; }
}
