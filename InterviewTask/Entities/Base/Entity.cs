using System;

namespace Entities.Base
{
    public class Entity<T>
    {
        public T Id { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
