using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olirator.Models.RollStrategies
{
    interface RollStrategyInterface
    {
        public List<RollResultInterface> execute(List<DieInterface> dice);
    }
}
