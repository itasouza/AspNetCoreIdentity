using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Model
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
