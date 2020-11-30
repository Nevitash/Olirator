using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Olirator.Constants.ExceptionConstants;

namespace Olirator.Models
{
    public class Die : DieInterface
    {
        public Random Random { get; }
        public int Sides { get; }

        public int? Result { get; set; }

        public bool Rolled { get; set; } = false;

        public Die(int sides, Random random)
        {
            if(sides > 0)
            {
                Random = random;
                Sides = sides;
            } else
            {
                throw new ArgumentException(ERROR_MESSAGE_INVALID_SIDES_FOR_DIE);
            }
        }

        public int? Roll()
        {
            if (!Rolled)
            {
                Result = Random.Next(1, Sides);
                Rolled = true;

                return Result;
            } else
            {
                throw new InvalidOperationException(ERROR_MESSAGE_DIE_WAS_ALREADY_ROLLED);
            }
        
            
        }

        public int? Reroll()
        {
            if (Rolled)
            {
                Rolled = false;

                return Roll();
            } else
            {
                throw new InvalidOperationException(ERROR_MESSAGE_REROLL_BEFORE_ROLL);
            }
        }
    }
}
