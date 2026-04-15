using Domain.Primitives.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Primitives;

public sealed record InventoryId(int Value) : TypedId<int>(Value);