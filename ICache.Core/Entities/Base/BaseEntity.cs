using System;

namespace ICache.Core.Entities.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
