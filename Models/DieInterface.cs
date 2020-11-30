using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olirator.Models
{
    public interface DieInterface
    {
        public Random Random { get; }
        public int Sides { get; }

        public int? Result { get; set; }

        public bool Rolled { get; }

        public int? Roll();

        public int? Reroll();
    }
}
