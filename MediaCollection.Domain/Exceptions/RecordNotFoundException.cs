using System;
using System.Collections.Generic;
using System.Text;

namespace MediaCollection.Domain.Exceptions;

// TODO Write summaries
public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message) : base(message) 
    { 
    }
}
