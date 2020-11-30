using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olirator.Constants
{
    public static class ExceptionConstants
    {
        public const string ERROR_MESSAGE_INVALID_SIDES_FOR_DIE = "A die needs at least 1 side";
        public const string ERROR_MESSAGE_DIE_WAS_ALREADY_ROLLED = "The die has already been rolled";
        public const string ERROR_MESSAGE_REROLL_BEFORE_ROLL = "The die has to be rolled first before it can be rerolled";
    }
}
