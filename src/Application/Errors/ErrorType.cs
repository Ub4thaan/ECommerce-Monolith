using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Errors;

public enum ErrorType
{
    Unknown,
    Failure,
    Validation,
    Problem,
    NotFound,
    Conflict,
    Internal
}