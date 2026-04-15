using Domain.Primitives.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Primitives;

public sealed record OrderItemId(int Value) : TypedId<int>(Value);
