using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olirator.Models
{
    public class RollResult : RollResultInterface
    {
        public int? RollPosition { get ; set; }
        public string Comment { get; set; }
        public DieInterface Die { get; set; }
        public bool? Success { get; set; }
    }
}
