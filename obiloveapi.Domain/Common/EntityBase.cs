// obiloveapi.Domain/Common/EntityBase.cs
using System;

namespace obiloveapi.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; protected set; }
    }
}
