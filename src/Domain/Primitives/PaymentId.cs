using Domain.Primitives.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Primitives;

public sealed record PaymentId(int Value) : TypedId<int>(Value);