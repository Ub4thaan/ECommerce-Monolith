using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Entities.Abstractions;

public interface IDbEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}
